using System;

class Program
{
    static void Main()
    {
        FullTimeEmployee fullTime =
            new FullTimeEmployee("Bill", 5000m);

        Contractor contractor =
            new Contractor("Fred", 50m, 40m);

        Console.WriteLine("Full-Time Employee");
        Console.WriteLine(fullTime.GenerateReport());
        Console.WriteLine($"CalculatePay(): ${fullTime.CalculatePay():F2}");

        Console.WriteLine();

        Console.WriteLine("Contractor");
        Console.WriteLine(contractor.GenerateReport());
        Console.WriteLine($"CalculatePay(): ${contractor.CalculatePay():F2}");
    }
}