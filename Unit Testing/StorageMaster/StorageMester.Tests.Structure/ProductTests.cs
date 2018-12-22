using NUnit.Framework;
using StorageMaster.Entities.Products;
using System;
using System.Reflection;
using System.Linq;
using StorageMaster;

namespace StorageMester.Tests.Structure
{
    public class ProductTests
    {
        private Type product;

        [SetUp]
        public void InitializeProduct()
        {
            product = typeof(Product);
        }

        [Test]
        public void ProductClassesShouldExist()
        {
            string[] productClasses = new[]
            {
                "Product",
                "Ram",
                "SolidStateDrive",
                "Gpu"
            };

            foreach (string className in productClasses)
            {
                Type type = typeof(StartUp).Assembly.GetTypes()
                    .FirstOrDefault(t => t.Name == className);
                Assert.IsNotNull(type, $"{className} does not exists!");
            }
        }

        [Test]
        [TestCase("Weight", typeof(double))]
        [TestCase("Price", typeof(double))]
        public void ProductPropertiesShouldExists(string propertyName, Type propertyType)
        {
            PropertyInfo propertyInfo = product.GetProperty(propertyName);

            Assert.IsNotNull(propertyInfo, $"{propertyName} does not exists!");
            Assert.AreEqual(propertyType, propertyInfo.PropertyType, $"{propertyName} is not of correvt type!");
        }

        [Test]
        public void ProductShouldBeAbstractClass()
        {
            bool productIsAbstract = product.IsAbstract;
            Assert.That(productIsAbstract, "Product is not abstract class!");
        }

        [Test]
        public void DifferentProductsShouldDeriveFromProduct()
        {
            Type[] types = new Type[]
            {
                typeof(Gpu),
                typeof(HardDrive),
                typeof(Ram),
                typeof(SolidStateDrive),
            };

            foreach (Type type in types)
            {
                bool isDerivedClass = type.BaseType == product;
                Assert.That(isDerivedClass, $"{type.Name} does not inherit {product.Name}");
            }
        }

        [Test]
        public void ProductShouldHaveProtectedConstructor()
        {
            ConstructorInfo constructor = product
                .GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault();

            Assert.IsNotNull(constructor, $"Product has no protected constructor!");
            ParameterInfo[] parameters = constructor.GetParameters();
            bool constrctorIsValid = parameters.Length == 2
                && constructor.IsFamily
                && typeof(double) == parameters[0].ParameterType
                && typeof(double) == parameters[1].ParameterType;

            Assert.That(constrctorIsValid, "Product constructor is not valid!");
        }
    }
}
