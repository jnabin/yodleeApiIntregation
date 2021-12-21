using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using IdentityModel;
using Microsoft.IdentityModel.Tokens;

namespace YodleeIntegration.Api.Test.IdentityServer
{
    public static class MockJsonWebToken
    {
        public static string Issuer { get; } = "https://localhost:5001";
        public static string Audience { get; } = "https://localhost:5001/resources";
        public static SecurityKey SecurityKey { get; }
        public static SigningCredentials SigningCredentials { get; }

        private static readonly JwtSecurityTokenHandler STokenHandler = new JwtSecurityTokenHandler();
        private static readonly RandomNumberGenerator SRng = RandomNumberGenerator.Create();
        private static readonly byte[] SKey = new byte[32];

        static MockJsonWebToken()
        {
            SRng.GetBytes(SKey);
            SecurityKey = new SymmetricSecurityKey(SKey) { KeyId = Guid.NewGuid().ToString() };
            SigningCredentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);
        }

        public static string GenerateJwtToken(IEnumerable<Claim> claims)
        {
            return STokenHandler.WriteToken(new JwtSecurityToken(Issuer, Audience, claims, null, DateTime.UtcNow.AddMinutes(20), SigningCredentials));
        }

        public static string GenerateJwtTokenAsUser()
        {
            return GenerateJwtToken(UserClaims);
        }

        public static List<Claim> UserClaims { get; set; } = new List<Claim>
        {
            new Claim(JwtClaimTypes.PreferredUserName, "test"),
            new Claim(JwtClaimTypes.Email, "test@test.com"),
            new Claim(JwtClaimTypes.Subject, "10000000-0000-0000-0000-000000000000"),
            new Claim(JwtClaimTypes.Scope, "openid"),
            new Claim(JwtClaimTypes.Scope, "api.com:read"),
            new Claim(JwtClaimTypes.Scope, "api.com:write"),
        };
    }
}
