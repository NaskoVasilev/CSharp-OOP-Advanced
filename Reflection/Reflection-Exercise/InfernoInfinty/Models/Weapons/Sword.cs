using InfernoInfinty.Enums;

namespace InfernoInfinty.Models.Weapons
{
    public class Sword : Weapon
    {
        private const int minDamage = 4;
        private const int maxDamage = 6;
        private const int numberOfSockets = 3;

        public Sword(string name, LevelOfRarity levelOfRarity)
            : base(name, levelOfRarity, minDamage, maxDamage, numberOfSockets)
        {
        }
    }
}
