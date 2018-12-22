namespace InfernoInfinty.Contracts
{
    public interface ICommandInterpreter
    {
        IExecutable InterpritCommand(string[] data);
    }
}
