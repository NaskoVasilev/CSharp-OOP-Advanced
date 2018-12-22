using System;
using System.Linq;
using System.Reflection;

namespace CustomClassAttribute
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Type type = typeof(Weapon);
            ClassInfoAttribute attribute = type.GetCustomAttribute<ClassInfoAttribute>();
            Type attributeType = typeof(ClassInfoAttribute);

            string command;

            while ((command = Console.ReadLine())!="END")
            {
                PropertyInfo property = attributeType.GetProperties()
                    .FirstOrDefault(p => p.Name == command);

                object value = property.GetValue(attribute);
                
                if(command == "Description")
                {
                    Console.WriteLine($"Class description: {value}");
                }
                else
                {
                    Console.WriteLine($"{property.Name}: {value}");
                }
                
            }
        }
    }
}
