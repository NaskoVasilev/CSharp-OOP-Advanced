using System;

namespace CustomList
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CommandInterpreter commandInterpreter = new CommandInterpreter();

            string command = "";

            while ((command = Console.ReadLine()) != "END")
            {
                string[] data = command.Split();
                commandInterpreter.ParseCommand(data);
            }
        }
    }
}
