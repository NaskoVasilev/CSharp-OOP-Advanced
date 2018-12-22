namespace Logger.Core
{
    using Contracts;
    using System;

    public class Engine : IEngine
    {
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] args = Console.ReadLine().Split();
                commandInterpreter.AddAppender(args);
            }

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] args = command.Split("|");
                commandInterpreter.ParseCommand(args);
            }

            commandInterpreter.LoggerInfo();
        }
    }
}
