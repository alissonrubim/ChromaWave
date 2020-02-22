using ChromaWave.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromaWave.Views.Components.Visuals
{
    interface Tab
    {
        void Setup();

        void Start();

        void Stop();

        void Update();

        void ApplySettings(Settings settings);

        void SaveSettings(Settings settings);
    }
}
