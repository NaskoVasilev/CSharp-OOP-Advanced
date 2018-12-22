using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string className, params string[] requestedFields)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Class under investigation: {className}");
        Type type = Type.GetType(className);
        object instance = Activator.CreateInstance(type);

        foreach (string filedName in requestedFields)
        {
            FieldInfo fieldInfo = type.GetField(filedName, BindingFlags.NonPublic | BindingFlags.Public
                | BindingFlags.Static | BindingFlags.Instance);
            sb.AppendLine($"{filedName} = {fieldInfo.GetValue(instance)}");
        }

        return sb.ToString().TrimEnd();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        StringBuilder sb = new StringBuilder();
        Type type = Type.GetType(className);

        FieldInfo[] allFields = type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

        foreach (FieldInfo fieldInfo in allFields)
        {
            sb.AppendLine($"{fieldInfo.Name} must be private!");
        }

        MethodInfo[] nonPublicMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
        MethodInfo[] publicMethods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);

        foreach (MethodInfo method in nonPublicMethods.Where(x => x.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} have to be public!");
        }


        foreach (MethodInfo method in publicMethods.Where(x => x.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} have to be private!");
        }

        return sb.ToString().TrimEnd();
    }

    public string RevealPrivateMethods(string className)
    {
        Type type = Type.GetType(className);

        MethodInfo[] privateMethods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"All Private Methods of Class: {className}");
        sb.AppendLine($"Base Class: {type.BaseType.Name}");

        foreach (MethodInfo method in privateMethods)
        {
            sb.AppendLine(method.Name);
        }

        return sb.ToString().TrimEnd();
    }

    public string CollectGettersAndSetters(string className)
    {
        Type type = Type.GetType(className);

        MethodInfo[] allMethods = type.GetMethods(BindingFlags.Static | BindingFlags.Instance
            | BindingFlags.Public | BindingFlags.NonPublic);
        MethodInfo[] getters = allMethods.Where(x => x.Name.StartsWith("get")).ToArray();
        MethodInfo[] setters = allMethods.Where(x => x.Name.StartsWith("set")).ToArray();

        StringBuilder sb = new StringBuilder();

        foreach (var getter in getters)
        {
            sb.AppendLine($"{getter.Name} will return {getter.ReturnType}");
        }

        foreach (var setter in setters)
        {
            sb.AppendLine($"{setter.Name} will set field of {setter.GetParameters()[0].ParameterType}");
        }

        return sb.ToString().TrimEnd();
    }
}
