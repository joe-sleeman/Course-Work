using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreyScott
{
    // Grid:
    //      This class will do most of the computations and stuff related to our simulation
    public class Grid
    {
        List<Cell> cellList;
        Graphics graphics;
        int GRID_SIZE = Constants.GRID_SIZE;
        SimulationParameters simulationParameters;
        IColourScheme colourScheme;

        // Constructor
        public Grid(Graphics graphics, Cell[,] cellArray, SimulationParameters simulationParameters, Enums.ColourScheme colourScheme)
        {
            ColourSchemeFactory colourSchemeFactory = new ColourSchemeFactory();
            this.graphics = graphics;
            this.simulationParameters = simulationParameters;
            this.colourScheme = colourSchemeFactory.CreateColourScheme(colourScheme);
            cellList = new List<Cell>();
            // Go through the array and put it in our cell list
            for (int row = 0; row < GRID_SIZE; row++)
            {
                for (int col = 0; col < GRID_SIZE; col++)
                {
                    cellList.Add(cellArray[row, col]);
                }
            }
        }

        // GridCycle will do one single cycle of the simulation based on the enum passed in then draw to screen
        public void GridCycle(Enums.Laplacian eLaplacian)
        {
            LaplacianFactory laplacianFactory = new LaplacianFactory();             // Refactor to avoid code duplication !!!!!
            ILaplacian laplacian = laplacianFactory.CreateLaplacian(eLaplacian);
            computeNewValuesForAllCells(laplacian);
            drawAllCells();            
        }
        // One thousand iterations through our simulation and then when finished, draw to screen
        public void OneThousandStepCycle(Enums.Laplacian eLaplacian)
        {
            LaplacianFactory laplacianFactory = new LaplacianFactory();
            ILaplacian laplacian = laplacianFactory.CreateLaplacian(eLaplacian);
            for (int i = 0; i < 1000; i++)
            {
                computeNewValuesForAllCells(laplacian);
            }
            drawAllCells();
        }
        // Five thousand iterations
        public void FiveThousandStepCycle(Enums.Laplacian eLaplacian)
        {
            LaplacianFactory laplacianFactory = new LaplacianFactory();
            ILaplacian laplacian = laplacianFactory.CreateLaplacian(eLaplacian);
            for (int i = 0; i < 5000; i++)
            {
                computeNewValuesForAllCells(laplacian);
            }
            drawAllCells();
        }
        // Draw every cell to the screen - based on example given by lecturer Patricia Haden
        void drawAllCells()
        {
            int col = 0;
            int row = 0;
            int size = Constants.CELL_SIZE;     // Get our cell size from Constants class

            int currX = 0;
            int currY = 0;

            Brush currBrush;

            foreach (Cell cell in cellList)
            {
                currX = col * size;
                currY = row * size;
                currBrush = new SolidBrush(cell.CellColour);        // Create brush based on the cell's CellColour property
                graphics.FillRectangle(currBrush, currX, currY, size, size);
                col++;

                if (col == GRID_SIZE)
                {
                    row++;
                    col = 0;
                }
            }
        }
        
        // computeNewValuesForAllCells will compute new values for all of our cells, based on their neighbours concentrations
        // of chemicals A & B
        void computeNewValuesForAllCells(ILaplacian laplacian)
        {
            // Compute new values - store in NewA and NewB property until we have computed for every cell
            foreach (Cell cell in cellList)
            {
                double lapA = laplacian.ComputeLaplacian(cell.A, true, cell);
                double lapB = laplacian.ComputeLaplacian(cell.B, false, cell);

                cell.NewA = computeNewA(cell.A, cell.B, lapA);
                cell.NewB = computeNewB(cell.A, cell.B, lapB);
            }
            // Assign these new values to be current values now that we have finished computations
            foreach (Cell cell in cellList)
            {
                cell.A = cell.NewA;
                cell.B = cell.NewB;
                cell.ComputeColour(colourScheme);
            }
        }

        // Computation method used to compute new A values by using the formular given to us in the assignment brief
        double computeNewA(double A, double B, double lapA)
        {
            double diffA = simulationParameters.DiffA;
            double feedA = simulationParameters.FeedA;

            double returnValue = A + (diffA * lapA) - (A * B * B) + (feedA * (1 - A));  // This is the formular

            return checkReturnValue(returnValue);
        }

        // Computation method used to compute new B values using the formular given to us in assignment brief
        // This one is more long-winded than the above method, by seperating the formular into left and right
        // sides and then combining them at the end. Not sure which is more readable and nice, so have included
        // one of each
        double computeNewB(double A, double B, double lapB)
        {
            double diffB = simulationParameters.DiffB;
            double feedA = simulationParameters.FeedA;
            double killB = simulationParameters.KillB;

            double leftBracket = diffB * lapB;          // left side of formular
            double rightBracket = (killB + feedA) * B;  // right side of formular

            double returnValue = B + leftBracket + (A * B * B) - rightBracket;

            return checkReturnValue(returnValue);
        }

        // CheckReturnValue - used to check if our return value is out of bounds (> 1 or < 0)
        // Will then set values to be 1 or 0 based on which bound it breaks
        double checkReturnValue(double returnValue)
        {
            if (returnValue > 1)
                returnValue = 1;
            if (returnValue < 0)
                returnValue = 0;

            return returnValue;
        }
    }
}
