using NUnit.Framework;
using StorageMaster;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Storage;
using StorageMaster.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace StorageMester.BusinessLogic.Tests
{
    [TestFixture]
    public class StorageMasterTests
    {
        private StorageMaster.Core.StorageMaster storageMaster;
        private const string storageName = "Shop";
        private const string storageType = "Warehouse";
        private const double productPrice = 100;
        private const string productType = "HardDrive";

        [SetUp]
        public void SetUp()
        {
            storageMaster = new StorageMaster.Core.StorageMaster();
        }

        [Test]
        public void AddProductValidation()
        {
            string type = "HardDrive";
            double price = 100;
            string result = storageMaster.AddProduct(type, price);
            Assert.AreEqual(result, $"Added {type} to pool", "Method does not return correct message!");

            Type storageMasterType = GetType("StorageMaster");
            Dictionary<string, Stack<Product>> products = (Dictionary<string, Stack<Product>>)storageMasterType
                .GetField("productsPool", (BindingFlags)62)
                .GetValue(storageMaster);

            Assert.AreEqual(products["HardDrive"].Peek().Price, price);
            Assert.AreEqual(products["HardDrive"].Peek().GetType(), typeof(HardDrive));
        }

        [Test]
        public void RegisterStorageValidation()
        {
            string storageName = "Storage";
            string storageType = "Warehouse";
            string result = storageMaster.RegisterStorage(storageType, storageName);

            Assert.AreEqual(result, $"Registered {storageName}");

            Dictionary<string, Storage> storages = (Dictionary<string, Storage>)GetType("StorageMaster")
                .GetField("storageRegistry", (BindingFlags)62)
                .GetValue(storageMaster);

            Assert.AreEqual(storages[storageName].GetType(), typeof(Warehouse));
        }

        [Test]
        public void SelectVehicleValidation()
        {
            storageMaster.RegisterStorage(storageType, storageName);
            string result = storageMaster.SelectVehicle(storageName, 0);

            Vehicle vehicle = (Vehicle)GetType("StorageMaster")
                .GetField("currentVehicle", (BindingFlags)62)
                .GetValue(storageMaster);

            Assert.AreEqual(result, $"Selected {vehicle.GetType().Name}");

            Assert.AreEqual(vehicle.GetType(), typeof(Semi));
        }

        [Test]
        public void LoadVehicleShouldThrowExceptiopnWhenPoolDoesNotContainsProduct()
        {
            RegisterStorageAndProduct();
            Assert.Throws<InvalidOperationException>(() => storageMaster
            .LoadVehicle(new List<string>() { "HardDrive", "Gpu" }));
        }

        [Test]
        public void LoadVehicleValidation()
        {
            RegisterStorageAndProduct();
            string result = storageMaster.LoadVehicle(new List<string>() { productType });

            Assert.AreEqual(result, $"Loaded 1/1 products into Semi");
        }

        [Test]
        public void SendVehicleToShouldThrowsExceptionWhenStoragesDoNotExists()
        {
            Assert.Throws<InvalidOperationException>(() => storageMaster.SendVehicleTo(storageName, 0, "Atanas"));
            Assert.Throws<InvalidOperationException>(() => storageMaster.SendVehicleTo("Atanas", 0, storageName));
        }

        [Test]
        public void SendVehicleToValidation()
        {
            RegisterStorageAndProduct();
            string destinationStorageName = "DestinationShop";
            string destinationStorageType = "Warehouse";
            storageMaster.RegisterStorage(destinationStorageType, destinationStorageName);
            int garageSlot = 0;
            string result = storageMaster.SendVehicleTo(storageName, garageSlot, destinationStorageName);

            Assert.AreEqual(result, $"Sent Semi to {destinationStorageName} (slot {3})");
        }

        [Test]
        public void UnloadVehicleMethodValidation()
        {
            RegisterStorageAndProduct();
            storageMaster.AddProduct("Gpu", 120);

            int garageSlot = 1;
            AddProductToVehicle(storageName, garageSlot);

            string result = storageMaster.UnloadVehicle(storageName, garageSlot);
            Assert.AreEqual(result, $"Unloaded 3/3 products at {storageName}");
        }

        [Test]
        public void GetStorageStatusVallidation()
        {
            RegisterStorageAndProduct();
            AddProductToVehicle(storageName, 1);
            storageMaster.UnloadVehicle(storageName, 1);
            string result = storageMaster.GetStorageStatus(storageName);

            Assert.AreEqual(result,
                "Stock (1.9/10): [Gpu (1), HardDrive (1), SolidStateDrive (1)]\r\nGarage: [Semi|Semi|Semi|empty|empty|empty|empty|empty|empty|empty]");
        }

        [Test]
        public void GetSummaryValidation()
        {
            RegisterStorageAndProduct();
            AddProductToVehicle(storageName, 1);
            storageMaster.UnloadVehicle(storageName, 1);
            string result = storageMaster.GetSummary();

            Assert.AreEqual(result, "Shop:\r\nStorage worth: $400.00");
        }

        private void AddProductToVehicle(string stotageName, int garageSlot)
        {
            Dictionary<string, Storage> storages = (Dictionary<string, Storage>)GetType("StorageMaster")
              .GetField("storageRegistry", (BindingFlags)62)
              .GetValue(storageMaster);
            Storage targetStorage = storages[storageName];
            Vehicle targetVehicle = targetStorage.GetVehicle(garageSlot);
            targetVehicle.LoadProduct(new HardDrive(100));
            targetVehicle.LoadProduct(new Gpu(100));
            targetVehicle.LoadProduct(new SolidStateDrive(200));
        }

        private void RegisterStorageAndProduct()
        {
            storageMaster.RegisterStorage(storageType, storageName);
            storageMaster.AddProduct(productType, productPrice);
            storageMaster.SelectVehicle(storageName, 0);
        }

        private Type GetType(string type)
        {
            return typeof(StartUp)
                .Assembly
                .GetTypes()
                .FirstOrDefault(x => x.Name == type);
        }
    }
}
