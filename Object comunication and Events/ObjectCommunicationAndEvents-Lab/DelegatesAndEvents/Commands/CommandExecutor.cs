using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesAndEvents.Commands
{
    public class CommandExecutor : IExecutor
    {
        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
        }
    }
}
