public class Easy : Mission
{
    private const int EasyEnduranceRequired = 20;
    private const string MissionName = "Suppression of civil rebellion";
    private const int EasyWearLevelDecrement = 30;

    public Easy(double scoreToComplete) 
        : base(MissionName, EasyEnduranceRequired, scoreToComplete, EasyWearLevelDecrement)
    {
    }
}
