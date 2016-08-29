using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyScott
{
    // Cell class:
    //              This class will store values for the chemicals A and B. It will also hold a list of other cells
    //              which are positioned around the cell, aptly named "neighbourList". The cell will also hold it's 
    //              colour, which it can figure out based on the concentration of the B chemical. It also needs to
    //              be given an IColourScheme in order to figure out it's colour.
    //              NewA and NewB are variables used to store new values for A and B, but retain it's current values
    //              while other cells are calculating their colours. This is because other cells are dependent on 
    //              the cells current values, so we can only apply their new values once we have finished calculating
    //              all of the cells NewA and NewB values.
    public class Cell
    {
        
        public List<Cell> neighbourList;
        public Color CellColour { get; set; }
        public double A { get; set; }
        public double B { get; set; }
        public double NewA { get; set; }
        public double NewB { get; set; }

        // Constructor -- Takes two doubles - A and B values - initializes the neighbourList
        public Cell(double A, double B)
        {
            this.A = A;
            this.B = B;
            neighbourList = new List<Cell>();
        }
        public void ComputeColour(IColourScheme colourScheme)   // Gets passed in a colour scheme
        {                                                   
            CellColour = colourScheme.ComputeColour(B);         // Uses colour scheme to compute colour
        }

        public void AddNeighbours(List<Cell> neighbourList)     // Gets passed in a list of neighbours
        {
            this.neighbourList = neighbourList;                 // Sets that list to belong to the Cell
        }


    }
}
