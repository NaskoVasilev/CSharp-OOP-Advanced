using DelegatesAndEvents.Enums;

namespace DelegatesAndEvents.Loggers
{
    public abstract class Logger : IHandler
    {
        private IHandler successor;

        protected void PassToSuccessor(LogType type, string message)
        {
            if (this.successor != null)
            {
                this.successor.Handle(type, message);
            }
        }

        public abstract void Handle(LogType logType, string message);

        public void SetSuccessor(IHandler handler)
        {
            this.successor = handler;
        }
    }
}
