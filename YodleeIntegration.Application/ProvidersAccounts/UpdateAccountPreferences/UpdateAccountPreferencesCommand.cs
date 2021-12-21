using MediatR;
using System.Net.Http;
using YodleeIntegration.Application.Request;
using YodleeIntegration.Domain.Model.Authorizations;
using YodleeIntegration.Domain.Model.Configurations;

namespace YodleeIntegration.Application.ProvidersAccounts.UpdateAccountPreferences
{
    public class UpdateAccountPreferencesCommand : IRequest<HttpResponseMessage>
    {
        public ProvidersAccountRequest ProvidersAccountRequest { get; }

        public YodleeConfiguration YodleeConfiguration { get; }

        public YodleeAccessToken YodleeAccessToken { get; set; }
        public UpdateAccountPreferencesRequestBody UpdateAccountPreferencesRequestBody { get; set; }
        public UpdateAccountPreferencesCommand(ProvidersAccountRequest providersAccountRequest,
            YodleeConfiguration yodleeConfiguration,
            YodleeAccessToken yodleeAccessToken, UpdateAccountPreferencesRequestBody updateAccountPreferencesRequestBody)
        {
            ProvidersAccountRequest = providersAccountRequest;
            YodleeConfiguration = yodleeConfiguration;
            YodleeAccessToken = yodleeAccessToken;
            UpdateAccountPreferencesRequestBody = updateAccountPreferencesRequestBody;
        }
    }
}
