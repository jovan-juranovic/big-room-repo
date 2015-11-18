using System.Collections.Generic;
using System.Linq;
using BigRoom.BusinessLayer.Interfaces;
using BigRoom.DataAccessLayer.UnitOfWork;
using BigRoom.Model;

namespace BigRoom.BusinessLayer.Services
{
    public class CartService : ICartService
    {
        public bool CreateNewOrder(Cart cart)
        {
            using (var uow = new UnitOfWork())
            {
                uow.CartRepository.Insert(cart);
                return uow.Save() > 0;
            }
        }

        public IEnumerable<Cart> GetActiveOrders()
        {
            using (var uow = new UnitOfWork())
            {
                return uow.CartRepository.GetAll(
                    filter: order => order.Status == CartStatus.Open,
                    orderBy: order => order.OrderBy(x => x.OrderDate),
                    includeProperties: "User,CartItems,ShippingDetail,CreditCard");
            }
        }

        public Cart GetActiveOrder(int id)
        {
            using (var uow = new UnitOfWork())
            {
                return uow.CartRepository.GetAll(
                    filter: order => order.Id == id,
                    orderBy: null,
                    includeProperties: "User,CartItems,ShippingDetail,CreditCard").Single();
            }
        }
    }
}
