using Logger.Appenders.Factory.Contracts;
using Logger.Appenders.Contracts;
using Logger.Layouts.Factory.Contracts;
using Logger.Layouts.Factory;
using Logger.Layouts.Contracts;
using Logger.Loggers;
using System;
using Logger.Enums;

namespace Logger.Appenders.Factory
{
    public class AppenderFactory : IAppenderFactory
    {
        private readonly ILayoutFactory layoutFactory;

        public AppenderFactory()
        {
            this.layoutFactory = new LayoutFactory();
        }

        public IAppender CreateAppender(string[] args)
        {
            IAppender appender;
            string type = args[0];
            string layoutType = args[1];

            ILayout layout = this.layoutFactory.CreateLayout(layoutType);

            switch (type)
            {
                case "ConsoleAppender":
                    appender = new ConsoleAppender(layout);
                    break;
                case "FileAppender":
                    appender = new FileAppender(layout, new LogFile());
                    break;
                default:
                    throw new ArgumentException("Invalid appender type");
            }

            if (args.Length > 2)
            {
                string messageTypeAsString = args[2];
                MessageType messageType = Enum.Parse<MessageType>(messageTypeAsString);
                appender.MessageType = messageType;
            }

            return appender;
        }
    }
}
