using System;
using System.Collections.Generic;
using System.Text;

namespace WorkForce.Models
{
    public class PartTimeEmployee : Employee
    {
        private const int DefaultWorkHoursPerWeek = 20;

        public PartTimeEmployee(string name) : base(name,DefaultWorkHoursPerWeek)
        {
        }
    }
}
