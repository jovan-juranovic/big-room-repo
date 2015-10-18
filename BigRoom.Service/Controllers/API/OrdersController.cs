using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using BigRoom.BusinessLayer.Interfaces;
using BigRoom.BusinessLayer.Services;
using BigRoom.Model;
using BigRoom.Service.Common;
using BigRoom.Service.Models.CartVms;

namespace BigRoom.Service.Controllers.API
{
    public class OrdersController : BaseApiController
    {
        private readonly ICartService cartService;

        public OrdersController()
        {
            this.cartService = new CartService();
        }

        public OrdersController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        public IHttpActionResult Post(OrderVM order)
        {
            Cart cart = new Cart
            {
                Subtotal = order.Subtotal,
                ShippingTotal = order.ShippingTotal,
                TotalAmount = order.Subtotal + order.ShippingTotal,
                Comment = order.Comment,
                OrderDate = DateTime.Now,
                OrderNumber = Guid.NewGuid(),
                Status = CartStatus.Open,
                UserId = 1,
                CartItems = order.Items.Select(ci => new CartItem
                {
                    Quantity = ci.Quantity,
                    Price = ci.Price,
                    ShippingPrice = ci.ShippingPrice,
                    TotalPrice = ci.Price + ci.ShippingPrice,
                    Comment = ci.Comment,
                    ProductId = ci.Id
                }).ToList(),
                ShippingDetail = new ShippingDetail
                {
                    FullName = order.Customer.FullName,
                    Address1 = order.Customer.Address1,
                    Address2 = order.Customer.Address2,
                    City = order.Customer.City,
                    Region = order.Customer.Region,
                    ZipCode = order.Customer.ZipCode,
                    PhoneNumber = order.Customer.Phone,
                    CountryId = order.Customer.Country
                },
                CreditCard = new CreditCard
                {
                    CardNumber = order.Payment.CardNumber,
                    NameOnCard = order.Payment.NameOnCard,
                    Expiration = order.Payment.Expiration
                }
            };

            if (this.cartService.CreateNewOrder(cart))
            {
                return this.StatusCode(HttpStatusCode.Created);
            }

            return this.InternalServerError();
        }
    }
}
