using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class BankAccountDepositBonusCalculations
    {
        [Theory]
        [InlineData(100, 42)]
        [InlineData(150, 12)]
        public void DepositUsesTheBonusCalculator(decimal amountToDeposit, decimal expected)
        {
            var stubbedBonusCalculator = new Mock<ICalculateAccountBonuses>();
            var account = new BankAccount(stubbedBonusCalculator.Object, null); ;
            var openingBalance = account.GetBalance();
            stubbedBonusCalculator.Setup(b => b.GetDepositBonusFor(openingBalance, amountToDeposit)).Returns(expected);

            account.Deposit(amountToDeposit);

            Assert.Equal(openingBalance + amountToDeposit + expected, account.GetBalance());
        }
    }
}
