using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromaWave.Models
{
    public class AudioDevice
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Channels { get; set; }
    }
}
