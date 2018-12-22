using _03BarracksFactory.Contracts;
using _03BarracksFactory.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _03BarracksFactory.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            string commandClassName = char.ToUpper(commandName[0]) + commandName.Substring(1) + "Command";
            Type type = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(x => x.Name == commandClassName);

            FieldInfo[] fieldsToInject = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f => f.GetCustomAttribute<InjectAttribute>() != null)
                .ToArray();

            object[] fieldsArgs = fieldsToInject
                .Select(f => this.serviceProvider.GetService(f.FieldType))
                .ToArray();

            object[] constructorArgs = new object[] { data }
            .Concat(fieldsArgs)
            .ToArray();

            IExecutable instance = (IExecutable)Activator.CreateInstance(type, constructorArgs);

            return instance;
        }
    }
}
