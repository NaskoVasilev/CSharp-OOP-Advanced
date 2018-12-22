namespace DependencyInversion.Strategies
{
    using Strategies.Contracts;
    using System;

    public class DivisionStrategy : ICalculationStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            if(secondOperand == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero!");
            }

            return firstOperand / secondOperand;
        }
    }
}
