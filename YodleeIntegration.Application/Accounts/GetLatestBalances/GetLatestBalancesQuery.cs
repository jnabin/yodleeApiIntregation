using MediatR;
using System.Net.Http;
using YodleeIntegration.Application.Request;
using YodleeIntegration.Domain.Model.Authorizations;
using YodleeIntegration.Domain.Model.Configurations;

namespace YodleeIntegration.Application.Accounts.GetLatestBalances
{
    public class GetLatestBalancesQuery : IRequest<HttpResponseMessage>
    {
        public AccountsRequest AccountsRequest { get; }

        public YodleeConfiguration YodleeConfiguration { get; }

        public YodleeAccessToken YodleeAccessToken { get; set; }

        public GetLatestBalancesQuery(
            AccountsRequest accountsRequest,
            YodleeConfiguration yodleeConfiguration,
            YodleeAccessToken yodleeAccessToken
            )
        {
            AccountsRequest = accountsRequest;
            YodleeConfiguration = yodleeConfiguration;
            YodleeAccessToken = yodleeAccessToken;
        }
    }
}
