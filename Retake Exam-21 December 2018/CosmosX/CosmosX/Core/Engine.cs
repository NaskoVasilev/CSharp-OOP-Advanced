using CosmosX.Core.Contracts;
using CosmosX.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CosmosX.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private ICommandParser commandParser;
        private bool isRunning;

        public Engine(IReader reader, IWriter writer, ICommandParser commandParser)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandParser = commandParser;
            this.isRunning = false;
        }

        public void Run()
        {
            this.isRunning = true;

            while (isRunning)
            {
                List<string> arguments = reader.ReadLine().Split().ToList();

                if(arguments[0] == "Exit")
                {
                    isRunning = false;
                }

                string result = commandParser.Parse(arguments);
                writer.WriteLine(result);
            }
        }
    }
}