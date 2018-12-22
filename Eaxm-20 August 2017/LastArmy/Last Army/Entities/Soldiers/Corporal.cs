using System.Collections.Generic;

public class Corporal : Soldier
{
    private const double overallSkillMultiplier = 2.5;
    private const double EnduranceIncrease = 10;
    private readonly List<string> weaponsAllowed = new List<string>
        {
            nameof(Gun),
            nameof(AutomaticMachine),
            nameof(Helmet),
            nameof(Knife),
            nameof(MachineGun)
        };

    public Corporal(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance)
    {
    }

    protected override IReadOnlyList<string> WeaponsAllowed => this.weaponsAllowed;

    protected override double OverallSkillMultilier => overallSkillMultiplier;

    public override void Regenerate()
    {
        this.Endurance += EnduranceIncrease + this.Age;
    }
}
