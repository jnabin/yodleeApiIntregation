using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using YodleeIntegration.Api.Models;
using YodleeIntegration.Application.Derived.GetHoldingSummary;
using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Application.Request.Derived;
using YodleeIntegration.Common.ServiceClient;

namespace YodleeIntegration.Application.Test.Derived.GetHoldingSummary
{
    public class GetHoldingSummaryNegativeTest : BaseTest
    {
        private Mock<ILogger<GetHoldingSummaryQueryHandler>> _logger;

        [SetUp]
        public void Setup()
        {
            _serviceHttpClient = _serviceProvider.GetService<IServiceHttpClient>(); ;
            _mockYodleeConfigurationRepository = new Mock<IYodleeConfigurationRepository>();
            _logger = new Mock<ILogger<GetHoldingSummaryQueryHandler>>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
        }

        [Test]
        public async Task GetHoldingSummary()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var serviceHttpClient = new Mock<IServiceHttpClient>();

            serviceHttpClient.Setup(x => x.GetAsync(It.IsAny<string>())).Returns(Task.FromResult(new HttpResponseMessage { StatusCode = HttpStatusCode.OK, RequestMessage = new HttpRequestMessage { Method = HttpMethod.Get } }));

            GetHoldingSummaryQueryHandler queryHandler = new GetHoldingSummaryQueryHandler(mockUnitOfWork.Object, serviceHttpClient.Object, _logger.Object);

            var configuration = await GetConfiguration();
            var command = new GetHoldingSummaryQuery(new HoldingSummaryRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", YodleeEndpoints.HoldingsSummary)
            }, configuration, new Domain.Model.Authorizations.YodleeAccessToken());

            var response = await queryHandler.Handle(command, CancellationToken.None);

            Assert.IsTrue(response.IsSuccessStatusCode);
        }
    }
}