using InfernoInfinty.Enums;

namespace InfernoInfinty.Models.Gems
{
    public class Emerald : Gem
    {
        private const int strengthBonus = 1;
        private const int agilityBonus = 4;
        private const int vitalityBonus = 9;

        public Emerald(LevelsOfClarity levelsOfClarity)
            : base(strengthBonus, agilityBonus, vitalityBonus, levelsOfClarity)
        {
        }
    }
}
