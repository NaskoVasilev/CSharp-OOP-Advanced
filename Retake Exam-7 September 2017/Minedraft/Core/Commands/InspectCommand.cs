using System.Collections.Generic;
using System.Linq;

public class InspectCommand : Command
{
    private IProviderController providerController;
    private IHarvesterController harvesterController;

    public InspectCommand(IList<string> arguments, IProviderController providerController, IHarvesterController harvesterController)
        : base(arguments)
    {
        this.providerController = providerController;
        this.harvesterController = harvesterController;
    }

    public override string Execute()
    {
        int id = int.Parse(Arguments[0]);

        IEntity entity = this.providerController.Entities.FirstOrDefault(e => e.ID == id);
        
        if(entity == null)
        {
            entity = this.harvesterController.Entities.FirstOrDefault(e => e.ID == id);
        }

        return entity == null ? string.Format(Constants.EntityNotFound, id)
            : entity.ToString();
    }
}
