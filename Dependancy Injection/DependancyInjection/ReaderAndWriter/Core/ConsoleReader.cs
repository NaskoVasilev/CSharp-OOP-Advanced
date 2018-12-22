using ReaderAndWriter.Core.Contracts;
using System;

namespace ReaderAndWriter.Core
{
    public class ConsoleReader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
