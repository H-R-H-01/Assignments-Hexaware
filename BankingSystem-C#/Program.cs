using System;
using BankingSystem.main;

namespace BankingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 1: Loan Eligibility
            LoanEligibility.CheckEligibility(750, 60000);

            // Task 2: Banking Transaction System
            BankingTransaction.PerformTransaction();

            // Task 3: Calculate Future Balance for Multiple Customers
            CustomerInvestment.PrintFutureBalance();

            // Task 4: Account Balance Checking
            AccountBalanceCheck.CheckAccountBalance();

            // Task 5: Password Validation
            PasswordValidation.ValidatePassword("Test1234");

            // Task 6: Bank Transactions History
            BankTransactions.ViewTransactions();

            // Task 7: Bank Account with Classes and Methods
            Bank bank = new Bank();
            bank.PerformBankingOperations();

            // Task 8: Inheritance and Polymorphism
            BankTask8 bankTask8 = new BankTask8();
            bankTask8.ExecuteTask8Operations();

            // Task 9: Abstraction
            BankTask9 bankTask9 = new BankTask9();
            bankTask9.PerformBankingOperations();

            // Task 10: Has A Relation / Association
            BankAppTask10 bankApp = new BankAppTask10();
            bankApp.RunBankingSystem();

            // Task 11: Interface/Abstract Class, Single Inheritance, Static Variable
            BankTask11 bank11 = new BankTask11();
            CustomerTask10 customer = new CustomerTask10(1, "John", "Doe", "john.doe@example.com", "9876543210", "123 Main Street");

            bank11.CreateAccount(customer, "Savings", 1000);
            bank11.CreateAccount(customer, "Current", 2000);
            bank11.CreateAccount(customer, "ZeroBalance", 0);

            bank11.Deposit(1001, 500);
            bank11.Withdraw(1002, 1500);
            bank11.Transfer(1001, 1003, 300);
            bank11.GetAccountDetails(1001);

            bank11.CalculateInterest();
            foreach (var account in bank11.ListAccounts())
            {
                bank11.GetAccountDetails(account.AccountNumber);
            }


            //Task12 :  Exception Handling 
            BankServiceProviderTask12 bank12 = new BankServiceProviderTask12();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nBanking System Menu:");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. List All Accounts");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                int choice;

                try
                {
                    choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.Write("Customer ID: ");
                            int id = int.Parse(Console.ReadLine());
                            Console.Write("First Name: ");
                            string firstName = Console.ReadLine();
                            Console.Write("Last Name: ");
                            string lastName = Console.ReadLine();
                            Console.Write("Account Type (Savings/Current): ");
                            string type = Console.ReadLine();
                            Console.Write("Initial Balance: ");
                            float balance = float.Parse(Console.ReadLine());

                            bank12.CreateAccount(new CustomerTask12(id, firstName, lastName), type, balance);
                            break;

                        case 2:
                            Console.Write("Account Number: ");
                            long accNo = long.Parse(Console.ReadLine());
                            Console.Write("Amount to Deposit: ");
                            float depositAmount = float.Parse(Console.ReadLine());
                            float newBalance = bank12.Deposit(accNo, depositAmount);
                            Console.WriteLine($"Deposited {depositAmount:C}. New Balance: {newBalance:C}");
                            break;

                        case 3:
                            Console.Write("Account Number: ");
                            accNo = long.Parse(Console.ReadLine());
                            Console.Write("Amount to Withdraw: ");
                            float withdrawAmount = float.Parse(Console.ReadLine());
                            newBalance = bank12.Withdraw(accNo, withdrawAmount);
                            Console.WriteLine($"Withdrew {withdrawAmount:C}. New Balance: {newBalance:C}");
                            break;

                        case 4:
                            var accounts = bank12.ListAccounts();
                            foreach (var acc in accounts)
                            {
                                Console.WriteLine($"Account Number: {acc.AccountNumber}, Type: {acc.AccountType}, Balance: {acc.AccountBalance:C}");
                            }
                            break;

                        case 5:
                            exit = true;
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Invalid input. {ex.Message}");
                }
                catch (InvalidAccountTask12Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (InsufficientFundTask12Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (OverDraftLimitTask12Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                }
            }



        }
    }
}
