using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using BigRoom.BusinessLayer.Services;
using BigRoom.BusinessLayer.Util;

namespace BigRoom.Service.Common.Handlers
{
    public class BasicAuthHandler : DelegatingHandler
    {
        private const string Scheme = "Basic";
        private const string Base64Value = "token";

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                HttpRequestHeaders headers = request.Headers;
                if (headers.Authorization != null && headers.Authorization.Scheme == Scheme)
                {
                    string credentials = headers.Authorization.Parameter.FromBase64String();
                    AuthenticateUser(credentials);
                }
                else
                {
                    var cookie = headers.GetCookies(Base64Value).First();
                    if (cookie != null)
                    {
                        CookieState cookieState = cookie[Base64Value];
                        string credentials = cookieState.Value.FromBase64String();
                        AuthenticateUser(credentials);
                    }
                }
            
                HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    response.Headers.WwwAuthenticate.Add(new AuthenticationHeaderValue(Scheme));
                }

                return response;
            }
            catch (Exception ex)
            {
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.Unauthorized);
                response.Content = new StringContent(ex.Message);
                response.Headers.WwwAuthenticate.Add(new AuthenticationHeaderValue(Scheme));
                return response;
            }
        }

        private static void AuthenticateUser(string credentials)
        {
            string[] parts = credentials.Split(':');
            string userId = parts[0].Trim();
            string password = parts[1].Trim();

            if (UserLoginService.CredentialsAreValid(userId, password))
            {
                SetPrincipal(userId);
            }
        }

        private static void SetPrincipal(string userId)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userId),
                new Claim(ClaimTypes.AuthenticationMethod, AuthenticationMethods.Password)
            };

            ClaimsPrincipal principal = new ClaimsPrincipal(new[] {new ClaimsIdentity(claims, Scheme)});
            Thread.CurrentPrincipal = principal;
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
        }
    }
}