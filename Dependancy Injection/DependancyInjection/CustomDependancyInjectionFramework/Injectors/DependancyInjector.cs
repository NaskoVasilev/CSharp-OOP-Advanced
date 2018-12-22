using CustomDependancyInjectionFramework.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDependancyInjectionFramework.Injectors
{
    public class DependancyInjector
    {
        public static Injector CreateInjector(IModule module)
        {
            module.Configure();
            return new Injector(module);
        }
    }
}
