using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private const int AxeAttack = 10;
        private const int AxeDurability = 10;
        private const int DummyHealth = 20;
        private const int DummyExperience = 20;
        Axe axe;
        Dummy dummy;

        [SetUp]
        public void SetUp()
        {
            this.axe = new Axe(AxeAttack,AxeDurability);
            this.dummy = new Dummy(DummyHealth, DummyExperience);
        }

        [Test]
        public void DummyLosesHealthIfAttacked()
        {
            axe.Attack(dummy);
            int expectdHealth = 10;
            Assert.AreEqual(dummy.Health, expectdHealth, "Dummy does not lose health after attack!");
        }

        [Test]
        public void DeadDummyThrowsAnExceptionIfAttacked()
        {
            axe.Attack(dummy);
            axe.Attack(dummy);

            Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException
                .With.Message.EqualTo("Dummy is dead."), "Dead dummy does not throws exception after attack!");
        }

        [Test]
        public void DeadDummyCanGiveXP()
        {
            int attackDamage = 30;
            dummy.TakeAttack(attackDamage);
            Assert.That(dummy.GiveExperience(), Is.EqualTo(DummyExperience), "Dead dummy cannot give experience!");
        }

        [Test]
        public void AliveDummyCannotGiveXP()
        {
            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience(), "Alive dummy give experience!");
        }
    }
}
