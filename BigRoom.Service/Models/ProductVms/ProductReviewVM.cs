namespace BigRoom.Service.Models.ProductVms
{
    public class ProductReviewVM
    {
        public int Id { get; set; }
        public string PostingDate { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public string UserEmail { get; set; }
        public string ProductName { get; set; }
    }
}