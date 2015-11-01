using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BigRoom.BusinessLayer.Interfaces;
using BigRoom.BusinessLayer.Services;
using BigRoom.BusinessLayer.Util;
using BigRoom.Model;
using BigRoom.Service.Common;
using BigRoom.Service.Models.UserVms;

namespace BigRoom.Service.Controllers.API
{
    public class UsersController : BaseApiController
    {
        #region Fields

        private readonly IUserService userService;

        #endregion

        #region Ctors

        public UsersController()
        {
            this.userService = new UserService();
        }

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        #endregion

        #region API

        public IEnumerable<UserVM> Get()
        {
            return GetUsers();
        }

        public UserVM Get(int id)
        {
            User user = this.userService.FindUser(id);
            return new UserVM
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }

        public IHttpActionResult Post(UserVM request)
        {
            if (IsValid(request))
            {
                User user = GetMappedUser(request);
                if (this.userService.CreateUser(user))
                {
                    return this.Created(user);
                }

                return this.BadRequest();
            }

            return this.BadRequest("User is not valid.");
        }

        public IHttpActionResult Put(UserVM request)
        {
            if (IsValid(request))
            {
                User user = this.userService.FindUser(request.Id);
                if (user == null)
                {
                    return this.NotFound();
                }

                user.Name = request.Name;
                user.Email = request.Email;

                if (this.userService.EditUser(user))
                {
                    List<UserVM> users = GetUsers();
                    return this.Ok(users);
                }

                return this.BadRequest();
            }

            return this.BadRequest("User is not valid.");
        }

        public IHttpActionResult Delete(int id)
        {
            User user = this.userService.FindUser(id);
            if (user == null)
            {
                return this.NotFound();
            }

            if (this.userService.DeleteUser(id))
            {
                return this.Ok("Success");
            }

            return this.BadRequest();
        }

        #endregion

        private static User GetMappedUser(UserVM request)
        {
            return new User
            {
                Name = request.Name,
                Email = request.Email,
                IsAdmin = false
            };
        }

        private static bool IsValid(UserVM user)
        {
            return !user.Name.IsNullOrEmpty() && !user.Email.IsNullOrEmpty();
        }

        private List<UserVM> GetUsers()
        {
            return this.userService.GetUsers().Select(user => new UserVM
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            }).ToList();
        }
    }
}
