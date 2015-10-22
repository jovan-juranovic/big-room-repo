using System.Web.Mvc;
using BigRoom.Service.Common.Filters;

namespace BigRoom.Service.Common
{
    [LoginGuard]
    public class BaseMvcController : Controller
    {
    }
}