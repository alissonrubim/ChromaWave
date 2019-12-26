using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromaWave.Models
{
    public class AudioSample
    {
        public ISampleProvider SampleProvider;
        public float[] SampleFrames;
        public WaveFormat WaveFormat;
        public List<AudioChannelSample> AudioChannelSamples = new List<AudioChannelSample>();
    }
}
