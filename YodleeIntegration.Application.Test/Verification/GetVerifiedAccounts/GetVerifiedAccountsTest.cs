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
using YodleeIntegration.Application.Verification.GetVerifiedAccounts;

namespace YodleeIntegration.Application.Test.Verification.GetVerifiedAccounts
{
    public class GetVerifiedAccountsTest : BaseVerificationTest
    {
        private Mock<ILogger<GetVerifiedAccountsQueryHandler>> _logger;

        [SetUp]
        public void Setup()
        {
            _logger = new Mock<ILogger<GetVerifiedAccountsQueryHandler>>();
        }

        [Test]
        public async Task Test_GetVerifiedAccounts_SuccessStatusCode()
        {
            var configuration = await GetConfiguration();

            _newServiceHttpClient.Setup(x => x.GetAsync(It.IsAny<string>())).
                Returns(MediatrMockReturns(configuration.Url, HttpMethod.Get, YodleeEndpoints.VerificationAccount));

            var token = await GetToken();
            var command = new GetVerifiedAccountsQuery(new GetVerifiedAccountsRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", YodleeEndpoints.VerificationAccount)
            }, configuration, token.Token.Map());

            var handler = new GetVerifiedAccountsQueryHandler(_mockUnitOfWork.Object,
                _newServiceHttpClient.Object, _logger.Object);

            var response = await handler.Handle(command, CancellationToken.None);

            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [Test]
        public async Task Test_GetVerifiedAccounts_SuccessResponse()
        {
            var configuration = await GetConfiguration();

            _newServiceHttpClient.Setup(x => x.GetAsync(It.IsAny<string>())).
                Returns(MediatrMockReturns(configuration.Url, HttpMethod.Get, YodleeEndpoints.VerificationAccount,
                new StringContent(JsonConvert.SerializeObject(GetVerficationResponse()))));

            var token = await GetToken();
            var command = new GetVerifiedAccountsQuery(new GetVerifiedAccountsRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", YodleeEndpoints.VerificationAccount)
            }, configuration, token.Token.Map());

            var handler = new GetVerifiedAccountsQueryHandler(_mockUnitOfWork.Object,
                 _newServiceHttpClient.Object, _logger.Object);

            var response = await handler.Handle(command, CancellationToken.None);

            var verificationAccountResponse =
                    JsonConvert.DeserializeObject<VerficationResponse>(
                        await response.Content.ReadAsStringAsync());

            Assert.IsNotNull(verificationAccountResponse.Verfications);
        }
    }
}