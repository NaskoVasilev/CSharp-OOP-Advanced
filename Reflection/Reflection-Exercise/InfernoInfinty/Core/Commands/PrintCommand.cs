using InfernoInfinty.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfernoInfinty.Core.Commands
{
    public class PrintCommand : Command
    {
        [Inject]
        IWeaponRepository weaponRepository;

        public PrintCommand(string[] data, IWeaponRepository weaponRepository) : base(data)
        {
            this.weaponRepository = weaponRepository;
        }

        public override void Execute()
        {
            string name = Data[1];
            Weapon weapon = weaponRepository.GetWeapon(name);
            Console.WriteLine(weapon.ToString());
        }
    }
}
