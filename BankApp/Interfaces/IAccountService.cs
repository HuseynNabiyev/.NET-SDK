using BankApp.Models; // Add this line

namespace BankApp.Interfaces
{
    public interface IAccountService
    {
        void AddAccount(Account account); // Ensure this method is defined
        void Deposit(string accountNumber, decimal amount);
        void Withdraw(string accountNumber, decimal amount);
        void DisplayBalance(string accountNumber);
    }
}