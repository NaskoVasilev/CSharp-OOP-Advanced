using System;

namespace CustomDependancyInjectionFramework.Attributes
{
    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Field)]
    public class InjectAttribute : Attribute
    {
    }
}
