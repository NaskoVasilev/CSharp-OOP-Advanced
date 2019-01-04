using CosmosX.Core;
using CosmosX.Core.Contracts;
using CosmosX.IO;
using CosmosX.IO.Contracts;
using CosmosX.Entities.Reactors.ReactorFactory.Contracts;
using CosmosX.Entities.Reactors.ReactorFactory;
using CosmosX.Entities.Modules.ModuleFactory.Contracts;
using CosmosX.Entities.Modules.ModuleFactory;

namespace CosmosX
{
    public class StartUp
    {
        public static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IReactorFactory reactorFactory = new ReactorFactory();
            IModuleFactory moduleFactory = new ModuleFactory();

            IManager reactorManager = new ReactorManager(reactorFactory, moduleFactory);

            ICommandParser commandParser = new CommandParser(reactorManager);
            IEngine engine = new Engine(reader, writer, commandParser);
            engine.Run();
        }
    }
}
