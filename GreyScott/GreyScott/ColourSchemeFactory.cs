using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyScott
{
    // Factory used to figure out the colour scheme requested by the user
    public class ColourSchemeFactory
    {
        public IColourScheme CreateColourScheme(Enums.ColourScheme colourScheme)
        {
            IColourScheme newColourScheme = null;

            switch (colourScheme)       // Switch on our passed in enum
            {
                case Enums.ColourScheme.GreyScale:
                    newColourScheme = new GreyScale();
                    break;
                case Enums.ColourScheme.ShortRainbow:
                    newColourScheme = new ShortRainbow();
                    break;
                case Enums.ColourScheme.YellowToRed:
                    newColourScheme = new YellowToRed();
                    break;
                case Enums.ColourScheme.GreenToBlack:
                    newColourScheme = new GreenToBlack();
                    break;
            }
            return newColourScheme;     // Return requested colour scheme
        }
    }
}
