using System.Web.Mvc;
using BigRoom.Service.Common;

namespace BigRoom.Service.Controllers.MVC
{
    public class OrderController : BaseMvcController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
