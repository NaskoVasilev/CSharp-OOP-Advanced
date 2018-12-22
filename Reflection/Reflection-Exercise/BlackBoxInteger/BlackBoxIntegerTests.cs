namespace BlackBoxInteger
{
    using System;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type type = typeof(BlackBoxInteger);
            FieldInfo valueField = type.GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance);
            ConstructorInfo[] constrctors = type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
            BlackBoxInteger blackBoxInteger = constrctors[1].Invoke(new object[] { }) as BlackBoxInteger;

            string command = "";

            while ((command = Console.ReadLine()) != "END")
            {
                string[] data = command.Split("_");
                string methodName = data[0];
                int value = int.Parse(data[1]);

                MethodInfo method = type.GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);
                method.Invoke(blackBoxInteger, new object[] { value });
                Console.WriteLine(valueField.GetValue(blackBoxInteger));
            }
        }
    }
}
