using MediatR;
using System.Net.Http;
using YodleeIntegration.Application.Request.Document;
using YodleeIntegration.Domain.Model.Authorizations;
using YodleeIntegration.Domain.Model.Configurations;

namespace YodleeIntegration.Application.Documents.DownloadADocument
{
    public class DownloadADocumentQuery
        : IRequest<HttpResponseMessage>
    {
        public DownloadDocumentRequest DownloadDocumentRequest { get; }

        public YodleeConfiguration YodleeConfiguration { get; }

        public YodleeAccessToken YodleeAccessToken { get; set; }

        public DownloadADocumentQuery(
            DownloadDocumentRequest downloadDocumentRequest,
            YodleeConfiguration yodleeConfiguration,
            YodleeAccessToken yodleeAccessToken
        )
        {
            DownloadDocumentRequest = downloadDocumentRequest;
            YodleeConfiguration = yodleeConfiguration;
            YodleeAccessToken = yodleeAccessToken;
        }
    }
}