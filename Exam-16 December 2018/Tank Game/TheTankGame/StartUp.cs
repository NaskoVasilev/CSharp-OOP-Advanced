namespace TheTankGame
{
    using Core;
    using Core.Contracts;
    using IO;
    using IO.Contracts;
    using TheTankGame.Entities.Parts.Factories;
    using TheTankGame.Entities.Parts.Factories.Contracts;
    using TheTankGame.Entities.Vehicles.Factories;
    using TheTankGame.Entities.Vehicles.Factories.Contracts;

    public class StartUp
    {
        public static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IVehicleFactory vehicleFactory = new VehicleFactory();
            IPartFactory partFactory = new PartFactory();

            IBattleOperator battleOperator = new TankBattleOperator();
            IManager manager = new TankManager(battleOperator, vehicleFactory, partFactory);

            ICommandInterpreter commandInterpreter = new CommandInterpreter(manager);

            IEngine engine = new Engine(
                reader,
                writer,
                commandInterpreter);

            engine.Run();
        }
    }
}
