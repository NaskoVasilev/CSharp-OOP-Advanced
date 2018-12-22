using InfernoInfinty.Core.Commands;
using System;
using InfernoInfinty.Models.Weapons;
using System.Collections.Generic;

namespace InfernoInfinty.Core
{
    public class WeaponRepository : IWeaponRepository
    {
        private IDictionary<string, Weapon> weapons;

        public WeaponRepository()
        {
            this.weapons = new Dictionary<string, Weapon>();
        }

        public void AddWeapon(Weapon weapon)
        {
            if (this.weapons.ContainsKey(weapon.Name))
            {
                throw new InvalidOperationException("There is weapon with such name yet!");
            }
            this.weapons.Add(weapon.Name, weapon);
        }

        public Weapon GetWeapon(string name)
        {
            CheckWeaponExists(name);
            return this.weapons[name];
        }

        public void RemoveWeapon(Weapon weapon)
        {
            CheckWeaponExists(weapon.Name);
            this.weapons.Remove(weapon.Name);
        }

        private void CheckWeaponExists(string name)
        {
            if (!this.weapons.ContainsKey(name))
            {
                throw new InvalidOperationException("There is no such weapon!");
            }
        }
    }
}
