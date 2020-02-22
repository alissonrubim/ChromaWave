using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChromaWave.Models;
using ChromaWave.Controller;
using ChromaWave.Views.Components.Visuals;
using ChromaWave.Helpers;

namespace ChromaWave.Views.Forms.Main.Visuals
{
    public partial class TabEffects : UserControl, Tab
    {
        private List<AudioDevice> audioDevices = new List<AudioDevice>();
        private RenderCanvas renderCanvas;
        private SpectrumVisualizer renderedSpectrumVisualizer;
        private LoopbackCaptureController loopbackCaptureController;
        private class ValuesCache
        {
            public static float AmplitudePercentageRight;
            public static float AmplitudePercentageLeft;

            public static float LastSampleOnChannelLeft;
            public static float LastSampleOnChannelRight;
            public static float LastSampleOnFrequency1000Hz;
        }

        public TabEffects()
        {
            InitializeComponent();

            renderedSpectrumVisualizer = new SpectrumVisualizer();
            renderedSpectrumVisualizer.Opactity = 0.2f;
            loopbackCaptureController = new LoopbackCaptureController();
            loopbackCaptureController.OnCapture += loopbackCaptureController_OnCapture;
        }

        public new virtual void Update()
        {
            previewSpectrumVisualizer.Update();
            renderedSpectrumVisualizer.Update();
            renderCanvas.SetRenderedBitmapForPixelCalculation(renderedSpectrumVisualizer.GetRenderedBitmap());
            updateVUMeterUI();
        }

        public void Setup()
        {
            loadAudioDevices();
            loadComboboxWaveDirection();
            loadComboboxWaveVelocity();
        }

        public void Start()
        {
            if(comboBoxAudioDevices.SelectedIndex > -1)
                loopbackCaptureController.Start(audioDevices[comboBoxAudioDevices.SelectedIndex]);

            ValuesCache.AmplitudePercentageLeft = 100f + trackBarAmplitudeLeft.Value;
            ValuesCache.AmplitudePercentageRight = 100f + trackBarAmplitudeRight.Value;
        }

        public void Stop()
        {
            if (loopbackCaptureController.State != NAudio.CoreAudioApi.CaptureState.Stopped)
                loopbackCaptureController.Stop();
        }

        public void ApplySettings(Settings settings)
        {
            trackBarSaturation.Value = settings.SpectrumSaturation;
            trackBarBrightness.Value = settings.SpectrumBrightness;
            comboBoxWaveVelocity.SelectedItem = settings.SpectrumVelocity;
            comboBoxWaveDirection.SelectedItem = settings.SpectrumDirection;
            comboBoxAudioDevices.SelectedIndex = audioDevices.IndexOf(audioDevices.Where(x => x.Name.Equals(settings.SelectedDeviceName)).FirstOrDefault());
        }

        public void SaveSettings(Settings settings)
        {
            settings.SpectrumBrightness = trackBarBrightness.Value;
            settings.SpectrumSaturation = trackBarSaturation.Value;
            settings.SpectrumVelocity = (SpectrumVisualizerVelocity)comboBoxWaveVelocity.SelectedItem;
            settings.SpectrumDirection = (SpectrumVisualizerDirection)comboBoxWaveDirection.SelectedItem;
            if (comboBoxAudioDevices.SelectedIndex > -1)
                settings.SelectedDeviceName = audioDevices[comboBoxAudioDevices.SelectedIndex].Name;
        }

        public void SetRenderCanvas(RenderCanvas renderCanvas)
        {
            this.renderCanvas = renderCanvas;

            renderCanvas.BackColor = this.BackColor; //!important -> without this setup, the opacity from SpectrumVisualizer can no work properly
            renderedSpectrumVisualizer.Size = renderCanvas.Size;
            renderedSpectrumVisualizer.Location = new Point(0, 0);
            renderCanvas.Controls.Add(renderedSpectrumVisualizer);
            renderedSpectrumVisualizer.SyncronizeTo = previewSpectrumVisualizer; //Syncronize the two ChromaVisualizer
        }

        #region Private
        private void updateVUMeterUI()
        {
            float amplify = 5f;

            int valueChannelLeft = Convert.ToInt32(ValuesCache.LastSampleOnChannelLeft * amplify * ValuesCache.AmplitudePercentageLeft);
            volumeMeterLeft.Value = valueChannelLeft > 100 ? 100 : valueChannelLeft;

            int valueChannelRight = Convert.ToInt32(ValuesCache.LastSampleOnChannelRight * amplify * ValuesCache.AmplitudePercentageRight);
            volumeMeterRight.Value = valueChannelRight > 100 ? 100 : valueChannelRight;

            int valueFrequency1000Hz = Convert.ToInt32(Math.Abs(ValuesCache.LastSampleOnFrequency1000Hz) * 100000 * amplify * ValuesCache.AmplitudePercentageRight);
            volumeMeterFrequency1K.Value = valueFrequency1000Hz > 100 ? 100 : valueFrequency1000Hz;

            volumeMeterLeft.Update();
            volumeMeterRight.Update();
            volumeMeterFrequency1K.Update();
        }

        private void loadAudioDevices()
        {
            comboBoxAudioDevices.Items.Clear();
            audioDevices = AudioDeviceController.GetAllAudioDevices();
            foreach (AudioDevice audioDevice in audioDevices)
                comboBoxAudioDevices.Items.Add(audioDevice.Name);
        }

        private void loadComboboxWaveDirection()
        {
            comboBoxWaveDirection.DataSource = Enum.GetValues(typeof(SpectrumVisualizerDirection));
        }

        private void loadComboboxWaveVelocity()
        {
            comboBoxWaveVelocity.DataSource = Enum.GetValues(typeof(SpectrumVisualizerVelocity));
        }

        private void comboBoxWaveDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            previewSpectrumVisualizer.Direction = (SpectrumVisualizerDirection)comboBoxWaveDirection.SelectedItem;
            renderedSpectrumVisualizer.Direction = previewSpectrumVisualizer.Direction;
        }

        private void comboBoxWaveVelocity_SelectedIndexChanged(object sender, EventArgs e)
        {
            previewSpectrumVisualizer.Velocity = (SpectrumVisualizerVelocity)comboBoxWaveVelocity.SelectedItem;
            renderedSpectrumVisualizer.Velocity = previewSpectrumVisualizer.Velocity;
        }

        private void comboBoxAudioDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            Stop();
            Start();
        }
        
        private void trackBarBrightness_ValueChanged(object sender, EventArgs e)
        {
            previewSpectrumVisualizer.Brightness = trackBarBrightness.Value;
            renderedSpectrumVisualizer.Brightness = previewSpectrumVisualizer.Brightness;
        }

        private void trackBarSaturation_ValueChanged(object sender, EventArgs e)
        {
            previewSpectrumVisualizer.Saturation = trackBarSaturation.Value;
            renderedSpectrumVisualizer.Saturation = previewSpectrumVisualizer.Saturation;
        }


        private void buttonReload_Click(object sender, EventArgs e)
        {
            loadAudioDevices();
        }

        private void trackBarAmplitudeRight_Scroll(object sender, EventArgs e)
        {
            ValuesCache.AmplitudePercentageRight = 100f + trackBarAmplitudeRight.Value;
            if (checkBoxSync.Checked)
            {
                trackBarAmplitudeLeft.Value = trackBarAmplitudeRight.Value;
                ValuesCache.AmplitudePercentageLeft = 100f + trackBarAmplitudeLeft.Value;
            }
        }

        private void trackBarAmplitudeLeft_Scroll(object sender, EventArgs e)
        {
            ValuesCache.AmplitudePercentageLeft = 100f + trackBarAmplitudeLeft.Value;
            if (checkBoxSync.Checked)
            {
                trackBarAmplitudeRight.Value = trackBarAmplitudeLeft.Value;
                ValuesCache.AmplitudePercentageRight = 100f + trackBarAmplitudeRight.Value;
            }
        }

        private void loopbackCaptureController_OnCapture(AudioSample audioSample)
        {
            ValuesCache.LastSampleOnChannelLeft = AudioProcessingHelper.CalculateSampleByMaxValue(audioSample.AudioChannelSamples[0].SampleFrames);
            ValuesCache.LastSampleOnChannelRight = AudioProcessingHelper.CalculateSampleByMaxValue(audioSample.AudioChannelSamples[1].SampleFrames);

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
                ValuesCache.LastSampleOnFrequency1000Hz = e.Result[1024].Y;
            });
            float[] buff = new float[audioSample.SampleFrames.Length];
            sa.Process(audioSample.SampleFrames);
        }
        #endregion
    }
}
