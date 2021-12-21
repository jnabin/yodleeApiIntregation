using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using YodleeIntegration.Api.Models;
using YodleeIntegration.Application.Request;
using YodleeIntegration.Application.Request.Verification;
using YodleeIntegration.Application.Response;
using YodleeIntegration.Application.Verification.InitiaiteMatchingServiceandChallengeDeposit;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.Test.Verification.InitiaiteMatchingServiceandChallengeDeposit
{
    public class InitializeChallengeDepositTest : BaseVerificationTest
    {
        private Mock<ILogger<InitializeChallengeDepositQueryHandler>> _logger;

        [SetUp]
        public void Setup()
        {
            _logger = new Mock<ILogger<InitializeChallengeDepositQueryHandler>>();
        }

        [Test]
        public async Task Test_InitializeChallengeDepositTest_SuccessStatus()
        {
            var configuration = await GetConfiguration();

            _newServiceHttpClient.Setup(x => x.PostJsonEncodedAsync(
                It.IsAny<InitializeChallengeDepositRequestBody>(), It.IsAny<string>())).Returns(
                MediatrMockReturns(configuration.Url, HttpMethod.Post, YodleeEndpoints.Verification));

            InitializeChallengeDepositQueryHandler queryHandler = new InitializeChallengeDepositQueryHandler(
                _mockUnitOfWork.Object, _newServiceHttpClient.Object, _logger.Object);

            var token = await GetToken();
            var command = new InitializeChallengeDepositQuery(new InitializeChallengeDepositRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", YodleeEndpoints.Verification)
            }, configuration, token.Token.Map(), GetInitializeChallengeDepositRequestBody());

            var response = await queryHandler.Handle(command, CancellationToken.None);

            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [Test]
        public async Task Test_InitializeChallengeDepositTest_SuccessReponse()
        {
            var configuration = await GetConfiguration();

            _newServiceHttpClient.Setup(x => x.PostJsonEncodedAsync(
                It.IsAny<InitializeChallengeDepositRequestBody>(), It.IsAny<string>())).Returns(
                MediatrMockReturns(configuration.Url, HttpMethod.Post, YodleeEndpoints.Verification,
                new StringContent(JsonConvert.SerializeObject(GetVerficationResponse()))));

            InitializeChallengeDepositQueryHandler queryHandler = new InitializeChallengeDepositQueryHandler(
                _mockUnitOfWork.Object, _newServiceHttpClient.Object, _logger.Object);

            var token = await GetToken();
            var command = new InitializeChallengeDepositQuery(new InitializeChallengeDepositRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", YodleeEndpoints.Verification)
            }, configuration, token.Token.Map(), GetInitializeChallengeDepositRequestBody());

            var response = await queryHandler.Handle(command, CancellationToken.None);

            var verificationAccountResponse =
                   JsonConvert.DeserializeObject<VerficationResponse>(
                       await response.Content.ReadAsStringAsync());

            Assert.IsNotNull(verificationAccountResponse.Verfications);
        }

        private static InitializeChallengeDepositRequestBody GetInitializeChallengeDepositRequestBody()
        {
            return new InitializeChallengeDepositRequestBody
            {
                AccountId = 123,
                ProviderAccountId = 234,
                VerificationType = "string",
                Account = new VerificationAccount()
            };
        }
    }
}