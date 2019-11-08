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

namespace ChromaWave
{
    public partial class FormMain : Form
    {
        private Settings pSettings;
        private List<AudioDevice> audioDevices = new List<AudioDevice>();
        private LoopbackCaptureController loopbackCaptureController;
        private float lastSampleChannelLeft;
        private float lastSampleChannelRight;

        public float AmplitudePercentageRight;
        public float AmplitudePercentageLeft;
        public FormMain()
        {
            InitializeComponent();

            loadSettings();
            loadAudioDevices();
            loadComboboxWaveVelocity();
            loadComboboxWaveDirection();

            loopbackCaptureController = new LoopbackCaptureController();
            loopbackCaptureController.OnCapture += loopbackCaptureController_OnCapture;

            applySettings();

            AmplitudePercentageLeft = 100f + trackBarAmplitudeLeft.Value;
            AmplitudePercentageRight = 100f + trackBarAmplitudeRight.Value;

            timerUIUpdate.Interval = 1000 / 30; //fps
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
        }

        private void saveSettings()
        {
            pSettings.SpectrumVelocity = (ChromaVisualizerVelocity)comboBoxWaveVelocity.SelectedItem;
            pSettings.SpectrumDirection = (ChromaVisualizerDirection)comboBoxWaveDirection.SelectedItem;
            pSettings.SpectrumBrightness = trackBarBrightness.Value;
            pSettings.SpectrumSaturation = trackBarSaturation.Value;
            pSettings.SelectedDeviceName = audioDevices[comboBoxAudioDevices.SelectedIndex].Name;
            SettingsController.Save(pSettings);
        }

        private void startCapturing()
        {
            if (loopbackCaptureController.State != CaptureState.Stopped)
                loopbackCaptureController.Stop();
            loopbackCaptureController.Start(audioDevices[comboBoxAudioDevices.SelectedIndex]);
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

        private void loopbackCaptureController_OnCapture(IEnumerable<AudioChannelSample> samples)
        {
            lastSampleChannelLeft = AudioProcessingHelper.CalculateSample_MaxValue(samples.ToArray()[0].Samples);
            lastSampleChannelRight = AudioProcessingHelper.CalculateSample_MaxValue(samples.ToArray()[1].Samples);
        }

        private void TimerUIUpdate_Tick(object sender, EventArgs e)
        {
            float amplify = 1f;

            this.SuspendLayout();
            int valueLeft = Convert.ToInt32(lastSampleChannelLeft * amplify * AmplitudePercentageLeft);
            volumeMeterLeft.Value = valueLeft > 100 ? 100 : valueLeft;

            int valueRight = Convert.ToInt32(lastSampleChannelRight * amplify * AmplitudePercentageRight);
            volumeMeterRight.Value = valueRight > 100 ? 100 : valueRight;

            //Re-draw controls
            volumeMeterLeft.Update();
            volumeMeterRight.Update();
            chromaVisualizer.Update();
            chromaMusicVisualizer.Update();

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
    }
}
