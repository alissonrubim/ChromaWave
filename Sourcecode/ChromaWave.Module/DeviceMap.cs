using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ChromaWave.Module
{
    public class DeviceMap
    {
        public byte[] BackgroundImage { get; set; }
        public Size Size { get; set; }
        public Point[,] Leds { get; set; }
    }
}
