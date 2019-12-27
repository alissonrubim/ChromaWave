using Colore;
using System.Collections.Generic;
using System.Drawing;

namespace ChromaWave.Module ////The namespace must be ChromaWave.Module
{

    public class DeviceMap
    {
        public byte[] BackgroundImage { get; set; }
        public Size Size { get; set; }
        public Point[,] Leds { get; set; }
    }

    public class Device
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public DeviceMap Map { get; set; }
    }

    public class DeviceModule
    {
        public string Name { get; set; }
        public List<Device> Devices { get; set; } = new List<Device>();
    }

    public class ChromaWaveDeviceController  ////The class name must be ChromaWaveDeviceController
    {
        public static DeviceModule Setup()  ///Needs to have a Setup method
        {
            DeviceModule module = new DeviceModule()
            {
                Name = "Razer"
            };

            module.Devices.Add(new Device()
            {
                Id = "RAZER_BLACKWIDOW_V1",
                Title = "BlackWidow",
                Map = new DeviceMap()
                {
                    BackgroundImage = Resource.keyboard,
                    Size = new Size(100, 100),
                    Leds = new Point[1, 2]
                    {
                        { new Point(10,10),  new Point(10,40) }
                    }
                }
                    
                /*Map = new int[7, 23]
                    {
                        {0,1,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0},
                        {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                        {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                        {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,1,1,1,0},
                        {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,0,1,1,1,1},
                        {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                        {0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0}
                    }*/
            });

            module.Devices.Add(new Device()
            {
                Id = "RAZER_DEATHADDER_V2",
                Title = "Death Adder",
                Map = new DeviceMap()
                {
                    BackgroundImage = Resource.mouse,
                    Size = new Size(50, 50),
                    Leds = new Point[1, 2]
                    {
                        { new Point(24,15),  new Point(24,40) }
                    }
                }
            });

            module.Devices.Add(new Device()
            {
                Id = "RAZER_CHROMA_7.1",
                Title = "Chroma 7.1",
                Map = new DeviceMap()
                {
                    BackgroundImage = Resource.headphones,
                    Size = new Size(50,50),
                    Leds = new Point[2,1]
                    {
                        { new Point(3,36) }, { new Point(41,36) }
                    }
                }
            });

            return module;
        }

        public static void OnCallDevice(string Id, dynamic Data)
        {

        }
    }
}
