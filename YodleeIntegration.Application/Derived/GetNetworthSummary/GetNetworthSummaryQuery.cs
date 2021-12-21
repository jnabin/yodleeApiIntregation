using MediatR;
using System.Net.Http;
using YodleeIntegration.Application.Request.Derived;
using YodleeIntegration.Domain.Model.Authorizations;
using YodleeIntegration.Domain.Model.Configurations;

namespace YodleeIntegration.Application.Derived.GetNetworthSummary
{
    public class GetNetworthSummaryQuery
        : IRequest<HttpResponseMessage>
    {
        public NetworthSummaryRequest NetworthSummaryRequest { get; }

        public YodleeConfiguration YodleeConfiguration { get; }

        public YodleeAccessToken YodleeAccessToken { get; set; }

        public GetNetworthSummaryQuery(
            NetworthSummaryRequest networthSummaryRequest,
            YodleeConfiguration yodleeConfiguration,
            YodleeAccessToken yodleeAccessToken
        )
        {
            NetworthSummaryRequest = networthSummaryRequest;
            YodleeConfiguration = yodleeConfiguration;
            YodleeAccessToken = yodleeAccessToken;
        }
    }
}