using System.Web.Http;
using System.Web.Http.Cors;

namespace BigRoom.Service.Common
{
    [EnableCors("*", "*", "*")]
    public class BaseApiController : ApiController
    {
    }
}