using System.Web;
using System.Web.Mvc;

namespace BigRoom.Service.Common.Filters
{
    public class LoginGuardAttribute : AuthorizeAttribute
    {
        private const string Base64Value = "token";

        public override void OnAuthorization(AuthorizationContext context)
        {
            var cookie = HttpContext.Current.Request.Cookies.Get(Base64Value);
            if (cookie == null)
            {
                context.Result = new RedirectResult("/Login", true);
            }
        }
    }
}