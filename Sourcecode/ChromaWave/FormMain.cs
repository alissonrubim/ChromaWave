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

namespace ChromaWave
{
    public partial class FormMain : Form
    {
        private List<AudioSource> audioSources;
        private WasapiLoopbackCapture loopbackCapture;
        
        public FormMain()
        {
            InitializeComponent();
            loadAudioSources();

            volumeMeterLeft.Value = 0;
            volumeMeterRight.Value = 0;
            volumeMeterFrequency1K.Value = 0;
            volumeMeterFrequency500.Value = 0;
        }

        private void loadAudioSources()
        {
            comboBoxSource.Items.Clear();
            audioSources = new List<AudioSource>();
            for (int i = -1; i < WaveOut.DeviceCount; i++)
            {
                WaveOutCapabilities capabilitie = WaveOut.GetCapabilities(i);
                AudioSource source = new AudioSource()
                {
                    Name = capabilitie.ProductName,
                    DeviceNumber = i,
                    Channels = capabilitie.Channels,
                };
                audioSources.Add(source);
                comboBoxSource.Items.Add(source.Name);
            }
        }
        private void startLoopbackCapture()
        {
            //Only start in the current loopback is null or already stopped.
            if (loopbackCapture != null && loopbackCapture.CaptureState != NAudio.CoreAudioApi.CaptureState.Stopped)
            {
                stopLoopbackCapture();
            }
            else
            {
                loopbackCapture = new WasapiLoopbackCapture();
                loopbackCapture.DataAvailable += (Sender, Args) =>
                {
                    if (loopbackCapture.WaveFormat.BitsPerSample == 32) 
                    {
                        if (loopbackCapture.WaveFormat.Channels == 2) 
                        {
                            WaveBuffer wavebuffer = new WaveBuffer(Args.Buffer);

                            Random a = new Random();
                            volumeMeterLeft.Value = a.Next(0, 100);
                            volumeMeterFrequency500.Value = a.Next(0, 100);
                        }
                    }
                    
                };

                loopbackCapture.RecordingStopped += (s, a) =>
                {
                    loopbackCapture.Dispose();
                };

                try
                {
                    loopbackCapture.StartRecording();
                }
                catch (Exception e)
                {
                    MessageBox.Show($"An error ocurred when we try to start the loopback capture. Error message: {e.Message}", "Attention",  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    stopLoopbackCapture();
                }
            }
        }

        private void stopLoopbackCapture()
        {
            loopbackCapture.StopRecording();
            loopbackCapture = null;
        }

        private void ComboBoxSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            startLoopbackCapture();
        }

        private void ButtonReload_Click(object sender, EventArgs e)
        {
            loadAudioSources();
        }

        private void TrackBarAmplitudeLeft_Scroll(object sender, EventArgs e)
        {
            trackBarAmplitudeRight.Value = trackBarAmplitudeLeft.Value;
        }

        private void TrackBarAmplitudeRight_Scroll(object sender, EventArgs e)
        {
            trackBarAmplitudeLeft.Value = trackBarAmplitudeRight.Value;
        }
    }
}
