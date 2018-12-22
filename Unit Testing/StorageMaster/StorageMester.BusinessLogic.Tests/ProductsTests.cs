using NUnit.Framework;
using StorageMaster.Entities.Products;
using System;

namespace StorageMester.BusinessLogic.Tests
{
    [TestFixture]
    public class ProductsTests
    {
        [Test]
        public void CreateInvalidProduct()
        {
            var types = new[]
            {
            typeof(Gpu),
            typeof(HardDrive),
            typeof(Ram),
            typeof(SolidStateDrive),
        };

            var parameters = new object[]
            {
               -2.5
            };

            foreach (var type in types)
            {
                Assert.That(() => CreateObjectInstance(type, parameters), Throws.InvalidOperationException,
                    $"No exception was thrown attempting to create a {type.Name} with invalid price");
            }


        }

        private object CreateObjectInstance(Type type, object[] parameters)
        {
            try
            {
                return Activator.CreateInstance(type, parameters);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

    }
}
