public class LastArmyMain
{
    static void Main()
    {
        IAmmunitionFactory ammunitionFactory = new AmmunitionFactory();
        ISoldierFactory soldierFactory = new SoldierFactory();
        IMissionFactory missionFactory = new MissionFactory();

        IArmy army = new Army();
        IWareHouse wareHouse = new WareHouse();

        MissionController missionController = new MissionController(army, wareHouse);
        GameController gameController = new GameController(army,
            wareHouse,
            ammunitionFactory,
            soldierFactory,
            missionController,
            missionFactory);

        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();

        Engine engine = new Engine(gameController, reader, writer);
        engine.Run();
    }
}
