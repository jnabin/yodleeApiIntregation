using MediatR;
using System.Net.Http;
using YodleeIntegration.Application.Request;
using YodleeIntegration.Domain.Model.Authorizations;
using YodleeIntegration.Domain.Model.Configurations;

namespace YodleeIntegration.Application.Derived.GetTransactionSummary
{
    public class GetTransactionSummaryQuery
        : IRequest<HttpResponseMessage>
    {
        public TransactionSummaryRequest TransactionSummaryRequest { get; }

        public YodleeConfiguration YodleeConfiguration { get; }

        public YodleeAccessToken YodleeAccessToken { get; set; }

        public GetTransactionSummaryQuery(
            TransactionSummaryRequest transactionSummaryRequest,
            YodleeConfiguration yodleeConfiguration,
            YodleeAccessToken yodleeAccessToken
        )
        {
            TransactionSummaryRequest = transactionSummaryRequest;
            YodleeConfiguration = yodleeConfiguration;
            YodleeAccessToken = yodleeAccessToken;
        }
    }
}