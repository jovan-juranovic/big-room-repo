using System.Collections.Generic;
using BigRoom.Model;

namespace BigRoom.BusinessLayer.Interfaces
{
    public interface IProductReviewService
    {
        IEnumerable<ProductReview> GetReviewsByProduct(int productId);
        bool InsertReview(ProductReview review);
        IEnumerable<ProductReview> GetUnapprovedReviews();
    }
}