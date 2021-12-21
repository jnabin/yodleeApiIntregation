using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using YodleeIntegration.Api.Models;
using YodleeIntegration.Application.DataExtracts.GetUserData;
using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Application.Request.DataExtracts;
using YodleeIntegration.Common.ServiceClient;

namespace YodleeIntegration.Application.Test.DataExtracts.GetUserData
{
    public class GetUserDataPositiveTest : BaseTest
    {
        private Mock<ILogger<GetUserDataQueryHandler>> _logger;

        [SetUp]
        public void Setup()
        {
            _serviceHttpClient = _serviceProvider.GetService<IServiceHttpClient>();
            _mockYodleeConfigurationRepository = new Mock<IYodleeConfigurationRepository>();
            _logger = new Mock<ILogger<GetUserDataQueryHandler>>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
        }

        [Test]
        public async Task GetUserData()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var serviceHttpClient = new Mock<IServiceHttpClient>();

            serviceHttpClient.Setup(x => x.GetAsync(It.IsAny<string>())).Returns(Task.FromResult(new HttpResponseMessage { StatusCode = HttpStatusCode.OK, RequestMessage = new HttpRequestMessage { Method = HttpMethod.Get } }));

            GetUserDataQueryHandler queryHandler = new GetUserDataQueryHandler(mockUnitOfWork.Object, serviceHttpClient.Object, _logger.Object);

            var configuration = await GetConfiguration();
            var command = new GetUserDataQuery(new UserDataRequest()
            {
                QueryParameters = GetParams(),
                Endpoint = string.Concat($"{configuration.Url}", YodleeEndpoints.UserData)
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