using System;
using System.Collections.Generic;
using Core.DL.Module.Config;
using JWT.Algorithms;
using JWT.Builder;

namespace Core.DL.Module.Auth {
    public static class Jwt {
        public static string FromUserId(int userId) {
            var days = AppConfig.Get().GetJwtLifeDays();
            return new JwtBuilder()
                .WithAlgorithm(new HMACSHA256Algorithm())
                .WithSecret(AppConfig.Get().GetJwtSecretKey())
                .AddClaim(
                    "exp",
                    DateTimeOffset.UtcNow.AddDays(AppConfig.Get().GetJwtLifeDays()).ToUnixTimeSeconds()
                )
                .AddClaim("user_id", userId)
                .Build();
        }

        public static int GetUserIdFromToken(string token) {
            try {
                var result = Convert.ToInt32(new JwtBuilder()
                    .WithSecret(AppConfig.Get().GetJwtSecretKey())
                    .MustVerifySignature()
                    .Decode<IDictionary<string, object>>(token)["user_id"]);
            }
            catch (Exception e) {
            }

            return 0;
        }
    }
}