using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigRoom.BusinessLayer.Interfaces;
using BigRoom.DataAccessLayer.UnitOfWork;
using BigRoom.Model;

namespace BigRoom.BusinessLayer.Services
{
    public class CartItemService : ICartItemService
    {
        public bool InsertCartItem(CartItem item)
        {
            item.TotalPrice = item.Price + item.ShippingPrice;
            using (var uow = new UnitOfWork())
            {
                uow.CartItemRepository.Insert(item);
                return uow.Save() == 1;
            }
        }

        public IEnumerable<CartItem> GetCartItems(Guid cartGuid)
        {
            using (var uow = new UnitOfWork())
            {
                return uow.CartItemRepository.GetAll(item => item.CartId == cartGuid);
            }
        }
    }
}
