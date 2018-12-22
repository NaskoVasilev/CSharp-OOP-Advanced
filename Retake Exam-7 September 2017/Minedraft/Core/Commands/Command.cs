using System.Collections.Generic;

public abstract class Command : ICommand
{
    public Command(IList<string> arguments)
    {
        Arguments = arguments;
    }

    public IList<string> Arguments { get; private set; }

    public abstract string Execute();
}

