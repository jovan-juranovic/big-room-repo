using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BigRoom.BusinessLayer.Interfaces;
using BigRoom.BusinessLayer.Services;
using BigRoom.BusinessLayer.Util;
using BigRoom.Model;
using BigRoom.Service.Common;
using BigRoom.Service.Models.CartVms;

namespace BigRoom.Service.Controllers.API
{
    public class CartItemsController : BaseApiController
    {
        #region Fields

        private readonly ICartService cartService;
        private readonly ICartItemService cartItemService;

        #endregion

        #region Ctor's

        public CartItemsController()
        {
            this.cartService = new CartService();
            this.cartItemService = new CartItemService();
        }

        public CartItemsController(ICartService cartService, ICartItemService cartItemService)
        {
            this.cartService = cartService;
            this.cartItemService = cartItemService;
        }

        #endregion

        #region API

        public IEnumerable<CartItemVM> Get()
        {
            int userId = 1;
            Guid cartGuid = this.cartService.GetOrCreateCart(userId);
            return this.cartItemService.GetCartItems(cartGuid).Select(item => new CartItemVM
            {
                Id = item.Id,
                Quantity = item.Quantity,
                Price = item.Price,
                ShippingPrice = item.ShippingPrice,
                Comment = item.Comment,
                TotalPrice = item.TotalPrice
            }).ToList();
        }

        public IHttpActionResult Post(AddProductRequestVM request)
        {
            if (IsNotValid(request))
            {
                return this.BadRequest("Validation failed !");
            }

            CartItem item = CreateItemFromRequest(request);

            if (this.cartItemService.InsertCartItem(item))
            {
                return this.Created(item);
            }

            return this.InternalServerError();
        }

        #endregion

        #region Helpers

        private CartItem CreateItemFromRequest(AddProductRequestVM request)
        {
            int userId = User.Identity.Name.ToInt32();
            Guid cartGuid = this.cartService.GetOrCreateCart(userId);

            return new CartItem
            {
                Quantity = 1,
                Price = request.Price.Value,
                ShippingPrice = request.ShippingPrice.Value,
                ProductId = request.ProductId,
                CartId = cartGuid
            };
        }

        private static bool IsNotValid(AddProductRequestVM request)
        {
            return request.ProductId < 1 || !request.Price.HasValue ||
                   !request.ShippingPrice.HasValue;
        }

        #endregion
    }
}
