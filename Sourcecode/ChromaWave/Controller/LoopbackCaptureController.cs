using ChromaWave.Models;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromaWave.Controller
{
    public delegate void LoopbackCaptureControllerEventHandler(IEnumerable<AudioChannelSample> samples);
    public class LoopbackCaptureController
    {
        private WasapiLoopbackCapture loopbackCapture;

        public LoopbackCaptureControllerEventHandler OnCapture;
        public CaptureState State
        {
            get
            {
                return GetState();
            } 
        }

        public CaptureState GetState()
        {
            if (loopbackCapture == null)
                return CaptureState.Stopped;
            return loopbackCapture.CaptureState;
        }
        public void Stop()
        {
            if (loopbackCapture.CaptureState != CaptureState.Stopped)
                loopbackCapture.StopRecording();
            while (loopbackCapture.CaptureState == CaptureState.Stopping) ;
        }

        public void Start(AudioDevice audioDevice)
        {
            if (loopbackCapture == null || loopbackCapture.CaptureState == NAudio.CoreAudioApi.CaptureState.Stopped) {
                //Start a capturing using a specific device
                loopbackCapture = new WasapiLoopbackCapture(new MMDeviceEnumerator().GetDevice(audioDevice.Id)); 
                loopbackCapture.DataAvailable += loopbackCapture_DataAvailable;
                try
                {
                    loopbackCapture.StartRecording();
                }
                catch (Exception e)
                {
                    new Exception($"An error ocurred when we try to start the loopback capture. Error message: {e.Message}");
                }
            }
            else
            {
                new Exception("Loopback could't start the capture because it's current capturing. You need to stop the old audio capturing before start a new one.");
            }
        }

        private void loopbackCapture_DataAvailable(object serder, WaveInEventArgs args)
        {
            if (args.BytesRecorded > 0)
            {
                if (loopbackCapture.WaveFormat.BitsPerSample == 32)
                {
                    if (loopbackCapture.WaveFormat.Channels == 2)
                    {
                        //Guarantee that the size of the buffer are in bytes
                        if (args.Buffer.Length == args.BytesRecorded)
                        {
                            float[] leftFrames = new float[args.Buffer.Length / 4];
                            float[] rightFrames = new float[args.Buffer.Length / 4];
                            int count = 0;
                            for (int i=0; i < args.Buffer.Length; i +=4)
                            {
                                leftFrames[count] = Convert.ToSingle(args.Buffer[i] + args.Buffer[i + 1]);
                                rightFrames[count] = Convert.ToSingle(args.Buffer[i+2] + args.Buffer[i + 3]);
                                count++;
                            }

                            //Separating the Channels
                            List<AudioChannelSample> audioChannelSamples = new List<AudioChannelSample>();
                            audioChannelSamples.Add(new AudioChannelSample()
                            {
                                ChannelNumber = 1,
                                Samples = leftFrames
                            });
                            audioChannelSamples.Add(new AudioChannelSample()
                            {
                                ChannelNumber = 2,
                                Samples = rightFrames
                            });

                            OnCapture?.Invoke(audioChannelSamples);
                        }

         


                        //Transform the buffer in a WaveProvider
                        //BufferedWaveProvider bufferedWaveProvider = new BufferedWaveProvider(loopbackCapture.WaveFormat);
                        //bufferedWaveProvider.AddSamples(args.Buffer, 0, args.Buffer.Length);

                        //Transform the WaveProvider in a SampleProvider
                        //ISampleProvider sampleProvider = bufferedWaveProvider.ToSampleProvider().ToStereo(1, 1);

                        //Calculating the Bytes per frame(Not Bits) inclusing the channels division
                        //var bytesPerFrame = loopbackCapture.WaveFormat.BitsPerSample / 8 * loopbackCapture.WaveFormat.Channels;

                        //Calculating the size of the Byte buffer
                        //var bufferedFrames = bufferedWaveProvider.BufferedBytes / bytesPerFrame;

                        //Reading all the flames in a sample
                        //var allSampleFrames = new float[bufferedFrames];
                        //sampleProvider.Read(allSampleFrames, 0, bufferedFrames);

                        //Separating the channels
                        //float[] leftFrames = new float[allSampleFrames.Length / loopbackCapture.WaveFormat.Channels];
                        //float[] rightFrames = new float[allSampleFrames.Length / loopbackCapture.WaveFormat.Channels];
                        //for (var i = 0; i < allSampleFrames.Length / loopbackCapture.WaveFormat.Channels - 1; i += loopbackCapture.WaveFormat.Channels)
                        //{
                        //    leftFrames[i / 2] = allSampleFrames[i];
                        //    rightFrames[i / 2] = allSampleFrames[i + 1];
                        //}

                        //Separating the Channels
                        //List<AudioChannelSample> audioChannelSamples = new List<AudioChannelSample>();
                        //audioChannelSamples.Add(new AudioChannelSample()
                        //{
                        //    ChannelNumber = 1,
                        //    Samples = leftFrames
                        //});
                        //audioChannelSamples.Add(new AudioChannelSample()
                        //{
                        //    ChannelNumber = 2,
                        //    Samples = rightFrames
                        //});

                        //OnCapture?.Invoke(audioChannelSamples);
                    }
                }
            }
        }
    }
}
