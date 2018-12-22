namespace KingGambit.Models
{
    using System.Collections.Generic;
    using Contracts;
    using System;

    public class King : INameable, IBoss, IAttackable
    {
        private List<IMortal> subordinates;

        public King(string name)
        {
            Name = name;
            this.subordinates = new List<IMortal>();
        }

        public string Name { get; }

        public IReadOnlyCollection<IMortal> Subordinates => this.subordinates.AsReadOnly();

        public event AttackEvenetHandler OnAttack;

        public void AddSubordinate(IMortal subordinate)
        {
            this.subordinates.Add(subordinate);
            this.OnAttack += subordinate.ResponToAttack;
            subordinate.SubordinateDie += this.RemoveSubordinate;
        }

        public void Attack()
        {
            this.RespondToAttack();

            if(this.OnAttack is AttackEvenetHandler attackHandler)
            {
                attackHandler();
            }
        }

        public void RemoveSubordinate(IMortal subordinate)
        {
            OnAttack -= subordinate.ResponToAttack;
            this.subordinates.Remove(subordinate);
        }

        public void RespondToAttack()
        {
            Console.WriteLine($"King {this.Name} is under attack!");
        }
    }
}
