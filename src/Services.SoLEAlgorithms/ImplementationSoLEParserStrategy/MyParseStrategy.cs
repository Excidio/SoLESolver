using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Services.SoLEAlgorithms.ImplementationSoLEParserStrategy
{
    public class MyParseStrategy : ISoLEParserStrategy
    {
        private LinkedList<string> Variables;
        private double[,] SoLE;

        public MyParseStrategy()
        {
            Variables = new LinkedList<string>();
            SoLE = null;
        }

        public LinkedList<string> GetExtractedSoLEVariables()
        {
            return Variables;
        }

        public double[,] GetExtractedSoLENumbers()
        {
            return SoLE;
        }

        public bool Parse(string[] equations)
        {
            Variables = InitVariables(equations);
            if (Variables.Count == equations.Count())
            {
                InitSoLE(equations);
                return SoLE.Length > 0;
            }

            return false;
        }

        private LinkedList<string> InitVariables(string[] equations)
        {
            var variables = new LinkedList<string>();

            foreach (var equation in equations)
            {
                var equationMatches = Regex.Matches(equation, @"[A-Za-zА-Яа-я]{1}[A-Za-zА-Яа-я0-9]*(\+|\-|=){1}");
                
                foreach (var equationMatch in equationMatches)
                {
                    var variable = equationMatch.ToString();
                    variable = variable.Substring(0, variable.Length - 1);

                    if (!variables.Any(v => v == variable))
                    {
                        variables.AddLast(variable);
                    }
                }
            }

            return variables;
        }

        private void InitSoLE(string[] equations)
        {
            int width = equations.Count();
            int height = width + 1;

            SoLE = new double[width, height];

            for (int i = 0; i < equations.Length; i++)
            {
                int j = 0;
                //проход по всем переменным
                foreach (var variable in Variables)
                {
                    var variableMatch = Regex.Match(equations[i], string.Format(@"(\+|-|=?)\d*(\.|,)*\d*({0})", variable)).ToString();

                    if (!string.IsNullOrEmpty(variableMatch))
                    {
                        var stringNumber = variableMatch.Substring(0, variableMatch.Length - variable.Length).Replace(".", ",");
                        double number;

                        if (double.TryParse(stringNumber, out number))
                        {
                            SoLE[i, j] = number;
                        }
                        else
                        {
                            SoLE[i, j] = double.Parse(stringNumber + "1");
                        }
                    }

                    j++;
                }

                //добавление результата в конец
                var lastValue = Regex.Match(equations[i], @"=(\+|-*)\d*").ToString();
                if (!string.IsNullOrEmpty(lastValue))
                {
                    lastValue = lastValue.Substring(1, lastValue.Length - 1);
                    SoLE[i, j] = double.Parse(lastValue);
                }
            }
        }
    }
}
