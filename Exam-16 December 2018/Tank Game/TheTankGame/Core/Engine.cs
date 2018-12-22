namespace TheTankGame.Core
{
    using System;

    using Contracts;
    using IO.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Engine : IEngine
    {
        private bool isRunning;
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandInterpreter commandInterpreter;
        private StringBuilder sb;

        public Engine(
            IReader reader, 
            IWriter writer, 
            ICommandInterpreter commandInterpreter)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandInterpreter = commandInterpreter;

            this.isRunning = false;
            sb = new StringBuilder();
        }

        public void Run()
        {
            this.isRunning = true;

            while(isRunning)
            {
                List<string> arguments = reader.ReadLine().Split().ToList();

                if(arguments[0] == "Terminate")
                {
                    isRunning = false;
                }

                string result = commandInterpreter.ProcessInput(arguments);
                sb.AppendLine(result);
            }

            writer.WriteLine(sb.ToString().TrimEnd());
        }
    }
}