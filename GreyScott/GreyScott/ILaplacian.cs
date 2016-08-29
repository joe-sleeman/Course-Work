using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyScott
{
    // The interface that all of our laplacian functions will implement
    public interface ILaplacian
    {   
        // Every laplacian function needs the ComputeLaplacian method
        double ComputeLaplacian(double chemical, bool isA, Cell cell);
    }
}
