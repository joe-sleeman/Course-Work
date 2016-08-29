using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyScott
{
    // GreyScale colour scheme implements IColourScheme interface
    public class GreyScale : IColourScheme
    {
        public Color ComputeColour(double B)
        {
            double x = B * 255;
            int y = (int)Math.Floor(x);
            return Color.FromArgb(y, y, y);
        }
    }
}
