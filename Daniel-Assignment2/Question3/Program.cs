using System;

abstract class BankAccount
{
    public int AccountNum { get; set; }
    public string AccountName { get; set; }
    public double Balance { get; set; }

    public BankAccount(int accountNum, string accountName, double initialBalance)
    {
        AccountNum = accountNum;
        AccountName = accountName;
        Balance = initialBalance;
    }

    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            Console.WriteLine($"Amount deposited is {amount}. New balance is {Balance}");
        } else
        {
            Console.WriteLine("Deposit must be above 0.");
        }
    }

    public void CheckBalance()
    {
        Console.WriteLine($"Account balance is {Balance}");
    }

    public abstract void Withdraw(double amount);
}

class SavingsAccount : BankAccount
{
    public double InterestRate { get; set; }

    public SavingsAccount(int accountNum, string accountName, double initialBalance, double interest) : base(accountNum, accountName, initialBalance)
    {
        InterestRate = interest;
    }

    public override void Withdraw(double amount)
    {
        if (amount > 0 && Balance >= amount)
        {
            Balance -= amount;
            Console.WriteLine($"Amount withdrawn is {amount}. The balance is {Balance}");
        } else
        {
            Console.WriteLine("Insufficient funds for withdrawal.");
        }
    }

    public void AddInterest()
    {
        double interest = Balance * InterestRate / 100;
        Balance += interest;
        Console.WriteLine($"Interest added is {interest}. New balance is {Balance}");
    }
}

class CurrentAccount : BankAccount
{
    public double OverDraft { get; set; }

    public CurrentAccount(int accountNum, string accountName, double initialBalance, double overDraft) : base(accountNum, accountName, initialBalance)
    {
        OverDraft = overDraft;
    }

    public override void Withdraw(double amount)
    {
        if (amount > 0 && Balance - amount >= -OverDraft)
        {
            Balance -= amount;
            Console.WriteLine($"{amount} withdrawn. New balance is {Balance}");
        } else
        {
            Console.WriteLine("Withdrawal exceeds overdraft limit.");
        }
    }
}

class Program
{
    static void Main(string[] args) { 
        SavingsAccount savings = new SavingsAccount(101, "Alice", 5000, 5.0);
        CurrentAccount current = new CurrentAccount(102, "Bob", 2000, 1000);

        savings.Deposit(1000); 
        savings.Withdraw(2000);      
        savings.AddInterest();
        savings.CheckBalance();

        current.Deposit(500);
        current.Withdraw(3000); 
        current.Withdraw(1000); 
        current.CheckBalance();
    }
}
