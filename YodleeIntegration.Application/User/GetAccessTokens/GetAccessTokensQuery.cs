using MediatR;
using System.Net.Http;
using YodleeIntegration.Application.Request.User;
using YodleeIntegration.Domain.Model.Authorizations;
using YodleeIntegration.Domain.Model.Configurations;

namespace YodleeIntegration.Application.User.GetAccessTokens
{
    public class GetAccessTokensQuery
        : IRequest<HttpResponseMessage>
    {
        public AccessTokensRequest AccessTokensRequest { get; }

        public YodleeConfiguration YodleeConfiguration { get; }

        public YodleeAccessToken YodleeAccessToken { get; set; }

        public GetAccessTokensQuery(
            AccessTokensRequest accessTokensRequest,
            YodleeConfiguration yodleeConfiguration,
            YodleeAccessToken yodleeAccessToken
        )
        {
            AccessTokensRequest = accessTokensRequest;
            YodleeConfiguration = yodleeConfiguration;
            YodleeAccessToken = yodleeAccessToken;
        }
    }
}