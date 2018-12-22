using NUnit.Framework;
using System;

namespace BankAccount.Tests
{
    [TestFixture]
    public class BankAccountTests
    {
        [Test]
        public void AccountInitializeWithPositiveValue()
        {
            BankAccount bankAccount = new BankAccount(2000M);

            decimal expectedValue = 2000M;
            decimal actualValue = bankAccount.Amount;

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [Test]
        public void DepositShouldAddMmoney()
        {
            // Arrange
            BankAccount bankAccount = new BankAccount();

            // Act
            bankAccount.Deposit(50);

            // Assert
            Assert.AreEqual(bankAccount.Balance, 50);
        }
    }
}
