namespace Logger.Appenders
{
    using Contracts;
    using Layouts.Contracts;
    using Logger.Enums;
    using System;

    public class ConsoleAppender : IAppender
    {
        private readonly ILayout consoleLayout;

        public ConsoleAppender(ILayout layout)
        {
            this.consoleLayout = layout;
            this.MessageType = MessageType.INFO;
        }

        public int MessagesCount { get; private set; }

        public MessageType MessageType { get; set; }

        public void Append(string dateTime, MessageType messageType, string message)
        {
            if (messageType >= this.MessageType)
            {
                string output = string.Format(consoleLayout.Format, dateTime, messageType, message);
                Console.WriteLine(output);
                this.MessagesCount++;
            }
        }

        public override string ToString()
        {
            return $"Appender type: ConsoleAppender, Layout type: {this.consoleLayout.GetType().Name}, " +
                $"Report level: {this.MessageType}, Messages appended: {this.MessagesCount}";
        }
    }
}
