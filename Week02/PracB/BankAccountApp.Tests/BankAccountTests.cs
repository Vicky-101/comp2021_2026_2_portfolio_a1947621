using Xunit;

public class BankAccountTests
{
    [Fact]
    public void Constructor_SetsOwnerAndBalance()
    {
        BankAccount account = new BankAccount("vicky", 1000m);

        Assert.Equal("vicky", account.Owner);
        Assert.Equal(1000m, account.Balance);
    }

    [Fact]
    public void Deposit_Decimal_IncreasesBalance()
    {
        BankAccount account = new BankAccount("vicky", 1000m);

        account.Deposit(500m);

        Assert.Equal(1500m, account.Balance);
    }

    [Fact]
    public void Deposit_Int_IncreasesBalance()
    {
        BankAccount account = new BankAccount("vicky", 1000m);

        account.Deposit(100);

        Assert.Equal(1100m, account.Balance);
    }

    [Fact]
    public void Deposit_Double_IncreasesBalance()
    {
        BankAccount account = new BankAccount("vicky", 1000m);

        account.Deposit(50.5);

        Assert.Equal(1050.5m, account.Balance);
    }

    [Fact]
    public void Withdraw_WhenBalanceIsEnough_DecreasesBalance()
    {
        BankAccount account = new BankAccount("vicky", 1000m);

        account.Withdraw(200m);

        Assert.Equal(800m, account.Balance);
    }

    [Fact]
    public void Withdraw_WhenBalanceIsTooLow_ThrowsException()
    {
        BankAccount account = new BankAccount("vicky", 1000m);

        Assert.Throws<InvalidOperationException>(() =>
            account.Withdraw(2000m));
    }
}