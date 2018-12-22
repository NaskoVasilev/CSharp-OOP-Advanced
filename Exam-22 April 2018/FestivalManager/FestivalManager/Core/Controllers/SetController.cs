namespace FestivalManager.Core.Controllers
{
	using System.Text;
	using System.Linq;

	using Contracts;
	using Entities.Contracts;

	public class SetController : ISetController
	{
		private readonly IStage stage;

		public SetController(IStage stage)
		{
			this.stage = stage;
		}

		public string PerformSets()
		{
			StringBuilder sb = new StringBuilder();

			int setCount = 1;

			var sortedSets = this.stage.Sets
				.OrderByDescending(s => s.ActualDuration)
				.ThenByDescending(s => s.Performers.Count)
				.ToArray();

			foreach (ISet set in sortedSets)
			{
				sb.AppendLine($"{setCount++}. {set.Name}:");

				bool setWasSuccessful = set.CanPerform();

				if (!setWasSuccessful)
				{
					sb.AppendLine("-- Did not perform");
					continue;
				}

				int songCount = 1;
				foreach (ISong song in set.Songs)
				{
					sb.AppendLine($"-- {songCount++}. {song}");

					foreach (IPerformer performer in set.Performers)
					{
						foreach (IInstrument instrument in performer.Instruments)
						{
							instrument.WearDown();
						}
					}
				}

				sb.AppendLine("-- Set Successful");
			}

			return sb.ToString().TrimEnd('\r', '\n');
		}
	}
}
