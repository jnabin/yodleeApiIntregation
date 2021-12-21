using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using YodleeIntegration.Api.Models;
using YodleeIntegration.Application.Documents.DownloadADocument;
using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Application.Request.Document;
using YodleeIntegration.Common.ServiceClient;

namespace YodleeIntegration.Application.Test.Documents.DownloadADocument
{
    public class DownloadADocumentPositiveTests : BaseTest
    {
        private Mock<ILogger<DownloadADocumentQueryHandler>> _logger;

        [SetUp]
        public void Setup()
        {
            _serviceHttpClient = _serviceProvider.GetService<IServiceHttpClient>(); ;
            _mockYodleeConfigurationRepository = new Mock<IYodleeConfigurationRepository>();
            _logger = new Mock<ILogger<DownloadADocumentQueryHandler>>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
        }

        [Test]
        public async Task DownloadADocument()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var serviceHttpClient = new Mock<IServiceHttpClient>();

            serviceHttpClient.Setup(x => x.GetAsync(It.IsAny<string>())).Returns(Task.FromResult(new HttpResponseMessage { StatusCode = HttpStatusCode.OK, RequestMessage = new HttpRequestMessage { Method = HttpMethod.Get } }));

            DownloadADocumentQueryHandler queryHandler = new DownloadADocumentQueryHandler(mockUnitOfWork.Object, serviceHttpClient.Object, _logger.Object);

            var configuration = await GetConfiguration();
            var command = new DownloadADocumentQuery(new DownloadDocumentRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", YodleeEndpoints.GetDocuments)
            }, configuration, new Domain.Model.Authorizations.YodleeAccessToken());

            var response = await queryHandler.Handle(command, CancellationToken.None);

            Assert.IsTrue(response.IsSuccessStatusCode);
        }
    }
}