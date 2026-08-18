using System;

class Program
{
    static void Main()
    {
        SavingsAccount savings =
            new SavingsAccount("Jordan", 1000m, 0.05m);

        Console.WriteLine("Before applying interest:");
        savings.DisplayAccountInfo();

        savings.ApplyInterest();

        Console.WriteLine();
        Console.WriteLine("After applying interest:");
        savings.DisplayAccountInfo();

        Console.WriteLine();

        CheckingAccount checking =
            new CheckingAccount("Alex", 1000m, 2m);

        Console.WriteLine("Before withdrawal:");
        checking.DisplayAccountInfo();

        checking.Withdraw(100m);

        Console.WriteLine();
        Console.WriteLine("After withdrawing $100:");
        checking.DisplayAccountInfo();
    }
}