namespace BankingDomain
{
    public interface INotifyTheFeds
    {
        void Notify(IGiveFederalRegulatorsAccountInformation bankAccount, decimal amountToWithdraw);
    }
}