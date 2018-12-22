using InfernoInfinty.Enums;
using InfernoInfinty.Factories;
using InfernoInfinty.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfernoInfinty.Core.Commands
{
    public class CreateCommand : Command
    {
        [Inject]
        private IWeaponRepository weaponRepository;
        [Inject]
        private WeaponFactory weaponFactory;

        public CreateCommand(string[] data, IWeaponRepository weaponRepository, WeaponFactory weaponFactory) : base(data)
        {
            this.weaponFactory = weaponFactory;
            this.weaponRepository = weaponRepository;
        }

        public override void Execute()
        {
            Weapon weapon = this.weaponFactory.CreateWeapon(Data);
            weaponRepository.AddWeapon(weapon);
        }
    }
}
