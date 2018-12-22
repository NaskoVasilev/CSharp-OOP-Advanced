namespace Logger.Loggers
{
    using Contracts;
    using Appenders.Contracts;
    using Enums;

    public class Logger : ILogger
    {
        private readonly IAppender consoleAppender;
        private readonly IAppender fileAppender;

        public Logger(IAppender consoleAppender)
        {
            this.consoleAppender = consoleAppender;
        }

        public Logger(IAppender consoleAppender, IAppender fileAppender)
            : this(consoleAppender)
        {
            this.fileAppender = fileAppender;
        }

        public void Critical(string dateTime, string message)
        {
            this.AppenedMessage(dateTime, MessageType.CRITICAL, message);
        }

        public void Error(string dateTime, string message)
        {
            this.AppenedMessage(dateTime, MessageType.ERROR, message);
        }

        public void Fatal(string dateTime, string message)
        {
            this.AppenedMessage(dateTime, MessageType.FATAL, message);
        }

        public void Info(string dateTime, string message)
        {
            this.AppenedMessage(dateTime, MessageType.INFO, message);
        }

        public void Warning(string dateTime, string message)
        {
            this.AppenedMessage(dateTime, MessageType.WARNING, message);
        }

        private void AppenedMessage(string dateTime, MessageType currentMessageType, string message)
        {
            consoleAppender?.Append(dateTime, currentMessageType, message);
            fileAppender?.Append(dateTime, currentMessageType, message);
        }
    }
}
