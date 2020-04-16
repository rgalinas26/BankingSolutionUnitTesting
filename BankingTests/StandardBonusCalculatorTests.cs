using BankingDomain;
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
            var bonusCalculator = new TestingBonusCalculator(true);

            var bonus = bonusCalculator.CalculateBonusUsingStandardAlgorithm(10001, 100);

            Assert.Equal(10M, bonus);

        }

        [Fact]
        public void AboveCutoffAfterClose()
        {
            var bonusCalculator = new TestingBonusCalculator(false);

            var bonus = bonusCalculator.CalculateBonusUsingStandardAlgorithm(10001, 100);

            Assert.Equal(5M, bonus);

        }

        [Fact]
        public void BelowCutoffAfterClose()
        {
            var bonusCalculator = new TestingBonusCalculator(false);

            var bonus = bonusCalculator.CalculateBonusUsingStandardAlgorithm(999, 100);

            Assert.Equal(0, bonus);

        }
    }

    public class TestingBonusCalculator : StandardBonusCalculator
    {
        private bool IsBeforeCutoff;
        public TestingBonusCalculator(bool isBeforeCutoff)
        {
            IsBeforeCutoff = isBeforeCutoff;
        }
        protected override bool BeforeCutoff()
        {
            return IsBeforeCutoff;
        }
    }
}
