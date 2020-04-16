using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class NotifyFederalRegulatorsTests
    {
        [Fact]
        public void CanDoIt()
        {
            // example of partial mock
            INotifyTheFeds notifier = new NotifyFederalRegulators();
            var accountStub = new Mock<IGiveFederalRegulatorsAccountInformation>();
            accountStub.Setup(b => b.GetBalance()).Returns(5000);
            notifier.Notify(accountStub.Object, 300);
        }
    }
}
