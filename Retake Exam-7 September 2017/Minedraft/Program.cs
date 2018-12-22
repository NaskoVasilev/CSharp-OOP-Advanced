public class Program
{
    public static void Main(string[] args)
    {
        IHarvesterFactory harvesterFactory = new HarvesterFactory();
        IEnergyRepository energyRepository = new EnergyRepository();

        IHarvesterController harvesterController = new HarvesterController(harvesterFactory, energyRepository);
        IProviderController providerController = new ProviderController(energyRepository);

        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();

        ICommandInterpreter commandInterpreter = new CommandInterpreter(harvesterController, providerController);

        Engine engine = new Engine(reader,writer,commandInterpreter);
        engine.Run();
    }
}