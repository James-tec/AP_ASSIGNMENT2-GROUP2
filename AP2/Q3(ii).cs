using System;

abstract class BankAccount
{
    public string AccountNumber { get; set; }
    public string HolderName { get; set; }
    public double Balance { get; protected set; }

    public BankAccount(string accNumber, string holderName, double balance)
    {
        AccountNumber = accNumber;
        HolderName = holderName;
        Balance = balance;
    }

    public void Deposit(double amount)
    {
        if (amount > 0)
            Balance += amount;
    }

    public void CheckBalance()
    {
        Console.WriteLine($"Balance: {Balance}");
    }

    public abstract void Withdraw(double amount);
}

class SavingsAccount : BankAccount
{
    public double InterestRate { get; set; }

    public SavingsAccount(string accNumber, string holderName, double balance, double interestRate)
        : base(accNumber, holderName, balance)
    {
        InterestRate = interestRate;
    }

    public override void Withdraw(double amount)
    {
        if (amount <= Balance)
        {
            Balance -= amount;
        }
        else
        {
            Console.WriteLine("Insufficient balance in savings account.");
        }
    }

    public void AddInterest()
    {
        Balance += Balance * InterestRate / 100;
    }
}

class CurrentAccount : BankAccount
{
    public double OverdraftLimit { get; set; }

    public CurrentAccount(string accNumber, string holderName, double balance, double overdraftLimit)
        : base(accNumber, holderName, balance)
    {
        OverdraftLimit = overdraftLimit;
    }

    public override void Withdraw(double amount)
    {
        if (Balance - amount >= -OverdraftLimit)
        {
            Balance -= amount;
        }
        else
        {
            Console.WriteLine("Withdrawal exceeds overdraft limit.");
        }
    }
}

// Example usage
class Program
{
    static void Main()
    {
        SavingsAccount savings = new SavingsAccount("S123", "Alice", 1000, 5);
        savings.Deposit(200);
        savings.Withdraw(500);
        savings.AddInterest();
        savings.CheckBalance();

        CurrentAccount current = new CurrentAccount("C123", "Bob", 500, 300);
        current.Withdraw(700); // Allowed
        current.Withdraw(200); // Exceeds overdraft
        current.CheckBalance();
    }
}
