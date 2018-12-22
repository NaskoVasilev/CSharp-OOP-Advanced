using InfernoInfinty.Factories;
using InfernoInfinty.Models.Gems;
using InfernoInfinty.Models.Weapons;

namespace InfernoInfinty.Core.Commands
{
    public class AddCommand : Command
    {
        [Inject]
        private IWeaponRepository weaponRepository;
        [Inject]
        private GemFactory gemFactory;

        public AddCommand(string[] data, IWeaponRepository weaponRepository, GemFactory gemFactory)
            : base(data)
        {
            this.gemFactory = gemFactory;
            this.weaponRepository = weaponRepository;
        }

        public override void Execute()
        {
            string weaponName = Data[1];
            int index = int.Parse(Data[2]);
            string[] gemInfo = Data[3].Split();
            Gem gem = gemFactory.CreateGem(gemInfo);
            Weapon weapon = weaponRepository.GetWeapon(weaponName);
            weapon.AddGem(index, gem);
        }
    }
}
