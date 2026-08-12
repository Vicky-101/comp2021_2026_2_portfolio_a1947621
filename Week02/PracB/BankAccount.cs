using System;

public class BankAccount
{
    public string Owner {get; set;}
    public decimal Balance {get; set;}
    
    public BankAccount(string owner, decimal balance)
    {
        Owner = owner;
        Balance = balance;
    }
    public void Deposit(decimal amount)
    {
        Balance += amount;
    }
    public void Withdraw(decimal amount)
    {
        if (amount > Balance)
        {
            throw new InvalidOperationException("Insufficient balance.");
        }
        Balance -=amount;
    }

}

 