
using System;

class Business
{
    double buyingPrice, transportCost, sellingPrice;

    // Default constructor
    public Business()
    {
        buyingPrice = 0;
        transportCost = 0;
        sellingPrice = 0;
    }

    // Parameterized constructor
    public Business(double buying, double transport, double selling)
    {
        buyingPrice = buying;
        transportCost = transport;
        sellingPrice = selling;
    }

    public void ComputeProfitOrLoss()
    {
        double totalCost = buyingPrice + transportCost;
        double result = sellingPrice - totalCost;

        if (result > 0)
            Console.WriteLine($"Profit: {result}");
        else if (result < 0)
            Console.WriteLine($"Loss: {-result}");
        else
            Console.WriteLine("No profit, no loss.");
    }

    static void Main()
    {
        Business item = new Business(1000, 200, 1300);
        item.ComputeProfitOrLoss();
    }
}

