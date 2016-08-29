using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreyScott
{
    // Manager Class:
    //              This class will control all of the simulations that we want to run
    //
    public class Manager
    {
        const int GRID_SIZE = Constants.GRID_SIZE;      // Get GRID_SIZE from our static class Constants

        Cell[,] cellArray;                              // 2D array used to store the Cells in our grid
        Graphics graphics;
        Grid grid;                                      // Grid that we will map our cells to
        Bitmap offScreenBitmap;
        SimulationParameters simulationParameters;      // SimulationParameters object which we can access to get/set parameters
        Enums.ColourScheme eColourScheme;
       
        // Constructor
        public Manager(Graphics graphics, SimulationParameters simulationParameters, Enums.ColourScheme eColourScheme)
        {
            this.graphics = graphics;
            this.simulationParameters = simulationParameters;
            this.eColourScheme = eColourScheme;
            offScreenBitmap = new Bitmap(Constants.IMAGE_SIZE, Constants.IMAGE_SIZE);
            Graphics offScreenGraphics = Graphics.FromImage(offScreenBitmap);
            cellArray = new Cell[GRID_SIZE, GRID_SIZE];
            populateArray();
            populateNeighbours();
            grid = new Grid(offScreenGraphics, cellArray, simulationParameters, eColourScheme);
        }

        // reset -- Private method used for when we want to reset a simulation - very useful for running a batch 
        void reset()
        {
            offScreenBitmap = new Bitmap(Constants.IMAGE_SIZE, Constants.IMAGE_SIZE);
            Graphics offScreenGraphics = Graphics.FromImage(offScreenBitmap);
            cellArray = new Cell[GRID_SIZE, GRID_SIZE];
            populateArray();
            populateNeighbours();
            grid = new Grid(offScreenGraphics, cellArray, simulationParameters, eColourScheme);
        }

        // The cycle for manager - will do 1 iteration of the laplacian function and then draw image to screen
        public void ManagerCycle(Enums.Laplacian eLaplacian)
        {
            grid.GridCycle(eLaplacian);
            graphics.DrawImage(offScreenBitmap, 0, 0);
        }
        // Cycle used to run one thousand times in the background and then draw image to screen
        public void OneThousandCycle(Enums.Laplacian eLaplacian)
        {
            grid.OneThousandStepCycle(eLaplacian);
            graphics.DrawImage(offScreenBitmap, 0, 0);
        }
        // Cycle for five thousand iterations and then draw to screen
        public void FiveThousandCycle(Enums.Laplacian eLaplacian)
        {
            grid.FiveThousandStepCycle(eLaplacian);
            graphics.DrawImage(offScreenBitmap, 0, 0);
        }
        // Save Image will save the image based on the save directory stored in parameters class, and on the
        // passed in string - imageName
        public void SaveImage(string imageName)
        {
            string saveDirectory = simulationParameters.SaveDirectory;
            offScreenBitmap.Save(saveDirectory + imageName);
        }
        // Batch cycle - used to run a batch of simulations back to back. Based on the starting A and B values
        // it will continue to run until it has reached the End values specified by the user in the form which
        // are stored in simulation parameters class
        public void BatchCycle(Enums.Laplacian eLaplacian)
        {
            double startA = simulationParameters.FeedA;
            double startB = simulationParameters.KillB;
            double endA = simulationParameters.EndFeedA;
            double endB = simulationParameters.EndKillB;

            for (double da = startA; da < endA; da += 0.001)
            {
                simulationParameters.FeedA = da;
                for (double db = startB; db < endB; db += 0.001)
                {
                    simulationParameters.KillB = db;
                    grid.FiveThousandStepCycle(eLaplacian);
                    string imageName = CreateImageName();
                    SaveImage(imageName);
                    reset();
                }
            }
        }

        // CreateImageName will generate an image name for us based on the current timestamp and the Feed A and Kill B
        // values stored in our simulation parameters class
        public string CreateImageName()
        {
            string now = DateTime.Now.ToString("yyyyMMddhhmmss");   // Make sure filename is unique using timestamp
            // Create a useful image name that will tell us information about the Feed A and Kill B values used to produce image
            string imageName = now + " " + "FA" + simulationParameters.FeedA + " KB" + simulationParameters.KillB + ".bmp";
            return imageName;
        }

        // PopulateArray will populate our cell array - will seed cells in the middle of the grid with 0, 1 values and the
        // rest of the array will have cells with 1, 0 values
        void populateArray()
        {
            int quarter = GRID_SIZE / 4;
            int threeQuarters = quarter * 3;

            for (int row = 0; row < GRID_SIZE; row++)
            {
                for (int col = 0; col < GRID_SIZE; col++)
                {
                    if (row >= quarter && row <= threeQuarters && col >= quarter && col <= threeQuarters)
                        cellArray[row, col] = new Cell(0, 1);       
                    else
                        cellArray[row, col] = new Cell(1, 0);
                }
            }
        }

        // populateNeighbours will populate our neighbour lists and then pass that neighbour list to the corresponding Cell
        void populateNeighbours()
        {
            int maxValue = GRID_SIZE - 1;
            int minValue = 0;

            for (int row = 0; row < GRID_SIZE; row++)
            {
                for (int col = 0; col < GRID_SIZE; col++)
                {
                    List<Cell> neighbourList = new List<Cell>();

                    // Put our positions for North, East, South, West neighbours in to nice, readable variable names
                    int north = row - 1;
                    int east = col + 1;
                    int south = row + 1;
                    int west = col - 1;

                    // Wrap neighbours if they are on the edge of our array
                    if (row == maxValue)        // We are at the bottom
                        south = minValue;

                    if (row == minValue)        // We are at the top
                        north = maxValue;

                    if (col == maxValue)        // We are at the Eastern edge
                        east = minValue;

                    if (col == minValue)        // We are at the Western edge
                        west = maxValue;

                    // Populate direct neighbours first - this will aid us in laplacian functions where we
                    // need to seperate the direct neighbours from the diagonal neighbours
                    Cell N = cellArray[north, col];
                    Cell E = cellArray[row, east];
                    Cell S = cellArray[south, col];
                    Cell W = cellArray[row, west];

                    // Populate diagonal neighbours last - this will also help us in laplacian functions
                    Cell NW = cellArray[north, west];
                    Cell NE = cellArray[north, east];
                    Cell SW = cellArray[south, west];
                    Cell SE = cellArray[south, east];

                    // Actually adding to the list in order stated above
                    neighbourList.Add(N);
                    neighbourList.Add(E);
                    neighbourList.Add(S);
                    neighbourList.Add(W);
                    neighbourList.Add(NW);
                    neighbourList.Add(NE);
                    neighbourList.Add(SW);
                    neighbourList.Add(SE);
                    // Give the list to the Cell
                    cellArray[row, col].AddNeighbours(neighbourList);
                }
            }
        }
    }
}
