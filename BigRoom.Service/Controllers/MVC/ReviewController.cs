using System.Web.Mvc;
using BigRoom.Service.Common;

namespace BigRoom.Service.Controllers.MVC
{
    public class ReviewController : BaseMvcController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
