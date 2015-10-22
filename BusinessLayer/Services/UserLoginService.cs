using System.Collections.Generic;
using System.Linq;
using BigRoom.DataAccessLayer.UnitOfWork;
using BigRoom.Model;

namespace BigRoom.BusinessLayer.Services
{
    public class UserLoginService
    {
        public static bool CredentialsAreValid(string userId, string password)
        {
            using (var uow = new UnitOfWork())
            {
                IEnumerable<User> users = uow.UserRepository.GetAll(u => u.Email == userId && u.Password == password);
                return users != null && users.Count() == 1;
            }
        }
    }
}
