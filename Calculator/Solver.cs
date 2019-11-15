using System;
using System.Globalization;

namespace Calculator
{
    /// <summary>
    /// Solves the equations enetered by the user
    /// 
    /// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/
    /// </summary>
    public static class Solver
    {
        public static string SolveMath(string operand1, string operand2, char operatorType)
        {
            double solution;
            
            switch (operatorType)
            {
                case '+':
                    solution = double.Parse(operand1) + double.Parse(operand2);
                    break;
                case '-':
                    solution = double.Parse(operand1) - double.Parse(operand2);
                    break;
                case '*':
                    solution = double.Parse(operand1) * double.Parse(operand2);
                    break;
                case '/':
                    solution = double.Parse(operand1) / double.Parse(operand2);
                    break;
                default:
                    throw new ArgumentException("Invalid operand");
            }

            return Math.Round(solution, 5).ToString(CultureInfo.InvariantCulture);
        }
    }
}