using System;

class Business
{
    private double buyingPrice;
    private double transportCost;
    private double sellingPrice;

    // Constructor with parameters
    public Business(double buyingPrice, double transportCost, double sellingPrice)
    {
        this.buyingPrice = buyingPrice;
        this.transportCost = transportCost;
        this.sellingPrice = sellingPrice;
    }

    // Default constructor
    public Business() : this(0, 0, 0) { }

    public void CalculateProfitOrLoss()
    {
        double totalCost = buyingPrice + transportCost;
        double profitOrLoss = sellingPrice - totalCost;

        if (profitOrLoss > 0)
        {
            Console.WriteLine($"Profit made: {profitOrLoss}");
        }
        else if (profitOrLoss < 0)
        {
            Console.WriteLine($"Loss incurred: {Math.Abs(profitOrLoss)}");
        }
        else
        {
            Console.WriteLine("No profit, no loss.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Business business = new Business(100, 20, 150);
        business.CalculateProfitOrLoss();
    }
}