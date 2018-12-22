using InfernoInfinty.Enums;
using InfernoInfinty.Models.Gems;
using System;
using System.Reflection;
using System.Linq;

namespace InfernoInfinty.Factories
{
    public class GemFactory
    {
        public Gem CreateGem(string[] gemInfo)
        {
            string levelOfClarityAsString = gemInfo[0];
            string gemType = gemInfo[1];
            LevelsOfClarity levelsOfClarity = Enum.Parse<LevelsOfClarity>(levelOfClarityAsString);

            Type type = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(x => x.Name == gemType);
            Gem gem = Activator.CreateInstance(type,levelsOfClarity) as Gem;
            return gem;
        }
    }
}
