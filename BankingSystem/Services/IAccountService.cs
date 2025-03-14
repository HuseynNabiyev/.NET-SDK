using BankingSystem.Models;
using System.Threading.Tasks;

namespace BankingSystem.Services
{
    public interface IAccountService
    {
        Task<Account> CreateAccountAsync(string accountNumber, decimal initialBalance);
        Task DepositAsync(int accountId, decimal amount);
        Task WithdrawAsync(int accountId, decimal amount);
        Task TransferAsync(int fromAccountId, int toAccountId, decimal amount);
        Task<Account> GetAccountDetailsAsync(int accountId);
    }
}