using CustomDependancyInjectionFramework.Attributes;
using CustomDependancyInjectionFramework.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomDependancyInjectionFramework.Modules
{
    public abstract class AbstractModule : IModule
    {
        IDictionary<Type, Dictionary<string, Type>> implementations;
        IDictionary<Type, object> instances;

        public AbstractModule()
        {
            this.implementations = new Dictionary<Type, Dictionary<string, Type>>();
            this.instances = new Dictionary<Type, object>();
        }

        public abstract void Configure();

        public object GetInstance(Type type)
        {
            this.instances.TryGetValue(type, out object instance);
            return instance;
        }

        public Type GetMapping(Type currentInterface, object attribute)
        {
            Dictionary<string,Type> currentImplementation = this.implementations[currentInterface];

            Type type = null;

            if(attribute is InjectAttribute)
            {
                if(currentImplementation.Count == 0)
                {
                    throw new ArgumentException($"No available mapping for class: {currentInterface.FullName}");
                }

                type = currentImplementation.Values.First();
            }
            else if(attribute is NamedAttribute namedAttribute)
            {
                string dependancyName = namedAttribute.Name;

                if(!currentImplementation.ContainsKey(dependancyName))
                {
                    throw new ArgumentException($"No available mapping for class: {dependancyName}");
                }

                type = currentImplementation[dependancyName];
            }

            return type;
        }

        public void SetInstance(Type implementation, object instance)
        {
            if (!this.instances.ContainsKey(implementation))
            {
                this.instances.Add(implementation, instance);
            }
        }

        protected void CreateMapping<TInterface, TImplementation>()
        {
            Type interfaceType = typeof(TInterface);
            Type implementationType = typeof(TImplementation);

            if(!this.implementations.ContainsKey(interfaceType))
            {
                this.implementations[interfaceType] = new Dictionary<string, Type>();
            }

            this.implementations[interfaceType].Add(implementationType.Name, implementationType);
        }
    }
}
