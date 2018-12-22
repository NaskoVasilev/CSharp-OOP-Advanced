﻿namespace DependencyInversion.Strategies
{
    using Strategies.Contracts;

    public class MultiplyingStrategy : ICalculationStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand * secondOperand;
        }
    }
}
