using System;
using System.Collections.Generic;
using System.Linq;

namespace ListyIterator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine().Split().Skip(1).ToList();
            ListyIterator<string> list = new ListyIterator<string>(elements);

            string input = "";

            while ((input = Console.ReadLine())!="END")
            {
                string[] data = input.Split();
                string command = data[0];

                switch(command)
                {
                    case "Move":
                        Console.WriteLine(list.Move());
                        break;
                    case "Print":
                        try
                        {
                            list.Print();
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "HasNext":
                        Console.WriteLine(list.HasNext());
                        break;
                    case "PrintAll":
                        Console.WriteLine(string.Join(" ",list));
                        break;
                }
            }
        }
    }
}
