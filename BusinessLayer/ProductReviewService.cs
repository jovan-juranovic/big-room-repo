using System.Collections.Generic;
using System.Linq;
using BigRoom.DataAccessLayer.UnitOfWork;
using BigRoom.Model;

namespace BigRoom.BusinessLayer
{
    public class ProductReviewService
    {
        public IEnumerable<ProductReview> GetReviewsByProduct(int productId)
        {
            using (var uow = new UnitOfWork())
            {
                return uow.ReviewRepository.GetAll(
                    filter: review => review.ProductId == productId,
                    orderBy: review => review.OrderBy(x => x.Rating),
                    includeProperties: "User");
            }
        }
    }
}
