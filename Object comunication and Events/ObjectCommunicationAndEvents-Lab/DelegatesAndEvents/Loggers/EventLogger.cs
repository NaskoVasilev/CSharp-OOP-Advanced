using System;
using DelegatesAndEvents.Enums;

namespace DelegatesAndEvents.Loggers
{
    public class EventLogger : Logger
    {
        public override void Handle(LogType logType, string message)
        {
            switch(logType)
            {
                case LogType.EVENT:
                    Console.WriteLine(logType.ToString() + ": " + message);
                    break;
            }

            this.PassToSuccessor(logType, message);
        }
    }
}
