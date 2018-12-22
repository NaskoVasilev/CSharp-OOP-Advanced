namespace HarvestingFields
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            Type type = typeof(HarvestingFields);
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic
                | BindingFlags.Static | BindingFlags.Instance);

            FieldInfo[] privateFields = fields.Where(x => x.IsPrivate).ToArray();
            FieldInfo[] publicFields = fields.Where(x => x.IsPublic).ToArray();
            FieldInfo[] protectedFields = fields.Where(x => x.IsFamily).ToArray();

            Dictionary<string, FieldInfo[]> fieldsByAccessModifiers = new Dictionary<string, FieldInfo[]>();
            fieldsByAccessModifiers.Add("public", publicFields);
            fieldsByAccessModifiers.Add("private", privateFields);
            fieldsByAccessModifiers.Add("protected", protectedFields);
            fieldsByAccessModifiers.Add("all", fields);

            string accessModifier = "";

            while ((accessModifier = Console.ReadLine()) != "HARVEST")
            {
                foreach (FieldInfo field in fieldsByAccessModifiers[accessModifier])
                {
                    Console.WriteLine($"{GetModifier(field)} {field.FieldType.Name} {field.Name}");
                }
            }
        }

        private static string GetModifier(FieldInfo field)
        {
            return field.IsPrivate ? "private" : field.IsPublic ? "public" : "protected";
        }
    }
}
