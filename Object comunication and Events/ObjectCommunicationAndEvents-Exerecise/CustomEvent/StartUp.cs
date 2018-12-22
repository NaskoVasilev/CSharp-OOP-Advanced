using System;

namespace CustomEvent
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Handler handler = new Handler();
            Dispetcher dispetcher = new Dispetcher("Nasko");
            dispetcher.NameChange += handler.OnDispatcherNameChange;

            string inputName = "";

            while ((inputName = Console.ReadLine()) != "End")
            {
                dispetcher.Name = inputName;
            }
        }
    }
}
