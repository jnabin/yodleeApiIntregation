using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using YodleeIntegration.Api.Models;
using YodleeIntegration.Application.Request;
using YodleeIntegration.Application.Response;
using YodleeIntegration.Application.User.GetUserDetails;

namespace YodleeIntegration.Application.Test.User.GetUserDetails
{
    public class GetUserDetailsTest : BaseUserTest
    {
        private Mock<ILogger<GetUserDetailsQueryHandler>> _logger;

        [SetUp]
        public void Setup()
        {
            _logger = new Mock<ILogger<GetUserDetailsQueryHandler>>();
        }

        [Test]
        public async Task Test_GetUserDetailsHandler_SuccessStatusCode()
        {
            GetUserDetailsQueryHandler queryHandler = new GetUserDetailsQueryHandler(
                _mockUnitOfWork.Object,
                _newServiceHttpClient.Object, _logger.Object);

            var configuration = await GetConfiguration();

            _newServiceHttpClient.Setup(x => x.GetAsync(It.IsAny<string>())).
               Returns(MediatrMockReturns(configuration.Url, HttpMethod.Get, YodleeEndpoints.User,
               new StringContent(JsonConvert.SerializeObject(GetUserResponse()))));

            var token = await GetToken();
            var command = new GetUserDetailsQuery(new BaseRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", YodleeEndpoints.User)
            }, configuration, token.Token.Map());

            var response = await queryHandler.Handle(command, CancellationToken.None);

            Assert.IsTrue(response.IsSuccessStatusCode);

        }

        [Test]
        public async Task Test_GetUserDetailsHandler_SucceesUserResponse()
        {
            GetUserDetailsQueryHandler queryHandler = new GetUserDetailsQueryHandler(
                _mockUnitOfWork.Object,
                _newServiceHttpClient.Object, _logger.Object);

            var configuration = await GetConfiguration();

            _newServiceHttpClient.Setup(x => x.GetAsync(It.IsAny<string>())).
               Returns(MediatrMockReturns(configuration.Url, HttpMethod.Get, YodleeEndpoints.User,
               new StringContent(JsonConvert.SerializeObject(GetUserResponse()))));

            var token = await GetToken();
            var command = new GetUserDetailsQuery(new BaseRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", YodleeEndpoints.User)
            }, configuration, token.Token.Map());

            var response = await queryHandler.Handle(command, CancellationToken.None);

            var userResponse =
                    JsonConvert.DeserializeObject<UserResponse>(
                        await response.Content.ReadAsStringAsync());

            Assert.IsNotNull(userResponse.User);

        }

    }
}