using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyScott
{
    // GreenToBlack colour scheme implements IColourScheme interface
    public class GreenToBlack : IColourScheme
    {
        public Color ComputeColour(double B)
        {
            double a = (1 - B);
            int g = (int)Math.Floor(153 * a);
            int r = 0;
            int b = 153;
            return Color.FromArgb(r, g, b);
        }
    }
}
