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
            for (int i = 0; i < equations.Length; i++)
            {
                equations[i] = equations[i].Replace(" ", string.Empty).ToLower();
            }

            return _SoLEParserStrategy.Parse(equations);
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
