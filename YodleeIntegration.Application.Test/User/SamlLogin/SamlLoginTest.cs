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
using YodleeIntegration.Application.User.SamlLogin;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.Test.User.SamlLogin
{
    public class SamlLoginNegativeTest : BaseUserTest
    {
        private Mock<ILogger<SamlLoginQueryHandler>> _logger;

        [SetUp]
        public void Setup()
        {
            _logger = new Mock<ILogger<SamlLoginQueryHandler>>();
        }

        [Test]
        public async Task Test_SamlLoginHandler_SuccessStatusCode()
        {
            _mockUnitOfWork.Setup(x => x.RequestLogRepository)
                .Returns(_mockRequestLogRepository.Object).Verifiable();

            var configuration = await GetConfiguration();

            _newServiceHttpClient.Setup(x => x.PostJsonEncodedAsync(It.IsAny<IEnumerable<KeyValuePair<string, string>>>(), It.IsAny<string>())).
                Returns(MediatrMockReturns(configuration.Url, HttpMethod.Post, YodleeEndpoints.SamlLogin));

            SamlLoginQueryHandler commandHandler = new SamlLoginQueryHandler(
               _mockUnitOfWork.Object,
               _newServiceHttpClient.Object, _logger.Object);

            var token = await GetToken();
            var command = new SamlLoginQuery(new SamlLoginRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", YodleeEndpoints.SamlLogin)
            }, configuration, token.Token.Map());

            var response = await commandHandler.Handle(command, CancellationToken.None);

            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [Test]
        public async Task Test_SamlLoginHandler_SuccessUserResponse()
        {
            _mockUnitOfWork.Setup(x => x.RequestLogRepository)
                .Returns(_mockRequestLogRepository.Object).Verifiable();

            var configuration = await GetConfiguration();

            _newServiceHttpClient.Setup(x => x.PostJsonEncodedAsync(It.IsAny<IEnumerable<KeyValuePair<string, string>>>(), It.IsAny<string>())).
                Returns(MediatrMockReturns(configuration.Url, HttpMethod.Post, YodleeEndpoints.SamlLogin,
               new StringContent(JsonConvert.SerializeObject(GetUserResponse()))));

            SamlLoginQueryHandler commandHandler = new SamlLoginQueryHandler(
               _mockUnitOfWork.Object,
               _newServiceHttpClient.Object, _logger.Object);

            var token = await GetToken();
            var command = new SamlLoginQuery(new SamlLoginRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", YodleeEndpoints.SamlLogin)
            }, configuration, token.Token.Map());

            var response = await commandHandler.Handle(command, CancellationToken.None);

            var userResponse =
                    JsonConvert.DeserializeObject<UserResponse>(
                        await response.Content.ReadAsStringAsync());

            Assert.IsNotNull(userResponse.User);
        }
    }
}