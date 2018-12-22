using NUnit.Framework;
using StorageMaster;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace StorageMester.Tests.Structure
{
    [TestFixture]
    public class VehicleTests
    {
        private Type vehicleType;

        [SetUp]
        public void InitializeVehicle()
        {
            vehicleType = typeof(Vehicle);
        }

        [Test]
        public void VehicleClassesShouldExist()
        {
            string[] vehicleClasses = new[]
            {
                "Vehicle",
                "Truck",
                "Semi",
                "Van"
            };

            foreach (string className in vehicleClasses)
            {
                Type type = typeof(StartUp).Assembly.GetTypes()
                    .FirstOrDefault(t => t.Name == className);
                Assert.IsNotNull(type, $"{className} does not exists!");
            }
        }

        [Test]
        [TestCase("Capacity", typeof(int))]
        [TestCase("Trunk", typeof(IReadOnlyCollection<Product>))]
        [TestCase("IsFull", typeof(bool))]
        [TestCase("IsEmpty", typeof(bool))]
        public void VehiclesPropertiesShouldExists(string propertyName, Type peopertyType)
        {
            Type vehicleType = typeof(Vehicle);

            PropertyInfo propertyInfo = vehicleType.GetProperty(propertyName);

            Assert.IsNotNull(propertyInfo, $"{propertyName} does not exists!");
            Assert.AreEqual(peopertyType, propertyInfo.PropertyType, $"{propertyName}  type is not correct!");
        }

        [Test]
        [TestCase("LoadProduct", typeof(void), new Type[] { typeof(Product) })]
        [TestCase("Unload", typeof(Product), new Type[] { })]
        public void VehiclesShouldContainsSpecificMethods(string methodName, Type returnType, Type[] parametersTypes)
        {
            MethodInfo methodInfo = vehicleType.GetMethod(methodName);
            Assert.IsNotNull(methodInfo, $"{methodName} does not exists!");
            Assert.AreEqual(returnType, methodInfo.ReturnType, $"{methodName} return type is not correct!");

            Type[] actulParameterTypes = methodInfo.GetParameters()
                .Select(p => p.ParameterType)
                .ToArray();

            Assert.That(parametersTypes, Is.EquivalentTo(actulParameterTypes),
                $"{methodName} does not take correct arguments!");
        }

        [Test]
        public void VehicleShouldHaveConstructorWhichTakeIntegerArgument()
        {
            ConstructorInfo constructor = vehicleType
                .GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault();

            Assert.IsNotNull(constructor, $"Vehicle has no protected constructor!");
            ParameterInfo[] parameters = constructor.GetParameters();
            bool constrctorIsValid = parameters.Length == 1
                && constructor.IsFamily
                && typeof(int) == parameters[0].ParameterType;

            Assert.That(constrctorIsValid, "Vehicle constructor is not valid!");
        }

        [Test]
        public void VehicleShouldBeAbstractClass()
        {
            bool vehicleIsAbstract = vehicleType.IsAbstract;
            Assert.That(vehicleIsAbstract, "Vehicle is not abstract class!");
        }

        [Test]
        public void DifferentVehiclesShouldDeriveFromVehicle()
        {
            Type[] types = new Type[]
            {
                typeof(Semi),
                typeof(Truck),
                typeof(Van),
            };

            foreach (Type type in types)
            {
                bool isDerivedClass = type.BaseType == vehicleType;
                Assert.That(isDerivedClass, $"{type.Name} does not inherit {vehicleType.Name}");
            }
        }
    }
}
