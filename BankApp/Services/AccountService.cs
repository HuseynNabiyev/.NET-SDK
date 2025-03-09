using BankApp.Interfaces;
using BankApp.Models; // Add this line
using System.Collections.Generic;

namespace BankApp.Services
{
    public class AccountService : IAccountService
    {
        private readonly Dictionary<string, Account> _accounts;

        public AccountService()
        {
            _accounts = new Dictionary<string, Account>();
        }

        public void AddAccount(Account account) // Ensure this method is implemented
        {
            _accounts[account.AccountNumber] = account;
        }

        public void Deposit(string accountNumber, decimal amount)
        {
            if (_accounts.TryGetValue(accountNumber, out var account))
                account.Deposit(amount);
            else
                throw new KeyNotFoundException("Account not found.");
        }

        public void Withdraw(string accountNumber, decimal amount)
        {
            if (_accounts.TryGetValue(accountNumber, out var account))
                account.Withdraw(amount);
            else
                throw new KeyNotFoundException("Account not found.");
        }

        public void DisplayBalance(string accountNumber)
        {
            if (_accounts.TryGetValue(accountNumber, out var account))
                account.DisplayBalance();
            else
                throw new KeyNotFoundException("Account not found.");
        }
    }
}