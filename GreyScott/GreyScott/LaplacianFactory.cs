using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyScott
{
    // Factory that whill return ILaplacian objects
    public class LaplacianFactory
    {
        public ILaplacian CreateLaplacian(Enums.Laplacian laplacian)
        {
            ILaplacian newLaplacian = null;

            switch (laplacian)
            {
                case Enums.Laplacian.Perpendicular:
                    newLaplacian = new PerpendicularLaplacian();
                    break;
                case Enums.Laplacian.DeltaMeans:
                    newLaplacian = new DeltaMeansLaplacian();
                    break;
                case Enums.Laplacian.Convolution:
                    newLaplacian = new ConvolutionLaplacian();
                    break;
            }
            return newLaplacian;
        }
    }
}
