using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ChromaWave.Models
{
    public class DeviceModule
    {
        public string Name;
        public List<Device> Devices = new List<Device>();
        public Assembly Assembly;
        public object DeviceController;
    }

    public class Device
    {
        public string Id;
        public string Title;
        public DeviceMap Map;
        public DeviceModule Module;
    }

    public class DeviceMap
    {
        public byte[] BackgroundImage;
        public Size Size;
        public Point[,] Leds; 
    }
}
