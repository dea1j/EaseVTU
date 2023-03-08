using System;
namespace EaseVTU.Data
{
    public class Recharge
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string? PaymentGatewayTransactionId { get; set; }
    }
}

