using System.Collections.Generic;

namespace Services.SoLEAlgorithms
{
    public interface ISoLEParserStrategy
    {
        /// <summary>
        /// Преобразование входного массива уравнений
        /// </summary>
        /// <param name="equations">Массив уравнений</param>
        /// <returns>Результат парсинга</returns>
        bool Parse(string[] equations);

        /// <summary>
        /// Получить извлеченные из СЛАУ числа
        /// </summary>
        /// <returns>Массив чисел</returns>
        double[,] GetExtractedSoLENumbers();

        /// <summary>
        /// Получить извлеченные из СЛАУ переменные
        /// </summary>
        /// <returns>Связный список переменных</returns>
        LinkedList<string> GetExtractedSoLEVariables();
    }
}
