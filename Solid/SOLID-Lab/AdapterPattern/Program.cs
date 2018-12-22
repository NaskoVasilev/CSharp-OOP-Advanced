using System;

namespace AdapterPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ITarget adapter = new Adapter();
            adapter.Request();
        }
    }
}
