using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyScott
{
    // Interface which all of our colourschemes will implement
    public interface IColourScheme
    {
        // All children must have ComputeColour method
        Color ComputeColour(double B);
    }
}
