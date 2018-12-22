using System;

namespace KingGambit.Models
{
    public class Footman : Subordinate
    {
        private const int DefaultHitPoints = 2;

        public Footman(string name) : base(name, DefaultHitPoints)
        {
        }

        public override void ResponToAttack()
        {
            Console.WriteLine($"Footman {this.Name} is panicking!");
        }
    }
}
