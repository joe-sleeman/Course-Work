using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyScott
{
    // Laplacian function implementing the ILaplacian interface
    public class DeltaMeansLaplacian : ILaplacian
    {
        Cell cell;
        public double ComputeLaplacian(double chemical, bool isA, Cell cell)
        {
            this.cell = cell;
            double averageOfNeighbours = findAverageOfNeighbours(isA);
            double difference = averageOfNeighbours - chemical;
            return difference;
        }

        // findAverageOfNeighborus will return an average of all of the cell's neighbours
        // passed in a boolean which is true if it is the A chemical, false if it is the B chemical
        double findAverageOfNeighbours(bool isA)
        {
            double average = 0;
            foreach (Cell c in cell.neighbourList)
            {
                if (isA)
                    average += c.A;
                else
                    average += c.B;
            }
            average = average / cell.neighbourList.Count;

            return average;
        }
    }
}
