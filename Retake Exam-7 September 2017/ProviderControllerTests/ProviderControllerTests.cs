using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

public class ProviderControllerTests
{
    private IProviderController providerController;

    [SetUp]
    public void SetUp()
    {
        IEnergyRepository energyRepository = new EnergyRepository();
        this.providerController = new ProviderController(energyRepository);
    }

    [Test]
    public void RegisterMethodValidation()
    {
        this.providerController.Register(new List<string>() { "Pressure", "40", "20" });
        this.providerController.Register(new List<string>() { "Solar", "60", "30" });

        Assert.That(this.providerController.Entities.Count, Is.EqualTo(2));
    }

    [Test]
    public void ProduceMethodShouldProduceEnergyCorrectly()
    {
        this.providerController.Register(new List<string> { "Pressure", "40", "100" });
        this.providerController.Register(new List<string> { "Solar", "80", "100" });

        this.providerController.Produce();
        double energyProduced = this.providerController.TotalEnergyProduced;

        Assert.AreEqual(300, energyProduced);
    }

    [Test]
    public void ProduceMethodShouldBrokeProviders()
    {
        this.providerController.Register(new List<string> { "Pressure", "10", "100" });
        this.providerController.Register(new List<string> { "Solar", "10", "100" });
        this.providerController.Register(new List<string> { "Standart", "10", "100" });

        for (int i = 0; i <= 10; i++)
        {
            this.providerController.Produce();
        }

        int expectedCount = 1;
        int actualCount = this.providerController.Entities.Count;

        Assert.AreEqual(expectedCount, actualCount);
    }

    [Test]
    public void ReapirMethodValidation()
    {
        this.providerController.Register(new List<string>() { "Pressure", "40", "20" });

        IEntity provider = this.providerController.Entities.First();
        double expectedDurability = provider.Durability;

        double reapairValue = 150;
        providerController.Repair(reapairValue);

        double actualDurability = provider.Durability;

        Assert.AreNotEqual(expectedDurability, actualDurability);
    }
}


