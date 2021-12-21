using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using YodleeIntegration.Api.Models;
using YodleeIntegration.Application.GetProviderCount;
using YodleeIntegration.Application.Providers;
using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Application.Request;
using YodleeIntegration.Application.Response;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.Test.ProviderTest
{
    public class ProviderIMediatorTests : BaseTest
    {
        private Mock<ILogger<GetProviderCountQueryHandler>> _loggerProviderCount;
        private Mock<IYodleeProviderCountRepository> _providerCountRepositoryMock;

        private Mock<ILogger<GetProvidersDetailsQueryHandler>> _loggerProviderDetails;
        private Mock<IYodleeProviderRepository> _providerDetailsRepositoryMock;

        private Mock<ILogger<GetProvidersQueryHandler>> _loggerProvider;

        [SetUp]
        public void Setup()
        {
            _loggerProviderCount = new Mock<ILogger<GetProviderCountQueryHandler>>();
            _loggerProviderDetails = new Mock<ILogger<GetProvidersDetailsQueryHandler>>();
            _loggerProvider = new Mock<ILogger<GetProvidersQueryHandler>>();

            _providerCountRepositoryMock = new Mock<IYodleeProviderCountRepository>();
            _providerCountRepositoryMock.Setup(m => m.SingleOrDefaultAsync(
                It.IsAny<Expression<Func<ProviderCount, bool>>>())).Returns(Task.FromResult(new ProviderCount()));
            _providerCountRepositoryMock.Setup(m => m.Add(It.IsAny<ProviderCount>())).Verifiable();
            _mockUnitOfWork.Setup(x => x.YodleeProviderCountRepository).Returns(_providerCountRepositoryMock.Object);
            _mockUnitOfWork.Setup(x => x.CompleteAsync()).Verifiable();

            _providerDetailsRepositoryMock = new Mock<IYodleeProviderRepository>();
            _providerDetailsRepositoryMock.Setup(m => m.SingleOrDefaultAsync(
                It.IsAny<Expression<Func<Provider, bool>>>())).Returns(Task.FromResult(new Provider()));
            _providerDetailsRepositoryMock.Setup(m => m.Add(It.IsAny<Provider>())).Verifiable();
            _mockUnitOfWork.Setup(x => x.YodleeProviderRepository).Returns(_providerDetailsRepositoryMock.Object);
            _mockUnitOfWork.Setup(x => x.CompleteAsync()).Verifiable();

        }

        [Test]
        public async Task Test_GetProviders_SuccessStatusCode()
        {
            var configuration = await GetConfiguration();
            _newServiceHttpClient.Setup(x => x.GetAsync(It.IsAny<string>())).
                Returns(MediatrMockReturns(configuration.Url, HttpMethod.Get, YodleeEndpoints.GetProviders));

            var token = await GetToken();
            var command = new GetProvidersQuery(new ProvidersRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", YodleeEndpoints.GetProviders)
            }, configuration, token.Token.Map());

            GetProvidersQueryHandler queryHandler = new GetProvidersQueryHandler(
                _mockUnitOfWork.Object, _newServiceHttpClient.Object, _loggerProvider.Object);

            var response = await queryHandler.Handle(command, CancellationToken.None);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [Test]
        public async Task Test_GetProviders_SuccessReponse()
        {
            var configuration = await GetConfiguration();
            _newServiceHttpClient.Setup(x => x.GetAsync(It.IsAny<string>())).
                Returns(MediatrMockReturns(configuration.Url, HttpMethod.Get, YodleeEndpoints.GetProviders,
                new StringContent(JsonConvert.SerializeObject(GetProvidersDetailsResponse()))));

            var token = await GetToken();
            var command = new GetProvidersQuery(new ProvidersRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", YodleeEndpoints.GetProviders)
            }, configuration, token.Token.Map());

            GetProvidersQueryHandler queryHandler = new GetProvidersQueryHandler(
                _mockUnitOfWork.Object, _newServiceHttpClient.Object, _loggerProvider.Object);

            var response = await queryHandler.Handle(command, CancellationToken.None);
            var providerResponse =
                    JsonConvert.DeserializeObject<ProvidersDetailsResponse>(
                        await response.Content.ReadAsStringAsync());

            Assert.IsNotNull(providerResponse.Provider);
        }

        [Test]
        public async Task Test_GetProviderDetailsHandler_SuccessStatusCode()
        {
            var configuration = await GetConfiguration();
            _newServiceHttpClient.Setup(x => x.GetAsync(It.IsAny<string>())).
                Returns(MediatrMockReturns(configuration.Url, HttpMethod.Get, $"{YodleeEndpoints.GetProvidersDetails}/76334"));

            var token = await GetToken();
            var command = new GetProvidersDetailsQuery(new ProvidersRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", $"{YodleeEndpoints.GetProvidersDetails}/76334")
            }, configuration, token.Token.Map());

            var queryHandler = new GetProvidersDetailsQueryHandler(_mockUnitOfWork.Object,
                _newServiceHttpClient.Object, _loggerProviderDetails.Object);

            var response = await queryHandler.Handle(command, CancellationToken.None);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [Test]
        public async Task Test_GetProviderDetailsHandler_SuccessResponse()
        {
            var configuration = await GetConfiguration();
            _newServiceHttpClient.Setup(x => x.GetAsync(It.IsAny<string>())).
                Returns(MediatrMockReturns(configuration.Url, HttpMethod.Get, $"{YodleeEndpoints.GetProvidersDetails}/76334",
                new StringContent(JsonConvert.SerializeObject(GetProvidersDetailsResponse()))));

            var token = await GetToken();
            var command = new GetProvidersDetailsQuery(new ProvidersRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", $"{YodleeEndpoints.GetProvidersDetails}/76334")
            }, configuration, token.Token.Map());

            var queryHandler = new GetProvidersDetailsQueryHandler(_mockUnitOfWork.Object,
                _newServiceHttpClient.Object, _loggerProviderDetails.Object);

            var response = await queryHandler.Handle(command, CancellationToken.None);
            var providerResponse =
                    JsonConvert.DeserializeObject<ProvidersDetailsResponse>(
                        await response.Content.ReadAsStringAsync());

            Assert.IsNotNull(providerResponse.Provider);
        }

        private static ProvidersDetailsResponse GetProvidersDetailsResponse()
        {
            return new ProvidersDetailsResponse
            {
                Provider = new List<Provider>()
            };
        }

        [Test]
        public async Task Test_GetProvidersCountHandler_SuccessStatusCode()
        {
            var configuration = await GetConfiguration();

            _newServiceHttpClient.Setup(x => x.GetAsync(It.IsAny<string>())).
                Returns(MediatrMockReturns(configuration.Url, HttpMethod.Get, YodleeEndpoints.GetProvidersCount));

            var token = await GetToken();
            var command = new GetProviderCountQuery(new ProvidersRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", YodleeEndpoints.GetProvidersCount)
            }, configuration, token.Token.Map());

            var queryHandler = new GetProviderCountQueryHandler(_mockUnitOfWork.Object,
                _newServiceHttpClient.Object, _loggerProviderCount.Object);

            var response = await queryHandler.Handle(command, CancellationToken.None);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [Test]
        public async Task Test_GetProvidersCountHandler_SuccessResponse()
        {
            var configuration = await GetConfiguration();

            _newServiceHttpClient.Setup(x => x.GetAsync(It.IsAny<string>())).
                Returns(MediatrMockReturns(configuration.Url, HttpMethod.Get, YodleeEndpoints.GetProvidersCount,
                new StringContent(JsonConvert.SerializeObject(GetProvidersCountResponse()))));

            var token = await GetToken();
            var command = new GetProviderCountQuery(new ProvidersRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", YodleeEndpoints.GetProvidersCount)
            }, configuration, token.Token.Map());

            var queryHandler = new GetProviderCountQueryHandler(_mockUnitOfWork.Object,
                _newServiceHttpClient.Object, _loggerProviderCount.Object);

            var response = await queryHandler.Handle(command, CancellationToken.None);

            var providerResponse =
                    JsonConvert.DeserializeObject<GetProvidersCountResponse>(
                        await response.Content.ReadAsStringAsync());

            Assert.IsNotNull(providerResponse.ProviderCount);
        }

        private static GetProvidersCountResponse GetProvidersCountResponse()
        {
            return new GetProvidersCountResponse
            {
                ProviderCount = new ProviderCount()
            };
        }
    }
}
