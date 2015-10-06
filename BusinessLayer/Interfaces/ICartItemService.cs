using System;
using System.Collections.Generic;
using BigRoom.Model;

namespace BigRoom.BusinessLayer.Interfaces
{
    public interface ICartItemService
    {
        bool InsertCartItem(CartItem item);
        IEnumerable<CartItem> GetCartItems(Guid cartGuid);
    }
}