using System;
using System.IO;
using Xunit;

public class BankAccountTests
{
    [Fact]
    public void DepositDecimal_IncreasesBalance()
    {
        BankAccount account = new BankAccount("Jordan", 1000m);

        account.Deposit(100m);

        Assert.Equal(1100m, account.Balance);
    }

    [Fact]
    public void DepositInt_IncreasesBalance()
    {
        BankAccount account = new BankAccount("Jordan", 1000m);

        account.Deposit(100);

        Assert.Equal(1100m, account.Balance);
    }

    [Fact]
    public void DepositDouble_IncreasesBalance()
    {
        BankAccount account = new BankAccount("Jordan", 1000m);

        account.Deposit(100.5);

        Assert.Equal(1100.5m, account.Balance);
    }

    [Fact]
    public void Withdraw_ReducesBalance()
    {
        BankAccount account = new BankAccount("Jordan", 1000m);

        account.Withdraw(200m);

        Assert.Equal(800m, account.Balance);
    }

    [Fact]
    public void Withdraw_WhenBalanceTooLow_ThrowsException()
    {
        BankAccount account = new BankAccount("Jordan", 100m);

        Assert.Throws<InvalidOperationException>(() =>
            account.Withdraw(200m));
    }

    [Fact]
    public void ApplyInterest_IncreasesBalance()
    {
        SavingsAccount account =
            new SavingsAccount("Jordan", 1000m, 0.05m);

        account.ApplyInterest();

        Assert.Equal(1050m, account.Balance);
    }

    [Fact]
    public void SavingsAccount_HasCorrectInterestRate()
    {
        SavingsAccount account =
            new SavingsAccount("Jordan", 1000m, 0.05m);

        Assert.Equal(0.05m, account.InterestRate);
    }

    [Fact]
    public void CheckingAccount_Withdraw_DeductsAmountAndFee()
    {
        CheckingAccount account =
            new CheckingAccount("Alex", 1000m, 2m);

        account.Withdraw(100m);

        Assert.Equal(898m, account.Balance);
    }

    [Fact]
    public void CheckingAccount_HasCorrectTransactionFee()
    {
        CheckingAccount account =
            new CheckingAccount("Alex", 1000m, 2m);

        Assert.Equal(2m, account.TransactionFee);
    }

    [Fact]
    public void CheckingAccount_Withdraw_WhenBalanceTooLow_ThrowsException()
    {
        CheckingAccount account =
            new CheckingAccount("Alex", 100m, 2m);

        Assert.Throws<InvalidOperationException>(() =>
            account.Withdraw(100m));
    }

    [Fact]
    public void BankAccount_DisplayAccountInfo_ShowsCorrectInformation()
    {
        BankAccount account =
            new BankAccount("Jordan", 1000m);

        StringWriter output = new StringWriter();
        Console.SetOut(output);

        account.DisplayAccountInfo();

        string result = output.ToString();

        Assert.Contains("Account: BankAccount", result);
        Assert.Contains("Owner: Jordan", result);
        Assert.Contains("Balance: $1000.00", result);
    }

    [Fact]
    public void SavingsAccount_DisplayAccountInfo_ShowsInterestRate()
    {
        SavingsAccount account =
            new SavingsAccount("Jordan", 1500m, 0.035m);

        StringWriter output = new StringWriter();
        Console.SetOut(output);

        account.DisplayAccountInfo();

        string result = output.ToString();

        Assert.Contains("Account: SavingsAccount", result);
        Assert.Contains("Owner: Jordan", result);
        Assert.Contains("Balance: $1500.00", result);
        Assert.Contains("Interest rate: 3.5%", result);
    }

    [Fact]
    public void CheckingAccount_DisplayAccountInfo_ShowsTransactionFee()
    {
        CheckingAccount account =
            new CheckingAccount("Alex", 1000m, 2m);

        StringWriter output = new StringWriter();
        Console.SetOut(output);

        account.DisplayAccountInfo();

        string result = output.ToString();

        Assert.Contains("Account: CheckingAccount", result);
        Assert.Contains("Owner: Alex", result);
        Assert.Contains("Balance: $1000.00", result);
        Assert.Contains("Transaction fee: $2.00", result);
    }
}