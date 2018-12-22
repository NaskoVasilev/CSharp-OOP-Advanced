using System;
using System.Collections.Generic;
using System.Text;

namespace AdapterPattern
{
    public class Adapter : ITarget
    {
        private Adaptee adaptee;

        public Adapter()
        {
            this.adaptee = new Adaptee();
        }

        public void Request()
        {
            adaptee.SpecificRequest();
        }
    }
}
