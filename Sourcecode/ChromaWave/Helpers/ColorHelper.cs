using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromaWave.Helpers
{
    public class ColorHelper
    {
        public static Color HSLConvert(double hue, double saturation, double light)
        {
            double v;
            double r, g, b;
            r = light; // default to gray
            g = light;
            b = light;
            v = (light <= 0.5) ? (light * (1.0 + saturation)) : (light + saturation - light * saturation);

            if (v > 0)
            {
                double m;
                double sv;
                int sextant;
                double fract, vsf, mid1, mid2;

                m = light + light - v;
                sv = (v - m) / v;
                hue *= 6.0;
                sextant = (int)hue;
                fract = hue - sextant;
                vsf = v * sv * fract;
                mid1 = m + vsf;
                mid2 = v - vsf;

                switch (sextant)
                {
                    case 0:
                        r = v;
                        g = mid1;
                        b = m;
                        break;
                    case 1:
                        r = mid2;
                        g = v;
                        b = m;
                        break;
                    case 2:
                        r = m;
                        g = v;
                        b = mid1;
                        break;
                    case 3:
                        r = m;
                        g = mid2;
                        b = v;
                        break;
                    case 4:
                        r = mid1;
                        g = m;
                        b = v;
                        break;
                    case 5:
                        r = v;
                        g = m;
                        b = mid2;
                        break;
                }
            }

            return Color.FromArgb(Convert.ToByte(r * 255.0f), Convert.ToByte(g * 255.0f), Convert.ToByte(b * 255.0f));
        }
    }
}
