using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    IReader reader;
    IWriter writer;
    ICommandInterpreter commandInterpreter;

    public Engine(IReader reader, IWriter writer, ICommandInterpreter commandInterpreter)
    {
        this.reader = reader;
        this.writer = writer;
        this.commandInterpreter = commandInterpreter;
    }

    public void Run()
    {
        while (true)
        {
            List<string> args = reader.ReadLine().Split().ToList();

            string result = commandInterpreter.ProcessCommand(args);
            writer.WriteLine(result);

            if (args[0] == "Shutdown")
            {
                break;
            }
        }
    }
}
