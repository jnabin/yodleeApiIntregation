using System.Net.Http;
using MediatR;
using YodleeIntegration.Application.Request.Derived;
using YodleeIntegration.Domain.Model.Authorizations;
using YodleeIntegration.Domain.Model.Configurations;

namespace YodleeIntegration.Application.Transactions.GetTransactionCategoryList
{
    public class GetTransactionsCategoryListQuery : IRequest<HttpResponseMessage>
    {
        public TransactionsRequest TransactionsRequest { get; }

        public YodleeConfiguration YodleeConfiguration { get; }

        public YodleeAccessToken YodleeAccessToken { get; set; }

        public GetTransactionsCategoryListQuery(
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
