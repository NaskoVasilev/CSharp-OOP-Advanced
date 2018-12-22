using System;

namespace SpecialTuple
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] personInfo = Console.ReadLine().Split();
            string fullName = personInfo[0] + " " + personInfo[1];
            string address = personInfo[2];
            string town = personInfo[3];

            string[] beerInfo = Console.ReadLine().Split();
            string personName = beerInfo[0];
            int quantity = int.Parse(beerInfo[1]);
            bool isDrunk = beerInfo[2] == "drunk";

            string[] bankInfo = Console.ReadLine().Split();
            string name = bankInfo[0];
            double balance = double.Parse(bankInfo[1]);
            string bankName =bankInfo[2];

            SpecialTuple<string, string,string> personTuple 
                = new SpecialTuple<string, string,string>(fullName, address,town);
            SpecialTuple<string, int,bool> beerTuple 
                = new SpecialTuple<string, int,bool>(personName, quantity,isDrunk);
            SpecialTuple<string, double,string> numbersTuple =
                new SpecialTuple<string, double,string>(name, balance,bankName);

            Console.WriteLine(personTuple);
            Console.WriteLine(beerTuple);
            Console.WriteLine(numbersTuple);
        }
    }
}
