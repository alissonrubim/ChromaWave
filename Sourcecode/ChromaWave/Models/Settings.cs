using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChromaWave.Views;

namespace ChromaWave.Models
{
    public class Settings
    {
        public SpectrumVisualizerVelocity SpectrumVelocity { get; set; } = SpectrumVisualizerVelocity.Slow;
        public SpectrumVisualizerDirection SpectrumDirection { get; set; } = SpectrumVisualizerDirection.Forward;

        public int SpectrumBrightness { get; set; } = 50;

        public int SpectrumSaturation { get; set; } = 100;

        public string SelectedDeviceName { get; set; } = null;

        public List<DeviceSettings> Devices { get; set; } = new List<DeviceSettings>();
    }

    public class DeviceSettings
    {
        public string Id { get; set; }
        public Point Location { get; set; }
    }
}
