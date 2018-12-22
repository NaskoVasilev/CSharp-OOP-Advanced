using System.Collections.Generic;
using System.Linq;

public class WareHouse : IWareHouse
{
    private Dictionary<string, IList<IAmmunition>> ammunitions;

    public WareHouse()
    {
        this.ammunitions = new Dictionary<string, IList<IAmmunition>>();
    }

    public void AddAmmunition(IList<IAmmunition> ammunitionsToAdd, string ammunitionName)
    {
        if (!ammunitions.ContainsKey(ammunitionName))
        {
            ammunitions.Add(ammunitionName, ammunitionsToAdd);
        }
        else
        {
            foreach (IAmmunition ammunition in ammunitionsToAdd)
            {
                this.ammunitions[ammunitionName].Add(ammunition);
            }
        }
    }

    public void EquipArmy(IArmy army)
    {
        foreach (ISoldier soldier in army.Soldiers)
        {
            TryEquipSoldier(soldier);
        }
    }

    public bool TryEquipSoldier(ISoldier soldier)
    {
        IList<string> weaponsNames = soldier.Weapons.Keys.
            Where(key => soldier.Weapons[key] == null)
            .ToList();

        bool isEquiped = true;

        foreach (string weaponName in weaponsNames)
        {
            IAmmunition ammunition = this.GetAmmunition(weaponName);

            if (ammunition == null)
            {
                isEquiped = false;
            }
            else
            {
                soldier.Weapons[weaponName] = ammunition;
            }
        }

        return isEquiped;
    }

    private IAmmunition GetAmmunition(string name)
    {
        if (!this.ammunitions.ContainsKey(name) || this.ammunitions[name].Count <= 0)
        {
            return null;
        }

        IAmmunition ammunition = this.ammunitions[name].Last();
        this.ammunitions[name].RemoveAt(this.ammunitions[name].Count - 1);
        return ammunition;
    }
}
