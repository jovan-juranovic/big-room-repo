using System;

namespace BigRoom.Service.Models.CartVms
{
    public class PaymentVM
    {
        public long CardNumber { get; set; }
        public string NameOnCard { get; set; }
        public DateTime Expiration { get; set; }
    }
}