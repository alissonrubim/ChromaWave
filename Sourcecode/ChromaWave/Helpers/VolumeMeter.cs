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
        private Color pBorderColor = Color.White;
        private int pBorderWidth = 1;
        private int pValue;
        private Color pBackgroundColor = Color.Transparent;
        private Color pBarColor = Color.White;
        private VolumeMeterRenderMethod pRenderMethod = VolumeMeterRenderMethod.Linear;
        private int pBlockSize = 20;
        private bool pAutoUpdate = false;

        #region Properties
        [Description("The color of the border."), Category("Aparência")]
        public Color BorderColor
        {
            get
            {
                return pBorderColor;
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
                return pBorderWidth;
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
                return pBackgroundColor;
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
                return pValue;
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
                return pBarColor;
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
                return pRenderMethod;
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
            this.DoubleBuffered = true;
        }

        private void VolumeMeter_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            int barHeight = Convert.ToInt32(this.Height * pValue / 100);
            int borderOffset = this.pBorderWidth / 2 + (this.pBorderWidth % 2 == 0 ? 0 : 1);

            //Border
            if (pBorderWidth > 0)
            {
                Pen borderPen = new Pen(this.BorderColor);
                borderPen.Width = this.pBorderWidth;
                Rectangle border = new Rectangle(new Point(0, 0), new Size(this.Width - 1, this.Height - 1));
                graphics.DrawRectangle(borderPen, border);
            }

            //BackGround
            SolidBrush backgroundColor = new SolidBrush(this.pBackgroundColor);
            Rectangle background = new Rectangle(new Point(borderOffset, borderOffset), new Size(this.Width - ((this.pBorderWidth) + 1), this.Height - (this.pBorderWidth + 1)));
            graphics.FillRectangle(backgroundColor, background);

            //Bar
            int StartPointLeft = borderOffset;
            int StartPointTop = (this.Height - barHeight) + borderOffset;
            SolidBrush barColor = new SolidBrush(this.pBarColor);

            if (pRenderMethod == VolumeMeterRenderMethod.Linear)
            {
                Rectangle bar = new Rectangle(new Point(StartPointLeft, StartPointTop), new Size(this.Width - ((this.pBorderWidth) + 1), barHeight - (this.pBorderWidth + 1)));
                graphics.FillRectangle(barColor, bar);
            }
            else if(pRenderMethod == VolumeMeterRenderMethod.Blocks)
            {
                int numberOfBlocks = (pValue*this.pBlockSize/100);
                int blockHeight = ((this.Height - (borderOffset * 2)) / this.pBlockSize) + 1;
                int separatorHeight = 1;
                for(var i = 0; i < this.pBlockSize; i++)
                {
                    if (i >= this.pBlockSize - numberOfBlocks)
                    {
                        int height = blockHeight - separatorHeight;
                        if (i == this.pBlockSize - 1)
                            height = blockHeight;
                        
                        Rectangle bar = new Rectangle(new Point(StartPointLeft, blockHeight * i), new Size(this.Width - ((this.pBorderWidth) + 1), height));
                        graphics.FillRectangle(barColor, bar);
                    }
                }
            }
        }

        private void SetValue(int value)
        {
            if (value < 0 || value > 100)
                throw new Exception("The VolumeMeter value should be between 0 and 100.");
            this.pValue = value;
            if (this.pAutoUpdate)
                Invalidate();
        }

        private void SetBorderColor(Color borderColor)
        {
            this.pBorderColor = borderColor;
            if (this.pAutoUpdate)
                Invalidate();
        }

        private void SetBorderWidth(int borderWidth)
        {
            this.pBorderWidth = borderWidth;
            if (this.pAutoUpdate)
                Invalidate();
        }

        private void SetBackgroundColor(Color backgroundColor)
        {
            this.pBackgroundColor = backgroundColor;
            if (this.pAutoUpdate)
                Invalidate();
        }

        private void SetBarColor(Color barColor)
        {
            this.pBarColor = barColor;
            if (this.pAutoUpdate)
                Invalidate();
        }

        private void SetRenderMethod(VolumeMeterRenderMethod renderMethod)
        {
            this.pRenderMethod = renderMethod;
            if(this.pAutoUpdate)
                Invalidate();
        }

        public new virtual void Update()
        {
            Invalidate();
        }
    }
}
