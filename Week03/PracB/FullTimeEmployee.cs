public class FullTimeEmployee : Employee, IReportable
{
    public decimal AnnualSalary { get; set; }

    public FullTimeEmployee(string name, decimal annualSalary)
        : base(name)
    {
        AnnualSalary = annualSalary;
    }

    public override decimal CalculatePay()
    {
        decimal tax = AnnualSalary * TaxRate;

        return AnnualSalary - tax;
    }

    public string GenerateReport()
    {
        decimal tax = AnnualSalary * TaxRate;

        return $"{Name}: Salary ${AnnualSalary:F2}, Tax ${tax:F2}, Pay ${CalculatePay():F2}";
    }
}