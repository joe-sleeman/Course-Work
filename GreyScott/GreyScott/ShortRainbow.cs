using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyScott
{
    // Short Rainbow colour scheme implements IColourScheme interface
    public class ShortRainbow : IColourScheme
    {
        // Algorithim based on: https://www.particleincell.com/2014/colormap/
        public Color ComputeColour(double B)
        {
            int r = 0;
            int g = 0;
            int b = 0;

            double a = (1 - B) / 0.25;
            int X = (int)Math.Floor(a);
            double Y = Math.Floor(255 * (a - X));
            switch (X)
            {
                case 0:
                    r = 255;
                    g = (int)Y;
                    b = 0;
                    break;
                case 1:
                    r = 255;
                    g = 255;
                    b = 0;
                    break;
                case 2:
                    r = 0;
                    g = 255;
                    b = (int)Y;
                    break;
                case 3:
                    r = 0;
                    g = 255 - (int)Y;
                    b = 255;
                    break;
                case 4:
                    r = 0;
                    g = 0;
                    b = 255;
                    break;
            }
            // return our colour
            return Color.FromArgb(r, g, b);
        }
    }
}
