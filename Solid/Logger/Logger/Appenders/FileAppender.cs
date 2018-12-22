namespace Logger.Appenders
{
    using Contracts;
    using Layouts.Contracts;
    using Logger.Enums;
    using Loggers.Contracts;
    using System.IO;

    public class FileAppender : IAppender
    {
        private readonly ILayout fileLayout;
        private readonly ILogFile file;
        private const string filePath = "log.txt";

        public FileAppender(ILayout layout, ILogFile file)
        {
            this.fileLayout = layout;
            this.file = file;
            this.MessageType = MessageType.INFO;
        }

        public MessageType MessageType { get; set; }

        public int MessagesCount { get; private set; }

        public void Append(string dateTime, MessageType messageType, string message)
        {
            if (messageType >= this.MessageType)
            {
                string output = string.Format(this.fileLayout.Format, dateTime, messageType, message) + "\n";
                File.AppendAllText(filePath, output);
                file.Write(output);
                this.MessagesCount++;
            }
        }

        public override string ToString()
        {
            return $"Appender type: FileAppender, Layout type: {this.fileLayout.GetType().Name}, " +
                $"Report level: {this.MessageType}, Messages appended: {MessagesCount}, File size: {this.file.Size}";
        }
    }
}
