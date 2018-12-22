using CustomDependencyInjectionReaderAndWriter.Core.Contracts;
using System;

namespace CustomDependencyInjectionReaderAndWriter.Core.ReadersAndWriters
{
    public class ConsoleReader : IReader
    {
        public string Read()
        {
            string input = Console.ReadLine();
            return input;
        }
    }
}
