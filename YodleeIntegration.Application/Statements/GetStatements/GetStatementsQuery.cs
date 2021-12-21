using MediatR;
using System.Net.Http;
using YodleeIntegration.Application.Request.Statements;
using YodleeIntegration.Domain.Model.Authorizations;
using YodleeIntegration.Domain.Model.Configurations;

namespace YodleeIntegration.Application.Statements.GetStatements
{
    public class GetStatementsQuery
        : IRequest<HttpResponseMessage>
    {
        public StatementsRequest StatementsRequest { get; }

        public YodleeConfiguration YodleeConfiguration { get; }

        public YodleeAccessToken YodleeAccessToken { get; set; }

        public GetStatementsQuery(
            StatementsRequest statementsRequest,
            YodleeConfiguration yodleeConfiguration,
            YodleeAccessToken yodleeAccessToken
        )
        {
            StatementsRequest = statementsRequest;
            YodleeConfiguration = yodleeConfiguration;
            YodleeAccessToken = yodleeAccessToken;
        }
    }
}