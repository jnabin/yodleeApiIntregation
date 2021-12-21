using MediatR;
using System.Net.Http;
using YodleeIntegration.Application.Request;
using YodleeIntegration.Domain.Model.Authorizations;
using YodleeIntegration.Domain.Model.Configurations;

namespace YodleeIntegration.Application.Accounts.UpdateAccount
{
    public class UpdateAccountCommand : IRequest<HttpResponseMessage>
    {
        public AccountsRequest AccountsRequest { get; }

        public YodleeConfiguration YodleeConfiguration { get; }

        public YodleeAccessToken YodleeAccessToken { get; set; }
        public UpdateAccountRequestBody UpdateAccountRequestBody { get; set; }
        public UpdateAccountCommand(AccountsRequest accountsRequest,
            YodleeConfiguration yodleeConfiguration,
            YodleeAccessToken yodleeAccessToken, UpdateAccountRequestBody updateAccountRequestBody)
        {
            AccountsRequest = accountsRequest;
            YodleeConfiguration = yodleeConfiguration;
            YodleeAccessToken = yodleeAccessToken;
            UpdateAccountRequestBody = updateAccountRequestBody;
        }
    }
}
