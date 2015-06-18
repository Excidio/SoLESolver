using Services.SoLEAlgorithms;
using System.Collections.Generic;

namespace Services
{
    public class SoLEParserService
    {
        private readonly ISoLEParserStrategy _SoLEParserStrategy;

        public SoLEParserService(ISoLEParserStrategy soLEParserStrategy)
        {
            _SoLEParserStrategy = soLEParserStrategy;
        }

        public bool Parse(string[] equations)
        {
            var result = _SoLEParserStrategy.Parse(equations);

            return result;
        }

        public double[,] GetExtractedSoLENumbers()
        {
            return _SoLEParserStrategy.GetExtractedSoLENumbers();
        }

        public LinkedList<string> GetExtractedSoLEVariables()
        {
            return _SoLEParserStrategy.GetExtractedSoLEVariables();
        }
        
    }
}
