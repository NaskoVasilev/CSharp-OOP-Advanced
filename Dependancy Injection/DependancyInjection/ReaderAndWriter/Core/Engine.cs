using ReaderAndWriter.Core.Contracts;
using System;

namespace ReaderAndWriter.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        public Engine(IReader reader,IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            while (true)
            {
                string message = reader.Read();
                writer.Write(message);
            }
        }
    }
}
