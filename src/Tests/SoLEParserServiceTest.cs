using NUnit.Framework;
using Services;
using Services.SoLEAlgorithms.ImplementationSoLEParserStrategy;
using System.Linq;

namespace Tests
{
    public class SoLEParserServiceTest
    {
        private readonly SoLEParserService _SoleParserService;

        public SoLEParserServiceTest()
	    {
            _SoleParserService = new SoLEParserService(new MyParseStrategy());
        }

        [Test]
        public void TestParseWith2Param()
        {
            //Arrange
            string[] sole = { "3x-2y=4", "x+3y=5" };

            string[] expSoLEVariablesResult = { "x", "y" };
            double[,] expSoLENumbersResult = {
 				{3, -2, 4},
 				{1,  3, 5}
 		    };

            // Act
            _SoleParserService.Parse(sole);

            //  Assert
            Assert.AreEqual(expSoLEVariablesResult, _SoleParserService.GetExtractedSoLEVariables().ToArray());
            Assert.AreEqual(expSoLENumbersResult, _SoleParserService.GetExtractedSoLENumbers());
        }

        [Test]
        public void TestParseWith3Param()
        {
            //Arrange
            string[] sole = { "c+y=6", "c+z=4", "z=1" };

            string[] expSoLEVariablesResult = { "c", "y", "z" };
            double[,] expSoLENumbersResult = {
 				{1, 1, 0, 6},
 				{1, 0, 1, 4},
 				{0, 0, 1, 1}
 		    };

            // Act
            _SoleParserService.Parse(sole);

            //  Assert
            Assert.AreEqual(expSoLEVariablesResult, _SoleParserService.GetExtractedSoLEVariables().ToArray());
            Assert.AreEqual(expSoLENumbersResult, _SoleParserService.GetExtractedSoLENumbers());
        }

        [Test]
        public void TestParseWith4Param()
        {
            //Arrange
            string[] sole = { "x1-x2+3x3+x4=5", "4x1-x2+5x3+4x4=4", "2x1-2x2+4x3+x4=6", "x1-4x2+5x3-x4=3" };

            string[] expSoLEVariablesResult = { "x1", "x2", "x3", "x4" };
            double[,] expSoLENumbersResult = {
 				{1, -1, 3,   1, 5},
 				{4, -1, 5,   4, 4},
 				{2, -2, 4,   1, 6},
                {1, -4, 5,  -1, 3},
 		    };

            // Act
            _SoleParserService.Parse(sole);

            //  Assert
            Assert.AreEqual(expSoLEVariablesResult, _SoleParserService.GetExtractedSoLEVariables().ToArray());
            Assert.AreEqual(expSoLENumbersResult, _SoleParserService.GetExtractedSoLENumbers());
        }

        [Test]
        public void TestParseWith4ParamAndWhiteSpaces()
        {
            //Arrange
            string[] sole = { 
                "   x   1    -   x   2  +  3   x3+x4  =5", 
                "4x1-x2  +5  x3+4x4=4", 
                "2x  1-2x2+4  x3+x  4=  6", 
                "x  1-  4x2  +5x3-x4=3" 
            };

            string[] expSoLEVariablesResult = { "x1", "x2", "x3", "x4" };
            double[,] expSoLENumbersResult = {
 				{1, -1, 3,   1, 5},
 				{4, -1, 5,   4, 4},
 				{2, -2, 4,   1, 6},
                {1, -4, 5,  -1, 3},
 		    };

            // Act
            _SoleParserService.Parse(sole);

            //  Assert
            Assert.AreEqual(expSoLEVariablesResult, _SoleParserService.GetExtractedSoLEVariables().ToArray());
            Assert.AreEqual(expSoLENumbersResult, _SoleParserService.GetExtractedSoLENumbers());
        }
    }
}