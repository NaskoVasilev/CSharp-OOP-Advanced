using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DIFramework
{
    public class ServiceCollection : IServiceCollection
    {
        private readonly IDictionary<Type, Type> dependancyContainer;

        public ServiceCollection()
        {
            this.dependancyContainer = new Dictionary<Type, Type>();
        }

        public void AddService<TImplementation, TClass>()
        {
            this.dependancyContainer[typeof(TImplementation)] = typeof(TClass);
        }

        public object CreateInstance(Type type)
        {
            if(dependancyContainer.ContainsKey(type))
            {
                type = dependancyContainer[type];
            }

            if(type.IsInterface || type.IsAbstract)
            {
                throw new ArgumentException($"Type {type.FullName} cannot be instantiated.");
            }

            ConstructorInfo constructor = type.GetConstructors()
                .OrderBy(x => x.GetParameters().Length)
                .FirstOrDefault();

            ParameterInfo[] constructorParameters = constructor.GetParameters();
            List<object> constructorParameterObjects = new List<object>();

            foreach (ParameterInfo parameter in constructorParameters)
            {
                var parameterObject = this.CreateInstance(parameter.ParameterType);
                constructorParameterObjects.Add(parameterObject);
            }

            object instance = constructor.Invoke(constructorParameterObjects.ToArray());

            return instance;
        }

        public TClass CreateInstance<TClass>()
        {
            return (TClass)this.CreateInstance(typeof(TClass));
        }
    }
}
