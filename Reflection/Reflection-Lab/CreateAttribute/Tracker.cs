using System;
using System.Linq;
using System.Reflection;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        Type type = typeof(StartUp);

        MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);

        foreach (var method in methods)
        {
            SoftUniAttribute customAttribute = method.GetCustomAttribute<SoftUniAttribute>();

            if (customAttribute != null)
            {
                Console.WriteLine($"{method.Name} is written by {customAttribute.Name}");
            }
        }
    }
}

