using InfernoInfinty.Contracts;
using InfernoInfinty.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace InfernoInfinty.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IExecutable InterpritCommand(string[] data)
        {
            string commandName = data[0] + "Command";
            Type type = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(x => x.Name == commandName);

            FieldInfo[] fieldsToInject = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f => f.GetCustomAttribute<InjectAttribute>() != null)
                .ToArray();

            object[] fieldsArgs = fieldsToInject
                .Select(f => this.serviceProvider.GetService(f.FieldType))
                .ToArray();

            object[] constructorArgs = new object[] { data }
                .Concat(fieldsArgs)
                .ToArray();

            IExecutable command = Activator.CreateInstance(type, constructorArgs) as IExecutable;
            return command;
        }
    }
}
