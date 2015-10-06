using System;
using System.Linq;
using BigRoom.BusinessLayer.Interfaces;
using BigRoom.BusinessLayer.Util;
using BigRoom.DataAccessLayer.UnitOfWork;
using BigRoom.Model;

namespace BigRoom.BusinessLayer.Services
{
    public class CartService : ICartService
    {
        public Guid GetOrCreateCart(int userId)
        {
            using (var uow = new UnitOfWork())
            {
                Cart cart = uow.CartRepository
                    .GetAll(c => c.UserId == userId && c.Status == CartStatus.Open)
                    .SingleOrDefault();

                if (cart != null)
                {
                    return cart.Id;
                }

                return CreateNewCart(userId, uow);
            }
        }

        public void CalculateCart(Guid cartGuid)
        {
            using (var uow = new UnitOfWork())
            {

            }
        }

        private static Guid CreateNewCart(int userId, UnitOfWork uow)
        {
            Cart newCart = new Cart
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Status = CartStatus.Open
            };

            uow.CartRepository.Insert(newCart);

            if (uow.Save() == 1)
            {
                return newCart.Id;
            }

            throw new InvalidOperationException("Cart could not be created !");
        }
    }
}
