using System;

namespace _10_multicast_delegate
{
    class Calculator
    {
        public double Add(double a, double b)
        {
            Console.WriteLine("Add operation...");
            return a + b;
        }
        public double Sub(double a, double b) => a - b;
        public double Mult(double a, double b) => a * b;
        public double Div(double a, double b) => a / b;
    }

    public delegate double ArifmeticOp(double a, double b);

    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();

            ArifmeticOp op = calc.Add;
            Console.WriteLine("Result = " + op(4, 2));

            op += calc.Mult;
            op += calc.Sub;

            Console.WriteLine("Result = " + op(4, 2));

            op -= calc.Sub;
            Console.WriteLine("Result = " + op(4, 2));
        }
    }
}
