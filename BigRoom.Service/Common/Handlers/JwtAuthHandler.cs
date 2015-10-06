using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using JWT;

namespace BigRoom.Service.Common.Handlers
{
    public class JwtAuthHandler : DelegatingHandler
    {
        private const string Scheme = "Bearer";
        private const string AuthType = "JWT";
        private const string NameClaim = "name";

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                HttpRequestHeaders headers = request.Headers;
                if (headers.Authorization != null && Scheme.Equals(headers.Authorization.Scheme))
                {
                    string secretKey = ConfigurationManager.AppSettings["SecretKey"];
                    string token = headers.Authorization.Parameter;
                    var payload = JsonWebToken.DecodeToObject(token, secretKey) as IDictionary<string, object>;

                    object userId;
                    if (payload != null && payload.TryGetValue(NameClaim, out userId))
                    {
                        SetPrincipal(userId);
                    }
                }

                HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    response.Content = new StringContent("This action requires user to be logged in.");
                }

                return response;
            }
            catch (Exception ex)
            {
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.Unauthorized);
                response.Content = new StringContent(ex.Message);
                return response;
            }
        }

        private static void SetPrincipal(object userId)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userId.ToString(), ClaimValueTypes.Integer32)
            };

            ClaimsPrincipal principal = new ClaimsPrincipal(new ClaimsIdentity(claims, AuthType));

            Thread.CurrentPrincipal = principal;
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
        }
    }
}