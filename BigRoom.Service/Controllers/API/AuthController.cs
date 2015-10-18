﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;
using BigRoom.Service.Common;
using BigRoom.Service.Models.JWTVms;
using JWT;

namespace BigRoom.Service.Controllers.API
{
    [AllowAnonymous]
    public class AuthController : BaseApiController
    {
        private const string AuthType = "JWT";

        public JWTResponse Post(JWTRequest jwtRequest)
        {
            DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            double exp = Math.Round((DateTime.UtcNow.AddMinutes(30) - unixEpoch).TotalSeconds);

            var payload = new Dictionary<string, object>
            {
                {"exp", exp},
                {"name", 1}
            };

            string secretKey = ConfigurationManager.AppSettings["SecretKey"];
            string token = JsonWebToken.Encode(payload, secretKey, JwtHashAlgorithm.HS256);

            return new JWTResponse
            {
                AccessToken = token,
                Type = AuthType,
                Expiration = exp
            };
        }
    }
}