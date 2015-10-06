namespace BigRoom.Service.Models.CartVms
{
    public class CartItemVM
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal ShippingPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public string Comment { get; set; }
    }
}