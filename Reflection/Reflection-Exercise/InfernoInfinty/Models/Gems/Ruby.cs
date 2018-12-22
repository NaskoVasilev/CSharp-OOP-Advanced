using InfernoInfinty.Enums;

namespace InfernoInfinty.Models.Gems
{
    public class Ruby : Gem
    {
        private const int strengthBonus = 7;
        private const int agilityBonus = 2;
        private const int vitalityBonus = 5;

        public Ruby(LevelsOfClarity levelsOfClarity)
            : base(strengthBonus, agilityBonus, vitalityBonus, levelsOfClarity)
        {
        }
    }
}
