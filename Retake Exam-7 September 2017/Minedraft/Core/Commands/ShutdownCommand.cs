using System.Collections.Generic;
using System.Text;

public class ShutdownCommand : Command
{
    private IProviderController providerController;
    private IHarvesterController harvesterController;

    public ShutdownCommand(IList<string> arguments, IProviderController providerController, IHarvesterController harvesterController)
        : base(arguments)
    {
        this.providerController = providerController;
        this.harvesterController = harvesterController;
    }

    public override string Execute()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine(Constants.SystemShutdown);
        sb.AppendLine(string.Format(Constants.TotalEnergyProduced, providerController.TotalEnergyProduced));
        sb.AppendLine(string.Format(Constants.TotalMinedPlumbs, harvesterController.OreProduced));

        return sb.ToString().TrimEnd();
    }
}
