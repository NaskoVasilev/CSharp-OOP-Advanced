using NUnit.Framework;
using System;
using System.Collections.Generic;

public class MissionControllerTests
{
    private MissionController missionController;
    private IArmy army;
    private IWareHouse wareHouse;

    [SetUp]
    public void SetUp()
    {
        army = new Army();
        wareHouse = new WareHouse();
        missionController = new MissionController(army, wareHouse);
    }

    [Test]
    public void PerformMissionShouldReturnFailMessage()
    {
        IMission mission = new Easy(1);
        string result = "";
        for (int i = 0; i < 4; i++)
        {
            result = missionController.PerformMission(mission);
        }

        Assert.IsTrue(result.StartsWith("Mission declined - Suppression of civil rebellion"));
    }

    [Test]
    public void PerformMissionShouldReturnSuccessMessage()
    {
        IMission mission = new Easy(0);

        string result = missionController.PerformMission(mission);
        string expectedResult = "Mission completed - Suppression of civil rebellion";

        Assert.IsTrue(result.StartsWith(expectedResult));
    }

    [Test]
    public void ShouldNotExecuteMission()
    {
        IMission mission = new Easy(1000);
        string result = missionController.PerformMission(mission);
        string expectedResult = "Mission on hold - Suppression of civil rebellion";
        Assert.AreEqual(result, expectedResult);
    }

    [Test]
    public void ShoulExecuteMission()
    {
        AddSoldiers();
        AddAmmunitions();

        wareHouse.AddAmmunition(new List<IAmmunition>() { new MachineGun("MachineGun")
            , new MachineGun("MachineGun") }, "MachineGun");

        IMission mission = new Easy(100);

        string result = missionController.PerformMission(mission);
        string expectedResult = "Mission completed - Suppression of civil rebellion";
        Assert.AreEqual(result, expectedResult);
        Assert.AreEqual(missionController.SuccessMissionCounter, 1);
    }

    [Test]
    public void ShouldDeclineMission()
    {
        string result = missionController.PerformMission(new Hard(1500));
        result += missionController.PerformMission(new Easy(1000));
        result += missionController.PerformMission(new Medium(700));

        string actualResult = missionController.PerformMission(new Hard(50000));
        string expectedResult = "Mission declined - Disposal of terrorists";

        Assert.That(actualResult.StartsWith(expectedResult));
        Assert.AreEqual(missionController.FailedMissionCounter, 1);
    }

    [Test]
    public void FailMissionsOnHoldValidation()
    {
        string result = missionController.PerformMission(new Hard(1500));
        result += missionController.PerformMission(new Easy(1000));
        result += missionController.PerformMission(new Medium(700));

        missionController.FailMissionsOnHold();

        Assert.AreEqual(missionController.FailedMissionCounter, 3);
    }
    private void AddSoldiers()
    {
        army.AddSoldier(new Ranker("Ranker", 20, 30, 40));
        army.AddSoldier(new Corporal("Corporal", 25, 35, 45));
        army.AddSoldier(new SpecialForce("Sepcial", 40, 100, 80));
    }

    private void AddAmmunitions()
    {
        List<IAmmunition> ammunitions = new List<IAmmunition>()
        {
            new Helmet("Helmet"),
            new Helmet("Helmet"),
        };

        wareHouse.AddAmmunition(ammunitions, "Helmet");
        wareHouse.AddAmmunition(new List<IAmmunition>() { new Gun("Gun"), new Gun("Gun") }, "Gun");
        wareHouse.AddAmmunition(new List<IAmmunition>() { new AutomaticMachine("AutomaticMachine")
            , new AutomaticMachine("AutomaticMachine") }, "AutomaticMachine");
        wareHouse.AddAmmunition(new List<IAmmunition>() { new Knife("Knife")
            , new Knife("Knife") }, "Knife");
    }
}

