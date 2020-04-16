using System;

namespace BankingDomain
{
    public class BankAccount : IGiveFederalRegulatorsAccountInformation
    {
        private decimal balance = 1200;
        private ICalculateAccountBonuses BonusCalculator;
        private INotifyTheFeds Feds;

        public BankAccount(ICalculateAccountBonuses bonusCalculator, INotifyTheFeds feds)
        {
            BonusCalculator = bonusCalculator;
            Feds = feds;
        }

        public int AccountNumber { get; set; }
        public virtual decimal GetBalance()
        {
            return balance;
        }

        public void Deposit(decimal amountToDeposit)
        {
            decimal bonus = BonusCalculator.GetDepositBonusFor(balance, amountToDeposit);
            balance += amountToDeposit + bonus;
        }

        public void Withdraw(decimal amountToWithdraw)
        {
            if (amountToWithdraw > balance)
            {
                throw new OverdraftException();
            }
            else
            {
                balance -= amountToWithdraw;
                Feds.Notify(this, amountToWithdraw);
            }
        }
    }
}