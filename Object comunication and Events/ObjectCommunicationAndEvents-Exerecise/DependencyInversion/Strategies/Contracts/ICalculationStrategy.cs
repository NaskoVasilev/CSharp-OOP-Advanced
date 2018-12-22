namespace DependencyInversion.Strategies.Contracts
{
    public interface ICalculationStrategy
    {
        int Calculate(int firstOperand, int secondOperand);
    }
}
