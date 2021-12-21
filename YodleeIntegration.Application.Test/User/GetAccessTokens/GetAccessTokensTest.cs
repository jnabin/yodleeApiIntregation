using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using YodleeIntegration.Api.Models;
using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Application.Request.User;
using YodleeIntegration.Application.Response;
using YodleeIntegration.Application.User.GetAccessTokens;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.Test.User.GetAccessTokens
{
    public class GetAccessTokensTest : BaseTest
    {
        private Mock<ILogger<GetAccessTokensQueryHandler>> _logger;
        private Mock<IYodleeAccessTokensRepository> _accessTokenRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _logger = new Mock<ILogger<GetAccessTokensQueryHandler>>();
            _accessTokenRepositoryMock = new Mock<IYodleeAccessTokensRepository>();

            _accessTokenRepositoryMock.Setup(m => m.SingleOrDefaultAsync(
                It.IsAny<Expression<Func<AccessTokens, bool>>>())).Returns(Task.FromResult(new AccessTokens()));

            _accessTokenRepositoryMock.Setup(m => m.Update(It.IsAny<AccessTokens>())).Verifiable();

            _mockUnitOfWork.Setup(x => x.YodleeAccessTokensRepository).Returns(_accessTokenRepositoryMock.Object);
            _mockUnitOfWork.Setup(x => x.CompleteAsync()).Verifiable();
        }

        [Test]
        public async Task Test_GetAccessTokens_SuccessStatusCode()
        {
            _mockUnitOfWork.Setup(x => x.RequestLogRepository)
                .Returns(_mockRequestLogRepository.Object).Verifiable();

            var configuration = await GetConfiguration();

            _newServiceHttpClient.Setup(x => x.GetAsync(It.IsAny<string>(), It.IsAny<IEnumerable<KeyValuePair<string, string>>>())).
                Returns(MediatrMockReturns(configuration.Url, HttpMethod.Get, YodleeEndpoints.AccessTokens));

            GetAccessTokensQueryHandler queryHandler = new GetAccessTokensQueryHandler(
               _mockUnitOfWork.Object,
               _newServiceHttpClient.Object, _logger.Object);

            var token = await GetToken();
            var command = new GetAccessTokensQuery(new AccessTokensRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", YodleeEndpoints.AccessTokens)
            }, configuration, token.Token.Map());

            var response = await queryHandler.Handle(command, CancellationToken.None);

            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [Test]
        public async Task Test_GetAccessTokens_SuccessAccessTokenResponse()
        {
            _mockUnitOfWork.Setup(x => x.RequestLogRepository)
                .Returns(_mockRequestLogRepository.Object).Verifiable();

            var configuration = await GetConfiguration();

            _newServiceHttpClient.Setup(x => x.GetAsync(It.IsAny<string>(), It.IsAny<IEnumerable<KeyValuePair<string, string>>>())).
                Returns(MediatrMockReturns(configuration.Url, HttpMethod.Get, YodleeEndpoints.AccessTokens,
                new StringContent(JsonConvert.SerializeObject(GetUserAccessToken()))));

            GetAccessTokensQueryHandler queryHandler = new GetAccessTokensQueryHandler(
               _mockUnitOfWork.Object,
               _newServiceHttpClient.Object, _logger.Object);

            var token = await GetToken();
            var command = new GetAccessTokensQuery(new AccessTokensRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", YodleeEndpoints.AccessTokens)
            }, configuration, token.Token.Map());

            var response = await queryHandler.Handle(command, CancellationToken.None);

            var tokenResponse =
                    JsonConvert.DeserializeObject<UserAccessToken>(
                        await response.Content.ReadAsStringAsync());

            Assert.IsNotNull(tokenResponse.AccessToken);
        }

        private static UserAccessToken GetUserAccessToken()
        {
            return new UserAccessToken
            {
                AccessToken = new AccessToken
                {
                    AccessTokens = new List<AccessTokens>()
                }
            };
        }
    }
}