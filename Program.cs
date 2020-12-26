using System;
using System.Collections.Generic;

namespace SampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculatorUserInterface Calculator = new CalculatorUserInterface();

            while (true)
            {
                Calculator.AskOperation();
                Calculator.Execute();
            }
        }
    }
}