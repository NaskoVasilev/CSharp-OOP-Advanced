using CosmosX.Entities.Modules.Contracts;
using CosmosX.Entities.Modules.ModuleFactory.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CosmosX.Entities.Modules.ModuleFactory
{
    public class ModuleFactory : IModuleFactory
    {
        public IModule CreateModule(string type,int id, int additionalParameter)
        {
            Type moduleType = Assembly.GetCallingAssembly()
                 .GetTypes()
                 .FirstOrDefault(t => t.Name == type);

            return (IModule)Activator.CreateInstance(moduleType, id, additionalParameter);
        }
    }
}
