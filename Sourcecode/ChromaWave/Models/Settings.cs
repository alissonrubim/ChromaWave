using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChromaWave.Views;

namespace ChromaWave.Models
{
    public class Settings
    {
        public ChromaVisualizerVelocity SpectrumVelocity { get; set; } = ChromaVisualizerVelocity.Slow;
        public ChromaVisualizerDirection SpectrumDirection { get; set; } = ChromaVisualizerDirection.Forward;

        public int SpectrumBrightness { get; set; } = 50;

        public int SpectrumSaturation { get; set; } = 100;

        public string SelectedDeviceName { get; set; } = null;
    }
}
