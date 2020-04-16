namespace BankingDomain
{
    public interface IGiveFederalRegulatorsAccountInformation
    {
        int AccountNumber { get; set; }

        decimal GetBalance();
    }
}