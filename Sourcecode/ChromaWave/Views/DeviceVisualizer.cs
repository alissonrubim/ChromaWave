﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChromaWave.Models;

namespace ChromaWave.Views
{
    public partial class DeviceVisualizer : UserControl
    {
        private Point lastAbsoluteCursorPosition;
        private bool isLeftClicked;
        private List<Panel> LedPanels = new List<Panel>();
        private Device device;
        private ChromaVisualizer chromaVisualizer;
        public DeviceVisualizer()
        {
            InitializeComponent();
            setupEvents();
        }

        public DeviceVisualizer(ChromaVisualizer chromaVisualizer,  Device device): base()
        {
            this.DoubleBuffered = true;
            this.chromaVisualizer = chromaVisualizer;
            this.device = device;

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
            foreach (Control control in this.Controls)
            {
                control.MouseDown += On_MouseDown;
                control.MouseMove += On_MouseMove;
                control.MouseUp += On_MouseUp;
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
                    return chromaVisualizer.GetColorAtPosition(globalLedLocation);
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
                    this.Left += newAbsoluteCursorPosition.X - lastAbsoluteCursorPosition.X;
                if (Math.Abs(newAbsoluteCursorPosition.Y - lastAbsoluteCursorPosition.Y) > 0)
                    this.Top += newAbsoluteCursorPosition.Y - lastAbsoluteCursorPosition.Y;
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

        public new virtual void Update()
        {
            if(!isLeftClicked)
                Invalidate();
        }
    }

}