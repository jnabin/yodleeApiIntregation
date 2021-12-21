using MediatR;
using System.Net.Http;
using YodleeIntegration.Application.Request;
using YodleeIntegration.Domain.Model.Authorizations;
using YodleeIntegration.Domain.Model.Configurations;

namespace YodleeIntegration.Application.ProvidersAccounts.UpdateProviderAccount
{
    public class UpdateProviderAccountCommand : IRequest<HttpResponseMessage>
    {
        public ProvidersAccountRequest ProvidersAccountRequest { get; }

        public YodleeConfiguration YodleeConfiguration { get; }

        public YodleeAccessToken YodleeAccessToken { get; set; }
        public ProviderAccountRequestBody ProviderAccountRequestBody { get; set; }
        public UpdateProviderAccountCommand(ProvidersAccountRequest providersAccountRequest,
            YodleeConfiguration yodleeConfiguration,
            YodleeAccessToken yodleeAccessToken, ProviderAccountRequestBody providerAccountRequestBody)
        {
            ProvidersAccountRequest = providersAccountRequest;
            YodleeConfiguration = yodleeConfiguration;
            YodleeAccessToken = yodleeAccessToken;
            ProviderAccountRequestBody = providerAccountRequestBody;
        }
    }
}
