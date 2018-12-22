// REMOVE any "using" statements, which start with "Travel." BEFORE SUBMITTING

namespace Travel.Tests
{
    using NUnit.Framework;
    using System.Collections.Generic;

    using Travel.Core.Controllers;
    using Travel.Entities;
    using Travel.Entities.Airplanes;
    using Travel.Entities.Items;
    using Travel.Entities.Items.Contracts;

    [TestFixture]
    public class FlightControllerTests
    {
        private FlightController flightController;
        private Airport airport;
        private Trip trip;
        private Airplane airplane;

        [SetUp]
        public void SetUp()
        {
            airport = new Airport();
            flightController = new FlightController(airport);
            this.airplane = new LightAirplane();
            this.trip = new Trip("Sofia", "Plovdiv", airplane);
            airport.AddTrip(trip);
        }

        [Test]
        public void TakeOffMethodShouldCompleteTrip()
        {
            airplane.AddPassenger(new Passenger("Nasko"));
            string result = flightController.TakeOff();

            Assert.That(trip.IsCompleted);
        }

        [Test]
        public void IfTripIsCompletedNothingShouldHappen()
        {
            trip.Complete();
            string result = flightController.TakeOff();
            string expectedResult = "Confiscated bags: 0 (0 items) => $0";

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void ShouldNotTryToCompleteCompletedTrip()
        {
            trip.Complete();
            airplane.AddPassenger(new Passenger("Name"));

            airport.AddTrip(new Trip("Sofia", "Plovdiv", airplane));
            string result = flightController.TakeOff();
            string expectedResult = "SofiaPlovdiv3:\r\nSuccessfully transported 1 passengers from Sofia to Plovdiv.\r\nConfiscated bags: 0 (0 items) => $0";

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void TestIfAirplaneIsOverbooked()
        {
            Passenger[] passengers = new Passenger[8];
            for (int i = 0; i < passengers.Length; i++)
            {
                passengers[i] = new Passenger("Atanas" + i);
                airplane.AddPassenger(passengers[i]);
            }

            string result = flightController.TakeOff();
            string expectedResult = "SofiaPlovdiv5:\r\nOverbooked! Ejected Atanas1, Atanas0, Atanas3\r\nConfiscated 0 bags " +
                "($0)\r\nSuccessfully transported 5 passengers from Sofia to Plovdiv.\r\nConfiscated bags: 0 (0 items) => $0";

            Assert.That(expectedResult, Is.EqualTo(result));
        }

        [Test]
        public void TestLoadCarryOnBaggage()
        {
            Passenger[] passengers = new Passenger[10];

            for (int i = 0; i < passengers.Length; i++)
            {
                passengers[i] = new Passenger("Nasko" + i);
                airplane.AddPassenger(passengers[i]);
            }

            Bag[] bags = new Bag[5];

            for (int i = 0; i < 5; i++)
            {
                if (i % 2 == 0)
                {
                    bags[i] = new Bag(passengers[i], new List<IItem>() { new Colombian() });
                    passengers[i].Bags.Add(bags[i]);
                }
                else
                {
                    bags[i] = new Bag(passengers[i], new List<IItem>() { new Toothbrush() });
                    passengers[i].Bags.Add(bags[i]);
                }
            }

            string result = flightController.TakeOff();
            string expectedResult = "SofiaPlovdiv6:\r\nOverbooked! Ejected Nasko1, Nasko0, Nasko3, Nasko7, Nasko8\r\n" +
                "Confiscated 3 bags ($50006)\r\nSuccessfully transported 5 passengers from Sofia to Plovdiv." +
                "\r\nConfiscated bags: 3 (3 items) => $50006";

            Assert.AreEqual(expectedResult, result);
        }
    }
}
