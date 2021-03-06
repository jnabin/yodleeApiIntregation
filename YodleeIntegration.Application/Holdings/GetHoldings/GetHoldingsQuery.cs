using MediatR;
using System.Net.Http;
using YodleeIntegration.Application.Request;
using YodleeIntegration.Domain.Model.Authorizations;
using YodleeIntegration.Domain.Model.Configurations;

namespace YodleeIntegration.Application.Holdings.GetHoldings
{
    public class GetHoldingsQuery : IRequest<HttpResponseMessage>
    {
        public HoldingsRequest HoldingsRequest { get; }

        public YodleeConfiguration YodleeConfiguration { get; }

        public YodleeAccessToken YodleeAccessToken { get; set; }

        public GetHoldingsQuery(
            HoldingsRequest holdingsRequest,
            YodleeConfiguration yodleeConfiguration,
            YodleeAccessToken yodleeAccessToken
            )
        {
            HoldingsRequest = holdingsRequest;
            YodleeConfiguration = yodleeConfiguration;
            YodleeAccessToken = yodleeAccessToken;
        }
    }
}
