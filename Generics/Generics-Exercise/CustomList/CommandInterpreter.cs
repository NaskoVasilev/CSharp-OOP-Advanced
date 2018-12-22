using System;
using System.Collections.Generic;
using System.Text;

namespace CustomList
{
    public class CommandInterpreter
    {
        private ICustomList<string> list;

        public CommandInterpreter()
        {
            this.list = new CustomList<string>();
        }

        public void ParseCommand(string[] args)
        {
            string command = args[0];
            string element = string.Empty;
            string output = "";

            switch (command)
            {
                case "Add":
                    element = args[1];
                    this.list.Add(element);
                    break;
                case "Remove":
                    int index = int.Parse(args[1]);
                    this.list.Remove(index);
                    break;
                case "Contains":
                    element = args[1];
                    output = this.list.Contains(element).ToString();
                    break;
                case "Swap":
                    int index1 = int.Parse(args[1]);
                    int index2 = int.Parse(args[2]);
                    this.list.Swap(index1, index2);
                    break;
                case "Greater":
                    element = args[1];
                    output = this.list.CountGreaterThan(element).ToString();
                    break;
                case "Min":
                    output = this.list.Min();
                    break;
                case "Max":
                    output = this.list.Max();
                    break;
                case "Sort":
                    list.Sort();
                    break;
                case "Print":
                    foreach (var item in list)
                    {
                        output += item + "\n";
                    }
                    break;
            }

            if (output != "")
            {
                Console.WriteLine(output.TrimEnd());
            }
        }
    }
}
