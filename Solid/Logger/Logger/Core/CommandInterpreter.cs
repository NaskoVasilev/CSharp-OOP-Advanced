namespace Logger.Core
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using Appenders.Contracts;
    using Appenders.Factory.Contracts;
    using Appenders.Factory;
    using Enums;

    class CommandInterpreter : ICommandInterpreter
    {
        private readonly IList<IAppender> appenders;
        private readonly IAppenderFactory appenderFactory;

        public CommandInterpreter()
        {
            this.appenders = new List<IAppender>();
            this.appenderFactory = new AppenderFactory();
        }

        public void AddAppender(string[] args)
        {
            this.appenders.Add(this.appenderFactory.CreateAppender(args));
        }

        public void ParseCommand(string[] args)
        {
            string messageTypeAsString = args[0];
            string dateTime = args[1];
            string message = args[2];
            MessageType messageType = Enum.Parse<MessageType>(messageTypeAsString);

            foreach (var appender in appenders)
            {
                appender.Append(dateTime, messageType, message);
            }
        }

        public void LoggerInfo()
        {
            Console.WriteLine("Logger info");

            foreach (var appender in appenders)
            {
                Console.WriteLine(appender.ToString());
            }
        }
    }
}
