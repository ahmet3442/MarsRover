using System;
using MarsRoverProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverProjectTest
{
    [TestClass]
    public class TestCases
    {
        string area { get; set; }
        string startingPosition { get; set; }
        string movies { get; set; }

        [TestMethod]
        public void Test_12N_LMLMLMLMM()
        {
            area = "5 5";
            startingPosition = "1 2 N";
            movies = "LMLMLMLMM";

            Position position = new Position(area, startingPosition, movies);
            position.StartMoving();


            var actualOutput = $"{position.X} {position.Y} {position.Direction.ToString()}";
            var expectedOutput = "1 3 N";

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void Test_33E_MMRMMRMRRM()
        {
            area = "5 5";
            startingPosition = "3 3 E";
            movies = "MMRMMRMRRM";


            Position position = new Position(area, startingPosition, movies);
            position.StartMoving();

            var actualOutput = $"{position.X} {position.Y} {position.Direction.ToString()}";
            var expectedOutput = "5 1 E";

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void Test_Ex_OutOfPlateau()
        {
            area = "5 5";
            startingPosition = "3 3 E";
            movies = "MMRMMRMRRMMMMMM";

            Position position = new Position(area, startingPosition, movies);
            var ex = Assert.ThrowsException<Exception>(() => position.StartMoving());
            Assert.AreEqual($"Oops! Position can not be beyond bounderies (0 , 0) and ({position.PlateauAreaList[0]} , {position.PlateauAreaList[1]})", ex.Message);
        }
    }
}
