using System;

public class Payroll
{
    private double hours;
    public double Hours
{
    get
    {
        return hours;
    }
    set
    {
        if (value < 0)
        {
            throw new ArgumentException(
                "Hours cannot be negative."
            );
        }

        hours = value;
    }
}
    private decimal rate;
    public decimal Rate
{
    get
    {
        return rate;
    }
    set
    {
        if (value < 0)
        {
            throw new ArgumentException(
                "Rate cannot be negative."
            );
        }

        rate = value;
    }
}
    private decimal taxRate;
    public decimal TaxRate
{
    get
    {
        return taxRate;
    }
    set
    {
        if (value < 0)
        {
            throw new ArgumentException(
                "Tax rate cannot be negative."
            );
        }

        taxRate = value;
    }
}

    public Payroll(double hours, decimal rate, decimal taxRate)
{
    Hours = hours;
    Rate = rate;
    TaxRate = taxRate;
}
       public decimal CalculateNetPay()
    {
        decimal grossPay = (decimal)hours * rate;
        decimal tax = grossPay * taxRate;
        decimal netPay = grossPay - tax;

        return netPay;
    }
        public void ChangeTaxRate(decimal newTaxRate)
    {
        TaxRate = newTaxRate;
    }
}