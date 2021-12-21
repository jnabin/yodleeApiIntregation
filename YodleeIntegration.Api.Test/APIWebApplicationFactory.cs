using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using YodleeIntegration.Api.Test.IdentityServer;

namespace YodleeIntegration.Api.Test
{
    public class ApiWebApplicationFactory : WebApplicationFactory<YodleeIntegration.Api.Startup>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            var host = builder.Build();
            host.Start();
            return host;
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder
                .UseSolutionRelativeContentRoot("YodleeIntegration.Api")
                .ConfigureTestServices(ConfigureServices)
                .UseEnvironment("Testing");
        }

        protected virtual void ConfigureServices(IServiceCollection services)
        {
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<DbContext>));

            if (descriptor != null)
            {
                services.Remove(descriptor);
            }

            services.Configure<JwtBearerOptions>(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.TokenValidationParameters = CreateTokenValidationParameters();
                options.Audience = MockJsonWebToken.Audience;
                options.Authority = MockJsonWebToken.Issuer;
                options.Configuration = new Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectConfiguration()
                {
                    Issuer = MockJsonWebToken.Issuer,
                };
            });
        }

        private TokenValidationParameters CreateTokenValidationParameters()
        {
            TokenValidationParameters tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = MockJsonWebToken.SecurityKey,

                SignatureValidator = delegate (string token, TokenValidationParameters parameters)
                {
                    JwtSecurityToken jwt = new JwtSecurityToken(token);
                    return jwt;
                },
                RequireExpirationTime = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                RequireSignedTokens = false,
            };

            return tokenValidationParameters;
        }
    }
}