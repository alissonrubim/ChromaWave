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

        public FormMain()
        {
            InitializeComponent();
            loadAudioDevices();

            loopbackCaptureController = new LoopbackCaptureController();
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
            trackBarAmplitudeRight.Value = trackBarAmplitudeLeft.Value;
        }

        private void TrackBarAmplitudeRight_Scroll(object sender, EventArgs e)
        {
            trackBarAmplitudeLeft.Value = trackBarAmplitudeRight.Value;
        }

        private void ComboBoxAudioDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            StartCapturing();
        }
    }
}
