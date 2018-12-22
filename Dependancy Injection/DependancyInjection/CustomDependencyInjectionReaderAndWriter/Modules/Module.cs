using CustomDependancyInjectionFramework.Modules;
using CustomDependencyInjectionReaderAndWriter.Core.Contracts;
using CustomDependencyInjectionReaderAndWriter.Core.ReadersAndWriters;

namespace CustomDependencyInjectionReaderAndWriter.Modules
{
    public class Module : AbstractModule
    {
        public override void Configure()
        {
            this.CreateMapping<IReader, ConsoleReader>();
            this.CreateMapping<IWriter, ConsoleWriter>();
            this.CreateMapping<IWriter, FileWriter>();
        }
    }
}
