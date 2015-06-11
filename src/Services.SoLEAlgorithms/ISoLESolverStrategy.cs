namespace Services.SoLEAlgorithms
{
    public interface ISoLESolverStrategy
    {
        /// <summary>
        /// Метод вычисляющий решение, для указанной системы уравнений
        /// </summary>
        /// <param name="SoLE">Система линейных уравнений</param>
        /// <returns>Результат</returns>
        double[] Solve(double[,] SoLE);
    }
}
