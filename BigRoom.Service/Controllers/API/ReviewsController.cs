using System;
using System.Collections.Generic;
using System.Web.Http;
using BigRoom.BusinessLayer.Interfaces;
using BigRoom.BusinessLayer.Services;
using BigRoom.BusinessLayer.Util;
using BigRoom.Model;
using BigRoom.Service.Common;
using BigRoom.Service.Models.ProductVms;
using BigRoom.Service.Models.ReviewVms;

namespace BigRoom.Service.Controllers.API
{
    public class ReviewsController : BaseApiController
    {
        #region Fields

        private readonly IProductReviewService reviewService;

        #endregion

        #region Ctor's

        public ReviewsController()
        {
            this.reviewService = new ProductReviewService();
        }

        public ReviewsController(IProductReviewService reviewService)
        {
            this.reviewService = reviewService;
        }

        #endregion

        #region API

        public IEnumerable<ProductReviewVM> Get()
        {
            throw new NotImplementedException();
        }

        public ProductReviewVM Get(int id)
        {
            throw new NotImplementedException();
        }

        [Authorize]
        public IHttpActionResult Post(ReviewRequest reviewRequest)
        {
            if (IsNotValid(reviewRequest))
            {
                return this.BadRequest("Validation failed !");
            }

            ProductReview review = CreateReviewFromRequest(reviewRequest);

            if (reviewService.InsertReview(review))
            {
                return this.Created(review);
            }

            return this.InternalServerError();
        }

        #endregion

        #region Helpers

        private static bool IsNotValid(ReviewRequest review)
        {
            return review.IsNull() || review.Title.IsNullOrEmpty() || review.Comment.IsNullOrEmpty() ||
                   (review.Rating < 1 || review.Rating > 5);
        }

        private ProductReview CreateReviewFromRequest(ReviewRequest reviewRequest)
        {
            return new ProductReview
            {
                Title = reviewRequest.Title,
                Comment = reviewRequest.Comment,
                PostingDate = DateTime.Now,
                Rating = reviewRequest.Rating,
                ProductId = reviewRequest.ProductId,
                UserId = Convert.ToInt32(User.Identity.Name),
                Approved = false
            };
        }

        #endregion
    }
}
