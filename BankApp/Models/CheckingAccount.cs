namespace BankApp.Models
{
    public class CheckingAccount : Account
    {
        public CheckingAccount(string accountNumber, decimal initialBalance)
            : base(accountNumber, initialBalance) { }

        public override void DisplayBalance()
        {
            Console.WriteLine($"Checking Account {AccountNumber} Balance: {Balance:C}");
        }
    }
}