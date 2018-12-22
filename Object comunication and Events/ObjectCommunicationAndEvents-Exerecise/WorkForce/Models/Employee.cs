using System;
using System.Collections.Generic;
using System.Text;

namespace WorkForce.Models
{
    public class Employee
    {
        public Employee(string name, int workHoursPerWeek)
        {
            Name = name;
            WorkHoursPerWeek = workHoursPerWeek;
        }

        public string Name { get; private set; }

        public int WorkHoursPerWeek { get; private set; }
    }
}
