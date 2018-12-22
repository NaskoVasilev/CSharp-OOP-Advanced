using NUnit.Framework;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Vehicles;
using System;

namespace StorageMester.BusinessLogic.Tests
{
    [TestFixture]
    public class VehicleBusinessLogicTests
    {
        private Vehicle vehicle;

        [SetUp]
        public void InitializeVehicle()
        {
            vehicle = new Truck();
        }

        [Test]
        public void LoadProductShouldAddTheProductToTheTrunk()
        {
            Product ram = new Ram(500);
            Product hardDrive = new HardDrive(200);
            vehicle.LoadProduct(ram);
            vehicle.LoadProduct(hardDrive);

            Assert.That(vehicle.Trunk, Is.EquivalentTo(new Product[] { ram, hardDrive }));
        }

        [Test]
        public void LoadProductShouldThrowsInvalidOperationExceptionWhenTrunkIsFull()
        {
            for (int i = 0; i < vehicle.Capacity; i++)
            {
                Product hardDrive = new HardDrive(12);
                vehicle.LoadProduct(hardDrive);
            }

            Assert.Throws<InvalidOperationException>(() => vehicle.LoadProduct(new HardDrive(100)));
        }

        [Test]
        public void UnloadShouldRemoveProductFromTrunk()
        {
            Product ram = new Ram(500);
            Product hardDrive = new HardDrive(200);
            vehicle.LoadProduct(ram);
            vehicle.LoadProduct(hardDrive);
            Product product = vehicle.Unload();

            Assert.That(vehicle.Trunk, Is.EquivalentTo(new Product[] { ram }));
        }

        [Test]
        public void UnloadShouldRemoveAndReturnProductFromTrunk()
        {
            Product ram = new Ram(500);
            vehicle.LoadProduct(ram);
            Product product = vehicle.Unload();

            Assert.AreSame(ram, product);
        }

        [Test]
        public void UnloadShouldThrowsInvalidOperationExceptionWhenTrunkIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => vehicle.Unload());
        }
    }
}
