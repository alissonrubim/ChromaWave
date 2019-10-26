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

namespace ChromaWave
{
    public partial class FormMain : Form
    {
        private List<AudioDevice> audioDevices = new List<AudioDevice>();
        private LoopbackCaptureController loopbackCaptureController;
        private float lastSampleChannelLeft;
        private float lastSampleChannelRight;

        public int AmplitudePercentageRight;
        public int AmplitudePercentageLeft;
        public FormMain()
        {
            InitializeComponent();
            loadAudioDevices();

            loopbackCaptureController = new LoopbackCaptureController();
            loopbackCaptureController.OnCapture += loopbackCaptureController_OnCapture;

            AmplitudePercentageLeft = 100 + trackBarAmplitudeLeft.Value;
            AmplitudePercentageRight = 100 + trackBarAmplitudeRight.Value;

            timerUIUpdate.Interval = 1000 / 30; //60fps
        }

        public void StartCapturing()
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

        private void ButtonReload_Click(object sender, EventArgs e)
        {
            loadAudioDevices();
        }

        private void TrackBarAmplitudeLeft_Scroll(object sender, EventArgs e)
        {
            AmplitudePercentageLeft = 100 + trackBarAmplitudeLeft.Value;
            if (checkBoxSync.Checked)
            {
                trackBarAmplitudeRight.Value = trackBarAmplitudeLeft.Value;
                AmplitudePercentageRight = 100 + trackBarAmplitudeRight.Value;
            }
        }

        private void TrackBarAmplitudeRight_Scroll(object sender, EventArgs e)
        {
            AmplitudePercentageRight = 100 + trackBarAmplitudeRight.Value;
            if (checkBoxSync.Checked)
            {
                trackBarAmplitudeLeft.Value = trackBarAmplitudeRight.Value;
                AmplitudePercentageLeft = 100 + trackBarAmplitudeLeft.Value;
            }
        }

        private void ComboBoxAudioDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            StartCapturing();
        }
    

        public float CalculateSample_MaxValue(float[] sample)
        {
            int calutationMesureRate = 1000;
            float masterSum = 0;
            for (var i = 0; i < sample.Length - calutationMesureRate; i += calutationMesureRate)
            {
                float sum = 0;
                for (int j = 0; j < calutationMesureRate; j++)
                    sum += Math.Abs(sample[i + j]);
                masterSum += sum / calutationMesureRate;
            }

            return masterSum / (Convert.ToInt32(sample.Length / calutationMesureRate) + 1);
        }

        private void loopbackCaptureController_OnCapture(IEnumerable<AudioChannelSample> samples)
        {
            lastSampleChannelLeft = CalculateSample_MaxValue(samples.ToArray()[0].Samples);
            lastSampleChannelRight = CalculateSample_MaxValue(samples.ToArray()[1].Samples);
        }

        private void TimerUIUpdate_Tick(object sender, EventArgs e)
        {
            this.SuspendLayout();
            int valueLeft = Convert.ToInt32(lastSampleChannelLeft * 1000 * AmplitudePercentageLeft / 100);
            volumeMeterLeft.Value = valueLeft > 100 ? 100 : valueLeft;

            int valueRight = Convert.ToInt32(lastSampleChannelRight * 1000 * AmplitudePercentageRight / 100);
            volumeMeterRight.Value = valueRight > 100 ? 100 : valueRight;
            this.ResumeLayout();
        }
    }
}
