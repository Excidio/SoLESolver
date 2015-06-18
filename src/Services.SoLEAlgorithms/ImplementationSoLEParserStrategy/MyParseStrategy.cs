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
                var equationsMatches = Regex.Matches(equation.Trim(), @"\D+\d*(\+|-|=)");
                foreach (var pm in equationsMatches)
                {
                    var variable = pm.ToString();
                    variable = variable.Substring(0, pm.ToString().Length - 1);

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

            int i = 0;
            foreach (var equation in equations)
            {
                int j = 0;
                //проход по всем переменным
                foreach (var sv in Variables)
                {
                    var a = Regex.Match(equation, string.Format(@"(\+|-|=?)(\d*)({0})", sv)).ToString();

                    if (!string.IsNullOrEmpty(a))
                    {
                        var stringNumber = a.Substring(0, a.Length - sv.Length);
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
                var lastValue = Regex.Match(equation, @"(=(\+|-*)\d*\d)").ToString();
                if (!string.IsNullOrEmpty(lastValue))
                {
                    lastValue = lastValue.Substring(1, lastValue.Length - 1);
                    SoLE[i, j] = double.Parse(lastValue);
                }
                i++;
                j = 0;
            }
        }
    }
}
