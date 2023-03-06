using System;
namespace EaseVTU.Data
{
    public class TopUp
    {
        public int TopUpId { get; set; }
        public int ProviderId { get; set; }
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
    }
}
