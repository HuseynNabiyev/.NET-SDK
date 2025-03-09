namespace BankApp.Models
{
    public class SavingsAccount : Account
    {
        public SavingsAccount(string accountNumber, decimal initialBalance)
            : base(accountNumber, initialBalance) { }

        public override void DisplayBalance()
        {
            Console.WriteLine($"Savings Account {AccountNumber} Balance: {Balance:C}");
        }
    }
}