using InfernoInfinty.Contracts;
using InfernoInfinty.Core;
using InfernoInfinty.Core.Commands;
using InfernoInfinty.Factories;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace InfernoInfinty
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IServiceProvider serviceProvider = ConfigureServices();

            ICommandInterpreter commandInterpreter = new CommandInterpreter(serviceProvider);
            IEngine engine = new Engine(commandInterpreter);
            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddTransient<GemFactory>();
            services.AddTransient<WeaponFactory>();
            services.AddSingleton<IWeaponRepository, WeaponRepository>();

            IServiceProvider provider = services.BuildServiceProvider();

            return provider;
        }
    }
}
