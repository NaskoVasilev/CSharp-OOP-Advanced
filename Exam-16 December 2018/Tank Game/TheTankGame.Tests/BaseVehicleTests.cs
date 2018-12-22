namespace TheTankGame.Tests
{
    using NUnit.Framework;
    using System;

    using TheTankGame.Entities.Miscellaneous;
    using TheTankGame.Entities.Miscellaneous.Contracts;
    using TheTankGame.Entities.Parts;
    using TheTankGame.Entities.Vehicles;

    [TestFixture]
    public class BaseVehicleTests
    {
        private const string VehicleModel = "A256";
        private const double Weight = 2500;
        private const decimal Price = 8000M;
        private const int Attack = 2000;
        private const int Defense = 1500;
        private const int HitPoints = 1000;
        IAssembler assembler;

        private Revenger vehicle;

        [SetUp]
        public void SetUp()
        {
            assembler = new VehicleAssembler();
            vehicle = new Revenger(VehicleModel, Weight, Price, Attack, Defense, HitPoints, assembler);
        }

        [Test]
        public void ShouldThrowArgumentExceptionWnenModleIsNullOrWhiteSpace()
        {
            Assert.Throws<ArgumentException>(() => new Revenger(null, Weight, Price, Attack, Defense, HitPoints, assembler));
            Assert.Throws<ArgumentException>(() => new Revenger(" ", Weight, Price, Attack, Defense, HitPoints, assembler));
        }

        [Test]
        public void ShouldThrowArgumentExceptionWnenWeightIsLessThanOrEqualToZero()
        {
            Assert.Throws<ArgumentException>(() => new Revenger(VehicleModel, -20, Price, Attack, Defense, HitPoints, assembler));
            Assert.Throws<ArgumentException>(() => new Revenger(VehicleModel, 0, Price, Attack, Defense, HitPoints, assembler));
        }


        [Test]
        public void ShouldThrowArgumentExceptionWnenPriceIsLessThanOrEqualToZero()
        {
            Assert.Throws<ArgumentException>(() => new Revenger(VehicleModel, Weight, -100, Attack, Defense, HitPoints, assembler));
            Assert.Throws<ArgumentException>(() => new Revenger(VehicleModel, Weight, 0, Attack, Defense, HitPoints, assembler));
        }

        [Test]
        public void ShouldThrowArgumentExceptionWnenAttackIsLessZero()
        {
            Assert.Throws<ArgumentException>(() => new Revenger(VehicleModel, Weight, Price, -125, Defense, HitPoints, assembler));
        }


        [Test]
        public void ShouldThrowArgumentExceptionWnenDefenseIsLessZero()
        {
            Assert.Throws<ArgumentException>(() => new Revenger(VehicleModel, Weight, Price, Attack, -120, HitPoints, assembler));
        }


        [Test]
        public void ShouldThrowArgumentExceptionWnenHitPointsIsLessZero()
        {
            Assert.Throws<ArgumentException>(() => new Revenger(VehicleModel, Weight, Price, Attack, Defense, -250, assembler));
        }

        [Test]
        public void TatalWeightValidation()
        {
            vehicle.AddArsenalPart(new ArsenalPart("ModelA", 150, 500, 100));
            vehicle.AddEndurancePart(new EndurancePart("ModelE", 200, 250, 100));
            vehicle.AddShellPart(new ShellPart("ModelS", 250, 250, 100));

            Assert.AreEqual(3100, vehicle.TotalWeight);
        }

        [Test]
        public void TatalPriceValidation()
        {
            vehicle.AddArsenalPart(new ArsenalPart("ModelA", 150, 500, 100));
            vehicle.AddEndurancePart(new EndurancePart("ModelE", 200, 250, 100));
            vehicle.AddShellPart(new ShellPart("ModelS", 250, 250, 250));

            Assert.AreEqual(9000, vehicle.TotalPrice);
        }

        [Test]
        public void TotalAttackValidation()
        {
            vehicle.AddArsenalPart(new ArsenalPart("ModelA", 150, 500, 100));
            vehicle.AddArsenalPart(new ArsenalPart("ModelE", 200, 250, 150));

            Assert.AreEqual(2250, vehicle.TotalAttack);
        }

        [Test]
        public void TotalDefenseValidation()
        {
            vehicle.AddShellPart(new ShellPart("ModelA", 150, 500, 100));
            vehicle.AddShellPart(new ShellPart("ModelE", 200, 250, 150));

            Assert.AreEqual(1750, vehicle.TotalDefense);
        }

        [Test]
        public void TotalHitPointsValidation()
        {
            vehicle.AddEndurancePart(new EndurancePart("ModelA", 150, 500, 100));
            vehicle.AddEndurancePart(new EndurancePart("ModelE", 200, 250, 150));

            Assert.AreEqual(1250, vehicle.TotalHitPoints);
        }

        [Test]
        public void AddArsenalPartValidation()
        {
            long expectedResult = vehicle.TotalAttack;
            vehicle.AddArsenalPart(new ArsenalPart("Modela", 100, 120, 200));
            long actualResult = vehicle.TotalAttack;

            Assert.AreNotEqual(expectedResult, actualResult);
        }

        [Test]
        public void AddShellPartValidation()
        {
            long expectedResult = vehicle.TotalDefense;
            vehicle.AddShellPart(new ShellPart("Modela", 100, 120, 200));
            long actualResult = vehicle.TotalDefense;

            Assert.AreNotEqual(expectedResult, actualResult);
        }

        [Test]
        public void AddEndurancePartValidation()
        {
            long expectedResult = vehicle.TotalHitPoints;
            vehicle.AddEndurancePart(new EndurancePart("Modela", 100, 120, 200));
            long actualResult = vehicle.TotalHitPoints;

            Assert.AreNotEqual(expectedResult, actualResult);
        }

        [Test]
        public void PartsPropertyShouldReturnAllElements()
        {
            BasePart[] parts = new BasePart[3];

            parts[0] = new ArsenalPart("ModelA", 150, 500, 100);
            parts[1] = new ShellPart("ModelS", 250, 250, 100);
            parts[2] = new EndurancePart("ModelE", 200, 250, 100);

            vehicle.AddArsenalPart(parts[0]);
            vehicle.AddShellPart(parts[1]);
            vehicle.AddEndurancePart(parts[2]);
            int index = 0;

            foreach (var part in vehicle.Parts)
            {
                Assert.AreSame(part, parts[index++]);
            }
        }

        [Test]
        public void ToStringValidationWithParts()
        {
            string actualResult = vehicle.ToString();
            string expectedResult = "Revenger - A256\r\nTotal Weight: 2500.000\r\nTotal Price: 8000.000\r\nAttack: 2000\r\nDefense: 1500\r\nHitPoints: 1000\r\nParts: None";

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ToStringValidationWithoutParts()
        {
            vehicle.AddArsenalPart(new ArsenalPart("Arsenal", 100, 222, 300));
            vehicle.AddShellPart(new ShellPart("Shell", 222, 333, 444));
            vehicle.AddEndurancePart(new EndurancePart("Endurance", 212, 265, 423));

            string actualResult = vehicle.ToString();
            string expectedResult = "Revenger - A256\r\nTotal Weight: 3034.000\r\nTotal Price: 8820.000\r\nAttack: 2300\r\nDefense: 1944\r\nHitPoints: 1423\r\nParts: Arsenal, Shell, Endurance";

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}