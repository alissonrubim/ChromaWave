using NAudio.CoreAudioApi;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChromaWave.Models;
using ChromaWave.Controller;
using ChromaWave.Views;
using ChromaWave.Helpers;
using NAudio.Dsp;

namespace ChromaWave
{
    public partial class FormMain : Form
    {
        private class FormCache
        {
            public float LastSampleOnChannelLeft;
            public float LastSampleOnChannelRight;
            public float LastSampleOnFrequency1000Hz;
        }

        private Settings pSettings;
        private List<AudioDevice> audioDevices = new List<AudioDevice>();
        private LoopbackCaptureController loopbackCaptureController;
        private FormCache pFormCache;
        private DevicesController devicesController;
        private List<DeviceVisualizer> deviceVisualizers = new List<DeviceVisualizer>();

        public float AmplitudePercentageRight;
        public float AmplitudePercentageLeft;
        public FormMain()
        {
            InitializeComponent();

            loadSettings();
            loadAudioDevices();
            loadComboboxWaveVelocity();
            loadComboboxWaveDirection();
            loadDeviceModules();

            pFormCache = new FormCache();

            loopbackCaptureController = new LoopbackCaptureController();
            loopbackCaptureController.OnCapture += loopbackCaptureController_OnCapture;

            applySettings();

            AmplitudePercentageLeft = 100f + trackBarAmplitudeLeft.Value;
            AmplitudePercentageRight = 100f + trackBarAmplitudeRight.Value;

            timerUIUpdate.Interval = 1000 / 30; //fps

            chromaMusicVisualizer.SyncronizeTo = chromaVisualizer; //Syncronize the two ChromaVisualizer
        }

        private void loadDeviceModules()
        {
            devicesController = new DevicesController();
            devicesController.LoadModules(); //Load all the devices modules
            foreach(DeviceModule deviceModule in devicesController.DeviceModules)
            {
                foreach(Device device in deviceModule.Devices)
                {
                    DeviceVisualizer deviceVisualizer = new DeviceVisualizer(chromaMusicVisualizer, device);
                    //This code put each device side by site, but the problem is: if you have a lot of devices, they will be put out of bound.
                    //deviceVisualizer.Location = new Point(10 + deviceVisualizers.Sum(x => x.Size.Width), 30);
                    deviceVisualizer.Location = new Point(10, 30);
                    groupBoxDevices.Controls.Add(deviceVisualizer);
                    deviceVisualizers.Add(deviceVisualizer);
                    deviceVisualizer.BringToFront();
                }
            }
        }

        private void loadSettings()
        {
            this.pSettings = SettingsController.Load();
        }

        private void applySettings()
        {
            comboBoxWaveVelocity.SelectedItem = this.pSettings.SpectrumVelocity;
            comboBoxWaveDirection.SelectedItem = this.pSettings.SpectrumDirection;
            trackBarBrightness.Value = pSettings.SpectrumBrightness;
            trackBarSaturation.Value = pSettings.SpectrumSaturation;
            comboBoxAudioDevices.SelectedIndex = audioDevices.IndexOf(audioDevices.Where(x => x.Name.Equals(this.pSettings.SelectedDeviceName)).FirstOrDefault());
            foreach (DeviceVisualizer visualizer in deviceVisualizers)
            {
                DeviceSettings deviceSetting = pSettings.Devices.Where(x => x.Id == visualizer.Id).FirstOrDefault();
                if (deviceSetting != null)
                {
                    visualizer.Location = deviceSetting.Location;
                }
            }
        }

        private void saveSettings()
        {
            pSettings.SpectrumVelocity = (ChromaVisualizerVelocity)comboBoxWaveVelocity.SelectedItem;
            pSettings.SpectrumDirection = (ChromaVisualizerDirection)comboBoxWaveDirection.SelectedItem;
            pSettings.SpectrumBrightness = trackBarBrightness.Value;
            pSettings.SpectrumSaturation = trackBarSaturation.Value;
            foreach(DeviceVisualizer visualizer in deviceVisualizers)
            {
                DeviceSettings deviceSetting = pSettings.Devices.Where(x => x.Id == visualizer.Id).FirstOrDefault();
                if (deviceSetting != null)
                {
                    deviceSetting.Location = visualizer.Location;
                }
                else
                {
                    deviceSetting = new DeviceSettings();
                    deviceSetting.Id = visualizer.Id;
                    deviceSetting.Location = visualizer.Location;
                    pSettings.Devices.Add(deviceSetting);
                }
            }
            if(comboBoxAudioDevices.SelectedIndex > -1)
                pSettings.SelectedDeviceName = audioDevices[comboBoxAudioDevices.SelectedIndex].Name;
            SettingsController.Save(pSettings);
        }

        private void startCapturing()
        {
            stopCapturing();
            loopbackCaptureController.Start(audioDevices[comboBoxAudioDevices.SelectedIndex]);
        }

        private void stopCapturing()
        {
            if (loopbackCaptureController.State != CaptureState.Stopped)
                loopbackCaptureController.Stop();
        }

        private void loadAudioDevices()
        {
            comboBoxAudioDevices.Items.Clear();
            audioDevices = AudioDeviceController.GetAllAudioDevices();
            foreach (AudioDevice audioDevice in audioDevices)
                comboBoxAudioDevices.Items.Add(audioDevice.Name);
        }

        private void loadComboboxWaveVelocity()
        {
            comboBoxWaveVelocity.DataSource = Enum.GetValues(typeof(ChromaVisualizerVelocity));            
        }

        private void loadComboboxWaveDirection()
        {
            comboBoxWaveDirection.DataSource = Enum.GetValues(typeof(ChromaVisualizerDirection));
        }

        private void ButtonReload_Click(object sender, EventArgs e)
        {
            loadAudioDevices();
        }

        private void TrackBarAmplitudeLeft_Scroll(object sender, EventArgs e)
        {
            AmplitudePercentageLeft = 100f + trackBarAmplitudeLeft.Value;
            if (checkBoxSync.Checked)
            {
                trackBarAmplitudeRight.Value = trackBarAmplitudeLeft.Value;
                AmplitudePercentageRight = 100f + trackBarAmplitudeRight.Value;
            }
        }

        private void TrackBarAmplitudeRight_Scroll(object sender, EventArgs e)
        {
            AmplitudePercentageRight = 100f + trackBarAmplitudeRight.Value;
            if (checkBoxSync.Checked)
            {
                trackBarAmplitudeLeft.Value = trackBarAmplitudeRight.Value;
                AmplitudePercentageLeft = 100f + trackBarAmplitudeLeft.Value;
            }
        }

        private void ComboBoxAudioDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            startCapturing();
        }

        private void loopbackCaptureController_OnCapture(AudioSample audioSample)
        {
            pFormCache.LastSampleOnChannelLeft = AudioProcessingHelper.CalculateSampleByMaxValue(audioSample.AudioChannelSamples[0].SampleFrames);
            pFormCache.LastSampleOnChannelRight = AudioProcessingHelper.CalculateSampleByMaxValue(audioSample.AudioChannelSamples[1].SampleFrames);

            /*Complex[] fftBuffer = new Complex[audioSample.SampleFrames.Length];
            for(var i =0; i< audioSample.SampleFrames.Length; i++)
            {
                fftBuffer[i].X = (float)(audioSample.SampleFrames[i] * FastFourierTransform.HammingWindow(i, audioSample.SampleFrames.Length));
                fftBuffer[i].Y = i;
            }

            FastFourierTransform.FFT(true, 10, fftBuffer);*/




            SampleAggregatorHelper sa = new SampleAggregatorHelper(audioSample.SampleProvider, (int)Math.Pow(2, 13));
            sa.PerformFFT = true;
            sa.FftCalculated += new EventHandler<FftEventArgs>((object sender, FftEventArgs e) =>
            {
                //for (var i = 0; i < e.Result.Length; i++)
                // {
                // e.Result[i].X;
                //e.Result[i].Y;
                /// }
                pFormCache.LastSampleOnFrequency1000Hz = e.Result[1024].Y;
            });
            float[] buff = new float[audioSample.SampleFrames.Length];
            sa.Process(audioSample.SampleFrames);

        }

        private void TimerUIUpdate_Tick(object sender, EventArgs e)
        {
            float amplify = 1f;

            this.SuspendLayout();
            int valueChannelLeft = Convert.ToInt32(pFormCache.LastSampleOnChannelLeft * amplify * AmplitudePercentageLeft);
            volumeMeterLeft.Value = valueChannelLeft > 100 ? 100 : valueChannelLeft;

            int valueChannelRight = Convert.ToInt32(pFormCache.LastSampleOnChannelRight * amplify * AmplitudePercentageRight);
            volumeMeterRight.Value = valueChannelRight > 100 ? 100 : valueChannelRight;

            int valueFrequency1000Hz = Convert.ToInt32(Math.Abs(pFormCache.LastSampleOnFrequency1000Hz) * 100000 * amplify * AmplitudePercentageRight);
            volumeMeterFrequency1K.Value = valueFrequency1000Hz > 100 ? 100 : valueFrequency1000Hz;

            //Re-draw controls
            volumeMeterLeft.Update();
            volumeMeterRight.Update();
            volumeMeterFrequency1K.Update();
            chromaVisualizer.Update();
            chromaMusicVisualizer.Update();
            foreach (DeviceVisualizer deviceVisualize in deviceVisualizers)
                deviceVisualize.Update();
            this.ResumeLayout();
        }

        private void ComboBoxWaveDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            chromaVisualizer.Direction = (ChromaVisualizerDirection)comboBoxWaveDirection.SelectedItem;
            chromaMusicVisualizer.Direction = chromaVisualizer.Direction;
        }

        private void ComboBoxWaveVelocity_SelectedIndexChanged(object sender, EventArgs e)
        {
            chromaVisualizer.Velocity = (ChromaVisualizerVelocity)comboBoxWaveVelocity.SelectedItem;
            chromaMusicVisualizer.Velocity = chromaVisualizer.Velocity;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            saveSettings();
        }

        private void TrackBarBrightness_ValueChanged(object sender, EventArgs e)
        {
            chromaVisualizer.Brightness = trackBarBrightness.Value;
            chromaMusicVisualizer.Brightness = chromaVisualizer.Brightness;
        }

        private void TrackBarSaturation_ValueChanged(object sender, EventArgs e)
        {
            chromaVisualizer.Saturation = trackBarSaturation.Value;
            chromaMusicVisualizer.Saturation = chromaVisualizer.Saturation;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            stopCapturing();
        }
    }
}
