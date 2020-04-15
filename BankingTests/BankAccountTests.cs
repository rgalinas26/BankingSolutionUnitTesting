using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class BankAccountTests
    {
        BankAccount Account;
        decimal OpeningBalance;

        public BankAccountTests()
        {
            Account = new BankAccount(new Mock<ICalculateAccountBonuses>().Object,
                new Mock<INotifyTheFeds>().Object);
            OpeningBalance = Account.GetBalance();
        }
        [Fact]
        public void NewAccountsHaveAppropriateBalance()
        {

            Assert.Equal(1200M, OpeningBalance);
        }

        [Fact]
        public void DepositingIncreasesBalance()
        {
            var amountToDeposit = 100M;

            Account.Deposit(amountToDeposit);

            Assert.Equal(OpeningBalance + 100M, Account.GetBalance());
        }

        [Fact]
        public void WithdrawlsDecreaseBalance()
        {
            var amountToWithdraw = 100M;

            Account.Withdraw(amountToWithdraw);

            Assert.Equal(OpeningBalance - 100M, Account.GetBalance());
        }

        public class DummyBonusCalculator : ICalculateAccountBonuses
        {
            public decimal GetDepositBonusFor(decimal balance, decimal amountToDeposit)
            {
                return 0;
            }
        }
    }
}
