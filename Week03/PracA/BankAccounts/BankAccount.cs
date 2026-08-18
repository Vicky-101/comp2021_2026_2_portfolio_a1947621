using System;

public class BankAccount
{
    public string Owner {get; set;}
    public decimal Balance {get; protected set;}
    
    public BankAccount(string owner, decimal balance)
    {
        Owner = owner;
        Balance = balance;
    }
    public void Deposit(decimal amount)
    {
        Balance += amount;
    }
    public void Deposit(int amount)
    {
        Balance+=amount;
    }
    public void Deposit(double amount)
    {
        Balance += (decimal) amount;
    }
    public virtual void Withdraw(decimal amount)
    {
        if (amount > Balance)
        {
            throw new InvalidOperationException("Insufficient balance.");
        }
        Balance -=amount;
    }
    public virtual void DisplayAccountInfo()
{
    Console.WriteLine($"Account: {GetType().Name}");
    Console.WriteLine($"Owner: {Owner}");
    Console.WriteLine($"Balance: ${Balance:F2}");
}

}

 