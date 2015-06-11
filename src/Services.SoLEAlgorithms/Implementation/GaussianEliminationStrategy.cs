namespace Services.SoLEAlgorithms.Implementation
{
    public class GaussianEliminationStrategy : ISoLESolverStrategy
    {
        public double[] Solve(double[,] SoLE)
        {
            int i, j, k;
            double[] result = new double[SoLE.GetLength(0)];
            var width = SoLE.GetLength(0);
            
            //прямой ход 
            for (i = 0; i < width; i++)
            {
                double a = SoLE[i, i];
                for (j = i + 1; j < width; j++)
                {
                    double b = SoLE[j, i];
                    for (k = i; k < width + 1; k++)
                        SoLE[j, k] = SoLE[i, k] * b - SoLE[j, k] * a;
                }
            }

            //обратный ход 
            for (i = width - 1; i >= 0; i--)
            {
                double summ = 0.0;
                for (j = i + 1; j < width; j++)
                    summ += SoLE[i, j] * result[j];

                summ = SoLE[i, width] - summ;
                if (SoLE[i, i] == 0)
                    return null;
                result[i] = summ / SoLE[i, i];
            }

            return result;
        }
    }
}
