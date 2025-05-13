using System;

class Business
{
    private double buyingPrice;
    private double transportPrice;
    private double sellingPrice;

    public Business()
    {
        buyingPrice = 0;
        transportPrice = 0;
        sellingPrice = 0;
    }

    public Business(double buyingPrice, double transportPrice, double sellingPrice)
    {
        this.buyingPrice = buyingPrice;
        this.transportPrice = transportPrice;
        this.sellingPrice = sellingPrice;
    }

    public void CalcProf()
    {
        double total = buyingPrice + transportPrice;
        double profit = sellingPrice - total;
        Console.WriteLine($"Your profit is {profit}");
    }

    public void CalcLoss()
    {
        double total = buyingPrice + transportPrice;
        double loss = total - sellingPrice;
        Console.WriteLine($"Your loss is {loss}");
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter buying price: ");
        double buyingPrice = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter selling price: ");
        double sellingPrice = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter transport price: ");
        double transportPrice = Convert.ToDouble(Console.ReadLine());

        Business newItem = new Business(buyingPrice, transportPrice, sellingPrice);

        double total = buyingPrice + transportPrice;

        if (sellingPrice > total)
        {
            newItem.CalcProf();
        }
        else if (sellingPrice < total)
        {
            newItem.CalcLoss();
        }
        else
        {
            Console.WriteLine("No profit, no loss.");
        }
    }
}
