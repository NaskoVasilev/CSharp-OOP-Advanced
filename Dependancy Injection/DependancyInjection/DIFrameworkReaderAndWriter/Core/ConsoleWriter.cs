﻿using System;

namespace DIFrameworkReaderAndWriter.Core
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string content)
        {
            Console.WriteLine(content);
        }
    }
}
