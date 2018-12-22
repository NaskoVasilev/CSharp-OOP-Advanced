using Moq;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class HeroTests
    {
        private const string HeroName = "Pesho";

        [Test]
        public void HeroGainsXPIfTargetDies()
        {
            Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();
            Hero hero = new Hero(HeroName, fakeWeapon.Object);
            Mock<ITarget> fakeTarget = new Mock<ITarget>();

            fakeTarget.Setup(p => p.Health)
                .Returns(0);
            fakeTarget.Setup(p => p.GiveExperience())
                .Returns(10);
            fakeTarget.Setup(p => p.IsDead())
                .Returns(true);

            hero.Attack(fakeTarget.Object);

            int expectedExperience = 10;
            int actualExperience = hero.Experience;

            Assert.AreEqual(actualExperience, expectedExperience);
        }
    }
}