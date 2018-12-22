using KingGambit.Contracts;
using KingGambit.Models;
using System;
using System.Linq;

namespace KingGambit
{
    class StartUp
    {
        static void Main(string[] args)
        {
            IBoss king = SetUpKing();

            string command = "";

            while ((command = Console.ReadLine())!= "End")
            {
                string[] data = command.Split();
                string commandType = data[0];

                if(commandType == "Attack")
                {
                    king.Attack();
                }
                else if(commandType == "Kill")
                {
                    string name = data[1];
                    IMortal subordinate = king.Subordinates.FirstOrDefault(s => s.Name == name);
                    subordinate.TakeDamage();
                }
            }
        }

        private static IBoss SetUpKing()
        {
            string kingName = Console.ReadLine();
            IBoss king = new King(kingName);

            string[] royalGuardsNames = Console.ReadLine().Split();

            foreach (string name in royalGuardsNames)
            {
                king.AddSubordinate(new RoyalGroup(name));
            }

            string[] footmanNames = Console.ReadLine().Split();

            foreach (string name in footmanNames)
            {
                king.AddSubordinate(new Footman(name));
            }

            return king;
        }
    }
}
