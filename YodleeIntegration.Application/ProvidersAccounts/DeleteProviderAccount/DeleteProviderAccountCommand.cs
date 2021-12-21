using MediatR;
using System.Net.Http;
using YodleeIntegration.Application.Request;
using YodleeIntegration.Domain.Model.Authorizations;
using YodleeIntegration.Domain.Model.Configurations;

namespace YodleeIntegration.Application.ProvidersAccounts.DeleteProviderAccount
{
    public class DeleteProviderAccountCommand : IRequest<HttpResponseMessage>
    {
        public ProvidersAccountRequest ProvidersAccountRequest { get; }

        public YodleeConfiguration YodleeConfiguration { get; }

        public YodleeAccessToken YodleeAccessToken { get; set; }
        public DeleteProviderAccountCommand(
            ProvidersAccountRequest providersAccountRequest,
            YodleeConfiguration yodleeConfiguration,
            YodleeAccessToken yodleeAccessToken)
        {
            ProvidersAccountRequest = providersAccountRequest;
            YodleeConfiguration = yodleeConfiguration;
            YodleeAccessToken = yodleeAccessToken;
        }
    }
}
