using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using YodleeIntegration.Api.Models;
using YodleeIntegration.Application.Documents.DeleteDocument;
using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Application.Request.Document;
using YodleeIntegration.Common.ServiceClient;

namespace YodleeIntegration.Application.Test.Documents.DeleteDocument
{
    public class DeleteDocumentPositiveTests : BaseTest
    {
        private Mock<ILogger<DeleteDocumentQueryHandler>> _logger;

        [SetUp]
        public void Setup()
        {
            _serviceHttpClient = _serviceProvider.GetService<IServiceHttpClient>(); ;
            _mockYodleeConfigurationRepository = new Mock<IYodleeConfigurationRepository>();
            _logger = new Mock<ILogger<DeleteDocumentQueryHandler>>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
        }

        [Test]
        public async Task DeleteDocument()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var serviceHttpClient = new Mock<IServiceHttpClient>();

            serviceHttpClient.Setup(x => x.DeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new HttpResponseMessage { StatusCode = HttpStatusCode.OK, RequestMessage = new HttpRequestMessage { Method = HttpMethod.Delete } }));

            DeleteDocumentQueryHandler queryHandler = new DeleteDocumentQueryHandler(mockUnitOfWork.Object, serviceHttpClient.Object, _logger.Object);

            var configuration = await GetConfiguration();
            var command = new DeleteDocumentQuery(new DeleteDocumentRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", YodleeEndpoints.GetDocuments)
            }, configuration, new Domain.Model.Authorizations.YodleeAccessToken());

            var response = await queryHandler.Handle(command, CancellationToken.None);

            Assert.IsTrue(response.IsSuccessStatusCode);
        }
    }
}