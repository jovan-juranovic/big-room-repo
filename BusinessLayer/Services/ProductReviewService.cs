using System.Collections.Generic;
using System.Linq;
using BigRoom.BusinessLayer.Interfaces;
using BigRoom.DataAccessLayer.UnitOfWork;
using BigRoom.Model;

namespace BigRoom.BusinessLayer.Services
{
    public class ProductReviewService : IProductReviewService
    {
        public IEnumerable<ProductReview> GetUnapprovedReviews()
        {
            using (var uow = new UnitOfWork())
            {
                return uow.ReviewRepository.GetAll(
                    filter: review => review.Approved == false,
                    orderBy: review => review.OrderBy(x => x.PostingDate),
                    includeProperties: "User,Product");
            }
        }

        public IEnumerable<ProductReview> GetReviewsByProduct(int productId)
        {
            using (var uow = new UnitOfWork())
            {
                return uow.ReviewRepository.GetAll(
                    filter: review => review.ProductId == productId && review.Approved,
                    orderBy: review => review.OrderBy(x => x.Rating),
                    includeProperties: "User");
            }
        }

        public bool InsertReview(ProductReview review)
        {
            using (var uow = new UnitOfWork())
            {
                uow.ReviewRepository.Insert(review);
                return uow.Save() == 1;
            }
        }
    }
}
