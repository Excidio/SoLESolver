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
    }
}