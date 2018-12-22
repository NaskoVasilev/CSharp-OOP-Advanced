// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)
namespace FestivalManager.Tests
{
    using System;
    using NUnit.Framework;

    using FestivalManager.Core.Controllers;
    using FestivalManager.Core.Controllers.Contracts;
    using FestivalManager.Entities.Contracts;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Sets;
    using FestivalManager.Entities.Instruments;

    [TestFixture]
	public class SetControllerTests
    {
        private ISetController setController;
        private IStage stage;
        private ISet set;

        [SetUp]
        public void SetUp()
        {
            this.stage = new Stage();
            this.setController = new SetController(stage);
            this.set = new Short("Atanas");
            this.stage.AddSet(set);
        }

		[Test]
	    public void SetCanNotBePtPerformedValidation()
	    {
            string actulaResult = this.setController.PerformSets();
            string expectedResult = "1. Atanas:\r\n-- Did not perform";

            Assert.AreEqual(expectedResult, actulaResult);
        }

        [Test]
        public void ShouldReturnSetsInfo()
        {
            AddPerformerAndSongToSet();

            string actualResult = setController.PerformSets();
            string expectedResult = "1. Atanas:\r\n-- 1. Song (02:20)\r\n-- Set Successful";

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void PerformSetShouldDecreaseInstrumentWearDown()
        {
            AddPerformerAndSongToSet();

            IInstrument instrument = new Guitar();
            IPerformer performer = new Performer("Nasko", 18);
            performer.AddInstrument(instrument);
            ISong song = new Song("Song", new TimeSpan(0, 2, 20));

            set.AddPerformer(performer);
            set.AddSong(song);

            double actualValue = instrument.Wear;
            setController.PerformSets();
            double expectedValue = instrument.Wear;

            Assert.AreNotEqual(expectedValue, actualValue);
        }

        private void AddPerformerAndSongToSet()
        {
            IInstrument instrument = new Guitar();
            IPerformer performer = new Performer("Nasko", 18);
            performer.AddInstrument(instrument);
            ISong song = new Song("Song", new TimeSpan(0, 2, 20));

            set.AddPerformer(performer);
            set.AddSong(song);
        }
    }
}