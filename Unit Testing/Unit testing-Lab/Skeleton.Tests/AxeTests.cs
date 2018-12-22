using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private const int AxeAttack = 2;
        private const int AxeDurability = 2;
        private const int DummyHealth = 10;
        private const int DummyExperience = 10;
        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void SetUp()
        {
            this.axe = new Axe(AxeAttack, AxeDurability);
            this.dummy = new Dummy(DummyHealth, DummyExperience);
        }

        [Test]
        public void WeaponLosesDurabilityAfterEachAttack()
        {
            axe.Attack(dummy);
            Assert.AreEqual(axe.DurabilityPoints, 1, "Durability does not change after attack!");
        }

        [Test]
        public void AttackWithBrokenWeaponnShouldThrowException()
        {
            axe.Attack(dummy);
            axe.Attack(dummy);

            Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException
                .With.Message.EqualTo("Axe is broken."), "Broken axe still can attack!");
        }
    }
}
