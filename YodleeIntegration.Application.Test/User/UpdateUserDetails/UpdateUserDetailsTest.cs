using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using YodleeIntegration.Api.Models;
using YodleeIntegration.Application.Request;
using YodleeIntegration.Application.Request.User;
using YodleeIntegration.Application.Response;
using YodleeIntegration.Application.User.UpdateUserDetails;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.Test.User.UpdateUserDetails
{
    public class UpdateUserDetailsTest : BaseUserTest
    {
        private Mock<ILogger<UpdateUserDetailsCommandHandler>> _logger;

        [SetUp]
        public void Setup()
        {
            _logger = new Mock<ILogger<UpdateUserDetailsCommandHandler>>();
        }

        [Test]
        public async Task Tesy_UpdateUserDetails_SuccessStatusCode()
        {
            _mockUnitOfWork.Setup(x => x.RequestLogRepository)
                .Returns(_mockRequestLogRepository.Object).Verifiable();

            var configuration = await GetConfiguration();

            _newServiceHttpClient.Setup(x => x.PutAsync(It.IsAny<UpdateUserDetailsRequestBody>(), It.IsAny<string>())).
                Returns(MediatrMockReturns(configuration.Url, HttpMethod.Put, YodleeEndpoints.User));

            UpdateUserDetailsCommandHandler commandHandler = new UpdateUserDetailsCommandHandler(
                _mockUnitOfWork.Object,
                _newServiceHttpClient.Object, _logger.Object);

            var token = await GetToken();
            var command = new UpdateUserDetailsCommand(new UserRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", YodleeEndpoints.User)
            }, configuration, token.Token.Map(), GetUpdateUserRequestBody());

            var response = await commandHandler.Handle(command, CancellationToken.None);

            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [Test]
        public async Task Tesy_UpdateUserDetails_SuccessUserResponse()
        {
            _mockUnitOfWork.Setup(x => x.RequestLogRepository)
                .Returns(_mockRequestLogRepository.Object).Verifiable();

            var configuration = await GetConfiguration();

            _newServiceHttpClient.Setup(x => x.PutAsync(It.IsAny<UpdateUserDetailsRequestBody>(), It.IsAny<string>())).
                Returns(MediatrMockReturns(configuration.Url, HttpMethod.Put, YodleeEndpoints.User,
                new StringContent(JsonConvert.SerializeObject(GetUpdateUserRequestBody()))));

            UpdateUserDetailsCommandHandler commandHandler = new UpdateUserDetailsCommandHandler(
                _mockUnitOfWork.Object,
                _newServiceHttpClient.Object, _logger.Object);

            var token = await GetToken();
            var command = new UpdateUserDetailsCommand(new UserRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", YodleeEndpoints.User)
            }, configuration, token.Token.Map(), GetUpdateUserRequestBody());

            var response = await commandHandler.Handle(command, CancellationToken.None);

            var userResponse =
                    JsonConvert.DeserializeObject<UserResponse>(
                        await response.Content.ReadAsStringAsync());

            Assert.IsNotNull(userResponse.User);
        }

        private static UpdateUserDetailsRequestBody GetUpdateUserRequestBody()
        {
            return new UpdateUserDetailsRequestBody
            {
                User = new Users
                {
                    Preferences = new Preference
                    {
                        DateFormat = "yyyy-dd-mm",
                        TimeZone = "utc",
                        Currency = "USD",
                        Locale = "en_US"
                    },
                    Address = new Address
                    {
                        Zip = "string",
                        Country = "America",
                        Address3 = "string",
                        Address2 = "string",
                        Address1 = "string",
                        City = "string",
                        State = "string"
                    },
                    Name = new Name
                    {
                        Middle = "string",
                        Last = "string",
                        FullName = "string",
                        First = "string"
                    },
                    Email = "string",
                    SegmentName = "string"
                }
            };
        }

    }
}