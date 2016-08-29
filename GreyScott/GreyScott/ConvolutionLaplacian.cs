using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyScott
{
    public class ConvolutionLaplacian : ILaplacian
    {
        List<Cell> directNeighbours;
        List<Cell> diagonalNeighbours;
        public double ComputeLaplacian(double chemical, bool isA, Cell cell)
        {
            // neighbour list is always passed in as follows: N, E, S, W, NW, NE, SW, SE
            // This will help because N E S W are all * 0.2 for convolution
            // NW NE SW SE are all * 0.05

            // Fill our directNeighbours list first
            directNeighbours = new List<Cell>();
            for (int i = 0; i < 4; i++)
            {
                directNeighbours.Add(cell.neighbourList[i]);
            }
            // Fill our diagonalNeighbours list
            diagonalNeighbours = new List<Cell>();
            for (int i = 4; i < 8; i++)
            {
                diagonalNeighbours.Add(cell.neighbourList[i]);
            }

            // Multiply ourself by -1
            chemical *= -1;
            // Run calculations on direct neighbours, sum results using below method
            double directNeighboursSum = sumChemical(isA, directNeighbours, true);
            // Same for diagonal neighbours
            double diagonalNeighboursSum = sumChemical(isA, diagonalNeighbours, false);
            // Sum all results and return value
            return chemical + directNeighboursSum + diagonalNeighboursSum;
        }

        double sumChemical(bool isA, List<Cell> neighbourList, bool direct)
        {
            double multiplier;
            double concentrationSum = 0;
            if (direct)
                multiplier = 0.2;
            else
                multiplier = 0.05;

            foreach (Cell cell in neighbourList)
            {
                if (isA)
                    concentrationSum += cell.A;
                else
                    concentrationSum += cell.B;
            }
            return concentrationSum * multiplier;            
        }
    }
}
