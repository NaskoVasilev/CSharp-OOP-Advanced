using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Soldier : ISoldier
{
    private double endurance;
    private const double MaxEndurance = 100;

    protected Soldier(string name, int age, double experience, double endurance)
    {
        Name = name;
        Age = age;
        Experience = experience;
        Endurance = endurance;
        this.Weapons = new Dictionary<string, IAmmunition>();

        this.AddWeapons();
    }

    public IDictionary<string, IAmmunition> Weapons { get;  }
    
    protected abstract IReadOnlyList<string> WeaponsAllowed { get; }

    public string Name { get; private set; }

    public int Age { get; private set; }

    public double Experience { get; private set; }

    public double Endurance
    {
        get
        {
            return this.endurance;
        }
        protected set
        {
            this.endurance = Math.Min(value, MaxEndurance);
        }
    }

    protected abstract double OverallSkillMultilier { get; }

    public double OverallSkill => (this.Age + this.Experience) * OverallSkillMultilier;

    public bool ReadyForMission(IMission mission)
    {
        if (this.Endurance < mission.EnduranceRequired)
        {
            return false;
        }

        bool hasAllEquipment = this.Weapons.Values.Count(weapon => weapon == null) == 0;

        if (!hasAllEquipment)
        {
            return false;
        }

        return this.Weapons.Values.Count(weapon => weapon.WearLevel <= 0) == 0;
    }
    
    public override string ToString() => string.Format(OutputMessages.SoldierToString, this.Name, this.OverallSkill);

    public abstract void Regenerate();

    public void CompleteMission(IMission mission)
    {
        this.Endurance -= mission.EnduranceRequired;
        this.Experience += mission.EnduranceRequired;
        this.AmmunitionRevision(mission.WearLevelDecrement);
    }

    private void AmmunitionRevision(double missionWearLevelDecrement)
    {
        IEnumerable<string> keys = this.Weapons.Keys.ToList();

        foreach (string weaponName in keys)
        {
            this.Weapons[weaponName].DecreaseWearLevel(missionWearLevelDecrement);

            if (this.Weapons[weaponName].WearLevel <= 0)
            {
                this.Weapons[weaponName] = null;
            }
        }
    }

    private void AddWeapons()
    {
        foreach (string weapon in this.WeaponsAllowed)
        {
            this.Weapons.Add(weapon, null);
        }
    }
}