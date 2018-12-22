using System.Collections.Generic;

public interface IWareHouse
{
    void EquipArmy(IArmy army);

    bool TryEquipSoldier(ISoldier soldier);

    void AddAmmunition(IList<IAmmunition> ammunitionsToAdd,string ammunitionName);
}
