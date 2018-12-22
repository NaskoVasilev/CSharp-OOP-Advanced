using Microsoft.Extensions.DependencyInjection;
using ReaderAndWriter.Core;
using ReaderAndWriter.Core.Contracts;
using System;

namespace ReaderAndWriter
{
    class StartUp
    {
        static void Main(string[] args)
        {
            IServiceProvider serviceProvider = ConfigureServices();

            IEngine engine = serviceProvider.GetService<IEngine>();
            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.AddTransient<IWriter, ConsoleWriter>();
            serviceCollection.AddTransient<IWriter, FileWriter>();
            serviceCollection.AddTransient<IReader, ConsoleReader>();
            serviceCollection.AddTransient<IEngine, Engine>();

            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
