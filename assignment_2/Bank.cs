using System;

class BankAccount
{
    public string AccountNumber;
    public string HolderName;
    public double Balance;

    public BankAccount(string number, string name, double balance)
    {
        AccountNumber = number;
        HolderName = name;
        Balance = balance;
    }

    public void Deposit(double amount)
    {
        Balance += amount;
        Console.WriteLine($"Deposited: {amount}, New Balance: {Balance}");
    }

    public virtual void Withdraw(double amount) { }

    public void CheckBalance()
    {
        Console.WriteLine($"Balance: {Balance}");
    }
}

class SavingAccount : BankAccount
{
    public SavingAccount(string number, string name, double balance)
        : base(number, name, balance) { }

    public override void Withdraw(double amount)
    {
        if (Balance >= amount)
        {
            Balance -= amount;
            Console.WriteLine($"Withdrew: {amount}, New Balance: {Balance}");
        }
        else
        {
            Console.WriteLine("Withdrawal denied. Insufficient funds.");
        }
    }

    public void ApplyInterest(double rate)
    {
        double interest = Balance * rate;
        Balance += interest;
        Console.WriteLine($"Interest applied: {interest}, New Balance: {Balance}");
    }
}

class CurrentAccount : BankAccount
{
    private double overdraftLimit;

    public CurrentAccount(string number, string name, double balance, double overdraft)
        : base(number, name, balance)
    {
        overdraftLimit = overdraft;
    }

    public override void Withdraw(double amount)
    {
        if (Balance - amount >= -overdraftLimit)
        {
            Balance -= amount;
            Console.WriteLine($"Withdrew: {amount}, New Balance: {Balance}");
        }
        else
        {
            Console.WriteLine("Withdrawal denied. Overdraft limit exceeded.");
        }
    }
}

class Program
{
    static void Main()
    {
        SavingAccount sav = new SavingAccount("S001", "Alice", 5000);
        sav.Deposit(1000);
        sav.Withdraw(2000);
        sav.ApplyInterest(0.05);

        Console.WriteLine();

        CurrentAccount cur = new CurrentAccount("C001", "Bob", 3000, 1000);
        cur.Deposit(500);
        cur.Withdraw(3800);  // Should be allowed within overdraft
        cur.Withdraw(1000);  // Should be denied
    }
}
