using System;

public class Business
{
    private decimal buyingPrice;
    private decimal transportCost;
    private decimal sellingPrice;

    // Default constructor
    public Business()
    {
        buyingPrice = 0;
        transportCost = 0;
        sellingPrice = 0;
    }

    // Parameterized constructor
    public Business(decimal buyingPrice, decimal transportCost, decimal sellingPrice)
    {
        this.buyingPrice = buyingPrice;
        this.transportCost = transportCost;
        this.sellingPrice = sellingPrice;
    }

    // Method to calculate profit or loss
    public decimal CalculateProfitOrLoss()
    {
        decimal totalCost = buyingPrice + transportCost;
        return sellingPrice - totalCost;
    }

    // Method to display result
    public void DisplayResult()
    {
        decimal result = CalculateProfitOrLoss();
        if (result > 0)
        {
            Console.WriteLine($"Profit of: {result:C}");
        }
        else if (result < 0)
        {
            Console.WriteLine($"Loss of: {-result:C}");
        }
        else
        {
            Console.WriteLine("No profit, no loss. Break-even.");
        }
    }
}

public class Program
{
    public static void Main()
    {
        Console.Write("Enter buying price: ");
        decimal buyingPrice = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Enter transport cost: ");
        decimal transportCost = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Enter selling price: ");
        decimal sellingPrice = Convert.ToDecimal(Console.ReadLine());

        // Create Business object using parameterized constructor
        Business item = new Business(buyingPrice, transportCost, sellingPrice);
        item.DisplayResult();
    }
}
