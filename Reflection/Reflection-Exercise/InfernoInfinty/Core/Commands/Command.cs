using InfernoInfinty.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfernoInfinty.Core.Commands
{
    public abstract class Command : IExecutable
    {
        public Command(string[] data)
        {
            Data = data;
        }

        public string[] Data { get; private set; }

        public abstract void Execute();
    }
}
