﻿using CustomDependencyInjectionReaderAndWriter.Core.Contracts;
using System;

namespace CustomDependencyInjectionReaderAndWriter.Core.ReadersAndWriters
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string content)
        {
            Console.WriteLine(content);
        }
    }
}
