using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GreyScott;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;

namespace UnitTestGreyScott
{
    [TestClass]
    public class UnitTest1
    {

        // Laplacian functions with all cells 1,0
        [TestMethod]
        public void TestConvolutionLaplacian_ReturnDouble()
        {
            ILaplacian testLaplacian = new ConvolutionLaplacian();
            Cell cell = new Cell(1, 0);
            List<Cell> cellNeighbourList = new List<Cell>();
            for (int i = 0; i < 8; i++ )
            {
                cellNeighbourList.Add(new Cell(1, 0));
            }
            cell.AddNeighbours(cellNeighbourList);

            double expected = -1;
            double actual = testLaplacian.ComputeLaplacian(1, false, cell);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]    // We expect to crash if there is no neighbour list
        public void TestConvulationLaplacian_WithNoNeighbours_ShouldReturn()
        {
            ILaplacian testLaplacian = new ConvolutionLaplacian();
            Cell cell = new Cell(1, 0);

            double expected = -1;
            double actual = testLaplacian.ComputeLaplacian(1, true, cell);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPerpendicularLaplacian_ReturnDouble()
        {
            ILaplacian testLaplacian = new PerpendicularLaplacian();
            Cell cell = new Cell(1, 0);
            List<Cell> cellNeighbourList = new List<Cell>();
            for (int i = 0; i < 8; i++)
            {
                cellNeighbourList.Add(new Cell(1, 0));
            }
            cell.AddNeighbours(cellNeighbourList);

            double expected = 0.00;
            double actual = testLaplacian.ComputeLaplacian(1, true, cell);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDeltaMeansLaplacian_ReturnDouble()
        {
            ILaplacian testLaplacian = new DeltaMeansLaplacian();
            Cell cell = new Cell(1, 0);
            List<Cell> cellNeighbourList = new List<Cell>();
            for (int i = 0; i < 8; i++)
            {
                cellNeighbourList.Add(new Cell(1, 0));
            }
            cell.AddNeighbours(cellNeighbourList);

            double expected = 0.00;
            double actual = testLaplacian.ComputeLaplacian(1, true, cell);
            Assert.AreEqual(expected, actual);
        }


        // Colour scheme tests
        [TestMethod]
        public void TestGreenToBlack_ReturnColour()
        {
            IColourScheme greenToBlack = new GreenToBlack();
            Color expected = Color.FromArgb(0, 114, 153);
            Color actual = greenToBlack.ComputeColour(0.25);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestYellowToRed_ReturnColour()
        {
            IColourScheme yellowToRed = new YellowToRed();
            Color expected = Color.FromArgb(255, 140, 0);
            Color actual = yellowToRed.ComputeColour(0.45);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGreyScale_ReturnColour()
        {
            IColourScheme greyScale = new GreyScale();
            Color expected = Color.FromArgb(209, 209, 209);
            Color actual = greyScale.ComputeColour(0.82);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestShortRainbow_ReturnColour()
        {
            IColourScheme shortRainbow = new ShortRainbow();
            Color expected = Color.FromArgb(255, 20, 0);
            Color actual = shortRainbow.ComputeColour(0.98);
            Assert.AreEqual(expected, actual);
        }

        // Factories

        // Laplacian Factory
        [TestMethod]
        public void TestLaplacianFactory_WithEnumPerpendicular_ShouldReturnNewPerpendicularLaplacian()
        {
            LaplacianFactory laplacianFactory = new LaplacianFactory();
            ILaplacian expected = new PerpendicularLaplacian();
            ILaplacian actual = laplacianFactory.CreateLaplacian(Enums.Laplacian.Perpendicular);
            Assert.AreEqual(expected.GetType(), actual.GetType());  
        }

        [TestMethod]
        public void TestLaplacianFactory_WithEnumDeltaMeans_ShouldReturnDeltaMeansObject()
        {
            LaplacianFactory laplacianFactory = new LaplacianFactory();
            ILaplacian expected = new DeltaMeansLaplacian();
            ILaplacian actual = laplacianFactory.CreateLaplacian(Enums.Laplacian.DeltaMeans);
            Assert.AreEqual(expected.GetType(), actual.GetType());
        }

        [TestMethod]
        public void TestLaplacianFactory_WithEnumConvolution_ShouldReturnConvolutionObject()
        {
            LaplacianFactory laplacianFactory = new LaplacianFactory();
            ILaplacian expected = new ConvolutionLaplacian();
            ILaplacian actual = laplacianFactory.CreateLaplacian(Enums.Laplacian.Convolution);
            Assert.AreEqual(expected.GetType(), actual.GetType());
        }

        // Colour Scheme Factory

        [TestMethod]
        public void TestColourSchemeFactory_WithEnumGreyScale_ShouldReturnGreyScaleObject()
        {
            ColourSchemeFactory colourSchemeFactory = new ColourSchemeFactory();
            IColourScheme expected = new GreyScale();
            IColourScheme actual = colourSchemeFactory.CreateColourScheme(Enums.ColourScheme.GreyScale);
            Assert.AreEqual(expected.GetType(), actual.GetType());
        }

        [TestMethod]
        public void TestColourSchemeFactory_WithEnumShortRainBow_ShouldReturnShortRainbowObject()
        {
            ColourSchemeFactory colourSchemeFactory = new ColourSchemeFactory();
            IColourScheme expected = new ShortRainbow();
            IColourScheme actual = colourSchemeFactory.CreateColourScheme(Enums.ColourScheme.ShortRainbow);
            Assert.AreEqual(expected.GetType(), actual.GetType());
        }

        [TestMethod]
        public void TestColourSchemeFactory_WithEnumYellowToRed_ShouldReturnYellowToRedObject()
        {
            ColourSchemeFactory colourSchemeFactory = new ColourSchemeFactory();
            IColourScheme expected = new YellowToRed();
            IColourScheme actual = colourSchemeFactory.CreateColourScheme(Enums.ColourScheme.YellowToRed);
            Assert.AreEqual(expected.GetType(), actual.GetType());
        }

        [TestMethod]
        public void TestColourSchemeFactory_WithEnumGreenToBlack_ShouldReturnGreenToBlackObject()
        {
            ColourSchemeFactory colourSchemeFactory = new ColourSchemeFactory();
            IColourScheme expected = new GreenToBlack();
            IColourScheme actual = colourSchemeFactory.CreateColourScheme(Enums.ColourScheme.GreenToBlack);
            Assert.AreEqual(expected.GetType(), actual.GetType());
        }
    }
}
