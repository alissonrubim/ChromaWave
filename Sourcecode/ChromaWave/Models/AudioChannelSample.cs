using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromaWave.Models
{
    public class AudioChannelSample
    {
        public int ChannelNumber { get; set; }
        public float[] SampleFrames { get; set; }
    }
}
