namespace Travel.Entities.Factories
{
    using Contracts;
    using Items.Contracts;

    using System;
    using System.Linq;
    using System.Reflection;

    public class ItemFactory : IItemFactory
	{
		public IItem CreateItem(string type)
		{
            Type itemType = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == type);

            IItem airplane = (IItem)Activator.CreateInstance(itemType);
            return airplane;
        }
	}
}
