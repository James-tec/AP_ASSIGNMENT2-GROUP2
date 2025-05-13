using System;

// Abstract base class
public abstract class BankAccount
{
    public string AccountNumber { get; set; }
    public string HolderName { get; set; }
    public decimal Balance { get; protected set; }

    public BankAccount(string accountNumber, string holderName, decimal initialBalance)
    {
        AccountNumber = accountNumber;
        HolderName = holderName;
        Balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            Console.WriteLine($"Deposited {amount:C}. New Balance: {Balance:C}");
        }
        else
        {
            Console.WriteLine("Deposit amount must be positive.");
        }
    }

    public void CheckBalance()
    {
        Console.WriteLine($"Account: {AccountNumber}, Holder: {HolderName}, Balance: {Balance:C}");
    }

    public abstract void Withdraw(decimal amount);
}

// Savings Account
public class SavingsAccount : BankAccount
{
    public decimal InterestRate { get; set; } // in %

    public SavingsAccount(string accountNumber, string holderName, decimal initialBalance, decimal interestRate)
        : base(accountNumber, holderName, initialBalance)
    {
        InterestRate = interestRate;
    }

    public override void Withdraw(decimal amount)
    {
        if (amount <= Balance)
        {
            Balance -= amount;
            Console.WriteLine($"Withdrawn {amount:C} from Savings Account. New Balance: {Balance:C}");
        }
        else
        {
            Console.WriteLine("Withdrawal denied: Insufficient balance.");
        }
    }

    public void ApplyInterest()
    {
        decimal interest = (InterestRate / 100) * Balance;
        Balance += interest;
        Console.WriteLine($"Interest of {interest:C} applied. New Balance: {Balance:C}");
    }
}

// Current Account
public class CurrentAccount : BankAccount
{
    public decimal OverdraftLimit { get; set; }

    public CurrentAccount(string accountNumber, string holderName, decimal initialBalance, decimal overdraftLimit)
        : base(accountNumber, holderName, initialBalance)
    {
        OverdraftLimit = overdraftLimit;
    }

    public override void Withdraw(decimal amount)
    {
        if (Balance - amount >= -OverdraftLimit)
        {
            Balance -= amount;
            Console.WriteLine($"Withdrawn {amount:C} from Current Account. New Balance: {Balance:C}");
        }
        else
        {
            Console.WriteLine("Withdrawal denied: Overdraft limit exceeded.");
        }
    }
}

// Test the implementation
public class Program
{
    public static void Main()
    {
        // Create Savings Account
        SavingsAccount savings = new SavingsAccount("S001", "Alice", 5000m, 5m);
        savings.CheckBalance();
        savings.Deposit(1000m);
        savings.Withdraw(2000m);
        savings.ApplyInterest();
        savings.CheckBalance();

        Console.WriteLine();

        // Create Current Account
        CurrentAccount current = new CurrentAccount("C001", "Bob", 3000m, 1000m);
        current.CheckBalance();
        current.Deposit(500m);
        current.Withdraw(3500m);  // Within overdraft
        current.Withdraw(2000m);  // Exceeds overdraft
        current.CheckBalance();
    }
}
