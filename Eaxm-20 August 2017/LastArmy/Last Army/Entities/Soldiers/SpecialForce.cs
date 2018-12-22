using System.Collections.Generic;

public class SpecialForce : Soldier
{
    private const double overallSkillMiltiplier = 3.5;
    private const double EnduranceIncrease = 30;
    private readonly List<string> weaponsAllowed = new List<string>
        {
            nameof(Gun),
            nameof(AutomaticMachine),
            nameof(MachineGun),
            nameof(RPG),
            nameof(Helmet),
            nameof(Knife),
            nameof(NightVision)
        };

    public SpecialForce(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance)
    {
    }

    protected override IReadOnlyList<string> WeaponsAllowed => this.weaponsAllowed;

    protected override double OverallSkillMultilier => overallSkillMiltiplier;

    public override void Regenerate()
    {
        this.Endurance += EnduranceIncrease + this.Age;
    }
}
