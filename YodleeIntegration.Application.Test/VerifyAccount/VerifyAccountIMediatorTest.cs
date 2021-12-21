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
using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Application.Request;
using YodleeIntegration.Application.Response;
using YodleeIntegration.Application.VerifyAccounts;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.Test.VerifyAccount
{
    public class VerifyAccountIMediatorPositiveTest : BaseTest
    {
        private Mock<ILogger<VerifyAccountCommandHandler>> _logger;
        private Mock<IYodleeVerifyAccountDTORepository> _verifyRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _logger = new Mock<ILogger<VerifyAccountCommandHandler>>();

            _verifyRepositoryMock = new Mock<IYodleeVerifyAccountDTORepository>();

            _verifyRepositoryMock.Setup(m => m.SingleOrDefaultAsync(
                It.IsAny<Expression<Func<VerifyAccountDTO, bool>>>())).Returns(Task.FromResult(new VerifyAccountDTO()));

            _verifyRepositoryMock.Setup(m => m.Add(It.IsAny<VerifyAccountDTO>())).Verifiable();

            _mockUnitOfWork.Setup(x => x.YodleeVerifyAccountDTORepository).Returns(_verifyRepositoryMock.Object);

            _mockUnitOfWork.Setup(x => x.CompleteAsync()).Verifiable();
        }

        [Test]
        public async Task Test_VerifyAccountCommand_SuccessStatusCode()
        {
            var configuration = await GetConfiguration();

            VerifyAccountRequestBody verifyAccountRequestBody = CreateVerifyAccountRequestBody();

            var token = await GetToken();
            var command = new VerifyAccountCommand(new VerifyAccountRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", $"{YodleeEndpoints.VerifyAccount}")
            }, configuration, token.Token.Map(), verifyAccountRequestBody);

            _newServiceHttpClient.Setup(x => x.PostJsonEncodedAsync(verifyAccountRequestBody, It.IsAny<string>())).
                Returns(MediatrMockReturns(configuration.Url, HttpMethod.Post, YodleeEndpoints.VerifyAccount));

            VerifyAccountCommandHandler queryHandler = new VerifyAccountCommandHandler(_mockUnitOfWork.Object,
                _newServiceHttpClient.Object, _logger.Object);

            var response = await queryHandler.Handle(command, CancellationToken.None);

            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [Test]
        public async Task Test_VerifyAccountCommand_SuccessResponse()
        {
            var configuration = await GetConfiguration();

            VerifyAccountRequestBody verifyAccountRequestBody = CreateVerifyAccountRequestBody();

            var token = await GetToken();
            var command = new VerifyAccountCommand(new VerifyAccountRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", $"{YodleeEndpoints.VerifyAccount}")
            }, configuration, token.Token.Map(), verifyAccountRequestBody);

            _newServiceHttpClient.Setup(x => x.PostJsonEncodedAsync(verifyAccountRequestBody, It.IsAny<string>())).
                Returns(MediatrMockReturns(configuration.Url, HttpMethod.Post, YodleeEndpoints.VerifyAccount,
                new StringContent(JsonConvert.SerializeObject(GetVerifyAccountResponseBody()))));

            VerifyAccountCommandHandler queryHandler = new VerifyAccountCommandHandler(_mockUnitOfWork.Object,
                _newServiceHttpClient.Object, _logger.Object);

            var response = await queryHandler.Handle(command, CancellationToken.None);

            var verifyResponse =
                    JsonConvert.DeserializeObject<VerifyAccountResponseBody>(
                        await response.Content.ReadAsStringAsync());

            Assert.IsNotNull(verifyResponse.VerifyAccount);

        }

        private static VerifyAccountRequestBody CreateVerifyAccountRequestBody()
        {
            return new VerifyAccountRequestBody{
                    Container = "bank",
                    AccountId = 10045967,

                    TransactionCriteria = new List<VerifyAccountTransactionCriteria>()
                    {
                        new VerifyAccountTransactionCriteria()
                        {
                            Date="string",
                            Amount=0,
                            Keyword="string",
                            DateVariance="string",
                            BaseType="CREDIT"
                        }
                    }
                };
        }

        private static VerifyAccountResponseBody GetVerifyAccountResponseBody()
        {
            return new VerifyAccountResponseBody
            {
                VerifyAccount = new VerifyAccountDTO()
            };
        }

    }
}