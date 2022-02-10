using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic_calculator
{
    internal class Calculation
    {
        public Calculation() { }

        private static double Add(double x, double y) => x + y;
        private static double Subtract(double x, double y) => x - y;
        private static double Multiply(double x, double y) => x * y;
        private static double Divide(double x, double y) => x / y;

        public static double Negate(double number) => -number;

        public static double ToDecimal(double number) => number / 100;

        public static double Calculate(double x, double y, Operations op)
        {
            double result = 0;

            switch (op.GetOperation)
            {
                case Operations.OperationsType.Add:
                    result = Add(x, y);
                    break;
                case Operations.OperationsType.Subtract:
                    result = Subtract(x, y);
                    break;
                case Operations.OperationsType.Multiply:
                    result = Multiply(x, y);
                    break;
                case Operations.OperationsType.Divide:
                    result = Divide(x, y);
                    break;
                default:
                    result = 0;
                    break;
            }
            return result;
        }
  
    }
}
