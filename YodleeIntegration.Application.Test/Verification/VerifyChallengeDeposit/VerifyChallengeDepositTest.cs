using System.Collections.Generic;
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
using YodleeIntegration.Application.Verification.VerifyChallengeDeposit;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.Test.Verification.VerifyChallengeDeposit
{
    public class VerifyChallengeDepositTest : BaseVerificationTest
    {
        private Mock<ILogger<VerifyChallengeDepositCommandHandler>> _logger;

        [SetUp]
        public void Setup()
        {
            _logger = new Mock<ILogger<VerifyChallengeDepositCommandHandler>>();
        }

        [Test]
        public async Task Test_VerifyChallengeDeposit_SuccessStatus()
        {
            var configuration = await GetConfiguration();

            _newServiceHttpClient.Setup(x => x.PutAsync(It.IsAny<VerifyChallengeDepositRequestBody>(),
                It.IsAny<string>())).Returns(MediatrMockReturns(configuration.Url, HttpMethod.Post,
                YodleeEndpoints.Verification));

            VerifyChallengeDepositCommandHandler queryHandler = new VerifyChallengeDepositCommandHandler(
                _mockUnitOfWork.Object, _newServiceHttpClient.Object, _logger.Object);
            
            var token = await GetToken();
            var command = new VerifyChallengeDepositCommand(new VerifyChallengeDepositRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", YodleeEndpoints.Verification)
            }, configuration, token.Token.Map(), new VerifyChallengeDepositRequestBody());

            var response = await queryHandler.Handle(command, CancellationToken.None);

            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [Test]
        public async Task Test_VerifyChallengeDeposit_SuccessResponse()
        {
            var configuration = await GetConfiguration();

            _newServiceHttpClient.Setup(x => x.PutAsync(It.IsAny<VerifyChallengeDepositRequestBody>(),
                It.IsAny<string>())).Returns(MediatrMockReturns(configuration.Url, HttpMethod.Post,
                YodleeEndpoints.Verification,
                new StringContent(JsonConvert.SerializeObject(GetVerficationResponse()))));

            VerifyChallengeDepositCommandHandler queryHandler = new VerifyChallengeDepositCommandHandler(
                _mockUnitOfWork.Object, _newServiceHttpClient.Object, _logger.Object);

            var token = await GetToken();
            var command = new VerifyChallengeDepositCommand(new VerifyChallengeDepositRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", YodleeEndpoints.Verification)
            }, configuration, token.Token.Map(), new VerifyChallengeDepositRequestBody());

            var response = await queryHandler.Handle(command, CancellationToken.None);

            var verificationAccountResponse =
                   JsonConvert.DeserializeObject<VerficationResponse>(
                       await response.Content.ReadAsStringAsync());

            Assert.IsNotNull(verificationAccountResponse.Verfications);
        }

        private static VerifyChallengeDepositRequestBody GetVerifyChallengeDepositRequestBody()
        {
            return new VerifyChallengeDepositRequestBody
            {
                AccountId = 123,
                ProviderAccountId = 344,
                Account = new VerificationAccount(),
                Transaction = new List<VerificationTransaction>()
            };
        }
    }
}