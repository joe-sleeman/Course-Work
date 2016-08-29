using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyScott
{
    public class YellowToRed : IColourScheme
    {
        public Color ComputeColour(double B)
        {
            double a = (1 - B);
            int g = (int)Math.Floor(255 * a);
            int r = 255;
            int b = 0;
            return Color.FromArgb(r, g, b);
        }
    }
}
