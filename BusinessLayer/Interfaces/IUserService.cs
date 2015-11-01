using System.Collections.Generic;
using BigRoom.Model;

namespace BigRoom.BusinessLayer.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User FindUser(int id);
        bool CreateUser(User user);
        bool EditUser(User user);
        bool DeleteUser(int id);
    }
}