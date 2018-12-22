using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    public CommandInterpreter(IHarvesterController harvesterController, IProviderController providerController)
    {
        HarvesterController = harvesterController;
        ProviderController = providerController;
    }

    public IHarvesterController HarvesterController { get; private set; }

    public IProviderController ProviderController { get; private set; }

    public string ProcessCommand(IList<string> args)
    {
        string commandName = args[0];
        List<string> commandArgs = args.Skip(1).ToList();

        Type commandType = Assembly.GetCallingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == commandName + "Command");

        List<object> commandParameters = new List<object>() { commandArgs };

        ConstructorInfo constructor = commandType.GetConstructors().FirstOrDefault();
        ParameterInfo[] constructorRequiredParams = constructor.GetParameters();


        foreach (ParameterInfo parameter in constructorRequiredParams)
        {
            if (parameter.ParameterType == typeof(IHarvesterController))
            {
                commandParameters.Add(this.HarvesterController);
            }
            else if (parameter.ParameterType == typeof(IProviderController))
            {
                commandParameters.Add(this.ProviderController);
            }
        }

        ICommand command = (ICommand)constructor.Invoke(commandParameters.ToArray());

        return command.Execute();
    }
}
