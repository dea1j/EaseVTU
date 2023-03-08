using System;
namespace EaseVTU.Data
{
    public class User
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int PhoneNumber { get; set; }
        public decimal Balance { get; set; }
        public string? PaymentGatewayCustomerId { get; set; }
    }
}

