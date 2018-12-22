using InfernoInfinty.Models.Weapons;

namespace InfernoInfinty.Core.Commands
{
    public interface IWeaponRepository
    {
        void AddWeapon(Weapon weapon);

        void RemoveWeapon(Weapon weapon);

        Weapon GetWeapon(string name);
    }
}
