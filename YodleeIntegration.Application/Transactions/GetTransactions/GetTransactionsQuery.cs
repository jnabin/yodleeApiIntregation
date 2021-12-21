using MediatR;
using System.Net.Http;
using YodleeIntegration.Application.Request.Derived;
using YodleeIntegration.Domain.Model.Authorizations;
using YodleeIntegration.Domain.Model.Configurations;

namespace YodleeIntegration.Application.Transactions.GetTransactions
{
    public class GetTransactionsQuery : IRequest<HttpResponseMessage>
    {
        public TransactionsRequest TransactionsRequest { get; }

        public YodleeConfiguration YodleeConfiguration { get; }

        public YodleeAccessToken YodleeAccessToken { get; set; }

        public GetTransactionsQuery(
            TransactionsRequest transactionsRequest,
            YodleeConfiguration yodleeConfiguration,
            YodleeAccessToken yodleeAccessToken
            )
        {
            TransactionsRequest = transactionsRequest;
            YodleeConfiguration = yodleeConfiguration;
            YodleeAccessToken = yodleeAccessToken;
        }
    }
}
