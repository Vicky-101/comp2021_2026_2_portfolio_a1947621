public class SavingsAccount : BankAccount
{
    public decimal InterestRate { get; set; }

    public SavingsAccount(string owner, decimal balance, decimal interestRate)
        : base(owner, balance)
    {
        InterestRate = interestRate;
    }

    public void ApplyInterest()
    {
        decimal interest = Balance * InterestRate;
        Balance += interest;
    }
}