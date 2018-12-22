using System;

namespace DIFrameworkReaderAndWriter.Core
{
    public class ConsoleReader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
