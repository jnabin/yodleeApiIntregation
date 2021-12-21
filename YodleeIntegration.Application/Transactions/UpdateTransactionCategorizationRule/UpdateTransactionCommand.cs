using MediatR;
using System.Net.Http;
using YodleeIntegration.Application.Request.Derived;
using YodleeIntegration.Domain.Model.Authorizations;
using YodleeIntegration.Domain.Model.Configurations;

namespace YodleeIntegration.Application.Transactions.UpdateTransactionCategorizationRule
{
    public class UpdateTransactionCommand : IRequest<HttpResponseMessage>
    {
        public TransactionsRequest TransactionsRequest { get; }

        public YodleeConfiguration YodleeConfiguration { get; }

        public YodleeAccessToken YodleeAccessToken { get; set; }
        public object UpdateTransactionRequestBody { get; set; }
        public UpdateTransactionCommand(TransactionsRequest transactionsRequest,
            YodleeConfiguration yodleeConfiguration,
            YodleeAccessToken yodleeAccessToken, object updateTransactionRequestBody)
        {
            TransactionsRequest = transactionsRequest;
            YodleeConfiguration = yodleeConfiguration;
            YodleeAccessToken = yodleeAccessToken;
            UpdateTransactionRequestBody = updateTransactionRequestBody;
        }
    }
}
