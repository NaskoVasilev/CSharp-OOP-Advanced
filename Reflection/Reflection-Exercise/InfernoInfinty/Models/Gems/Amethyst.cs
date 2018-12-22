using InfernoInfinty.Enums;

namespace InfernoInfinty.Models.Gems
{
    public class Amethyst : Gem
    {
        private const int strengthBonus = 2;
        private const int agilityBonus = 8;
        private const int vitalityBonus = 4;

        public Amethyst(LevelsOfClarity levelsOfClarity)
            : base(strengthBonus, agilityBonus, vitalityBonus, levelsOfClarity)
        {
        }
    }
}
