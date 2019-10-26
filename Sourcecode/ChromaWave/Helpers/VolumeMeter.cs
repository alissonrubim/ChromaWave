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
    public enum VolumeMeterRenderMethod { Linear, Blocks }
    public partial class VolumeMeter : UserControl
    {
        private Color borderColor = Color.White;
        public int borderWidth = 1;
        private int value;
        private Color backgroundColor = Color.Transparent;
        private Color barColor = Color.White;
        private VolumeMeterRenderMethod renderMethod = VolumeMeterRenderMethod.Linear;
        private int BlockSize = 20;

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

        [Browsable(true)]
        [DisplayName("Render Method")]
        [Description("The render method that will be used to generate the bar."), Category("Aparência")]
        public VolumeMeterRenderMethod RenderMethod
        {
            get
            {
                return renderMethod;
            }
            set
            {
                SetRenderMethod(value);
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
            Rectangle background = new Rectangle(new Point(borderOffset, borderOffset), new Size(this.Width - ((this.borderWidth) + 1), this.Height - (this.borderWidth + 1)));
            graphics.FillRectangle(backgroundColor, background);

            //Bar
            int StartPointLeft = borderOffset;
            int StartPointTop = (this.Height - barHeight) + borderOffset;
            SolidBrush barColor = new SolidBrush(this.barColor);

            if (renderMethod == VolumeMeterRenderMethod.Linear)
            {
                Rectangle bar = new Rectangle(new Point(StartPointLeft, StartPointTop), new Size(this.Width - ((this.borderWidth) + 1), barHeight - (this.borderWidth + 1)));
                graphics.FillRectangle(barColor, bar);
            }
            else
            {
                int numberOfBlocks = (value*this.BlockSize/100);
                int blockHeight = ((this.Height - (borderOffset * 2)) / this.BlockSize) + 1;
                int separatorHeight = 1;
                for(var i = 0; i < this.BlockSize; i++)
                {
                    if (i >= this.BlockSize - numberOfBlocks)
                    {
                        int height = blockHeight - separatorHeight;
                        if (i == this.BlockSize - 1)
                            height = blockHeight;
                        
                        Rectangle bar = new Rectangle(new Point(StartPointLeft, blockHeight * i), new Size(this.Width - ((this.borderWidth) + 1), height));
                        graphics.FillRectangle(barColor, bar);
                    }
                }
            }
        }

        private void SetValue(int value)
        {
            if (value < 0 || value > 100)
                throw new Exception("The VolumeMeter value should be between 0 and 100.");
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

        private void SetRenderMethod(VolumeMeterRenderMethod renderMethod)
        {
            this.renderMethod = renderMethod;
            Invalidate();
        }
    }
}
