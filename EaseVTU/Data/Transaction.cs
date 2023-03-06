using System;
namespace EaseVTU.Data
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public TransactionStatus Status { get; set; }
    }
}

