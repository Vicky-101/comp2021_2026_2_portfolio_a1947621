using Xunit;

public class EmployeeTests
{
    [Fact]
    public void FullTimeEmployee_CalculatePay_ReturnsCorrectPay()
    {
        Employee employee =
            new FullTimeEmployee("Bill", 6250m);

        decimal result = employee.CalculatePay();

        Assert.Equal(5000m, result);
    }

    [Fact]
    public void Contractor_CalculatePay_ReturnsCorrectPay()
    {
        Employee employee =
            new Contractor("Fred", 50m, 50m);

        decimal result = employee.CalculatePay();

        Assert.Equal(2000m, result);
    }

    [Fact]
    public void Employee_Name_ReturnsCorrectName()
    {
        Employee employee =
            new FullTimeEmployee("Bill", 6250m);

        Assert.Equal("Bill", employee.Name);
    }

    [Fact]
    public void Employee_TaxRate_IsTwentyPercent()
    {
        Assert.Equal(0.2m, Employee.TaxRate);
    }
}