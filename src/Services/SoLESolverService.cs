using Services.SoLEAlgorithms;

namespace Services
{
    public class SoLESolverService
    {
        private ISoLESolverStrategy _SoLESolverStrategy;

        public SoLESolverService()
        {
        }

        public SoLESolverService(ISoLESolverStrategy strategy)
        {
            setSoLESolverStrategy(strategy);
        }

        public void setSoLESolverStrategy(ISoLESolverStrategy strategy)
        {
            _SoLESolverStrategy = strategy;
        }

        public double[] SolveSoLE(double[,] SoLE)
        {
            return _SoLESolverStrategy.Solve(SoLE);
        }
    }
}
