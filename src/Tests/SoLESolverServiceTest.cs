using NUnit.Framework;
using Services;
using Services.SoLEAlgorithms.Implementation;

namespace Tests
{
    public class SoLESolverServiceTest
    {
        [Test]
        public void TestSolverWith2Param()
        {
            //Arrange
            //Основная задача
            var _SoleSolverService = new SoLESolverService(new GaussianEliminationStrategy());

            double[,] array = {
 				{3, -2, 4},
 				{1,  3, 5}
 		    };
            double[] expResult = { 2, 1 };

            // Act
            var actResult = _SoleSolverService.SolveSoLE(array);

            //  Assert
            //Проверка статуса основной задачи
            Assert.AreEqual(expResult, actResult);
        }

        [Test]
        public void TestSolverWith3Param()
        {
            //Arrange
            //Основная задача
            var _SoleSolverService = new SoLESolverService(new GaussianEliminationStrategy());

            double[,] array = {
 				{ 2,  1, -1,  8},
 				{-3, -1,  2, -11},
 				{-2,  1,  2, -3}
 		    };
            double[] expResult = { 2, 3, -1 };

            // Act
            var actResult = _SoleSolverService.SolveSoLE(array);

            //  Assert
            //Проверка статуса основной задачи
            Assert.AreEqual(expResult, actResult);
        }

        [Test]
        public void TestSolverWith4Param()
        {
            //Arrange
            //Основная задача
            var _SoleSolverService = new SoLESolverService(new GaussianEliminationStrategy());

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
            //Проверка статуса основной задачи
            Assert.AreEqual(expResult, actResult);
        }
    }
}