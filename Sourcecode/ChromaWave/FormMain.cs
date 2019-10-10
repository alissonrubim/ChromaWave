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

namespace ChromaWave
{
    public partial class FormMain : Form
    {
        private List<AudioSource> audioSources;
        private WasapiLoopbackCapture loopbackCapture;
        private List<SampleFrequency> sampleFrequencys = new List<SampleFrequency>();
        public FormMain()
        {
            InitializeComponent();
            loadAudioSources();

            sampleFrequencys.Add(new SampleFrequency
            {
                Frequency = 32
            });

            sampleFrequencys.Add(new SampleFrequency
            {
                Frequency = 250
            });

            sampleFrequencys.Add(new SampleFrequency
            {
                Frequency = 1000
            });

            sampleFrequencys.Add(new SampleFrequency
            {
                Frequency = 4000
            });

            sampleFrequencys.Add(new SampleFrequency
            {
                Frequency = 8000
            });

        }

        private void loadAudioSources()
        {
            audioSources = new List<AudioSource>();
            for (int i = -1; i < WaveOut.DeviceCount; i++)
            {
                WaveOutCapabilities capabilitie = WaveOut.GetCapabilities(i);
                AudioSource source = new AudioSource()
                {
                    Name = capabilitie.ProductName,
                    DeviceNumber = i
                };
                audioSources.Add(source);
                comboBoxSource.Items.Add(source.Name);
            }
        }

        private void startLoopbackCapture()
        {
            if (loopbackCapture != null && loopbackCapture.CaptureState != NAudio.CoreAudioApi.CaptureState.Stopped)
            {
                stopLoopbackCapture();
            }
            else
            {
                loopbackCapture = new WasapiLoopbackCapture();
                loopbackCapture.DataAvailable += (s, args) =>
                {
                    int bitsPerSample = loopbackCapture.WaveFormat.BitsPerSample;
                    if (bitsPerSample == 32)
                    {
                        WaveBuffer wavebuffer = new WaveBuffer(args.Buffer);

                        List<float> bufferLeft = new List<float>();
                        for (int i = 0; i < wavebuffer.MaxSize / 8; i += 8)
                        {
                            bufferLeft.Add(wavebuffer.FloatBuffer[i]);
                            bufferLeft.Add(wavebuffer.FloatBuffer[i+1]);
                            bufferLeft.Add(wavebuffer.FloatBuffer[i+2]);
                            bufferLeft.Add(wavebuffer.FloatBuffer[i+3]);
                        }

                        for (int sampleFrequencyIndex = 0; sampleFrequencyIndex < sampleFrequencys.Count(); sampleFrequencyIndex++)
                        {
                            int min = sampleFrequencyIndex == 0 ? 0 : sampleFrequencys[sampleFrequencyIndex - 1].Frequency;
                            int max = sampleFrequencys[sampleFrequencyIndex].Frequency;

                            double maxValue = 0;
                            for (int i = min; i < max; i++)
                                if (i < bufferLeft.Count())
                                {
                                    var sample = Math.Abs(bufferLeft[i]);
                                    if (sample > maxValue) maxValue = sample;
                                }


                            sampleFrequencys[sampleFrequencyIndex].LeftValue = maxValue;
                        }

                        this.Invoke(new Action(() =>
                        {
                            foreach (SampleFrequency sampleFrequency in sampleFrequencys)
                            {
                                if (sampleFrequency.Frequency == 32)
                                    setProgressBarValue(progressBarWave32, sampleFrequency.LeftValue);

                                if (sampleFrequency.Frequency == 250)
                                    setProgressBarValue(progressBarWave250, sampleFrequency.LeftValue);

                                if (sampleFrequency.Frequency == 1000)
                                    setProgressBarValue(progressBarWave1k, sampleFrequency.LeftValue);

                                if (sampleFrequency.Frequency == 4000)
                                    setProgressBarValue(progressBarWave4k, sampleFrequency.LeftValue);

                                if (sampleFrequency.Frequency == 8000)
                                    setProgressBarValue(progressBarWave16k, sampleFrequency.LeftValue);
                            }
                        }));
                    }
                    
                };

                loopbackCapture.RecordingStopped += (s, a) =>
                {
                    loopbackCapture.Dispose();
                };

                loopbackCapture.StartRecording();
            }
        }

        private void setProgressBarValue(ProgressBar progessBar, double value)
        {
            value = value * 200;
            value = value > progessBar.Maximum ? progessBar.Maximum : value;
            progessBar.Value = Convert.ToInt32(value);
        }
        private void stopLoopbackCapture()
        {
            loopbackCapture.StopRecording();
        }

        private void ComboBoxSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            startLoopbackCapture();
        }
    }

    public class SampleFrequency
    {
        public int Frequency { get; set; }
        public double LeftValue { get; set; }
        public double RightValue { get; set; }
    }

}
