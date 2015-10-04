using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BigRoom.Service.Common.Filters;

namespace BigRoom.Service.Common
{
    [EnableCors("*", "*", "*")]
    [CustomExceptionFilter]
    public abstract class BaseApiController : ApiController
    {
        protected Exception ReportError(string errorMessage)
        {
            if (string.IsNullOrEmpty(errorMessage))
            {
                errorMessage = "Something went wrong while processing your request. Please refresh the page and try again.";
            }

            throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, errorMessage));
        }

        protected IHttpActionResult Created<T>(T resource)
        {
            return this.Created("Success", resource);
        }
    }
}