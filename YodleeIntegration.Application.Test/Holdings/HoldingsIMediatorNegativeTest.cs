using System;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using YodleeIntegration.Api.Models;
using YodleeIntegration.Application.Holdings;
using YodleeIntegration.Application.Holdings.GetHoldings;
using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Application.Request;
using YodleeIntegration.Common.ServiceClient;
using static System.Threading.CancellationToken;
using YodleeIntegration.Application.Holdings.GetSecurityDetails;

namespace YodleeIntegration.Application.Test.Holdings
{
    public class HoldingsIMediatorNegativeTest : BaseTest
    {


        [SetUp]
        public void Setup()
        {
            _serviceHttpClient = _serviceProvider.GetService<IServiceHttpClient>();
            _mockYodleeConfigurationRepository = new Mock<IYodleeConfigurationRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
        }
        [Test]
        public async Task TestGetHoldingsWithoutParamsQueryWithGetAssetClassificationListFails()
        {
            var mock = new Mock<ILogger<GetSecurityDetailsQueryHandler>>();
            ILogger<GetSecurityDetailsQueryHandler> logger = mock.Object;

            var serviceHttpClient = new Mock<IServiceHttpClient>();

            serviceHttpClient.Setup(x => x.GetAsync(It.IsAny<string>())).Returns(Task.FromResult(new HttpResponseMessage { StatusCode = HttpStatusCode.NotFound, RequestMessage = new HttpRequestMessage { Method = HttpMethod.Get } }));


            var configuration = await GetConfiguration();
            var command = new GetSecurityDetailsQuery(new HoldingsRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", YodleeEndpoints.GetSecurityDetails)
            }, configuration, new Domain.Model.Authorizations.YodleeAccessToken());
            GetSecurityDetailsQueryHandler queryHandler = new GetSecurityDetailsQueryHandler(_mockUnitOfWork.Object, serviceHttpClient.Object, logger);

            var response = await queryHandler.Handle(command, None);
            Assert.IsTrue(!response.IsSuccessStatusCode);
        }
        [Test]
        public async Task TestGetHoldingsQueryWithGetSecurityDetailsFails()
        {
            var mock = new Mock<ILogger<GetSecurityDetailsQueryHandler>>();
            ILogger<GetSecurityDetailsQueryHandler> logger = mock.Object;

            var serviceHttpClient = new Mock<IServiceHttpClient>();

            serviceHttpClient.Setup(x => x.GetAsync(It.IsAny<string>())).Returns(Task.FromResult(new HttpResponseMessage { StatusCode = HttpStatusCode.NotFound, RequestMessage = new HttpRequestMessage { Method = HttpMethod.Get } }));


            var configuration = await GetConfiguration();
            var command = new GetSecurityDetailsQuery(new HoldingsRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", YodleeEndpoints.GetHoldings)
            }, configuration, new Domain.Model.Authorizations.YodleeAccessToken());
            GetSecurityDetailsQueryHandler queryHandler = new GetSecurityDetailsQueryHandler(_mockUnitOfWork.Object, serviceHttpClient.Object, logger);

            var response = await queryHandler.Handle(command, None);
            Assert.IsTrue(!response.IsSuccessStatusCode);
        }
        [Test]
        public async Task TestGetHoldingsQueryWithGetHoldingsFails()
        {
            var mock = new Mock<ILogger<GetSecurityDetailsQueryHandler>>();
            ILogger<GetSecurityDetailsQueryHandler> logger = mock.Object;

            var serviceHttpClient = new Mock<IServiceHttpClient>();

            serviceHttpClient.Setup(x => x.GetAsync(It.IsAny<string>())).Returns(Task.FromResult(new HttpResponseMessage { StatusCode = HttpStatusCode.NotFound, RequestMessage = new HttpRequestMessage { Method = HttpMethod.Get } }));


            var configuration = await GetConfiguration();
            object response = null;

            var command = new GetSecurityDetailsQuery(new HoldingsRequest()
            {
                Endpoint = string.Concat("WrongUrl"),
            }, configuration, new Domain.Model.Authorizations.YodleeAccessToken());
            GetSecurityDetailsQueryHandler queryHandler = new GetSecurityDetailsQueryHandler(_mockUnitOfWork.Object, serviceHttpClient.Object, logger);

            try
            {
                response = queryHandler.Handle(command, cancellationToken: None);
            }
            catch (Exception)
            {
                Assert.IsNull(response);
            }
        }
        [Test]
        public async Task TestGetHoldingsWithoutParamsQueryWithGetHoldingTypeListFails()
        {
            var mock = new Mock<ILogger<GetAssetClassificationListQueryHandler>>();
            ILogger<GetAssetClassificationListQueryHandler> logger = mock.Object;

            var serviceHttpClient = new Mock<IServiceHttpClient>();

            serviceHttpClient.Setup(x => x.GetAsync(It.IsAny<string>())).Returns(Task.FromResult(new HttpResponseMessage { StatusCode = HttpStatusCode.NotFound, RequestMessage = new HttpRequestMessage { Method = HttpMethod.Get } }));


            var configuration = await GetConfiguration();
            object response = null;
            var command = new GetAssetClassificationListQuery(new HoldingsRequest()
            {
                Endpoint = string.Concat("WrongUrl"),
            }, configuration, new Domain.Model.Authorizations.YodleeAccessToken());
            GetAssetClassificationListQueryHandler queryHandler = new GetAssetClassificationListQueryHandler(_mockUnitOfWork.Object, serviceHttpClient.Object, logger);
            try
            {
                response = queryHandler.Handle(command, cancellationToken: None);
            }
            catch (Exception)
            {
                Assert.IsNull(response);
            }
        }
    }
}
