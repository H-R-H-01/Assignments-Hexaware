using System;
using System.Collections.Generic;

namespace BankingSystem.main
{
    // Task 1: Loan Eligibility
    public class LoanEligibility
    {
        public static void CheckEligibility(int creditScore, int income)
        {
            Console.WriteLine($"\n\nUser's Credit Score: {creditScore} \nUser's Annual Income: {income}\n\n");

            if (creditScore > 700 && income > 50000)
            {
                Console.WriteLine("You are eligible for the Loan.");
            }
            else
            {
                Console.WriteLine("Your input doesn't meet the requirements for the loan.");
            }
        }
    }

    // Task 2: Banking Transaction System
    public class BankingTransaction
    {
        public static void PerformTransaction()
        {
            double balance = 10000;
            int choice = 0;
            do
            {
                Console.WriteLine("\n\nEnter your choice :\n1.Check Balance\n2.Withdraw\n3.Deposit\n4.Exit\n");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine($"Your current Balance is {balance}");
                        break;
                    case 2:
                        Console.WriteLine("Enter the amount to withdraw : ");
                        double withdraw = double.Parse(Console.ReadLine());
                        if ((withdraw < balance) && ((withdraw % 100 == 0) || (withdraw % 500 == 0)))
                        {
                            balance -= withdraw;
                            Console.WriteLine($"Withdrawal successful. Your current balance is {balance}");
                        }
                        else
                        {
                            Console.WriteLine($"\n\n**Enter a valid amount in multiples of 100 or 500. Your current balance is {balance}\n\n");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Enter the amount to deposit : ");
                        double deposit = double.Parse(Console.ReadLine());
                        if (deposit > 0)
                        {
                            balance += deposit;
                            Console.WriteLine($"Deposit successful. Your current balance is {balance}");
                        }
                        else
                        {
                            Console.WriteLine("Enter a valid amount to deposit");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Thank you for using the Transaction Simulator");
                        break;
                    default:
                        Console.WriteLine("Enter a valid choice");
                        break;
                }
            } while (choice != 4);
        }
    }

    // Task 3: Calculate Future Balance for Multiple Customers
    public class CustomerInvestment
    {
        public static void PrintFutureBalance()
        {
            int[] cId = new int[5];
            double[] cBal = new double[5];
            double[] interest = new double[5];
            int[] nYears = new int[5];
            double[] fBal = new double[5];

            for (int i = 0; i < 5; i++)
            {
                cId[i] = i + 1;
                Console.WriteLine($"\nEnter the customer {i}'s Initial Balance : ");
                cBal[i] = double.Parse(Console.ReadLine());
                Console.WriteLine($"\nEnter the customer {i}'s Annual Interest Rate : ");
                interest[i] = double.Parse(Console.ReadLine());
                Console.WriteLine($"\nEnter the customer {i}'s Duration of investment (no. of years) : ");
                nYears[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Customer Id\tBalance\t\tFuture Balance");
            for (int j = 0; j < 5; j++)
            {
                fBal[j] = cBal[j] * Math.Pow((1 + interest[j] / 100), nYears[j]);
                Console.WriteLine($"{cId[j]}\t\t{cBal[j]}\t\t{fBal[j]}");
            }
        }
    }

    // Task 4: Account Balance Checking
    public class AccountBalanceCheck
    {
        public static void CheckAccountBalance()
        {
            int[] cust_id = new int[5] { 1, 2, 3, 4, 5 };
            int[] accNo = new int[5] { 11111111, 22222222, 33333333, 44444444, 55555555 };
            double[] accBal = new double[5] { 1000, 2000, 3000, 4000, 5000 };
            int userInput;
            bool isValid = false;

            do
            {
                Console.WriteLine("Enter your Account No:");
                if (int.TryParse(Console.ReadLine(), out userInput))
                {
                    int index = Array.FindIndex(accNo, acc => acc == userInput);
                    if (index != -1)
                    {
                        Console.WriteLine($"Your account balance is: {accBal[index]}");
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Account Number. Try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Account Number. Try again.");
                }
            } while (!isValid);
        }
    }

    // Task 5: Password Validation
    public class PasswordValidation
    {
        public static void ValidatePassword(string password)
        {
            if (password.Length < 8)
            {
                Console.WriteLine("Password must be at least 8 characters long");
            }
            else if (!password.Any(char.IsUpper))
            {
                Console.WriteLine("Password must contain at least one uppercase letter");
            }
            else if (!password.Any(char.IsDigit))
            {
                Console.WriteLine("Password must contain at least one digit");
            }
            else
            {
                Console.WriteLine("Password is valid.");
            }
        }
    }

    // Task 6: Bank Transactions History
    public class BankTransactions
    {
        public static void ViewTransactions()
        {
            List<string> transactions = new List<string>();

            while (true)
            {
                Console.WriteLine("\nEnter an option:\n1. Deposit\n2. Withdraw\n3. View Transactions\n4. Exit");

                string Choice = Console.ReadLine();

                switch (Choice)
                {
                    case "1":
                        Console.Write("Enter deposit amount: ");
                        decimal depositAmount;
                        if (decimal.TryParse(Console.ReadLine(), out depositAmount))
                        {
                            transactions.Add($"Deposit: ${depositAmount:F2}");
                            Console.WriteLine("Deposit added successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Invalid amount. Please try again.");
                        }
                        break;

                    case "2":
                        Console.Write("Enter withdrawal amount: ");
                        decimal withdrawalAmount;
                        if (decimal.TryParse(Console.ReadLine(), out withdrawalAmount))
                        {
                            transactions.Add($"Withdrawal: ${withdrawalAmount}");
                            Console.WriteLine("Withdrawal added successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Invalid amount. Please try again.");
                        }
                        break;

                    case "3":
                        Console.WriteLine("\nTransaction History:");
                        foreach (string transaction in transactions)
                        {
                            Console.WriteLine(transaction);
                        }
                        break;

                    case "4":
                        Console.WriteLine("Thank you for using the simulator");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }

    // Task 7: Bank Account with Classes and Methods
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public Customer() { }

        public Customer(int customerId, string firstName, string lastName, string emailAddress, string phoneNumber, string address)
        {
            CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        public void PrintDetails()
        {
            Console.WriteLine($"Customer ID: {CustomerId}\nFirst Name: {FirstName}\nLast Name: {LastName}\nEmail Address: {EmailAddress}\nPhone Number: {PhoneNumber}\nAddress: {Address}");
        }
    }

    public class Account
    {
        public int AccountNumber { get; set; }
        public string AccountType { get; set; }
        public double AccountBalance { get; set; }

        public Account() { }

        public Account(int accountNumber, string accountType, double accountBalance)
        {
            AccountNumber = accountNumber;
            AccountType = accountType;
            AccountBalance = accountBalance;
        }

        // Overloaded Deposit Methods
        public void Deposit(float amount)
        {
            AccountBalance += amount;
            Console.WriteLine($"Deposited: {amount}. New Balance: {AccountBalance}");
        }

        public void Deposit(int amount)
        {
            AccountBalance += amount;
            Console.WriteLine($"Deposited: {amount}. New Balance: {AccountBalance}");
        }

        public void Deposit(double amount)
        {
            AccountBalance += amount;
            Console.WriteLine($"Deposited: {amount}. New Balance: {AccountBalance}");
        }

        // Overloaded Withdraw Methods
        public void Withdraw(float amount)
        {
            if (AccountBalance >= amount)
            {
                AccountBalance -= amount;
                Console.WriteLine($"Withdrew: {amount}. New Balance: {AccountBalance}");
            }
            else
            {
                Console.WriteLine("Insufficient balance.");
            }
        }

        public void Withdraw(int amount)
        {
            if (AccountBalance >= amount)
            {
                AccountBalance -= amount;
                Console.WriteLine($"Withdrew: {amount}. New Balance: {AccountBalance}");
            }
            else
            {
                Console.WriteLine("Insufficient balance.");
            }
        }

        public virtual void Withdraw(double amount)
        {
            if (AccountBalance >= amount)
            {
                AccountBalance -= amount;
                Console.WriteLine($"Withdrew: {amount}. New Balance: {AccountBalance}");
            }
            else
            {
                Console.WriteLine("Insufficient balance.");
            }
        }

        public virtual void CalculateInterest()
        {
            Console.WriteLine("Interest calculation is not available for this account type.");
        }
        public void PrintDetails()
        {
            Console.WriteLine($"Account Number: {AccountNumber}\nAccount Type: {AccountType}\nAccount Balance: {AccountBalance}");
        }
    }


    public class Bank
    {
        public void PerformBankingOperations()
        {
            Account account = new Account(11111111, "Savings", 5000.0);
            Console.WriteLine("\nPerforming Banking Operations...");
            account.Deposit(1000);
            account.Withdraw(500);
            account.CalculateInterest();
            account.PrintDetails();
        }
    }
    //Task 8 : Inheritance and polymorphism 
    public class SavingsAccount : Account
    {
        public double InterestRate { get; set; }

        public SavingsAccount(int accountNumber, double accountBalance, double interestRate)
            : base(accountNumber, "Savings", accountBalance)
        {
            InterestRate = interestRate;
        }

        public override void CalculateInterest()
        {
            double interestAmount = AccountBalance * InterestRate / 100;
            AccountBalance += interestAmount;
            Console.WriteLine($"Interest added: {interestAmount}. New Balance: {AccountBalance}");
        }
    }

    public class CurrentAccount : Account
    {
        private const double OverdraftLimit = 1000.0;

        public CurrentAccount(int accountNumber, double accountBalance)
            : base(accountNumber, "Current", accountBalance)
        {
        }

        public override void Withdraw(double amount)
        {
            if (AccountBalance - amount >= -OverdraftLimit)
            {
                AccountBalance -= amount;
                Console.WriteLine($"Withdrew: {amount}. New Balance: {AccountBalance}");
            }
            else
            {
                Console.WriteLine("Withdrawal exceeds overdraft limit.");
            }
        }

        public override void CalculateInterest()
        {
            Console.WriteLine("No interest calculation for Current Accounts.");
        }
    }

    public class BankTask8
    {
        public void ExecuteTask8Operations()
        {
            Account account = null;

            Console.WriteLine("Choose Account Type:\n1. Savings Account\n2. Current Account");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter Account Number:");
                    int savingsAccountNumber = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Initial Balance:");
                    double savingsBalance = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Interest Rate:");
                    double interestRate = double.Parse(Console.ReadLine());
                    account = new SavingsAccount(savingsAccountNumber, savingsBalance, interestRate);
                    break;

                case 2:
                    Console.WriteLine("Enter Account Number:");
                    int currentAccountNumber = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Initial Balance:");
                    double currentBalance = double.Parse(Console.ReadLine());
                    account = new CurrentAccount(currentAccountNumber, currentBalance);
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    return;
            }

            while (true)
            {
                Console.WriteLine("\nChoose an Operation:\n1. Deposit\n2. Withdraw\n3. Calculate Interest\n4. Exit");
                int operation = int.Parse(Console.ReadLine());

                switch (operation)
                {
                    case 1:
                        Console.WriteLine("Enter amount to deposit:");
                        double depositAmount = double.Parse(Console.ReadLine());
                        account.Deposit(depositAmount);
                        break;

                    case 2:
                        Console.WriteLine("Enter amount to withdraw:");
                        double withdrawAmount = double.Parse(Console.ReadLine());
                        account.Withdraw(withdrawAmount);
                        break;

                    case 3:
                        account.CalculateInterest();
                        break;

                    case 4:
                        Console.WriteLine("Exiting banking operations. Thank you!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }
    }

    public abstract class BankAccountTask9
    {
        public string AccountNumber { get; set; }
        public string CustomerName { get; set; }
        public float Balance { get; protected set; }

        // Default Constructor
        public BankAccountTask9()
        {
            AccountNumber = "Unknown";
            CustomerName = "Unknown";
            Balance = 0.0f;
        }

        // Parameterized Constructor
        public BankAccountTask9(string accountNumber, string customerName, float balance)
        {
            AccountNumber = accountNumber;
            CustomerName = customerName;
            Balance = balance;
        }

        // Print Account Information
        public void PrintAccountInfo()
        {
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Customer Name: {CustomerName}");
            Console.WriteLine($"Balance: {Balance:C}");
        }

        // Abstract Methods
        public abstract void Deposit(float amount);
        public abstract void Withdraw(float amount);
        public abstract void CalculateInterest();
    }

    public class SavingsAccountTask9 : BankAccountTask9
    {
        public float InterestRate { get; set; }

        public SavingsAccountTask9(string accountNumber, string customerName, float balance, float interestRate)
            : base(accountNumber, customerName, balance)
        {
            InterestRate = interestRate;
        }

        public override void Deposit(float amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Deposit amount must be positive.");
                return;
            }

            Balance += amount;
            Console.WriteLine($"{amount:C} deposited successfully.");
        }

        public override void Withdraw(float amount)
        {
            if (amount > Balance)
            {
                Console.WriteLine("Insufficient balance.");
                return;
            }

            Balance -= amount;
            Console.WriteLine($"{amount:C} withdrawn successfully.");
        }

        public override void CalculateInterest()
        {
            float interest = Balance * (InterestRate / 100);
            Balance += interest;
            Console.WriteLine($"Interest of {interest:C} added to balance.");
        }
    }

    public class CurrentAccountTask9 : BankAccountTask9
    {
        private const float OverdraftLimit = 1000.0f;

        public CurrentAccountTask9(string accountNumber, string customerName, float balance)
            : base(accountNumber, customerName, balance)
        {
        }

        public override void Deposit(float amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Deposit amount must be positive.");
                return;
            }

            Balance += amount;
            Console.WriteLine($"{amount:C} deposited successfully.");
        }

        public override void Withdraw(float amount)
        {
            if (amount > Balance + OverdraftLimit)
            {
                Console.WriteLine($"Overdraft limit exceeded. Maximum allowed withdrawal is {Balance + OverdraftLimit:C}.");
                return;
            }

            Balance -= amount;
            Console.WriteLine($"{amount:C} withdrawn successfully.");
        }

        public override void CalculateInterest()
        {
            Console.WriteLine("Current accounts do not accrue interest.");
        }
    }

    public class BankTask9
    {
        public void PerformBankingOperations()
        {
            BankAccountTask9 account = null;
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n--- Banking Menu ---");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Calculate Interest");
                Console.WriteLine("5. Display Account Info");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Choose Account Type:");
                        Console.WriteLine("1. Savings Account");
                        Console.WriteLine("2. Current Account");
                        int accountType = int.Parse(Console.ReadLine());

                        Console.Write("Enter Account Number: ");
                        string accountNumber = Console.ReadLine();
                        Console.Write("Enter Customer Name: ");
                        string customerName = Console.ReadLine();
                        Console.Write("Enter Initial Balance: ");
                        float balance = float.Parse(Console.ReadLine());

                        if (accountType == 1)
                        {
                            Console.Write("Enter Interest Rate: ");
                            float interestRate = float.Parse(Console.ReadLine());
                            account = new SavingsAccountTask9(accountNumber, customerName, balance, interestRate);
                        }
                        else if (accountType == 2)
                        {
                            account = new CurrentAccountTask9(accountNumber, customerName, balance);
                        }

                        Console.WriteLine("Account created successfully.");
                        break;

                    case 2:
                        if (account == null)
                        {
                            Console.WriteLine("Please create an account first.");
                            break;
                        }
                        Console.Write("Enter deposit amount: ");
                        float depositAmount = float.Parse(Console.ReadLine());
                        account.Deposit(depositAmount);
                        break;

                    case 3:
                        if (account == null)
                        {
                            Console.WriteLine("Please create an account first.");
                            break;
                        }
                        Console.Write("Enter withdrawal amount: ");
                        float withdrawalAmount = float.Parse(Console.ReadLine());
                        account.Withdraw(withdrawalAmount);
                        break;

                    case 4:
                        if (account == null)
                        {
                            Console.WriteLine("Please create an account first.");
                            break;
                        }
                        account.CalculateInterest();
                        break;

                    case 5:
                        if (account == null)
                        {
                            Console.WriteLine("Please create an account first.");
                            break;
                        }
                        account.PrintAccountInfo();
                        break;

                    case 6:
                        exit = true;
                        Console.WriteLine("Exiting the banking system.");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }


    public class CustomerTask10
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        // Default Constructor
        public CustomerTask10()
        {
            CustomerID = 0;
            FirstName = "Unknown";
            LastName = "Unknown";
            EmailAddress = "Unknown";
            PhoneNumber = "Unknown";
            Address = "Unknown";
        }

        // Parameterized Constructor
        public CustomerTask10(int customerId, string firstName, string lastName, string emailAddress, string phoneNumber, string address)
        {
            CustomerID = customerId;
            FirstName = firstName;
            LastName = lastName;
            SetEmail(emailAddress);
            SetPhoneNumber(phoneNumber);
            Address = address;
        }

        public void SetEmail(string email)
        {
            if (email.Contains("@") && email.Contains("."))
            {
                EmailAddress = email;
            }
            else
            {
                throw new ArgumentException("Invalid email address format.");
            }
        }

        public void SetPhoneNumber(string phoneNumber)
        {
            if (phoneNumber.Length == 10 && long.TryParse(phoneNumber, out _))
            {
                PhoneNumber = phoneNumber;
            }
            else
            {
                throw new ArgumentException("Invalid phone number format. Must be 10 digits.");
            }
        }

        public void PrintCustomerInfo()
        {
            Console.WriteLine($"Customer ID: {CustomerID}");
            Console.WriteLine($"Name: {FirstName} {LastName}");
            Console.WriteLine($"Email: {EmailAddress}");
            Console.WriteLine($"Phone: {PhoneNumber}");
            Console.WriteLine($"Address: {Address}");
        }
    }

    public class AccountTask10
    {
        private static long AccountNumberCounter = 1001;

        public long AccountNumber { get; private set; }
        public string AccountType { get; set; }
        public float AccountBalance { get; private set; }
        public CustomerTask10 Customer { get; set; }

        // Default Constructor
        public AccountTask10()
        {
            AccountNumber = AccountNumberCounter++;
            AccountType = "Unknown";
            AccountBalance = 0.0f;
            Customer = null;
        }

        // Parameterized Constructor
        public AccountTask10(CustomerTask10 customer, string accountType, float initialBalance)
        {
            AccountNumber = AccountNumberCounter++;
            AccountType = accountType;
            AccountBalance = initialBalance;
            Customer = customer;
        }

        public void Deposit(float amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be positive.");
            }

            AccountBalance += amount;
        }

        public void Withdraw(float amount)
        {
            if (amount > AccountBalance)
            {
                throw new InvalidOperationException("Insufficient funds.");
            }

            AccountBalance -= amount;
        }

        public void PrintAccountInfo()
        {
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Account Type: {AccountType}");
            Console.WriteLine($"Balance: {AccountBalance:C}");
            Customer.PrintCustomerInfo();
        }
    }

    public class BankTask10
    {
        private readonly List<AccountTask10> accounts = new();

        public void CreateAccount(CustomerTask10 customer, string accountType, float initialBalance)
        {
            var account = new AccountTask10(customer, accountType, initialBalance);
            accounts.Add(account);
            Console.WriteLine($"Account successfully created with Account Number: {account.AccountNumber}");
        }

        public float GetAccountBalance(long accountNumber)
        {
            var account = FindAccount(accountNumber);
            return account.AccountBalance;
        }

        public void Deposit(long accountNumber, float amount)
        {
            var account = FindAccount(accountNumber);
            account.Deposit(amount);
            Console.WriteLine($"Deposit successful. New Balance: {account.AccountBalance:C}");
        }

        public void Withdraw(long accountNumber, float amount)
        {
            var account = FindAccount(accountNumber);
            account.Withdraw(amount);
            Console.WriteLine($"Withdrawal successful. New Balance: {account.AccountBalance:C}");
        }

        public void Transfer(long fromAccountNumber, long toAccountNumber, float amount)
        {
            var fromAccount = FindAccount(fromAccountNumber);
            var toAccount = FindAccount(toAccountNumber);

            fromAccount.Withdraw(amount);
            toAccount.Deposit(amount);

            Console.WriteLine($"Transfer successful. {amount:C} transferred from {fromAccountNumber} to {toAccountNumber}.");
        }

        public void GetAccountDetails(long accountNumber)
        {
            var account = FindAccount(accountNumber);
            account.PrintAccountInfo();
        }

        private AccountTask10 FindAccount(long accountNumber)
        {
            var account = accounts.Find(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                throw new KeyNotFoundException($"Account with Account Number {accountNumber} not found.");
            }

            return account;
        }
    }

    public class BankAppTask10
    {
        public void RunBankingSystem()
        {
            BankTask10 bank = new BankTask10();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n--- Bank Application Menu ---");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Get Balance");
                Console.WriteLine("3. Deposit");
                Console.WriteLine("4. Withdraw");
                Console.WriteLine("5. Transfer");
                Console.WriteLine("6. Get Account Details");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                try
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("\n--- Create Account ---");
                            Console.Write("Enter Customer ID: ");
                            int customerId = int.Parse(Console.ReadLine());
                            Console.Write("Enter First Name: ");
                            string firstName = Console.ReadLine();
                            Console.Write("Enter Last Name: ");
                            string lastName = Console.ReadLine();
                            Console.Write("Enter Email Address: ");
                            string email = Console.ReadLine();
                            Console.Write("Enter Phone Number: ");
                            string phone = Console.ReadLine();
                            Console.Write("Enter Address: ");
                            string address = Console.ReadLine();
                            CustomerTask10 customer = new CustomerTask10(customerId, firstName, lastName, email, phone, address);

                            Console.Write("Enter Account Type (Savings/Current): ");
                            string accountType = Console.ReadLine();
                            Console.Write("Enter Initial Balance: ");
                            float balance = float.Parse(Console.ReadLine());

                            bank.CreateAccount(customer, accountType, balance);
                            break;

                        case 2:
                            Console.Write("Enter Account Number: ");
                            long accountNumber = long.Parse(Console.ReadLine());
                            Console.WriteLine($"Balance: {bank.GetAccountBalance(accountNumber):C}");
                            break;

                        case 3:
                            Console.Write("Enter Account Number: ");
                            accountNumber = long.Parse(Console.ReadLine());
                            Console.Write("Enter Deposit Amount: ");
                            float depositAmount = float.Parse(Console.ReadLine());
                            bank.Deposit(accountNumber, depositAmount);
                            break;

                        case 4:
                            Console.Write("Enter Account Number: ");
                            accountNumber = long.Parse(Console.ReadLine());
                            Console.Write("Enter Withdrawal Amount: ");
                            float withdrawalAmount = float.Parse(Console.ReadLine());
                            bank.Withdraw(accountNumber, withdrawalAmount);
                            break;

                        case 5:
                            Console.Write("Enter From Account Number: ");
                            long fromAccountNumber = long.Parse(Console.ReadLine());
                            Console.Write("Enter To Account Number: ");
                            long toAccountNumber = long.Parse(Console.ReadLine());
                            Console.Write("Enter Transfer Amount: ");
                            float transferAmount = float.Parse(Console.ReadLine());
                            bank.Transfer(fromAccountNumber, toAccountNumber, transferAmount);
                            break;

                        case 6:
                            Console.Write("Enter Account Number: ");
                            accountNumber = long.Parse(Console.ReadLine());
                            bank.GetAccountDetails(accountNumber);
                            break;

                        case 7:
                            exit = true;
                            Console.WriteLine("Exiting the banking system.");
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }


    public interface ICustomerServiceProvider
    {
        float GetAccountBalance(long accountNumber);
        float Deposit(long accountNumber, float amount);
        float Withdraw(long accountNumber, float amount);
        void Transfer(long fromAccountNumber, long toAccountNumber, float amount);
        void GetAccountDetails(long accountNumber);
    }

    // Interface for Bank Service
    public interface IBankServiceProvider
    {
        void CreateAccount(CustomerTask10 customer, string accountType, float balance);
        AccountTask11[] ListAccounts();
        void CalculateInterest();
    }

    // Base Account Class
    public abstract class AccountTask11
    {
        private static long lastAccNo = 1001; // Static variable for account number generation
        public long AccountNumber { get; private set; }
        public string AccountType { get; set; }
        public float AccountBalance { get; protected set; }
        public CustomerTask10 Customer { get; set; }

        // Constructor
        public AccountTask11(CustomerTask10 customer, string accountType, float initialBalance)
        {
            AccountNumber = lastAccNo++;
            AccountType = accountType;
            AccountBalance = initialBalance;
            Customer = customer;
        }

        public abstract void Deposit(float amount);
        public abstract void Withdraw(float amount);
    }

    // Savings Account
    public class SavingsAccountTask11 : AccountTask11
    {
        private const float MinimumBalance = 500.0f;
        public float InterestRate { get; set; }

        public SavingsAccountTask11(CustomerTask10 customer, float initialBalance, float interestRate)
            : base(customer, "Savings", initialBalance)
        {
            if (initialBalance < MinimumBalance)
                throw new ArgumentException($"Initial balance must be at least {MinimumBalance} for a savings account.");

            InterestRate = interestRate;
        }

        public override void Deposit(float amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be positive.");

            AccountBalance += amount;
        }

        public override void Withdraw(float amount)
        {
            if (AccountBalance - amount < MinimumBalance)
                throw new InvalidOperationException($"Cannot withdraw. Minimum balance of {MinimumBalance} must be maintained.");

            AccountBalance -= amount;
        }

        public void CalculateInterest()
        {
            float interest = AccountBalance * InterestRate / 100;
            AccountBalance += interest;
        }
    }

    // Current Account
    public class CurrentAccountTask11 : AccountTask11
    {
        public float OverdraftLimit { get; set; }

        public CurrentAccountTask11(CustomerTask10 customer, float initialBalance, float overdraftLimit)
            : base(customer, "Current", initialBalance)
        {
            OverdraftLimit = overdraftLimit;
        }

        public override void Deposit(float amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be positive.");

            AccountBalance += amount;
        }

        public override void Withdraw(float amount)
        {
            if (AccountBalance - amount < -OverdraftLimit)
                throw new InvalidOperationException($"Cannot withdraw. Overdraft limit of {-OverdraftLimit} exceeded.");

            AccountBalance -= amount;
        }
    }

    // Zero Balance Account
    public class ZeroBalanceAccountTask11 : AccountTask11
    {
        public ZeroBalanceAccountTask11(CustomerTask10 customer)
            : base(customer, "Zero Balance", 0.0f) { }

        public override void Deposit(float amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be positive.");

            AccountBalance += amount;
        }

        public override void Withdraw(float amount)
        {
            if (AccountBalance - amount < 0)
                throw new InvalidOperationException("Insufficient funds for withdrawal.");

            AccountBalance -= amount;
        }
    }

    // Bank Class Implementing Interfaces
    public class BankTask11 : ICustomerServiceProvider, IBankServiceProvider
    {
        private readonly List<AccountTask11> accounts = new();

        public void CreateAccount(CustomerTask10 customer, string accountType, float balance)
        {
            AccountTask11 account = accountType switch
            {
                "Savings" => new SavingsAccountTask11(customer, balance, 5.0f), // Default 5% interest rate
                "Current" => new CurrentAccountTask11(customer, balance, 10000.0f), // Default overdraft limit
                "ZeroBalance" => new ZeroBalanceAccountTask11(customer),
                _ => throw new ArgumentException("Invalid account type."),
            };

            accounts.Add(account);
            Console.WriteLine($"Account created successfully with Account Number: {account.AccountNumber}");
        }

        public AccountTask11[] ListAccounts()
        {
            return accounts.ToArray();
        }

        public void CalculateInterest()
        {
            foreach (var account in accounts)
            {
                if (account is SavingsAccountTask11 savingsAccount)
                {
                    savingsAccount.CalculateInterest();
                }
            }
        }

        public float GetAccountBalance(long accountNumber)
        {
            var account = FindAccount(accountNumber);
            return account.AccountBalance;
        }

        public float Deposit(long accountNumber, float amount)
        {
            var account = FindAccount(accountNumber);
            account.Deposit(amount);
            return account.AccountBalance;
        }

        public float Withdraw(long accountNumber, float amount)
        {
            var account = FindAccount(accountNumber);
            account.Withdraw(amount);
            return account.AccountBalance;
        }

        public void Transfer(long fromAccountNumber, long toAccountNumber, float amount)
        {
            var fromAccount = FindAccount(fromAccountNumber);
            var toAccount = FindAccount(toAccountNumber);

            fromAccount.Withdraw(amount);
            toAccount.Deposit(amount);

            Console.WriteLine($"Transfer of {amount:C} completed from Account {fromAccountNumber} to Account {toAccountNumber}.");
        }

        public void GetAccountDetails(long accountNumber)
        {
            var account = FindAccount(accountNumber);
            account.Customer.PrintCustomerInfo();
            Console.WriteLine($"Account Number: {account.AccountNumber}, Type: {account.AccountType}, Balance: {account.AccountBalance:C}");
        }

        private AccountTask11 FindAccount(long accountNumber)
        {
            var account = accounts.Find(a => a.AccountNumber == accountNumber);
            if (account == null)
                throw new KeyNotFoundException($"Account with Account Number {accountNumber} not found.");
            return account;
        }
    }

    // Custom Exception for Insufficient Funds
    public class InsufficientFundTask12Exception : Exception
    {
        public InsufficientFundTask12Exception(string message) : base(message) { }
    }

    // Custom Exception for Invalid Account
    public class InvalidAccountTask12Exception : Exception
    {
        public InvalidAccountTask12Exception(string message) : base(message) { }
    }

    // Custom Exception for Overdraft Limit Exceeded
    public class OverDraftLimitTask12Exception : Exception
    {
        public OverDraftLimitTask12Exception(string message) : base(message) { }
    }

    // Abstract Account Class
    public abstract class AccountTask12
    {
        private static long lastAccountNumber = 1000;

        public long AccountNumber { get; }
        public string AccountType { get; set; }
        public float AccountBalance { get; set; }
        public CustomerTask12 Customer { get; set; }

        protected AccountTask12(CustomerTask12 customer, string accountType, float initialBalance)
        {
            AccountNumber = ++lastAccountNumber;
            Customer = customer;
            AccountType = accountType;
            AccountBalance = initialBalance;
        }

        public abstract void Deposit(float amount);
        public abstract void Withdraw(float amount);
    }

    // Savings Account Class
    public class SavingsAccountTask12 : AccountTask12
    {
        public float InterestRate { get; set; }

        public SavingsAccountTask12(CustomerTask12 customer, float initialBalance, float interestRate)
            : base(customer, "Savings", initialBalance)
        {
            if (initialBalance < 500)
                throw new ArgumentException("Savings account requires a minimum balance of 500.");
            InterestRate = interestRate;
        }

        public override void Deposit(float amount)
        {
            AccountBalance += amount;
        }

        public override void Withdraw(float amount)
        {
            if (AccountBalance - amount < 500)
                throw new InsufficientFundTask12Exception("Insufficient funds. Minimum balance of 500 required.");
            AccountBalance -= amount;
        }
    }

    // Current Account Class
    public class CurrentAccountTask12 : AccountTask12
    {
        public float OverdraftLimit { get; set; }

        public CurrentAccountTask12(CustomerTask12 customer, float initialBalance, float overdraftLimit)
            : base(customer, "Current", initialBalance)
        {
            OverdraftLimit = overdraftLimit;
        }

        public override void Deposit(float amount)
        {
            AccountBalance += amount;
        }

        public override void Withdraw(float amount)
        {
            if (AccountBalance - amount < -OverdraftLimit)
                throw new OverDraftLimitTask12Exception($"Overdraft limit of {OverdraftLimit} exceeded.");
            AccountBalance -= amount;
        }
    }

    // Customer Class
    public class CustomerTask12
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public CustomerTask12(int id, string firstName, string lastName)
        {
            CustomerID = id;
            FirstName = firstName;
            LastName = lastName;
        }
    }

    // Customer Service Implementation
    public class CustomerServiceProviderTask12
    {
        protected List<AccountTask12> accountList = new List<AccountTask12>();

        protected AccountTask12 FindAccount(long accountNumber)
        {
            var account = accountList.Find(a => a.AccountNumber == accountNumber);
            if (account == null)
                throw new InvalidAccountTask12Exception($"Account with Account Number {accountNumber} not found.");
            return account;
        }

        public float Deposit(long accountNumber, float amount)
        {
            var account = FindAccount(accountNumber);
            account.Deposit(amount);
            return account.AccountBalance;
        }

        public float Withdraw(long accountNumber, float amount)
        {
            var account = FindAccount(accountNumber);
            account.Withdraw(amount);
            return account.AccountBalance;
        }
    }

    // Bank Service Implementation
    public class BankServiceProviderTask12 : CustomerServiceProviderTask12
    {
        public void CreateAccount(CustomerTask12 customer, string accountType, float balance)
        {
            AccountTask12 account = accountType switch
            {
                "Savings" => new SavingsAccountTask12(customer, balance, 0.03f),
                "Current" => new CurrentAccountTask12(customer, balance, 1000),
                _ => throw new ArgumentException("Invalid account type.")
            };

            accountList.Add(account);
            Console.WriteLine($"Account {account.AccountNumber} created for {customer.FirstName} {customer.LastName}.");
        }

        public AccountTask12[] ListAccounts()
        {
            return accountList.ToArray();
        }
    }

    //




}
