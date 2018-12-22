using CustomDependancyInjectionFramework.Contracts;
using CustomDependancyInjectionFramework.Injectors;
using CustomDependencyInjectionReaderAndWriter.Core;
using CustomDependencyInjectionReaderAndWriter.Core.Contracts;
using CustomDependencyInjectionReaderAndWriter.Modules;

namespace CustomDependencyInjectionReaderAndWriter
{
    class StartUp
    {
        static void Main(string[] args)
        {
            IModule module = new Module();
            Injector injector = DependancyInjector.CreateInjector(module);

            IEngine engine = injector.Inject<Engine>();
            engine.Run();
        }
    }
}
