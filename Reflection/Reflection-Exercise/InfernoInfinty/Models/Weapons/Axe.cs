using InfernoInfinty.Enums;

namespace InfernoInfinty.Models.Weapons
{
    public class Axe : Weapon
    {
        private const int minDamage = 5;
        private const int maxDamage = 10;
        private const int numberOfSockets = 4;

        public Axe(string name, LevelOfRarity levelOfRarity) 
            : base(name, levelOfRarity, minDamage, maxDamage, numberOfSockets)
        {
        }
    }
}
