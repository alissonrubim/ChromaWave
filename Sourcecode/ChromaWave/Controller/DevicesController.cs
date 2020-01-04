using ChromaWave.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ChromaWave.Controller
{
    public class DevicesController
    {
        public List<DeviceModule> DeviceModules = new List<DeviceModule>();
        public void LoadModules()
        {
            foreach (string directory in Directory.GetDirectories("Modules"))
            {
                foreach(string file in Directory.GetFiles(directory, "*.dll"))
                {
                    FileInfo fileInfo = new FileInfo(file);
                    if (fileInfo.Name.IndexOf("ChromaWave.Module") == 0)
                    {
                        Assembly module = Assembly.LoadFile(fileInfo.FullName);
                        AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler((a, b) =>
                        {
                            string dllName = b.Name.Split(',')[0].Trim();
                            dllName += ".dll";
                            dllName = Path.Combine(fileInfo.DirectoryName, dllName);
                            if (File.Exists(dllName))
                                return Assembly.LoadFile(dllName);
                            else
                                return null;
                        }); 

                        string moduleControllerName = $"{Path.GetFileNameWithoutExtension(fileInfo.Name)}.ChromaWaveModule";
                        Type deviceControllerType = module.GetType(moduleControllerName);
                        if (deviceControllerType == null)
                            throw new Exception($"{moduleControllerName} was not found inside {file}");
                        object deviceController = Activator.CreateInstance(deviceControllerType);
                        MethodInfo method = deviceControllerType.GetMethod("Setup");
                        if (method == null)
                            throw new Exception("Module needs to have a Setup method");
                        dynamic result = method.Invoke(deviceController, new object[] { });

                        DeviceModule devicesModule = new DeviceModule()
                        {
                            Name = result.Name,
                            DeviceController = deviceController,
                            Assembly = module
                        };

                        List<Device> devices = new List<Device>();
                        foreach (dynamic dynamicResult in result.Devices)
                        {
                            devicesModule.Devices.Add(new Device()
                            {
                                Id = dynamicResult.Id,
                                Title = dynamicResult.Title,
                                Module = devicesModule,
                                Map = new DeviceMap()
                                {
                                    BackgroundImage = dynamicResult.Map.BackgroundImage,
                                    Size = dynamicResult.Map.Size,
                                    Leds = dynamicResult.Map.Leds,
                                }
                            });
                        }

                        DeviceModules.Add(devicesModule);
                    }
                }

            }            
        }
    }
}
