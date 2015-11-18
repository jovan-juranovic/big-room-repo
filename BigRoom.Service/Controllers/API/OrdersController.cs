using System;
using System.Collections.Generic;
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
        private readonly ICountryService countryService;
        private readonly IProductService productService;

        public OrdersController()
        {
            this.cartService = new CartService();
            this.countryService = new CountryService();
            this.productService = new ProductService();
        }

        public OrdersController(ICartService cartService, ICountryService countryService, IProductService productService)
        {
            this.cartService = cartService;
            this.countryService = countryService;
            this.productService = productService;
        }

        public IEnumerable<OrderVM> Get()
        {
            return this.cartService.GetActiveOrders().Select(order => new OrderVM
            {
                Id = order.Id,
                Username = order.User.Email,
                OrderNumber = order.OrderNumber.ToString(),
                OrderDate = order.OrderDate.Value.ToString("g"),
                Customer = new CustomerVM
                {
                    Address1 = order.ShippingDetail.Address1,
                    Address2 = order.ShippingDetail.Address2,
                    City = order.ShippingDetail.City,
                    Country = order.ShippingDetail.CountryId,
                    FullName = order.ShippingDetail.FullName,
                    Phone = order.ShippingDetail.PhoneNumber,
                    Region = order.ShippingDetail.Region,
                    ZipCode = order.ShippingDetail.ZipCode
                },
                Payment = new PaymentVM
                {
                    NameOnCard = order.CreditCard.NameOnCard,
                    CardNumber = order.CreditCard.CardNumber,
                    Expiration = order.CreditCard.Expiration
                },
                Items = order.CartItems.Select(item => new CartItemVM
                {
                    Id = item.Id,
                    Price = item.Price,
                    ShippingPrice = item.ShippingPrice,
                    Quantity = item.Quantity,
                    Comment = item.Comment
                }).ToList(),
                ShippingTotal = order.ShippingTotal.Value,
                Subtotal = order.Subtotal.Value,
                Total = order.TotalAmount.Value,
                Comment = order.Comment
            }).ToList();
        }

        public OrderVM Get(int id)
        {
            Cart order = this.cartService.GetActiveOrder(id);
            Country country = this.countryService.FindCountry(order.ShippingDetail.CountryId);
            List<Product> products = this.productService.GetProducts(null).ToList();
            return new OrderVM
            {
                Id = order.Id,
                Username = order.User.Email,
                OrderNumber = order.OrderNumber.ToString(),
                OrderDate = order.OrderDate.Value.ToString("g"),
                Customer = new CustomerVM
                {
                    Address1 = order.ShippingDetail.Address1,
                    Address2 = order.ShippingDetail.Address2,
                    City = order.ShippingDetail.City,
                    CountryName = country.Name,
                    FullName = order.ShippingDetail.FullName,
                    Phone = order.ShippingDetail.PhoneNumber,
                    Region = order.ShippingDetail.Region,
                    ZipCode = order.ShippingDetail.ZipCode
                },
                Payment = new PaymentVM
                {
                    NameOnCard = order.CreditCard.NameOnCard,
                    CardNumber = order.CreditCard.CardNumber,
                    Expiration = order.CreditCard.Expiration
                },
                Items = order.CartItems.Select(item => new CartItemVM
                {
                    Id = item.Id,
                    Price = item.Price,
                    ShippingPrice = item.ShippingPrice,
                    Quantity = item.Quantity,
                    Comment = item.Comment,
                    ProductName = products.Single(x => x.Id == item.ProductId).Name,
                    TotalPrice = item.TotalPrice
                }).ToList(),
                ShippingTotal = order.ShippingTotal.Value,
                Subtotal = order.Subtotal.Value,
                Total = order.TotalAmount.Value,
                Comment = order.Comment
            };
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
