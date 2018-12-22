using System;
using DIFramework;
using DIFrameworkReaderAndWriter.Core;

namespace DIFrameworkReaderAndWriter
{
    class StartUp
    {
        static void Main(string[] args)
        {
            IServiceCollection serviceCollection = ConfigureServices();

            IEngine engine = serviceCollection.CreateInstance<Engine>();
            engine.Run();
        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.AddService<IReader, ConsoleReader>();
            serviceCollection.AddService<IWriter, ConsoleWriter>();

            return serviceCollection;
        }
    }
}
