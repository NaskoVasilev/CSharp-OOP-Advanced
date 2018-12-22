using System;
using System.Collections.Generic;
using System.Text;

namespace WorkForce.Models
{
    public class StandardEmployee : Employee
    {
        private const int DefaultWorkHoursPerWeek = 40;

        public StandardEmployee(string name) : base(name, DefaultWorkHoursPerWeek)
        {
        }
    }
}
