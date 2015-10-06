namespace BigRoom.Service.Models.CartVms
{
    public class AddProductRequestVM
    {
        public int ProductId { get; set; }
        public decimal? Price { get; set; }
        public decimal? ShippingPrice { get; set; }
    }
}