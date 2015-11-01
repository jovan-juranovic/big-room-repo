using System.Collections.Generic;
using BigRoom.BusinessLayer.Interfaces;
using BigRoom.DataAccessLayer.UnitOfWork;
using BigRoom.Model;

namespace BigRoom.BusinessLayer.Services
{
    public class UserService : IUserService
    {
        public IEnumerable<User> GetUsers()
        {
            using (var uow = new UnitOfWork())
            {
                return uow.UserRepository.GetAll(user => user.IsAdmin == false);
            }
        }

        public User FindUser(int id)
        {
            using (var uow = new UnitOfWork())
            {
                return uow.UserRepository.Find(id);
            }
        }

        public bool CreateUser(User user)
        {
            using (var uow = new UnitOfWork())
            {
                uow.UserRepository.Insert(user);
                return uow.Save() == 1;
            }
        }

        public bool EditUser(User user)
        {
            using (var uow = new UnitOfWork())
            {
                uow.UserRepository.Update(user);
                return uow.Save() > 0;
            }
        }

        public bool DeleteUser(int id)
        {
            using (var uow = new UnitOfWork())
            {
                uow.UserRepository.Delete(id);
                return uow.Save() > 0;
            }
        }
    }
}
