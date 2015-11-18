using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BigRoom.BusinessLayer.Interfaces;
using BigRoom.BusinessLayer.Services;
using BigRoom.Service.Common;
using BigRoom.Service.Models.HomeVms;

namespace BigRoom.Service.Controllers.API
{
    public class CountingController : BaseApiController
    {
        private readonly IUserService userService;
        private readonly IProductReviewService productReviewService;
        private readonly IProductService productService;
        private readonly ICartService cartService;

        public CountingController()
        {
            this.userService = new UserService();
            this.productReviewService = new ProductReviewService();
            this.productService = new ProductService();
            this.cartService = new CartService();
        }

        public CountingController(IUserService userService, IProductReviewService productReviewService, IProductService productService, ICartService cartService)
        {
            this.userService = userService;
            this.productReviewService = productReviewService;
            this.productService = productService;
            this.cartService = cartService;
        }

        public CountingVM Get()
        {
            return new CountingVM
            {
                OrderCount = this.cartService.GetActiveOrders().Count(),
                ProductCount = this.productService.GetProducts(null).Count(),
                ReviewCount = this.productReviewService.GetUnapprovedReviews().Count(),
                UserCount = this.userService.GetUsers().Count()
            };
        }
    }
}
