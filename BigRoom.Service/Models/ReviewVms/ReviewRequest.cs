namespace BigRoom.Service.Models.ReviewVms
{
    public class ReviewRequest
    {
        public string Title { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public int ProductId { get; set; }
    }
}