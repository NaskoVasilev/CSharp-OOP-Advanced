using InfernoInfinty.Enums;

namespace InfernoInfinty.Models.Weapons
{
    public class Knife : Weapon
    {
        private const int minDamage = 3;
        private const int maxDamage = 4;
        private const int numberOfSockets = 2;


        public Knife(string name, LevelOfRarity levelOfRarity)
            : base(name, levelOfRarity, minDamage, maxDamage, numberOfSockets)
        {
        }
    }
}
