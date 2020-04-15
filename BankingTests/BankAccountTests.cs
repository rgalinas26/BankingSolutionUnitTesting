using BankingDomain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class BankAccountTests
    {
        [Fact]
        public void NewAccountsHaveAppropriateBalance()
        {
            BankAccount account = new BankAccount();
            decimal balance = account.GetBalance();

            Assert.Equal(1200M, balance);
        }

        [Fact]
        public void DepositingIncreasesBalance()
        {
            var account = new BankAccount();
            var openingBalance = account.GetBalance();
            var amountToDeposit = 100M;

            account.Deposit(amountToDeposit);

            Assert.Equal(openingBalance + 100M, account.GetBalance());
        }

        [Fact]
        public void WithdrawlsDecreaseBalance()
        {
            var account = new BankAccount();
            var openingBalance = account.GetBalance();
            var amountToWithdraw = 100M;

            account.Withdraw(amountToWithdraw);

            Assert.Equal(openingBalance - 100M, account.GetBalance());
        }
    }
}
