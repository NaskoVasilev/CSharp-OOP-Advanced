using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core.Commands
{
    public class RetireCommand : Command
    {
        [Inject]
        IRepository repository;

        public RetireCommand(string[] data, IRepository repository) 
            : base(data)
        {
            this.repository = repository;
        }

        public override string Execute()
        {
            string unitType = Data[1];
            repository.RemoveUnit(unitType);
            return $"{unitType} retired!";
        }
    }
}
