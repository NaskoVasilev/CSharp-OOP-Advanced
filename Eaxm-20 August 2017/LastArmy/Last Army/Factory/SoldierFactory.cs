﻿using System;
using System.Linq;
using System.Reflection;

public class SoldierFactory : ISoldierFactory
{
    public ISoldier CreateSoldier(string soldierTypeName, string name, int age, double experience, double endurance)
    {
        Type type = Assembly.GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == soldierTypeName);

        ISoldier soldier = (ISoldier)Activator.CreateInstance(type, new object[] { name, age, experience, endurance });
        return soldier;
    }
}
