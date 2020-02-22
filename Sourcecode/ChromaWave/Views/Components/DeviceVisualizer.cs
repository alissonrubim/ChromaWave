using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChromaWave.Models;
using ChromaWave.Views.Forms;

namespace ChromaWave.Views
{
    public partial class DeviceVisualizer : UserControl
    {
        private Point lastAbsoluteCursorPosition;
        private bool isLeftClicked;
        private List<Panel> LedPanels = new List<Panel>();
        private Device device;
        private RenderCanvas renderCanvas;
        public readonly string Id;
        public DeviceVisualizer()
        {
            InitializeComponent();
            setupEvents();
        }

        public DeviceVisualizer(RenderCanvas renderCanvas,  Device device): base()
        {
            this.DoubleBuffered = true;
            this.renderCanvas = renderCanvas;
            this.device = device;
            this.Id = device.Id;
            InitializeComponent();
            setupWithDevice();
            setupEvents();
        }

        private void setupWithDevice()
        {
            int borderSize = 6;
            labelTitle.Text = device.Title;
            pictureBoxIcon.Image = Helpers.ImageHelper.ByteArrayToImage(device.Map.BackgroundImage);
            pictureBoxIcon.Size = device.Map.Size;
            this.Size = new Size(
                device.Map.Size.Width + (borderSize * 2) + 2,
                device.Map.Size.Height + (borderSize * 2) + 2 + labelTitle.Height + borderSize
            );
            this.labelTitle.Width = this.Width;
            this.labelTitle.Location = new Point(0, pictureBoxIcon.Location.Y + pictureBoxIcon.Size.Height + borderSize);
            setupLeds(device.Map.Leds);
        }

        private void setupEvents()
        {
            this.MouseDown += On_MouseDown;
            this.MouseMove += On_MouseMove;
            this.MouseUp += On_MouseUp;
            this.DoubleClick += On_DoubleClick;
            foreach (Control control in this.Controls)
            {
                control.MouseDown += On_MouseDown;
                control.MouseMove += On_MouseMove;
                control.MouseUp += On_MouseUp;
                control.DoubleClick += On_DoubleClick;
            }
        }

        private void setupLeds(Point[,] leds)
        {
            foreach (Point led in leds)
            {
                Led ledPanel = new Led();
                ledPanel.OnGetColor += new Led.PixelGetColorHandler(() =>
                {
                    Point globalLedLocation = new Point(this.Location.X + led.X, this.Location.Y + led.Y);
                    return renderCanvas.GetColorAtPosition(globalLedLocation);
                });
                ledPanel.Size = new Size(8, 8);
                ledPanel.Location = new Point(pictureBoxIcon.Location.X + led.X - (ledPanel.Size.Width / 2), pictureBoxIcon.Location.Y + led.Y - (ledPanel.Size.Height / 2));
                this.Controls.Add(ledPanel);
                ledPanel.BringToFront();
            }
        }

        private void On_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                lastAbsoluteCursorPosition = Cursor.Position;
                isLeftClicked = true;
            }
        }

        private void On_MouseMove(object sender, MouseEventArgs e)
        {
            Point newAbsoluteCursorPosition = Cursor.Position;

            if (isLeftClicked)
            {
                if (Math.Abs(newAbsoluteCursorPosition.X - lastAbsoluteCursorPosition.X) > 0)
                {
                    var x = this.Left;
                    x += newAbsoluteCursorPosition.X - lastAbsoluteCursorPosition.X;
                    x = x < 0 ? 0 : x;
                    x = x > Parent.Width - this.Width ? Parent.Width - this.Width : x;
                    this.Left = x;
                }
                if (Math.Abs(newAbsoluteCursorPosition.Y - lastAbsoluteCursorPosition.Y) > 0)
                {
                    var y = this.Top;
                    y += newAbsoluteCursorPosition.Y - lastAbsoluteCursorPosition.Y;
                    y = y < 0 ? 0 : y;
                    y = y > Parent.Height - this.Height ? Parent.Height - this.Height : y;
                    this.Top = y;
                }
            }

            lastAbsoluteCursorPosition = newAbsoluteCursorPosition;
        }

        private void On_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Cursor.Current = Cursors.Default;
                isLeftClicked = false;
            }
        }

        private void On_DoubleClick(object sender, EventArgs e)
        {
            FormDeviceDetails form = new FormDeviceDetails(device);
            form.Show();
        }

        public new virtual void Update()
        {
            Invalidate();
        }
    }

}
