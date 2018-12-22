
namespace Logger.Appenders.Factory.Contracts
{
    using Appenders.Contracts;

    public interface IAppenderFactory
    {
        IAppender CreateAppender(string[] args);
    }
}
