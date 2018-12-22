using System;
using NUnit.Framework;
using StorageMaster.Entities.Storage;
using StorageMaster.Entities.Vehicles;
using StorageMaster.Entities.Products;
using System.Collections.Generic;

namespace StorageMester.BusinessLogic.Tests
{
    [TestFixture]
    public class StorageBusinessLogicTests
    {
        private Storage storage;

        [SetUp]
        public void InitializeStorage()
        {
            storage = new Warehouse("CoumputerParts");
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void GetVihcleShouldRerurnTheVehicle(int index)
        {
            Vehicle vehicle = storage.GetVehicle(index);
            Assert.IsNotNull(vehicle);

            bool isSemi = vehicle is Semi;
            Assert.That(isSemi);
        }

        [Test]
        [TestCase(10)]
        [TestCase(20)]
        public void GetVehicleShouldThrowInvalidOperationExceptionWhenIndexIsGreaterThanGarageSlots(int index)
        {
            Assert.That(() => storage.GetVehicle(index), Throws.InvalidOperationException
                .With.Message.EqualTo("Invalid garage slot!"));
        }

        [Test]
        [TestCase(3)]
        [TestCase(9)]
        public void GetVehicleShouldThrowInvalidOperationExceptionWhenGarageSlotIsNull(int index)
        {
            Assert.That(() => storage.GetVehicle(index), Throws.InvalidOperationException
                .With.Message.EqualTo("No vehicle in this garage slot!"));
        }

        [Test]
        public void SendVehcileToShouldWorkCorectly()
        {
            int index = 0;
            AutomatedWarehouse automatedWarehouse = new AutomatedWarehouse("Automated");
            int result = storage.SendVehicleTo(index, automatedWarehouse);
            Assert.AreEqual(result, 1, "The target place is not correct!");
            Assert.Throws<InvalidOperationException>(() => storage.GetVehicle(index), "Do not delete vehicle from source location!");

            Assert.AreEqual(automatedWarehouse.GetVehicle(result).GetType(), typeof(Semi), "The sent vehicle is not of the same type!");
        }

        [Test]
        public void SendVehicleToShouldThrowInvalidOperationExceptionWhenThereIsNoSpace()
        {
            AutomatedWarehouse automatedWarehouse = new AutomatedWarehouse("Automated");
            int index = 0;
            storage.SendVehicleTo(index, automatedWarehouse);

            Assert.That(() => storage.SendVehicleTo(1, automatedWarehouse), Throws
                .InvalidOperationException
                .With.Message.EqualTo("No room in garage!")
                , "Do not throws exception when source storage is full!");
        }

        [Test]
        public void UnlodVehicleValidation()
        {
            int garageSlot = 0;
            Vehicle vehicle = storage.GetVehicle(garageSlot);
            List<Product> products = new List<Product>() { new HardDrive(100), new HardDrive(200) };
            vehicle.LoadProduct(products[0]);
            vehicle.LoadProduct(products[1]);

            int unloadedProductCount = storage.UnloadVehicle(garageSlot);

            Assert.That(unloadedProductCount, Is.EqualTo(2), "Does not unloed correct amount of products!");

            int index = 0;
            foreach (var item in storage.Products)
            {
                Assert.AreEqual(item.Weight, products[index].Weight, "Does not add products to the storage!");
            }
        }

        [Test]
        public void UnloadVehicleShouldThrowsInvalidOperationExceptionIfStorageIsFull()
        {
            AutomatedWarehouse automatedWarehouse = new AutomatedWarehouse("House");
            int garageSlot = 0;
            Vehicle vehicle = automatedWarehouse.GetVehicle(garageSlot);
            vehicle.LoadProduct(new HardDrive(5000));
            vehicle.LoadProduct(new HardDrive(200));
            automatedWarehouse.UnloadVehicle(garageSlot);

            Assert.That(() => automatedWarehouse.UnloadVehicle(garageSlot),
                Throws.InvalidOperationException
                .With.Message.EqualTo("Storage is full!")
                , "When stotage is full does not throws exception!");
        }
    }
}
