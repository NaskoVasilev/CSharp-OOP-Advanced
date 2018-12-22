using System.Collections.Generic;
using System.Linq;

public class RegisterCommand : Command
{
    private IProviderController providerController;
    private IHarvesterController harvesterController;

    public RegisterCommand(IList<string> arguments, IProviderController providerController, IHarvesterController harvesterController)
        : base(arguments)
    {
        this.providerController = providerController;
        this.harvesterController = harvesterController;
    }

    public override string Execute()
    {
        string type = this.Arguments[0];
        string result = "";

        if(type == "Harvester")
        {
            result = harvesterController.Register(this.Arguments.Skip(1).ToList());
        }
        else if(type == "Provider")
        {
            result = providerController.Register(this.Arguments.Skip(1).ToList());
        }

        return result;
    }
}

