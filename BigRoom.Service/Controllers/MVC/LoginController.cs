using System.Web;
using System.Web.Mvc;
using BigRoom.BusinessLayer.Services;
using BigRoom.BusinessLayer.Util;

namespace BigRoom.Service.Controllers.MVC
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string userId, string password)
        {
            if (UserLoginService.CredentialsAreValid(userId, password))
            {
                string base64Value = string.Format("{0}:{1}", userId, password).ToBase64String();
                HttpCookie cookie = new HttpCookie("token", base64Value)
                {
                    Path = "/"
                };
                Response.Cookies.Add(cookie);

                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}
