using System;
using System.Collections.Generic;

namespace SampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculatorUserInterface Calculator = new CalculatorUserInterface();

            Calculator.AskOperation();
            Calculator.Execute();
        }
    }

    public class CalculatorUserInterface
    {
        private Func<double, double, double> fun;

        public enum ChoseOperation
        {
            Add = 1,
            Subtract,
            Multiply,
            Divide
        }

        public ChoseOperation AskOperation()
        {
            Console.WriteLine("Chose Operation:\n" +
                "1. Add\n" +
                "2. Subtract\n" +
                "3. Multiply\n" +
                "4. Divide");
            var result = (ChoseOperation)int.Parse(Console.ReadLine());

            SetOperation(result);

            return result;
        }

        private void SetOperation(ChoseOperation operation)
        {
            switch (operation)
            {
                case ChoseOperation.Add:
                    fun = Calculator.Add;
                    break;
                case ChoseOperation.Subtract:
                    fun = Calculator.Subtract;
                    break;
                case ChoseOperation.Multiply:
                    fun = Calculator.Multiply;
                    break;
                case ChoseOperation.Divide:
                    fun = Calculator.Divide;
                    break;
            }                
        }

        public void Execute()
        {
            if (fun == null) throw new ArgumentNullException("function is null.");

            double a, b;

            Console.WriteLine("Enter a: ");
            a = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter b: ");
            b = double.Parse(Console.ReadLine());

            var result = fun(a, b);
            Console.WriteLine($"Result: {result}");
        }
    }

    public static class Calculator
    {
        public static double Add(double a, double b) => a + b;
        public static double Subtract(double a, double b) => a - b;
        public static double Multiply(double a, double b) => a * b;
        public static double Divide(double a, double b) => a / b;
    }
}