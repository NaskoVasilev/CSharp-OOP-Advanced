using System;
using System.Collections.Generic;
using System.Text;

namespace AdapterPattern
{
    public class Adaptee
    {
        public void SpecificRequest()
        {
            Console.WriteLine("Specific request called!");
        }
    }
}
