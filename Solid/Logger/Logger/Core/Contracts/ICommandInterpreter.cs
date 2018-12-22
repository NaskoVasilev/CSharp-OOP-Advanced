namespace Logger.Core.Contracts
{
    public interface ICommandInterpreter
    {
        void AddAppender(string[] args);

        void ParseCommand(string[] args);

        void LoggerInfo();
    }
}
