using System;

namespace KingGambit.Models
{
    public class RoyalGroup : Subordinate
    {
        private const int DefaultHitPoints = 3;

        public RoyalGroup(string name) : base(name,DefaultHitPoints)
        {
        }

        public override void ResponToAttack()
        {
            Console.WriteLine($"Royal Guard {this.Name} is defending!");
        }
    }
}
