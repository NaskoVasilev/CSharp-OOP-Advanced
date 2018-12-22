using System;

namespace DIFrameworkReaderAndWriter.Core
{
    public class Engine : IEngine
    {
        private IReader consoleReader;
        private IWriter consoleWriter;

        public Engine(IReader consoleReader, IWriter consoleWriter)
        {
            this.consoleReader = consoleReader;
            this.consoleWriter = consoleWriter;
        }

        public void Run()
        {
            string message = consoleReader.Read();

            while (message!="exit")
            {
                consoleWriter.Write(message);

                message = consoleReader.Read();
            }
        }
    }
}
