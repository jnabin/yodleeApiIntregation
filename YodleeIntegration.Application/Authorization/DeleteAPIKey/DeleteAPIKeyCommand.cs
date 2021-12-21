using MediatR;
using System.Net.Http;
using YodleeIntegration.Application.Request;
using YodleeIntegration.Domain.Model.Authorizations;
using YodleeIntegration.Domain.Model.Configurations;

namespace YodleeIntegration.Application.Authorization.DeleteApiKey
{
    public class DeleteApiKeyCommand
        : IRequest<HttpResponseMessage>
    {
        public AuthorizationUserApiKeyRequest AuthorizationUserApiKeyRequest { get; }

        public YodleeConfiguration YodleeConfiguration { get; }

        public YodleeAccessToken YodleeAccessToken { get; set; }

        public DeleteApiKeyCommand(
            AuthorizationUserApiKeyRequest authorizationUserApiKeyRequest,
            YodleeConfiguration yodleeConfiguration,
            YodleeAccessToken yodleeAccessToken
        )
        {
            AuthorizationUserApiKeyRequest = authorizationUserApiKeyRequest;
            YodleeConfiguration = yodleeConfiguration;
            YodleeAccessToken = yodleeAccessToken;
        }
    }
}