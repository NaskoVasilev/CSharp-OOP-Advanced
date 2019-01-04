namespace CosmosX.Tests
{
    using CosmosX.Entities.Containers;
    using CosmosX.Entities.Modules.Absorbing;
    using CosmosX.Entities.Modules.Energy;
    using NUnit.Framework;
    using System.Linq;

    [TestFixture]
    public class ModuleContainerTests
    {
        private ModuleContainer moduleContainer;
        private const int Capacity = 4;

        [SetUp]
        public void SetUp()
        {
            this.moduleContainer = new ModuleContainer(Capacity);
        }

        [Test]
        public void AddModuleValidation()
        {
            moduleContainer.AddAbsorbingModule(new HeatProcessor(1, 100));
            moduleContainer.AddAbsorbingModule(new CooldownSystem(2, 200));
            moduleContainer.AddEnergyModule(new CryogenRod(3, 300));
            moduleContainer.AddEnergyModule(new CryogenRod(4, 400));

            Assert.That(moduleContainer.ModulesByInput.Count, Is.EqualTo(4));
            Assert.That(moduleContainer.TotalEnergyOutput, Is.EqualTo(700));
            Assert.AreEqual(moduleContainer.TotalHeatAbsorbing, 300);
        }

        [Test]
        public void WhenThereIsNoPlaceTheFirstModuleShouldBeRemoved()
        {
            moduleContainer.AddAbsorbingModule(new HeatProcessor(1, 100));
            moduleContainer.AddAbsorbingModule(new CooldownSystem(2, 200));
            moduleContainer.AddEnergyModule(new CryogenRod(3, 300));
            moduleContainer.AddEnergyModule(new CryogenRod(4, 400));
            moduleContainer.AddEnergyModule(new CryogenRod(5, 400));

            Assert.That(moduleContainer.ModulesByInput.Count, Is.EqualTo(4));
            Assert.AreEqual(moduleContainer.ModulesByInput.First().Id, 2);
            Assert.AreEqual(moduleContainer.ModulesByInput.Last().Id, 5);
        }
    }
}