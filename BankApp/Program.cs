using BankApp.Models;
using BankApp.Services;
using BankApp.Interfaces;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create account service
            IAccountService accountService = new AccountService();

            // Create accounts
            var savingsAccount = new SavingsAccount("SA001", 1000);
            var checkingAccount = new CheckingAccount("CA001", 500);

            // Add accounts to the service
            accountService.AddAccount(savingsAccount);
            accountService.AddAccount(checkingAccount);

            // Perform operations
            accountService.Deposit("SA001", 200);
            accountService.Withdraw("CA001", 100);

            // Display balances
            accountService.DisplayBalance("SA001");
            accountService.DisplayBalance("CA001");
        }
    }
}