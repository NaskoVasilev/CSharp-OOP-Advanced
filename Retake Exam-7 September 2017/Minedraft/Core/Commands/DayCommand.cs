using System;
using System.Collections.Generic;

public class DayCommand : Command
{
    private IProviderController providerController;
    private IHarvesterController harvesterController;

    public DayCommand(IList<string> arguments, IProviderController providerController, IHarvesterController harvesterController)
        : base(arguments)
    {
        this.providerController = providerController;
        this.harvesterController = harvesterController;
    }

    public override string Execute()
    {
        string result = providerController.Produce();
        result += Environment.NewLine;
        result += harvesterController.Produce();

        return result;
    }
}
