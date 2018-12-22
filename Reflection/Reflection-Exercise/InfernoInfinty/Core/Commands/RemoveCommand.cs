using InfernoInfinty.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfernoInfinty.Core.Commands
{
    public class RemoveCommand : Command
    {
        [Inject]
        IWeaponRepository weaponRepository;

        public RemoveCommand(string[] data, IWeaponRepository weaponRepository)
            : base(data)
        {
            this.weaponRepository = weaponRepository;
        }

        public override void Execute()
        {
            string name = Data[1];
            int index = int.Parse(Data[2]);
            Weapon weapon = weaponRepository.GetWeapon(name);
            weapon.RemoveGem(index);
        }
    }
}
