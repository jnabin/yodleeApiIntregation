using MediatR;
using System.Net.Http;
using YodleeIntegration.Application.Request.Derived;
using YodleeIntegration.Domain.Model.Authorizations;
using YodleeIntegration.Domain.Model.Configurations;

namespace YodleeIntegration.Application.Transactions.DeleteTransactionCategorization
{
    public class DeleteTransactionCategorizationCommand : IRequest<HttpResponseMessage>
    {
        public TransactionsRequest TransactionsRequest { get; }

        public YodleeConfiguration YodleeConfiguration { get; }

        public YodleeAccessToken YodleeAccessToken { get; set; }
        public DeleteTransactionCategorizationCommand(TransactionsRequest transactionsRequest,
            YodleeConfiguration yodleeConfiguration,
            YodleeAccessToken yodleeAccessToken)
        {
            TransactionsRequest = transactionsRequest;
            YodleeConfiguration = yodleeConfiguration;
            YodleeAccessToken = yodleeAccessToken;
        }
    }
}
