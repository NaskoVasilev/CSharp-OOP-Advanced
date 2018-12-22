public class Medium : Mission
{
    private const int MediumEnduranceRequired = 50;
    private const string MissionName = "Capturing dangerous criminals";
    private const int MediumWearLevelDecrement = 50;

    public Medium(double scoreToComplete)
        : base(MissionName, MediumEnduranceRequired, scoreToComplete, MediumWearLevelDecrement)
    {
    }
}

