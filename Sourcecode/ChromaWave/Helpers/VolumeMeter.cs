using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChromaWave.Helpers
{
    public partial class VolumeMeter : UserControl
    {
        private Color borderColor = Color.White;
        public int borderWidth = 1;
        private int value;
        private Color backgroundColor = Color.Transparent;
        private Color barColor = Color.White;

        #region Properties
        [Description("The color of the border."), Category("Aparência")]
        public Color BorderColor
        {
            get
            {
                return borderColor;
            }
            set
            {
                SetBorderColor(value);
            }
        }

        [Description("The size of the border."), Category("Aparência")]
        public int BorderWidth
        {
            get
            {
                return borderWidth;
            }
            set
            {
                SetBorderWidth(value);
            }
        }

        [Description("The background color of the vumeter."), Category("Aparência")]
        public Color BackgroundColor {
            get
            {
                return backgroundColor;
            }
            set
            {
                SetBackgroundColor(value);
            }
        }

        [Description("The current value of the VUMeter"), Category("Data")]
        public int Value {
            get
            {
                return value;
            }
            set
            {
                SetValue(value);
            }
        }

        [Description("The bar color of the vumeter."), Category("Aparência")]
        public Color BarColor
        {
            get
            {
                return barColor;
            }
            set
            {
                SetBarColor(value);
            }
        }
        #endregion

        public VolumeMeter()
        {
            InitializeComponent();
        }

        private void VolumeMeter_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            int barHeight = Convert.ToInt32(this.Height * value / 100);
            int borderOffset = this.borderWidth / 2 + (this.borderWidth % 2 == 0 ? 0 : 1);

            //Border
            if (borderWidth > 0)
            {
                Pen borderPen = new Pen(this.BorderColor);
                borderPen.Width = this.borderWidth;
                Rectangle border = new Rectangle(new Point(0, 0), new Size(this.Width - 1, this.Height - 1));
                graphics.DrawRectangle(borderPen, border);
            }

            //BackGround
            SolidBrush backgroundColor = new SolidBrush(this.backgroundColor);
            Rectangle background = new Rectangle(new Point(borderOffset, borderOffset), new Size(this.Width - ((this.borderWidth) + 1), this.Height - ((this.borderWidth) + 1)));
            graphics.FillRectangle(backgroundColor, background);

            //Bar
            int StartPointLeft = borderOffset;
            int StartPointTop = (this.Height - barHeight) + borderOffset;
            SolidBrush barColor = new SolidBrush(this.barColor);
            Rectangle bar = new Rectangle(new Point(StartPointLeft, StartPointTop), new Size(this.Width - ((this.borderWidth) + 1), barHeight - ((this.borderWidth) + 1)));
            graphics.FillRectangle(barColor, bar);
        }

        private void SetValue(int value)
        {
            this.value = value;
            Invalidate();
        }

        private void SetBorderColor(Color borderColor)
        {
            this.borderColor = borderColor;
            Invalidate();
        }

        private void SetBorderWidth(int borderWidth)
        {
            this.borderWidth = borderWidth;
            Invalidate();
        }

        private void SetBackgroundColor(Color backgroundColor)
        {
            this.backgroundColor = backgroundColor;
            Invalidate();
        }

        private void SetBarColor(Color barColor)
        {
            this.barColor = barColor;
            Invalidate();
        }
    }
}
