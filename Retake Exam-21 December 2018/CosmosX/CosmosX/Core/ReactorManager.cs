using System.Collections.Generic;
using System.Linq;
using CosmosX.Core.Contracts;
using CosmosX.Entities.CommonContracts;
using CosmosX.Entities.Containers;
using CosmosX.Entities.Containers.Contracts;
using CosmosX.Entities.Modules.Contracts;
using CosmosX.Entities.Modules.Energy.Contracts;
using CosmosX.Entities.Reactors;
using CosmosX.Entities.Reactors.Contracts;
using CosmosX.Utils;
using CosmosX.Entities.Modules.Absorbing.Contracts;
using System;
using CosmosX.Entities.Modules.ModuleFactory.Contracts;
using CosmosX.Entities.Reactors.ReactorFactory.Contracts;

namespace CosmosX.Core
{
    public class ReactorManager : IManager
    {
        private int currentId;
        private IReactorFactory reactorFactory;
        private IModuleFactory moduleFactory;
        private readonly IDictionary<int, IIdentifiable> identifiableObjects;
        private readonly IDictionary<int, IReactor> reactors;
        private readonly IDictionary<int, IModule> modules;

        public ReactorManager(IReactorFactory reactorFactory, IModuleFactory moduleFactory)
        {
            this.identifiableObjects = new Dictionary<int, IIdentifiable>();
            this.reactors = new Dictionary<int, IReactor>();
            this.modules = new Dictionary<int, IModule>();
            currentId = Constants.StartingId;
            this.reactorFactory = reactorFactory;
            this.moduleFactory = moduleFactory;
        }

        public string ReactorCommand(IList<string> arguments)
        {
            string reactorType = arguments[0];
            int additionalParameter = int.Parse(arguments[1]);
            int moduleCapacity = int.Parse(arguments[2]);

            IContainer container = new ModuleContainer(moduleCapacity);

            IReactor reactor = reactorFactory.CreateReactor(reactorType, currentId++, container, additionalParameter);

            this.reactors.Add(reactor.Id, reactor);
            this.identifiableObjects.Add(reactor.Id, reactor);

            string result = string.Format(Constants.ReactorCreateMessage, reactorType, reactor.Id);
            return result;
        }

        public string ModuleCommand(IList<string> arguments)
        {
            int reactorId = int.Parse(arguments[0]);
            string moduleType = arguments[1];
            int additionalParameter = int.Parse(arguments[2]);

            IModule module = moduleFactory.CreateModule(moduleType, currentId++, additionalParameter);
            this.modules.Add(module.Id, module);
            this.identifiableObjects.Add(module.Id, module);
            IReactor reactor = this.reactors[reactorId];

            if (module is IEnergyModule energyModule)
            {
                reactor.AddEnergyModule(energyModule);
            }
            else if (module is IAbsorbingModule absorbingModule)
            {
                reactor.AddAbsorbingModule(absorbingModule);
            }

            string result = string.Format(Constants.ModuleCreateMessage, moduleType, module.Id, reactorId);
            return result;
        }

        public string ReportCommand(IList<string> arguments)
        {
            int id = int.Parse(arguments[0]);
            string result = "";
            if (this.reactors.ContainsKey(id))
            {
                IReactor reactor = this.reactors[id];
                result = reactor.ToString();
            }
            else if (modules.ContainsKey(id))
            {
                IModule module = modules[id];
                result = module.ToString();
            }
            else
            {
                throw new ArgumentException("No entity with this id!");
            }

            return result;
        }

        public string ExitCommand(IList<string> arguments)
        {
            long cryoReactorCount = this.reactors
                .Values
                .Count(r => r.GetType().Name == nameof(CryoReactor));

            long heatReactorCount = this.reactors
                .Values
                .Count(r => r.GetType().Name == nameof(HeatReactor));

            long energyModulesCount = this.modules
                .Values
                .Count(m => m is IEnergyModule);

            long absorbingModulesCount = this.modules
                .Values
                .Count(m => m is IAbsorbingModule);

            long totalEnergyOutput = this.reactors
                .Values
                .Sum(r => r.TotalEnergyOutput);

            long totalHeatAbsorbing = this.reactors
                .Values
                .Sum(r => r.TotalHeatAbsorbing);

            string result = $"Cryo Reactors: {cryoReactorCount}\n" +
                            $"Heat Reactors: {heatReactorCount}\n" +
                            $"Energy Modules: {energyModulesCount}\n" +
                            $"Absorbing Modules: {absorbingModulesCount}\n" +
                            $"Total Energy Output: {totalEnergyOutput}\n" +
                            $"Total Heat Absorbing: {totalHeatAbsorbing}";

            return result.Trim();
        }
    }
}