using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class StandardBonusCalculatorTests
    {
        [Fact]
        public void AboveCutoffAndBeforeClose()
        {
            var fakeSystemTime = new Mock<ISystemTime>();
            var bonusCalculator = new StandardBonusCalculator(fakeSystemTime.Object);
            fakeSystemTime.Setup(f => f.GetCurrent()).Returns(new DateTime(2020, 4, 20, 13, 59, 59));

            var bonus = bonusCalculator.CalculateBonusUsingStandardAlgorithm(10001, 100);

            Assert.Equal(10M, bonus);

        }

        [Fact]
        public void AboveCutoffAfterClose()
        {
            var fakeSystemTime = new Mock<ISystemTime>();
            var bonusCalculator = new StandardBonusCalculator(fakeSystemTime.Object);
            fakeSystemTime.Setup(f => f.GetCurrent()).Returns(new DateTime(2020, 4, 20, 17, 01, 00));

            var bonus = bonusCalculator.CalculateBonusUsingStandardAlgorithm(10001, 100);

            Assert.Equal(5M, bonus);

        }

        [Fact]
        public void BelowCutoffAfterClose()
        {
            var fakeSystemTime = new Mock<ISystemTime>();
            var bonusCalculator = new StandardBonusCalculator(fakeSystemTime.Object);
            fakeSystemTime.Setup(f => f.GetCurrent()).Returns(new DateTime(2020, 4, 20, 13, 01, 00));

            var bonus = bonusCalculator.CalculateBonusUsingStandardAlgorithm(999, 100);

            Assert.Equal(0, bonus);


        }
    }

    //public class TestingBonusCalculator : StandardBonusCalculator
    //{
    //    private bool IsBeforeCutoff;
    //    public TestingBonusCalculator(bool isBeforeCutoff)
    //    {
    //        IsBeforeCutoff = isBeforeCutoff;
    //    }
    //    protected override bool BeforeCutoff()
    //    {
    //        return IsBeforeCutoff;
    //    }
    //}
}
