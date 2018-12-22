public class Hard : Mission
{
    private const int HardEnduranceRequired = 80;
    private const string MissionName = "Disposal of terrorists";
    private const int HardWearLevelDecrement = 70;

    public Hard(double scoreToComplete)
        : base(MissionName, HardEnduranceRequired, scoreToComplete, HardWearLevelDecrement)
    {
    }
}
