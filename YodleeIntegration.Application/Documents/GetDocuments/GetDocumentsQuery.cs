using MediatR;
using System.Net.Http;
using YodleeIntegration.Application.Request.Document;
using YodleeIntegration.Domain.Model.Authorizations;
using YodleeIntegration.Domain.Model.Configurations;

namespace YodleeIntegration.Application.Documents.GetDocuments
{
    public class GetDocumentsQuery
        : IRequest<HttpResponseMessage>
    {
        public GetDocumentsRequest GetDocumentsRequest { get; }

        public YodleeConfiguration YodleeConfiguration { get; }

        public YodleeAccessToken YodleeAccessToken { get; set; }

        public GetDocumentsQuery(
            GetDocumentsRequest getDocumentsRequest,
            YodleeConfiguration yodleeConfiguration,
            YodleeAccessToken yodleeAccessToken
        )
        {
            GetDocumentsRequest = getDocumentsRequest;
            YodleeConfiguration = yodleeConfiguration;
            YodleeAccessToken = yodleeAccessToken;
        }
    }
}