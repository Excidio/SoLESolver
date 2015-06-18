using NUnit.Framework;
using Services;
using Services.SoLEAlgorithms.ImplementationSoLESolverStrategy;

namespace Tests
{
    public class SoLESolverServiceWithGaussianEliminationStrategyTest
    {
        private readonly SoLESolverService _SoleSolverService;

        public SoLESolverServiceWithGaussianEliminationStrategyTest()
        {
            _SoleSolverService = new SoLESolverService(new GaussianEliminationStrategy());
        }

        [Test]
        public void TestSolveWith2Param()
        {
            //Arrange
            double[,] array = {
 				{3, -2, 4},
 				{1,  3, 5}
 		    };
            double[] expResult = { 2, 1 };

            // Act
            var actResult = _SoleSolverService.SolveSoLE(array);

            //  Assert
            Assert.AreEqual(expResult, actResult);
        }

        [Test]
        public void TestSolveWith3Param()
        {
            //Arrange
            double[,] array = {
 				{ 2,  1, -1,  8},
 				{-3, -1,  2, -11},
 				{-2,  1,  2, -3}
 		    };
            double[] expResult = { 2, 3, -1 };

            // Act
            var actResult = _SoleSolverService.SolveSoLE(array);

            //  Assert
            Assert.AreEqual(expResult, actResult);
        }

        [Test]
        public void TestSolveWith4Param()
        {
            //Arrange
            double[,] array = {
 				{ -2,  -1,  8,   1, -17},
 				{  1,  -3, -5,   9,  86},
 				{ -7,  -3,  3,   1, -26},
                {  7,   4,  5, -10, -43},
 		    };
            double[] expResult = { 7, -8, -2, 5 };

            // Act
            var actResult = _SoleSolverService.SolveSoLE(array);

            //  Assert
            Assert.AreEqual(expResult, actResult);
        }

        [Test]
        public void TestSolveWith8Param()
        {
            //Arrange
            double[,] array = {
                    { 1, 1, 1, 1, 1, 1, 1, 1, 36},
                    { 0, 1, 1, 1, 1, 1, 1, 1, 28},
                    { 0, 0, 1, 1, 1, 1, 1, 1, 21},
                    { 0, 0, 0, 1, 1, 1, 1, 1, 15},
                    { 0, 0, 0, 0, 1, 1, 1, 1, 10},
                    { 0, 0, 0, 0, 0, 1, 1, 1, 6},
                    { 0, 0, 0, 0, 0, 0, 1, 1, 3},
                    { 0, 0, 0, 0, 0, 0, 0, 1, 1},
            };

            double[] expResult = { 8, 7, 6, 5, 4, 3, 2, 1 };

            // Act
            var actResult = _SoleSolverService.SolveSoLE(array);

            //  Assert
            Assert.AreEqual(expResult, actResult);  
        }
    }
}