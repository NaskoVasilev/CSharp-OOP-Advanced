namespace Logger.Appenders.Contracts
{
    using Logger.Enums;

    public interface IAppender
    {
        void Append(string dateTime, MessageType messageType, string message);

        MessageType MessageType { get; set; }

        int MessagesCount { get; }
    }
}
