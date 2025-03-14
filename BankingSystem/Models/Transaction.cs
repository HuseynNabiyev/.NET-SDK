using BankingSystem.Models.Enums;

namespace BankingSystem.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public int AccountId { get; set; }
        public Account? Account { get; set; }
    }
}