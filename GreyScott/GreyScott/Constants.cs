using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyScott
{
    // Class used to store constants for the project. Saves us time and effort if we want to change
    // the grid or cell size
    public static class Constants
    {
        public const int GRID_SIZE = 256;
        public const int CELL_SIZE = 1;
        public const int IMAGE_SIZE = GRID_SIZE * CELL_SIZE;
    }
}
