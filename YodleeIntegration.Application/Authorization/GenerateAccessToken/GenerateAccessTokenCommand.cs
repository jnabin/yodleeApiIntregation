using MediatR;
using System.Net.Http;
using YodleeIntegration.Application.Request;
using YodleeIntegration.Domain.Model.Configurations;

namespace YodleeIntegration.Application.Authorization.GenerateAccessToken
{
    public class GenerateAccessTokenDataCommand : IRequest<HttpResponseMessage>
    {
        public AuthorizationUserTokenRequest AuthorizationUserTokenRequest { get; }

        public YodleeConfiguration YodleeConfiguration { get; }

        public string Username { get; }

        public GenerateAccessTokenDataCommand(
            AuthorizationUserTokenRequest authorizationUserTokenRequest,
            YodleeConfiguration yodleeConfiguration,
            string username
            )
        {
            AuthorizationUserTokenRequest = authorizationUserTokenRequest;
            YodleeConfiguration = yodleeConfiguration;
            Username = username;
        }
    }
}