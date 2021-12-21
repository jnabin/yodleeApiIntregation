using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using YodleeIntegration.Api.Models;
using YodleeIntegration.Application.Authorization.GenerateAccessToken;
using YodleeIntegration.Application.DataExtracts.GetEvents;
using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Application.Request.DataExtracts;
using YodleeIntegration.Common.ServiceClient;

namespace YodleeIntegration.Application.Test.DataExtracts.GetEvents
{
    public class GetEventsNegativeTest : BaseTest
    {
        private Mock<ILogger<GetEventsQueryHandler>> _logger;

        [SetUp]
        public void Setup()
        {
            _serviceHttpClient = _serviceProvider.GetService<IServiceHttpClient>();
            _mockYodleeConfigurationRepository = new Mock<IYodleeConfigurationRepository>();
            _mockYodleeAccessTokenRepository = new Mock<IYodleeAccessTokenRepository>();
            _mockRequestLogRepository = new Mock<IRequestLogRepository>();
            _loggerToken = new Mock<ILogger<GenerateAccessTokenCommandHandler>>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _logger = new Mock<ILogger<GetEventsQueryHandler>>();
        }

        [Test]
        public async Task GetEvents()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var serviceHttpClient = new Mock<IServiceHttpClient>();

            serviceHttpClient.Setup(x => x.GetAsync(It.IsAny<string>())).Returns(Task.FromResult(new HttpResponseMessage { StatusCode = HttpStatusCode.OK, RequestMessage = new HttpRequestMessage { Method = HttpMethod.Get } }));

            GetEventsQueryHandler queryHandler = new GetEventsQueryHandler(mockUnitOfWork.Object, serviceHttpClient.Object, _logger.Object);

            var configuration = await GetConfiguration();
            var command = new GetEventsQuery(new EventsRequest()
            {
                QueryParameters = GetParams(),
                Endpoint = string.Concat($"{configuration.Url}", YodleeEndpoints.Events)
            }, configuration, new Domain.Model.Authorizations.YodleeAccessToken());

            var response = await queryHandler.Handle(command, CancellationToken.None);

            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        private static IEnumerable<KeyValuePair<string, string>> GetParams()
        {
            var parameters = new List<KeyValuePair<string, string>>();
            parameters.Add(new KeyValuePair<string, string>("FromDate", "1/1/2000"));
            parameters.Add(new KeyValuePair<string, string>("ToDate", "1/1/2021"));
            parameters.Add(new KeyValuePair<string, string>("EventName", "Event"));
            return parameters;
        }
    }
}