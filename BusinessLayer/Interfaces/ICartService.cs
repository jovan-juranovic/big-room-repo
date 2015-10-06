using System;

namespace BigRoom.BusinessLayer.Interfaces
{
    public interface ICartService
    {
        Guid GetOrCreateCart(int userId);
    }
}