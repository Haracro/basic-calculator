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

        public static double Add(double x, double y) => x + y;
        public static double Subtract(double x, double y) => x - y;
        public static double Multiply(double x, double y) => x * y;
        public static double Divide(double x, double y) => x / y;

        public static double Negate(double number) => -number;

        public static double ToDecimal(double number) => number / 100;
  
    }
}
