using CustomDependancyInjectionFramework.Attributes;
using CustomDependancyInjectionFramework.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CustomDependancyInjectionFramework.Injectors
{
    public class Injector
    {
        IModule module;

        public Injector(IModule module)
        {
            this.module = module;
        }

        public TClass Inject<TClass>()
        {
            bool hasConstructorAttribute = this.CheckForConstructorInjection<TClass>();
            bool hasFieldAttribute = this.CheckForFiledInjection<TClass>();

            if (hasConstructorAttribute && hasFieldAttribute)
            {
                throw new ArgumentException($"There must be only field or constructor annotated with Inject attribute");
            }

            if (hasConstructorAttribute)
            {
                return this.CreateConstructorInjection<TClass>();
            }
            else if (hasFieldAttribute)
            {
                return this.CreateFieldInjection<TClass>();
            }

            return default(TClass);
        }

        private bool CheckForFiledInjection<TClass>()
        {
            return typeof(TClass)
                .GetFields((BindingFlags)62)
                .Any(field => field.GetCustomAttributes(typeof(InjectAttribute), true).Any());
        }

        private bool CheckForConstructorInjection<TClass>()
        {
            return typeof(TClass)
                .GetConstructors((BindingFlags)62)
                .Any(cinstructor => cinstructor.GetCustomAttributes(typeof(InjectAttribute), true).Any());
        }

        private TClass CreateConstructorInjection<TClass>()
        {
            Type desireClass = typeof(TClass);

            if (desireClass == null)
            {
                return default(TClass);
            }

            ConstructorInfo[] constructors = desireClass.GetConstructors();

            foreach (var constructor in constructors)
            {
                if (!this.CheckForConstructorInjection<TClass>())
                {
                    continue;
                }

                InjectAttribute inject = (InjectAttribute)constructor
                    .GetCustomAttributes(typeof(InjectAttribute), true)
                    .FirstOrDefault();
                ParameterInfo[] parameterTypes = constructor.GetParameters();
                object[] constructorParams = new object[parameterTypes.Length];
                int index = 0;

                foreach (ParameterInfo parameterType in parameterTypes)
                {
                    NamedAttribute namedAttribute = parameterType.GetCustomAttribute<NamedAttribute>(true);
                    Type dependancy = null;

                    if (namedAttribute == null)
                    {
                        dependancy = this.module.GetMapping(parameterType.ParameterType, inject);
                    }
                    else
                    {
                        dependancy = this.module.GetMapping(parameterType.ParameterType, namedAttribute);
                    }

                    if (parameterType.ParameterType.IsAssignableFrom(dependancy))
                    {
                        object instance = this.module.GetInstance(dependancy);

                        if (instance == null)
                        {
                            instance = Activator.CreateInstance(dependancy);
                            this.module.SetInstance(parameterType.ParameterType, instance);
                        }

                        constructorParams[index++] = instance;
                    }
                }

                return (TClass)Activator.CreateInstance(desireClass, constructorParams);
            }

            return default(TClass);
        }

        private TClass CreateFieldInjection<TClass>()
        {
            var desireClass = typeof(TClass);
            var desireClassInstance = this.module.GetInstance(desireClass);

            if(desireClassInstance == null)
            {
                desireClassInstance = Activator.CreateInstance(desireClass);
                this.module.SetInstance(desireClass, desireClassInstance); 
            }

            FieldInfo[] fields = desireClass.GetFields((BindingFlags)62);

            foreach (var field in fields)
            {
                InjectAttribute injectAttribute = field.GetCustomAttribute<InjectAttribute>(true);

                if (injectAttribute != null)
                {
                    Type dependancy = null;

                    NamedAttribute namedAttribute = field.GetCustomAttribute<NamedAttribute>(true);
                    Type type = field.FieldType;

                    if(namedAttribute == null)
                    {
                        dependancy = this.module.GetMapping(type, injectAttribute);
                    }
                    else
                    {
                        dependancy = this.module.GetMapping(type, namedAttribute);
                    }

                    if(type.IsAssignableFrom(dependancy))
                    {
                        object instance = this.module.GetInstance(dependancy);

                        if(instance == null)
                        {
                            instance = Activator.CreateInstance(dependancy);
                            this.module.SetInstance(dependancy, instance);
                        }

                        field.SetValue(desireClassInstance, instance);
                    }
                }
            }

            return (TClass)desireClassInstance;
        }
    }
}
