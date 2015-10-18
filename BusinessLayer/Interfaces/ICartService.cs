using System;
using BigRoom.Model;

namespace BigRoom.BusinessLayer.Interfaces
{
    public interface ICartService
    {
        bool CreateNewOrder(Cart cart);
    }
}