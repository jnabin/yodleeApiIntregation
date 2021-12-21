using MediatR;
using System.Net.Http;
using YodleeIntegration.Application.Request.Document;
using YodleeIntegration.Domain.Model.Authorizations;
using YodleeIntegration.Domain.Model.Configurations;

namespace YodleeIntegration.Application.Documents.DeleteDocument
{
    public class DeleteDocumentQuery
        : IRequest<HttpResponseMessage>
    {
        public DeleteDocumentRequest DeleteDocumentRequest { get; }

        public YodleeConfiguration YodleeConfiguration { get; }

        public YodleeAccessToken YodleeAccessToken { get; set; }

        public DeleteDocumentQuery(
            DeleteDocumentRequest deleteDocumentRequest,
            YodleeConfiguration yodleeConfiguration,
            YodleeAccessToken yodleeAccessToken
        )
        {
            DeleteDocumentRequest = deleteDocumentRequest;
            YodleeConfiguration = yodleeConfiguration;
            YodleeAccessToken = yodleeAccessToken;
        }
    }
}