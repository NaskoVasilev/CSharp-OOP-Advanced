namespace TheTankGame.Core
{
    using System.Collections.Generic;
    using System.Reflection;
    using System.Linq;
    using System;

    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly IManager tankManager;

        public CommandInterpreter(IManager tankManager)
        {
            this.tankManager = tankManager;
        }

        public string ProcessInput(IList<string> inputParameters)
        {
            string commandName = inputParameters[0];
            inputParameters.RemoveAt(0);

            var method = this.tankManager
                .GetType()
                .GetMethods()
                .FirstOrDefault(m => m.Name.Contains(commandName));

            string result = (string)method.Invoke(this.tankManager, new object[] { inputParameters });

            return result;
        }
    }
}