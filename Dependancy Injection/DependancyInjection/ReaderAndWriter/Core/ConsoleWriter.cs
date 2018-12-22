using ReaderAndWriter.Core.Contracts;
using System;

namespace ReaderAndWriter.Core
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
