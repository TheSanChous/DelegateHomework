using System;
using System.Collections.Generic;
using System.Text;

namespace SampleApp
{
    public class CalculatorUserInterface
    {
        private Func<double, double, double> OperationFunc;

        public enum Operation
        {
            Add = 1,
            Subtract,
            Multiply,
            Divide
        }

        public Operation AskOperation()
        {
            Console.WriteLine("Chose Operation:\n" +
                "1. Add\n" +
                "2. Subtract\n" +
                "3. Multiply\n" +
                "4. Divide");

            var result = (Operation)int.Parse(Console.ReadLine());

            SetOperationFunc(result);

            return result;
        }

        private void SetOperationFunc(Operation operation)
        {
            switch (operation)
            {
                case Operation.Add:
                    OperationFunc = Calculator.Add;
                    break;
                case Operation.Subtract:
                    OperationFunc = Calculator.Subtract;
                    break;
                case Operation.Multiply:
                    OperationFunc = Calculator.Multiply;
                    break;
                case Operation.Divide:
                    OperationFunc = Calculator.Divide;
                    break;
            }
        }

        public void Execute()
        {
            if (OperationFunc == null) throw new ArgumentNullException("Operation Function is null.");

            double a, b;

            Console.WriteLine("Enter a: ");
            a = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter b: ");
            b = double.Parse(Console.ReadLine());

            var result = OperationFunc(a, b);
            Console.WriteLine($"Result: {result}");
        }
    }
}
