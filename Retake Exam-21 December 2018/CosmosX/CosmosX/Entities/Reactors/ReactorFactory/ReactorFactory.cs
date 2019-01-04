using CosmosX.Entities.Containers.Contracts;
using CosmosX.Entities.Reactors.Contracts;
using CosmosX.Entities.Reactors.ReactorFactory.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CosmosX.Entities.Reactors.ReactorFactory
{
    public class ReactorFactory : IReactorFactory
    {
        public IReactor CreateReactor(string type, int id, IContainer moduleContainer, int reactorIndex)
        {
            Type rectorType = Assembly.GetCallingAssembly()
                 .GetTypes()
                 .FirstOrDefault(t => t.Name == type + "Reactor");

            return (IReactor)Activator.CreateInstance(rectorType, id, moduleContainer, reactorIndex);
        }
    }
}
