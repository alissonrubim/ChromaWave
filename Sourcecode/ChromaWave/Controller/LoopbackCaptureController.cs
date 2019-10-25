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
                        //Transform the buffer in a WaveProvider
                        BufferedWaveProvider bufferedWaveProvider = new BufferedWaveProvider(loopbackCapture.WaveFormat);
                        bufferedWaveProvider.AddSamples(args.Buffer, 0, args.Buffer.Length);

                        //Transform the WaveProvider in a SampleProvider 
                        ISampleProvider sampleProvider = bufferedWaveProvider.ToSampleProvider().ToStereo(1, 1);

                        var bytesPerFrame = loopbackCapture.WaveFormat.BitsPerSample / 8 * loopbackCapture.WaveFormat.Channels;
                        var bufferedFrames = bufferedWaveProvider.BufferedBytes / bytesPerFrame;
                        var frames = new float[bufferedFrames];
                        sampleProvider.Read(frames, 0, bufferedFrames);

                        float[] left = new float[frames.Length / 2];
                        for (var i = 0; i < frames.Length / 2 - 1; i += 2)
                        {
                            left[i/2] = frames[i];
                        }

                        List<AudioChannelSample> audioChannelSamples = new List<AudioChannelSample>();
                        audioChannelSamples.Add(new AudioChannelSample()
                        {
                            ChannelNumber = 1,
                            Samples = left
                        });

                        OnCapture?.Invoke(audioChannelSamples);
                    }
                }
            }
        }
    }
}
