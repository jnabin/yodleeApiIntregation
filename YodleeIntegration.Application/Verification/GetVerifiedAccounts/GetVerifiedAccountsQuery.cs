using MediatR;
using System.Net.Http;
using YodleeIntegration.Application.Request.Verification;
using YodleeIntegration.Domain.Model.Authorizations;
using YodleeIntegration.Domain.Model.Configurations;

namespace YodleeIntegration.Application.Verification.GetVerifiedAccounts
{
    public class GetVerifiedAccountsQuery
        : IRequest<HttpResponseMessage>
    {
        public GetVerifiedAccountsRequest GetVerifiedAccountsRequest { get; }

        public YodleeConfiguration YodleeConfiguration { get; }

        public YodleeAccessToken YodleeAccessToken { get; set; }

        public GetVerifiedAccountsQuery(
            GetVerifiedAccountsRequest getVerifiedAccountsRequest,
            YodleeConfiguration yodleeConfiguration,
            YodleeAccessToken yodleeAccessToken
        )
        {
            GetVerifiedAccountsRequest = getVerifiedAccountsRequest;
            YodleeConfiguration = yodleeConfiguration;
            YodleeAccessToken = yodleeAccessToken;
        }
    }
}