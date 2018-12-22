using System;

namespace BankAccount
{
    public class BankAccount
    {
        public BankAccount()
        {

        }

        public BankAccount(decimal amount)
        {
            Amount = amount;
            this.Balance = 0;
        }

        public decimal Amount { get; private set; }

        public decimal Balance { get;private set; }

        public void Withdraw(decimal amount)
        {
            if(this.Amount<amount)
            {
                throw new ArgumentException("Not enough money in your account!");
            }

            this.Balance -= amount;
        }

        public void Deposit(decimal amount)
        {
            this.Balance += amount;
        }
    }

}
