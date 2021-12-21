using MediatR;
using System.Net.Http;
using YodleeIntegration.Application.Request.Derived;
using YodleeIntegration.Domain.Model.Authorizations;
using YodleeIntegration.Domain.Model.Configurations;

namespace YodleeIntegration.Application.Derived.GetHoldingSummary
{
    public class GetHoldingSummaryQuery
        : IRequest<HttpResponseMessage>
    {
        public HoldingSummaryRequest HoldingSummaryRequest { get; }

        public YodleeConfiguration YodleeConfiguration { get; }

        public YodleeAccessToken YodleeAccessToken { get; set; }

        public GetHoldingSummaryQuery(
            HoldingSummaryRequest holdingSummaryRequest,
            YodleeConfiguration yodleeConfiguration,
            YodleeAccessToken yodleeAccessToken
        )
        {
            HoldingSummaryRequest = holdingSummaryRequest;
            YodleeConfiguration = yodleeConfiguration;
            YodleeAccessToken = yodleeAccessToken;
        }
    }
}