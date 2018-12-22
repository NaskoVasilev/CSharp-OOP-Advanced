using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesAndEvents.Commands
{
    public interface IExecutor
    {
        void ExecuteCommand(ICommand command);
    }
}
