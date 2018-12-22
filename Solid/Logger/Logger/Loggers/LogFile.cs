namespace Logger.Loggers
{
    using Contracts;
    using System.Linq;
    using System.Text;

    public class LogFile : ILogFile
    {
        private readonly StringBuilder messages;

        public LogFile()
        {
            this.messages = new StringBuilder();
            this.Size = 0;
        }

        public int Size { get; private set; }

        public void Write(string message)
        {
            messages.AppendLine(message);
            this.Size += message.Where(c => char.IsLetter(c)).Sum(c => (int)c);
        }
    }
}
