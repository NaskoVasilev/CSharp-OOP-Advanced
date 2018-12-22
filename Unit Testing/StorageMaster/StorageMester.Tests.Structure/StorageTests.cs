using NUnit.Framework;
using StorageMaster;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Storage;
using StorageMaster.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace StorageMester.Tests.Structure
{
    public class StorageTests
    {
        private Type storage;

        [SetUp]
        public void InitializeStotage()
        {
            storage = typeof(Storage);
        }

        [Test]
        public void StorageClassesShouldExists()
        {
            string[] storageClasses = new[]
            {
                "Storage",
                "Warehouse",
                "DistributionCenter",
                "AutomatedWarehouse"
            };

            foreach (string className in storageClasses)
            {
                Type type = typeof(StartUp).Assembly.GetTypes()
                    .FirstOrDefault(t => t.Name == className);
                Assert.IsNotNull(type, $"{className} does not exists!");
            }
        }

        [Test]
        [TestCase("Name", typeof(string))]
        [TestCase("Garage", typeof(IReadOnlyCollection<Vehicle>))]
        [TestCase("Products", typeof(IReadOnlyCollection<Product>))]
        [TestCase("Capacity", typeof(int))]
        [TestCase("GarageSlots", typeof(int))]
        [TestCase("IsFull", typeof(bool))]
        public void StoragePropertiesShouldExists(string propertyName, Type type)
        {
            PropertyInfo propertyInfo = storage.GetProperty(propertyName);

            Assert.IsNotNull(propertyInfo, $"{propertyName} does not exists!");
            Assert.AreEqual(type, propertyInfo.PropertyType, $"{propertyName}  type is not correct!");
        }

        [Test]
        [TestCase("GetVehicle", typeof(Vehicle), new Type[] { typeof(int) })]
        [TestCase("SendVehicleTo", typeof(int), new Type[] { typeof(int), typeof(Storage) })]
        [TestCase("UnloadVehicle", typeof(int), new Type[] { typeof(int) })]
        public void StorageShouldContainsSpecificMethods(string methodName, Type returnType, Type[] parametersTypes)
        {
            MethodInfo methodInfo = storage.GetMethod(methodName);
            Assert.IsNotNull(methodInfo, $"{methodName} does not exists!");
            Assert.AreEqual(returnType, methodInfo.ReturnType, $"{methodName} return type is not correct!");

            Type[] actualParametersTypes = methodInfo.GetParameters()
                .Select(p => p.ParameterType)
                .ToArray();

            Assert.That(actualParametersTypes, Is.EquivalentTo(parametersTypes),
                $"{methodName} does not take correct arguments!");
        }

        [Test]
        public void StorageShouldHaveProtectedConstructor()
        {
            ConstructorInfo constructor = storage
                .GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault();

            Assert.IsNotNull(constructor, $"Stotage has no protected constructor!");
            ParameterInfo[] parameters = constructor.GetParameters();
            bool constrctorIsValid = parameters.Length == 4
                && constructor.IsFamily;
            Assert.That(constrctorIsValid, "Vehicle constructor is not valid!");

            Type[] expectedTypes = new Type[]
            {
                typeof(string),
                typeof(int),
                typeof(int),
                typeof(IEnumerable<Vehicle>),
            };

            Type[] actualTypes = parameters.Select(p => p.ParameterType).ToArray();

            Assert.AreEqual(actualTypes, expectedTypes,
                $"Storage constructor does not take correct arguments!");
        }

        [Test]
        public void StorageShouldBeAbstractClass()
        {
            bool storageIsAbstract = storage.IsAbstract;
            Assert.That(storageIsAbstract, "Storage is not abstract class!");
        }

        [Test]
        public void DifferentVehiclesShouldDeriveFromVehicle()
        {
            Type[] types = new Type[]
            {
                typeof(Warehouse),
                typeof(AutomatedWarehouse),
                typeof(DistributionCenter),
            };

            foreach (Type type in types)
            {
                bool isDerivedClass = type.BaseType == storage;
                Assert.That(isDerivedClass, $"{type.Name} does not inherit {storage.Name}");
            }
        }
    }
}
