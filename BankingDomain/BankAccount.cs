using System;

namespace BankingDomain
{   
    public class BankAccount
    {
        private decimal balance = 1200;
        public decimal GetBalance()
        {
            return balance;
        }

        public void Deposit(decimal amountToDeposit)
        {
            balance += amountToDeposit;
        }

        public void Withdraw(decimal amountToWithdraw)
        {
            balance -= amountToWithdraw;
        }
    }
}