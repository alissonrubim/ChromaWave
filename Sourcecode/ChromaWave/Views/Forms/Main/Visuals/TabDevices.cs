using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChromaWave.Controller;
using ChromaWave.Models;
using ChromaWave.Views.Components.Visuals;

namespace ChromaWave.Views.Forms.Visuals
{
    public partial class TabDevices : UserControl, Tab
    {
        private DevicesModulesController devicesController;
        private List<DeviceVisualizer> deviceVisualizers = new List<DeviceVisualizer>();
        public TabDevices()
        {
            InitializeComponent();
        }

        public void Setup()
        {
            loadDevicesModules();
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public RenderCanvas GetRenderCanvas()
        {
            return this.renderCanvas;
        }

        public new virtual void Update()
        {
            foreach (DeviceVisualizer deviceVisualize in deviceVisualizers)
                deviceVisualize.Update();
        }

        public void ApplySettings(Settings settings)
        {
            foreach (DeviceVisualizer visualizer in deviceVisualizers)
            {
                DeviceSettings deviceSetting = settings.Devices.Where(x => x.Id == visualizer.Id).FirstOrDefault();
                if (deviceSetting != null)
                {
                    visualizer.Location = deviceSetting.Location;
                }
            }
        }

        public void SaveSettings(Settings settings)
        {
            foreach(DeviceVisualizer visualizer in deviceVisualizers)
            {
                DeviceSettings deviceSetting = settings.Devices.Where(x => x.Id == visualizer.Id).FirstOrDefault();
                if (deviceSetting != null)
                {
                    deviceSetting.Location = visualizer.Location;
                }
                else
                {
                    deviceSetting = new DeviceSettings();
                    deviceSetting.Id = visualizer.Id;
                    deviceSetting.Location = visualizer.Location;
                    settings.Devices.Add(deviceSetting);
                }
            }
        }

        #region Private
        public void loadDevicesModules()
        {
            devicesController = new DevicesModulesController();
            devicesController.LoadModules(); //Load all the devices modules
            foreach (DeviceModule deviceModule in devicesController.DeviceModules)
            {
                foreach (Device device in deviceModule.Devices)
                {
                    DeviceVisualizer deviceVisualizer = new DeviceVisualizer(GetRenderCanvas(), device);
                    //This code put each device side by site, but the problem is: if you have a lot of devices, they will be put out of bound.
                    //deviceVisualizer.Location = new Point(10 + deviceVisualizers.Sum(x => x.Size.Width), 30);
                    deviceVisualizer.Location = new Point(10, 30);
                    this.Controls.Add(deviceVisualizer);
                    deviceVisualizers.Add(deviceVisualizer);
                    deviceVisualizer.BringToFront();
                }
            }
        }
        #endregion
    }
}
