using InfernoInfinty.Enums;
using InfernoInfinty.Models.Weapons;
using System;
using System.Linq;
using System.Reflection;
namespace InfernoInfinty.Factories
{
    public class WeaponFactory
    {
        public Weapon CreateWeapon(string[] data)
        {
            string[] weaponInfo = data[1].Split();
            string levelOfRarityAsString = weaponInfo[0];
            LevelOfRarity levelOfRarity = Enum.Parse<LevelOfRarity>(levelOfRarityAsString);
            string weaponType = weaponInfo[1];
            string name = data[2];

            Type type = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(x => x.Name == weaponType);
            Weapon weapon = (Weapon)Activator.CreateInstance(type, name, levelOfRarity);
            return weapon;
        }
    }
}
