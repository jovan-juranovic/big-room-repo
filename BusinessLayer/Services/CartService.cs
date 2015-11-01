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
    }
}
