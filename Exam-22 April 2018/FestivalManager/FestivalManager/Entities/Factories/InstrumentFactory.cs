namespace FestivalManager.Entities.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;
    using Entities.Contracts;

    public class InstrumentFactory : IInstrumentFactory
    {
        public IInstrument CreateInstrument(string type)
        {
            Type instrumentType = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == type);

            IInstrument instrument = (IInstrument)Activator.CreateInstance(instrumentType);
            return instrument;
        }
    }
}