namespace _03BarracksFactory.Core.Factories
{
    using System;
    using Contracts;
    using System.Reflection;
    using System.Linq;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Type type = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(x => x.Name == unitType);
            IUnit instance = (IUnit)Activator.CreateInstance(type);

            return instance;
        }
    }
}
