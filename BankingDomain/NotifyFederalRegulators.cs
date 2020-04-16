using System;
using System.Collections.Generic;
using System.Text;

namespace BankingDomain
{
    public class NotifyFederalRegulators : INotifyTheFeds
    {
        public void Notify(IGiveFederalRegulatorsAccountInformation bankAccount, decimal amountToWithdraw)
        {
            var balance = bankAccount.GetBalance();
            Console.WriteLine($"An account with the balance of {balance:c} wants to withdraw {amountToWithdraw}");
        }
    }
}
