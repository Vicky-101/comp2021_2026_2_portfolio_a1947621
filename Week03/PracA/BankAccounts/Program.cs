using System;

class Program
{
    static void Main()
    {
        SavingsAccount savings =
            new SavingsAccount("Jordan", 1000m, 0.05m);

        Console.WriteLine("Savings Account");
        Console.WriteLine($"Owner: {savings.Owner}");
        Console.WriteLine($"Balance before interest: ${savings.Balance}");

        savings.ApplyInterest();

        Console.WriteLine($"Balance after interest: ${savings.Balance}");

        Console.WriteLine();

        CheckingAccount checking =
            new CheckingAccount("Alex", 1000m, 2m);

        Console.WriteLine("Checking Account");
        Console.WriteLine($"Owner: {checking.Owner}");
        Console.WriteLine($"Balance before withdrawal: ${checking.Balance}");

        checking.Withdraw(100m);

        Console.WriteLine($"Balance after withdrawing $100: ${checking.Balance}");
    }
}