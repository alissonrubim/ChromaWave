using ChromaWave.Models;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.CoreAudioApi;

namespace ChromaWave.Controller
{
    public class AudioDeviceController
    {
        public static List<AudioDevice> GetAllAudioDevices()
        {
            List<AudioDevice> audioSources = new List<AudioDevice>();

            //Get all devices current registed in the Windows (including input and output, in any state)
            MMDeviceCollection devices = new MMDeviceEnumerator().EnumerateAudioEndPoints(DataFlow.All, DeviceState.All);

            //Get all the friendly devices registered in the Audio Controller of the Windows;
            List<WaveOutCapabilities> capabilities = new List<WaveOutCapabilities>();
            for (int i = 0; i < WaveOut.DeviceCount - 1; i++)
                capabilities.Add(WaveOut.GetCapabilities(i));

            foreach (MMDevice device in devices)
            {
                foreach (WaveOutCapabilities capabilitie in capabilities)
                {
                    //Find the devices that have the same name. Note: impossible of a device has a same name as other, so compare IndexOf it's not so bad.
                    if (device.FriendlyName.IndexOf(capabilitie.ProductName) == 0)
                    {
                        audioSources.Add(new AudioDevice()
                        {
                            Name = device.FriendlyName,
                            Channels = capabilitie.Channels,
                            Id = device.ID
                        });
                    }
                }
            }
            
            return audioSources;
        }
    }
}
