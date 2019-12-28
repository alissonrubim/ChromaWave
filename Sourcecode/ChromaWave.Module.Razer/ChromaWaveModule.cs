using Colore;
using Colore.Effects.Keyboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ChromaWave.Module.Razer
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

    public class ChromaWaveModule 
    {
        public static DeviceModule Setup()
        {
            //IChroma chroma = ColoreProvider.CreateNativeAsync().Result;
            //chroma.Keyboard.SetKeyAsync(Key.A, Colore.Data.Color.Blue);

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
                    BackgroundImage = ImageToByteArray(Resource.keyboard),
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
                    BackgroundImage = ImageToByteArray(Resource.mouse),
                    Size = new Size(50, 50),
                    Leds = new Point[1, 2]
                    {
                        { new Point(25,15),  new Point(25,40) }
                    }
                }
            });

            module.Devices.Add(new Device()
            {
                Id = "RAZER_CHROMA_7.1",
                Title = "Chroma 7.1",
                Map = new DeviceMap()
                {
                    BackgroundImage = ImageToByteArray(Resource.headphones),
                    Size = new Size(50, 50),
                    Leds = new Point[2, 1]
                    {
                        { new Point(5,36) }, { new Point(45,36) }
                    }
                }
            });

            return module;
        }

        public static void OnCallDevice(string Id, dynamic Data)
        {

        }

        private static byte[] ImageToByteArray(Bitmap img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
    }
}
