using CosmosX.IO.Contracts;
using System;

namespace CosmosX.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }
    }
}