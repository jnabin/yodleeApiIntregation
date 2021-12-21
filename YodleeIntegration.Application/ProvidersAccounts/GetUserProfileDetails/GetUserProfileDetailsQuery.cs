using System.Net.Http;
using MediatR;
using YodleeIntegration.Application.Request;
using YodleeIntegration.Domain.Model.Authorizations;
using YodleeIntegration.Domain.Model.Configurations;

namespace YodleeIntegration.Application.ProvidersAccounts.GetUserProfileDetails
{
    public class GetUserProfileDetailsQuery : IRequest<HttpResponseMessage>
    {
        public ProvidersAccountRequest ProvidersAccountRequest { get; }

        public YodleeConfiguration YodleeConfiguration { get; }

        public YodleeAccessToken YodleeAccessToken { get; set; }

        public GetUserProfileDetailsQuery(
            ProvidersAccountRequest providersAccountRequest,
            YodleeConfiguration yodleeConfiguration,
            YodleeAccessToken yodleeAccessToken
            )
        {
            ProvidersAccountRequest = providersAccountRequest;
            YodleeConfiguration = yodleeConfiguration;
            YodleeAccessToken = yodleeAccessToken;
        }
    }
}
