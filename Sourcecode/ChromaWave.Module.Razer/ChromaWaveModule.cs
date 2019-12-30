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
    public class ChromaWaveModule: IChromaWaveModule
    {
        public Module Setup()
        {
            Module module = new Module()
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
                    Size = new Size(100, 30),
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
                Id = "LED_STRIP",
                Title = "LedStrip",
                Map = new DeviceMap()
                {
                    BackgroundImage = null,
                    Size = new Size(300, 5),
                    Leds = new Point[1, 21]
                    {
                        {
                            new Point(0, 0),
                            new Point(15, 0),  
                            new Point(30, 0),
                            new Point(45, 0),
                            new Point(60, 0),
                            new Point(75, 0),
                            new Point(90, 0),
                            new Point(105, 0),
                            new Point(120, 0),
                            new Point(135, 0),
                            new Point(150, 0),
                            new Point(165, 0),
                            new Point(180, 0),
                            new Point(195, 0),
                            new Point(210, 0),
                            new Point(225, 0),
                            new Point(240, 0),
                            new Point(255, 0),
                            new Point(270, 0),
                            new Point(285, 0),
                            new Point(300, 0)
                        }
                    }
                }
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

        private static byte[] ImageToByteArray(Bitmap img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }


        public void OnProcessDevice(string DeviceId)
        {
            throw new NotImplementedException();
        }
    }
}
