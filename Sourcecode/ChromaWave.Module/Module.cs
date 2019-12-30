using System;
using System.Collections.Generic;
using System.Text;

namespace ChromaWave.Module
{
    public class Module
    {
        public string Name { get; set; }
        public List<Device> Devices { get; set; } = new List<Device>();
    }
}
