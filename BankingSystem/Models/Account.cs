namespace BankingSystem.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string? AccountNumber { get; set; } // Mark as nullable
        public decimal Balance { get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}