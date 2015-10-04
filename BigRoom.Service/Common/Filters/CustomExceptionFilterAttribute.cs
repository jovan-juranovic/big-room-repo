using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace BigRoom.Service.Common.Filters
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            Exception ex = context.Exception;
            context.Response = context.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}