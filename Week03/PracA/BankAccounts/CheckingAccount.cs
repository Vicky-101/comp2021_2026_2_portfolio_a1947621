public class CheckingAccount : BankAccount
{
    public decimal TransactionFee { get; set; }

    public CheckingAccount(string owner, decimal balance, decimal transactionFee)
        : base(owner, balance)
    {
        TransactionFee = transactionFee;
    }

    public override void Withdraw(decimal amount)
    {
        base.Withdraw(amount + TransactionFee);
    }
}