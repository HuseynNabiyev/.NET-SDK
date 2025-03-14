using BankingSystem.Data;
using BankingSystem.Models;
using BankingSystem.Repositories;
using BankingSystem.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace BankingSystem
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<AppDbContext>()
                .AddScoped(typeof(IRepository<>), typeof(Repository<>))
                .AddScoped<IAccountService, AccountService>()
                .BuildServiceProvider();

            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                await dbContext.Database.EnsureCreatedAsync();

                var accountService = scope.ServiceProvider.GetRequiredService<IAccountService>();

                // Create accounts
                var account1 = await accountService.CreateAccountAsync("123456", 1000);
                var account2 = await accountService.CreateAccountAsync("654321", 500);

                // Perform transactions
                await accountService.DepositAsync(account1.Id, 200);
                await accountService.WithdrawAsync(account1.Id, 100);
                await accountService.TransferAsync(account1.Id, account2.Id, 300);

                // Display account details
                var updatedAccount1 = await accountService.GetAccountDetailsAsync(account1.Id);
                var updatedAccount2 = await accountService.GetAccountDetailsAsync(account2.Id);

                Console.WriteLine($"Account {updatedAccount1.AccountNumber} Balance: {updatedAccount1.Balance}");
                Console.WriteLine($"Account {updatedAccount2.AccountNumber} Balance: {updatedAccount2.Balance}");
            }
        }
    }
}