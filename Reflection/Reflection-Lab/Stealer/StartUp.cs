﻿using System;
using System.Text;
using System.Reflection;

class StartUp
{
    static void Main(string[] args)
    {
        Spy spy = new Spy();
        string result = spy.CollectGettersAndSetters("Hacker");
        Console.WriteLine(result);
    }
}
