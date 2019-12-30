using ChromaWave.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChromaWave.Views.Forms
{
    public partial class FormDeviceDetails : Form
    {
        public FormDeviceDetails()
        {
            InitializeComponent();
        }

        public FormDeviceDetails(Device device)
        {
            InitializeComponent();

            textBoxDeviceId.Text = device.Id;
            textBoxDeviceTitle.Text = device.Title;
            textBoxModuleName.Text = device.Module.Name;
            textBoxModuleLocation.Text = device.Module.Assembly.Location;
        }
    }
}
