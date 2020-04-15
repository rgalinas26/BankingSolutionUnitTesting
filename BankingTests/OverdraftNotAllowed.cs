using BankingDomain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class OverdraftNotAllowed
    {
        //[Fact]
        //public void SystemCurrentlyAllowsOverdraftButShouldnt()
        //{
        //    var bankAccount = new BankAccount(null);
        //    var openingBalance = bankAccount.GetBalance();

        //    bankAccount.Withdraw(openingBalance + 1);

        //    Assert.Equal(-1, bankAccount.GetBalance());
        //}

        [Fact]
        public void OverdraftDoesntRemoveMoneyFromTheAccount()
        {
            var bankAccount = new BankAccount(null);
            var openingBalance = bankAccount.GetBalance();

            try
            {
                bankAccount.Withdraw(openingBalance + 1);
            }
            catch (OverdraftException)
            {

                
            }

            Assert.Equal(openingBalance, bankAccount.GetBalance());
        }

        [Fact]
        public void OverdraftThrows()
        {
            var bankAccount = new BankAccount(null);
            var openingBalance = bankAccount.GetBalance();

            Assert.Throws<OverdraftException>(() => bankAccount.Withdraw(openingBalance + 1));

            

        }

        [Fact]
        public void CanTakeAllMoney()
        {
            var bankAccount = new BankAccount(null);

            bankAccount.Withdraw(bankAccount.GetBalance());

            Assert.Equal(0, bankAccount.GetBalance());
        }
    }
}
