using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyScott
{
    public class PerpendicularLaplacian : ILaplacian
    {
        const double H = 2.5 / 127.0;
        const double RH = 1.0 / H / H;
        List<Cell> neighbourList;

        public double ComputeLaplacian(double chemical, bool isA, Cell cell)
        {

            // We only care about the first four entries in the cell's neighbourList
            // as they are the N, E, S, W coordinates -- perpendicular - we will only add
            // the first four entries to our neighbour list
            neighbourList = new List<Cell>();
            for (int i = 0; i < 4; i++)
            {
                neighbourList.Add(cell.neighbourList[i]);
            }

            double concentrationSum = sumChemical(isA);
            double concentrationX = (4 * chemical);
            double newValue = RH * ((concentrationSum) - (concentrationX));
            return newValue;
        }

        // Sum the neighbours chemicals and return sum
        double sumChemical(bool isA)
        {
            double concentrationSum = 0;
            foreach (Cell cell in neighbourList)
            {
                if (isA)
                    concentrationSum += cell.A;
                else
                    concentrationSum += cell.B;
            }
            return concentrationSum;            
        }
    }
}
