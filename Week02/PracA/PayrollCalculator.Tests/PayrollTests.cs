using Xunit;
using System;

public class PayrollTests
{
    [Fact]
    public void Constructor_SetsPropertiesCorrectly()
    {
        Payroll payroll = new Payroll(10, 25m, 0.20m);

        Assert.Equal(10, payroll.Hours);
        Assert.Equal(25m, payroll.Rate);
        Assert.Equal(0.20m, payroll.TaxRate);
    }

    [Fact]
    public void Constructor_ThrowsException_WhenHoursNegative()
    {
        Assert.Throws<ArgumentException>(() =>
            new Payroll(-10, 25m, 0.20m)
        );
    }

    [Fact]
    public void Constructor_ThrowsException_WhenRateNegative()
    {
        Assert.Throws<ArgumentException>(() =>
            new Payroll(10, -25m, 0.20m)
        );
    }

    [Fact]
    public void Constructor_ThrowsException_WhenTaxRateNegative()
    {
        Assert.Throws<ArgumentException>(() =>
            new Payroll(10, 25m, -0.20m)
        );
    }

    [Fact]
    public void Hours_CanBeChanged()
    {
        Payroll payroll = new Payroll(10, 25m, 0.20m);

        payroll.Hours = 20;

        Assert.Equal(20, payroll.Hours);
    }

    [Fact]
    public void Hours_ThrowsException_WhenNegative()
    {
        Payroll payroll = new Payroll(10, 25m, 0.20m);

        Assert.Throws<ArgumentException>(() =>
            payroll.Hours = -5
        );
    }

    [Fact]
    public void Rate_CanBeChanged()
    {
        Payroll payroll = new Payroll(10, 25m, 0.20m);

        payroll.Rate = 30m;

        Assert.Equal(30m, payroll.Rate);
    }

    [Fact]
    public void Rate_ThrowsException_WhenNegative()
    {
        Payroll payroll = new Payroll(10, 25m, 0.20m);

        Assert.Throws<ArgumentException>(() =>
            payroll.Rate = -30m
        );
    }

    [Fact]
    public void TaxRate_CanBeChanged()
    {
        Payroll payroll = new Payroll(10, 25m, 0.20m);

        payroll.TaxRate = 0.25m;

        Assert.Equal(0.25m, payroll.TaxRate);
    }

    [Fact]
    public void TaxRate_ThrowsException_WhenNegative()
    {
        Payroll payroll = new Payroll(10, 25m, 0.20m);

        Assert.Throws<ArgumentException>(() =>
            payroll.TaxRate = -0.25m
        );
    }

    [Fact]
    public void CalculateNetPay_ReturnsCorrectAmount()
    {
        Payroll payroll = new Payroll(10, 25m, 0.20m);

        decimal result = payroll.CalculateNetPay();

        Assert.Equal(200m, result);
    }

    [Fact]
    public void ChangeTaxRate_ChangesTaxRate()
    {
        Payroll payroll = new Payroll(10, 25m, 0.20m);

        payroll.ChangeTaxRate(0.30m);

        Assert.Equal(0.30m, payroll.TaxRate);
    }

    [Fact]
    public void ChangeTaxRate_ThrowsException_WhenNegative()
    {
        Payroll payroll = new Payroll(10, 25m, 0.20m);

        Assert.Throws<ArgumentException>(() =>
            payroll.ChangeTaxRate(-0.30m)
        );
    }
}