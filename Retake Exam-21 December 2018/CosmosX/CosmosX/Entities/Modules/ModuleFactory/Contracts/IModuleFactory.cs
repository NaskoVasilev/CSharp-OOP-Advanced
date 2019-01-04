using CosmosX.Entities.Modules.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CosmosX.Entities.Modules.ModuleFactory.Contracts
{
    public interface IModuleFactory
    {
        IModule CreateModule(string type, int id, int additionalParameter);
    }
}
