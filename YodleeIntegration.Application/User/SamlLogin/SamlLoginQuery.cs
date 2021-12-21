using MediatR;
using System.Net.Http;
using YodleeIntegration.Application.Request.User;
using YodleeIntegration.Domain.Model.Authorizations;
using YodleeIntegration.Domain.Model.Configurations;

namespace YodleeIntegration.Application.User.SamlLogin
{
    public class SamlLoginQuery
        : IRequest<HttpResponseMessage>
    {
        public SamlLoginRequest SamlLoginRequest { get; }

        public YodleeConfiguration YodleeConfiguration { get; }

        public YodleeAccessToken YodleeAccessToken { get; set; }

        public SamlLoginQuery(
            SamlLoginRequest samlLoginRequest,
            YodleeConfiguration yodleeConfiguration,
            YodleeAccessToken yodleeAccessToken
        )
        {
            SamlLoginRequest = samlLoginRequest;
            YodleeConfiguration = yodleeConfiguration;
            YodleeAccessToken = yodleeAccessToken;
        }
    }
}