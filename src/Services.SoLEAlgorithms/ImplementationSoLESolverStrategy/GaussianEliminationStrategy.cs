namespace Services.SoLEAlgorithms.ImplementationSoLESolverStrategy
{
    public class GaussianEliminationStrategy : ISoLESolverStrategy
    {
        public double[] Solve(double[,] SoLE)
        {
            double[] result = new double[SoLE.GetLength(0)];
            var width = SoLE.GetLength(0);
            
            //прямой ход 
            if (width != 1)
            {
                for (int i = 0; i < width; i++)//обход по всем строкам
                {
                    if (SoLE[i, i] != 1)
                    {
                        var row = getBestRow(SoLE, i);
                        if (row == -1)
                            return null;
                        if (i != row)
                            exchangeRow(SoLE, i, row);
                    }
                   
                    for (int j = i + 1; j < width; j++)
                    {
                        var b = SoLE[j, i];
                        if (b != 0)
                        {
                            for (int k = i; k < width + 1; k++)
                                SoLE[j, k] = SoLE[j, k] * SoLE[i, i] - SoLE[i, k] * b;
                        }
                    }
                }
            }

            //обратный ход 
            for (int i = width - 1; i >= 0; i--)
            {
                double summ = 0.0;
                for (int j = i + 1; j < width; j++)
                    summ += SoLE[i, j] * result[j];

                summ = SoLE[i, width] - summ;
                if (SoLE[i, i] == 0)
                    return null;
                result[i] = summ / SoLE[i, i];
            }

            return result;
        }

        /// <summary>
        /// Изменение положений строк в системе уравнений
        /// </summary>
        /// <param name="SoLE">Система уравнений</param>
        /// <param name="from">Идентификатор строки откуда меняем</param>
        /// <param name="to">Идентификатор строки на какую меняем</param>
        private void exchangeRow(double[,] SoLE, int from, int to)
        {
            for (int i = 0; i < SoLE.GetLength(1); i++)
            {
                double temp = SoLE[from, i];
                SoLE[from, i] = SoLE[to, i];
                SoLE[to, i] = temp;
            }
        }

        /// <summary>
        /// Получение лучшей строки для вычислений
        /// </summary>
        /// <param name="SoLE">Система уравнений</param>
        /// <param name="begin">Идентификатор текущей строки</param>
        /// <returns>Возвращает идентификатор лучшей строки, -1 в случае, если нет строк или не найдено не нулевое значение</returns>
        private int getBestRow(double[,] SoLE, int begin)
        {
            var result = SoLE[begin, begin] == 0 ? - 1 : begin;

            for (int i = begin + 1; i < SoLE.GetLength(0); i++)
            {
                if (SoLE[i, begin] == 1)
                {
                    return i;
                }

                else if (result == -1 && SoLE[i, begin] != 0)
                {
                    result = i;
                }
            }

            return result;
        }
    }
}
