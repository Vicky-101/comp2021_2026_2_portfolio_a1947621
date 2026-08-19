using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>
        {
            new FullTimeEmployee("Bill", 6250m),
            new Contractor("Fred", 50m, 50m)
        };

        foreach (Employee employee in employees)
        {
            decimal pay = employee.CalculatePay();
            decimal tax = pay * Employee.TaxRate;

            Console.WriteLine(
                $"{employee.Name}: Pay ${pay}. Tax ${tax}."
            );
        }
    }
}