using InfernoInfinty.Enums;

namespace InfernoInfinty.Models.Gems
{
    public abstract class Gem
    {
        public Gem(int strengthBonus, int agilityBonus, int vitalityBonus, LevelsOfClarity levelsOfClarity)
        {
            this.LevelsOfClarity = levelsOfClarity;
            StrengthBonus = strengthBonus + (int)this.LevelsOfClarity;
            AgilityBonus = agilityBonus + (int)this.LevelsOfClarity;
            VitalityBonus = vitalityBonus + (int)this.LevelsOfClarity;
        }

        public int StrengthBonus { get; private set; }

        public int AgilityBonus { get; private set; }

        public int VitalityBonus { get; private set; }

        public LevelsOfClarity LevelsOfClarity { get; private set; }
    }
}
