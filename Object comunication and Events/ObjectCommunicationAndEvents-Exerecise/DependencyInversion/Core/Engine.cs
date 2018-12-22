namespace DependencyInversion.Core
{
    using Strategies;
    using Strategies.Contracts;
    using System;

    public class Engine
    {
        private PrimitiveCalculator calculator;

        public Engine(PrimitiveCalculator calculator)
        {
            this.calculator = calculator;
        }

        public void Run()
        {
            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] data = command.Split();

                if (data[0] == "mode")
                {
                    char calculationType = data[1][0];
                    ICalculationStrategy strategy = null;

                    switch (calculationType)
                    {
                        case '-':
                            strategy = new SubtractionStrategy();
                            break;
                        case '+':
                            strategy = new AdditionStrategy();
                            break;
                        case '*':
                            strategy = new MultiplyingStrategy();
                            break;
                        case '/':
                            strategy = new DivisionStrategy();
                            break;
                    }

                    this.calculator.ChangeStrategy(strategy);
                }
                else
                {
                    int firstOperand = int.Parse(data[0]);
                    int secondOperand = int.Parse(data[1]);

                    int result = calculator.PerformCalculation(firstOperand, secondOperand);
                    Console.WriteLine(result);
                }
            }
        }
    }
}
