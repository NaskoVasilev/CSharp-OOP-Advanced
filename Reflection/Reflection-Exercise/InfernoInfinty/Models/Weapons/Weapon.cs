using InfernoInfinty.Enums;
using InfernoInfinty.Models.Gems;
using System.Linq;

namespace InfernoInfinty.Models.Weapons
{
    public abstract class Weapon
    {
        protected Gem[] gems;

        protected Weapon(string name, LevelOfRarity levelOfRarity, int minDamage, int maxDamage, int numberOfSockets)
        {
            Name = name;
            LevelOfRarity = levelOfRarity;
            this.MinDamage = minDamage;
            this.MaxDamage = maxDamage;
            this.IncreaseDamage();
            this.NumberOfSockets = numberOfSockets;
            this.gems = new Gem[NumberOfSockets];
        }

        public string Name { get; }

        public LevelOfRarity LevelOfRarity { get; private set; }

        public int MinDamage { get; private set; }

        public int MaxDamage { get; private set; }

        public int NumberOfSockets { get; private set; }

        public int Strength => gems.Where(x => x != null).Sum(x => x.StrengthBonus);

        public int Agility => gems.Where(x => x != null).Sum(x => x.AgilityBonus);

        public int Vitality => gems.Where(x => x != null).Sum(x => x.VitalityBonus);

        public void AddGem(int index, Gem gem)
        {
            if (index >= 0 && index < this.NumberOfSockets)
            {
                this.gems[index] = gem;
            }
        }

        public void RemoveGem(int index)
        {
            if (index >= 0 && index < this.NumberOfSockets && this.gems[index] != null)
            {
                this.gems[index] = null;
            }
        }

        public override string ToString()
        {
            return $"{this.Name}: {this.MinDamage + this.Strength * 2 + this.Agility}-" +
                $"{this.MaxDamage + this.Strength * 3 + this.Agility * 4} Damage, +{this.Strength} Strength, +" +
                $"{this.Agility} Agility, +{this.Vitality} Vitality";
        }

        private void IncreaseDamage()
        {
            this.MinDamage *= (int)this.LevelOfRarity;
            this.MaxDamage *= (int)this.LevelOfRarity;
        }
    }
}
