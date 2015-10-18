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
            throw new NotImplementedException();
        }

        public IHttpActionResult Post(AddProductRequestVM request)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Helpers

        #endregion
    }
}
