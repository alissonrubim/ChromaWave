using System;
using System.Collections.Generic;
using System.Text;

namespace ChromaWave.Module
{
    public interface IChromaWaveModule
    {
        Module Setup();
        void OnProcessDevice(string DeviceId);
    }
}
