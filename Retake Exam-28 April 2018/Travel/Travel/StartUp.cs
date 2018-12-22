namespace Travel
{
    using Core;
    using Core.Contracts;
    using Core.Controllers;
    using Core.Controllers.Contracts;
    using Core.IO;
    using Core.IO.Contracts;
    using Entities;
    using Entities.Contracts;
    using System;
    using Travel.Entities.Factories;
    using Travel.Entities.Factories.Contracts;

    public static class StartUp
    {
        public static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IItemFactory itemFactory = new ItemFactory();
            IAirplaneFactory airplaneFactory = new AirplaneFactory();

            IAirport airport = new Airport();
            IAirportController airportController = new AirportController(airport, airplaneFactory, itemFactory);
            IFlightController flightController = new FlightController(airport);

            IEngine engine = new Engine(reader, writer, airportController, flightController);

            engine.Run();
        }
    }
}