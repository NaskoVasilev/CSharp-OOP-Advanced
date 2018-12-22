using InfernoInfinty.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfernoInfinty.Core
{
    public class Engine : IEngine
    {
        ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            string command = "";

            while ((command = Console.ReadLine()) != "END")
            {
                string[] data = command.Split(";");
                IExecutable commandInstance = commandInterpreter.InterpritCommand(data);
                commandInstance.Execute();
            }
        }
    }
}
