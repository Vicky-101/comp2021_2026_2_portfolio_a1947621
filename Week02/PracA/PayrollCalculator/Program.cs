using System;

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Enter employee name: ");
            string name = Console.ReadLine() ?? "";

            Console.Write("Hours worked: ");
            double hours = double.Parse(
                Console.ReadLine() ?? ""
            );

            Console.Write("Hourly rate: ");
            decimal rate = decimal.Parse(
                Console.ReadLine() ?? ""
            );

            Payroll payroll = new Payroll(
                hours,
                rate,
                0.20m
            );

            decimal netPay = payroll.CalculateNetPay();

            Console.WriteLine(
                $"{name} earned ${netPay:F2} after tax."
            );
        }
        catch (FormatException)
        {
            Console.WriteLine(
                "Invalid input. Please enter valid numbers."
            );
        }
        catch (ArgumentException error)
        {
            Console.WriteLine(error.Message);
        }
    }
}