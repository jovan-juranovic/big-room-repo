using System;
using System.Collections.Generic;
using BigRoom.Model;

namespace BigRoom.BusinessLayer.Interfaces
{
    public interface ICartService
    {
        bool CreateNewOrder(Cart cart);
        IEnumerable<Cart> GetActiveOrders();
        Cart GetActiveOrder(int id);
    }
}