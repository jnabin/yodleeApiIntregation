using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using YodleeIntegration.Api.Models;
using YodleeIntegration.Application.Request.Verification;
using YodleeIntegration.Application.Response;
using YodleeIntegration.Application.Verification.GetVerificationStatus;

namespace YodleeIntegration.Application.Test.Verification.GetVerificationStatus
{
    public class GetVerificationStatusTest : BaseVerificationTest
    {
        private Mock<ILogger<GetVerificationStatusQueryHandler>> _logger;

        [SetUp]
        public void Setup()
        {
            _logger = new Mock<ILogger<GetVerificationStatusQueryHandler>>();
        }

        [Test]
        public async Task Test_GetVerificationStatus_SuccessStatusCode()
        {
            var configuration = await GetConfiguration();

            _newServiceHttpClient.Setup(x => x.GetAsync(It.IsAny<string>())).
                Returns(MediatrMockReturns(configuration.Url, HttpMethod.Get, YodleeEndpoints.Verification));

            GetVerificationStatusQueryHandler queryHandler = new GetVerificationStatusQueryHandler(
                _mockUnitOfWork.Object, _newServiceHttpClient.Object, _logger.Object);

            var token = await GetToken();
            var command = new GetVerificationStatusQuery(new VerificationStatusRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", YodleeEndpoints.Verification)
            }, configuration, token.Token.Map());

            var response = await queryHandler.Handle(command, CancellationToken.None);

            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [Test]
        public async Task Test_GetVerificationStatus_SuccessResponse()
        {
            var configuration = await GetConfiguration();

            _newServiceHttpClient.Setup(x => x.GetAsync(It.IsAny<string>())).
                Returns(MediatrMockReturns(configuration.Url, HttpMethod.Get, YodleeEndpoints.Verification,
                 new StringContent(JsonConvert.SerializeObject(GetVerficationResponse()))));

            GetVerificationStatusQueryHandler queryHandler = new GetVerificationStatusQueryHandler(
                _mockUnitOfWork.Object, _newServiceHttpClient.Object, _logger.Object);

            var token = await GetToken();
            var command = new GetVerificationStatusQuery(new VerificationStatusRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", YodleeEndpoints.Verification)
            }, configuration, token.Token.Map());

            var response = await queryHandler.Handle(command, CancellationToken.None);

            var verificationResponse =
                    JsonConvert.DeserializeObject<VerficationResponse>(
                        await response.Content.ReadAsStringAsync());

            Assert.IsNotNull(verificationResponse.Verfications);
        }
    }
}