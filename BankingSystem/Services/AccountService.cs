using BankingSystem.Models;
using BankingSystem.Models.Enums; 
using BankingSystem.Repositories;
using System.Threading.Tasks;

namespace BankingSystem.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<Account> _accountRepository;
        private readonly IRepository<Transaction> _transactionRepository;

        public AccountService(IRepository<Account> accountRepository, IRepository<Transaction> transactionRepository)
        {
            _accountRepository = accountRepository;
            _transactionRepository = transactionRepository;
        }

        public async Task<Account> CreateAccountAsync(string accountNumber, decimal initialBalance)
        {
            var account = new Account { AccountNumber = accountNumber, Balance = initialBalance };
            await _accountRepository.AddAsync(account);
            return account;
        }

        public async Task DepositAsync(int accountId, decimal amount)
        {
            var account = await _accountRepository.GetByIdAsync(accountId);
            if (account != null)
            {
                account.Balance += amount;
                await _accountRepository.UpdateAsync(account);
                await _transactionRepository.AddAsync(new Transaction
                {
                    Amount = amount,
                    Type = TransactionType.Deposit,
                    AccountId = accountId
                });
            }
        }

        public async Task WithdrawAsync(int accountId, decimal amount)
        {
            var account = await _accountRepository.GetByIdAsync(accountId);
            if (account != null && account.Balance >= amount)
            {
                account.Balance -= amount;
                await _accountRepository.UpdateAsync(account);
                await _transactionRepository.AddAsync(new Transaction
                {
                    Amount = amount,
                    Type = TransactionType.Withdraw,
                    AccountId = accountId
                });
            }
        }

        public async Task TransferAsync(int fromAccountId, int toAccountId, decimal amount)
        {
            var fromAccount = await _accountRepository.GetByIdAsync(fromAccountId);
            var toAccount = await _accountRepository.GetByIdAsync(toAccountId);

            if (fromAccount != null && toAccount != null && fromAccount.Balance >= amount)
            {
                fromAccount.Balance -= amount;
                toAccount.Balance += amount;

                await _accountRepository.UpdateAsync(fromAccount);
                await _accountRepository.UpdateAsync(toAccount);

                await _transactionRepository.AddAsync(new Transaction
                {
                    Amount = amount,
                    Type = TransactionType.Transfer,
                    AccountId = fromAccountId
                });
            }
        }

        public async Task<Account> GetAccountDetailsAsync(int accountId)
        {
            return await _accountRepository.GetByIdAsync(accountId);
        }
    }
}