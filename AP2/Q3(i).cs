classDiagram 
    class BankAccount { 
        +string AccountNumber 
        +string HolderName 
        +decimal Balance 
        +BankAccount(string accountNumber, string holderName, decimal 
initialBalance) 
        +decimal CheckBalance() 
        +void Deposit(decimal amount) 
        +virtual bool Withdraw(decimal amount) 
    } 
    class SavingsAccount { 
        +decimal InterestRate 
        +SavingsAccount(string accountNumber, string holderName, 
decimal initialBalance, decimal interestRate) 
        +override bool Withdraw(decimal amount) 
        +void ApplyInterest() 
    } 
class CurrentAccount { 
+decimal OverdraftLimit 
+CurrentAccount(string accountNumber, string holderName, 
decimal initialBalance, decimal overdraftLimit) 
+override bool Withdraw(decimal amount) 
} 
BankAccount <|-- SavingsAccount : inherits from 
BankAccount <|-- CurrentAccount : inherits from 

               ┌───────────────────────────┐                
               │BankAccount                │                
               ├───────────────────────────┤                
               │- AccountNumber : string   │                
               │- HolderName : string      │                
               │- Balance : double         │                
               │+ Deposit(amount : double) │                
               │+ Withdraw(amount : double)│                
               │+ CheckBalance()           │                
               └───────────────────────────┘                
                /                        \                    
               /                          \                   
┌───────────────────────────┐  ┌───────────────────────────┐
│SavingsAccount             │  │CurrentAccount             │
├───────────────────────────┤  ├───────────────────────────┤
│- InterestRate : double    │  │- OverdraftLimit : double  │
│+ AddInterest()            │  │+ Withdraw(amount : double)│
│+ Withdraw(amount : double)│  └───────────────────────────┘
└───────────────────────────┘                               