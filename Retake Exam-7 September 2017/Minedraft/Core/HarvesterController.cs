using System;
using System.Collections.Generic;
using System.Linq;

public class HarvesterController : IHarvesterController
{
    private IHarvesterFactory harvesterFactory;
    private IEnergyRepository energyRepository;
    private readonly List<IHarvester> harvesters;
    private string mode;

    public HarvesterController(IHarvesterFactory harvesterFactory, IEnergyRepository energyRepository)
    {
        this.harvesterFactory = harvesterFactory;
        this.energyRepository = energyRepository;
        this.harvesters = new List<IHarvester>();
        this.mode = "Full";
    }

    public double OreProduced { get; private set; }

    public IReadOnlyCollection<IEntity> Entities => harvesters.AsReadOnly();

    public string ChangeMode(string mode)
    {
        this.mode = mode;

        List<IHarvester> reminder = new List<IHarvester>();

        foreach (IHarvester harvester in harvesters)
        {
            try
            {
                harvester.Broke();
            }
            catch (Exception)
            {
                reminder.Add(harvester);
            }
        }

        foreach (IHarvester harvester in reminder)
        {
            this.harvesters.Remove(harvester);
        }

        return string.Format(Constants.ChangeMode, mode);
    }

    public string Produce()
    {
        double neededEnergy = 0;

        foreach (var harvester in this.harvesters)
        {
            if (this.mode == "Full")
            {
                neededEnergy += harvester.EnergyRequirement;
            }
            else if (this.mode == "Half")
            {
                neededEnergy += harvester.EnergyRequirement * 50 / 100;
            }
            else if (this.mode == "Energy")
            {
                neededEnergy += harvester.EnergyRequirement * 20 / 100;
            }
        }

        bool energyIsEnough = energyRepository.TakeEnergy(neededEnergy);
        double minedOres = 0;

        if (energyIsEnough)
        {
            foreach (var harvester in this.harvesters)
            {
                minedOres += harvester.OreOutput;
            }

            if (this.mode == "Energy")
            {
                minedOres = minedOres * 20 / 100;
            }
            else if (this.mode == "Half")
            {
                minedOres = minedOres * 50 / 100;
            }

            this.OreProduced += minedOres;
        }

        return string.Format(Constants.OreOutputToday, minedOres);
    }

    public string Register(IList<string> args)
    {
        IHarvester harvester = this.harvesterFactory
            .GenerateHarvester(args);
        this.harvesters.Add(harvester);

        return string.Format(Constants.SuccessfullRegistration, harvester.GetType().Name);
    }
}

