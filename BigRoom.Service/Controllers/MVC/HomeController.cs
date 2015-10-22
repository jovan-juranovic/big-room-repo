using System.Web.Mvc;
using BigRoom.Service.Common;

namespace BigRoom.Service.Controllers.MVC
{
    public class HomeController : BaseMvcController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
