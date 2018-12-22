using System.Collections.Generic;
using System.Linq;
using System.Text;

public class GameController
{
    private IArmy army;
    private IWareHouse wareHouse;
    private IAmmunitionFactory ammunitionFactory;
    private ISoldierFactory soldierFactory;
    private MissionController missionController;
    private IMissionFactory missionFactory;

    public GameController(IArmy army,
        IWareHouse wareHouse,
        IAmmunitionFactory ammunitionFactory,
        ISoldierFactory soldierFactory,
        MissionController missionController,
        IMissionFactory missionFactory)
    {
        this.army = army;
        this.wareHouse = wareHouse;
        this.ammunitionFactory = ammunitionFactory;
        this.soldierFactory = soldierFactory;
        this.missionController = missionController;
        this.missionFactory = missionFactory;
    }

    public void AddWeaponsToWareHouse(string[] args)
    {
        string ammunitionName = args[0];
        int count = int.Parse(args[1]);

        IList<IAmmunition> ammunitions = new List<IAmmunition>();

        for (int i = 0; i < count; i++)
        {
            IAmmunition ammunition = this.ammunitionFactory.CreateAmmunition(ammunitionName);
            ammunitions.Add(ammunition);
        }

        this.wareHouse.AddAmmunition(ammunitions, ammunitionName);
    }


    public string AddSoldierToArmy(string[] args)
    {
        string soldierTypeName = args[0];
        string name = args[1];
        int age = int.Parse(args[2]);
        double experience = double.Parse(args[3]);
        double endurance = double.Parse(args[4]);

        ISoldier soldier = soldierFactory.CreateSoldier(soldierTypeName, name, age, experience, endurance);

        if (wareHouse.TryEquipSoldier(soldier))
        {
            this.army.AddSoldier(soldier);
        }
        else
        {
            return string.Format(OutputMessages.NoWeapon,soldier.GetType().Name, soldier.Name);
        }

        return null;
    }

    public void RegenarateSoldier(string[] args)
    {
        string soldierType = args[1];

        this.army.RegenerateTeam(soldierType);
    }

    public string CompleteMission(string[] args)
    {
        string type = args[0];
        double scoreToComplete = double.Parse(args[1]);

        IMission mission = missionFactory.CreateMission(type, scoreToComplete);
        string result = missionController.PerformMission(mission);

        return result;
    }

    public string GetStatistics()
    {
        missionController.FailMissionsOnHold();

        StringBuilder sb = new StringBuilder();

        sb.AppendLine("Results:");
        sb.AppendLine(string.Format(OutputMessages.SuccessfulMissionsCount, missionController.SuccessMissionCounter));
        sb.AppendLine(string.Format(OutputMessages.FailedMissionsCount, missionController.FailedMissionCounter));
        sb.AppendLine("Soldiers:");
        foreach (ISoldier soldier in army.Soldiers.OrderByDescending(s => s.OverallSkill))
        {
            sb.AppendLine(soldier.ToString());
        }

        return sb.ToString().TrimEnd();
    }
}
