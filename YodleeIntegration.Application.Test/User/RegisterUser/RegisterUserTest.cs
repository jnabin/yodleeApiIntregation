using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Linq.Expressions;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using YodleeIntegration.Api.Models;
using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Application.Request;
using YodleeIntegration.Application.Request.User;
using YodleeIntegration.Application.Response;
using YodleeIntegration.Application.User.RegisterUser;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.Test.User.RegisterUser
{
    public class RegisterUserTest : BaseUserTest
    {
        private Mock<ILogger<RegisterUserCommandHandler>> _logger;

        [SetUp]
        public void Setup()
        {
            _logger = new Mock<ILogger<RegisterUserCommandHandler>>();
        }

        [Test]
        public async Task Test_RegisterUserCommand_SuccessStatusCode()
        {
            var configuration = await GetConfiguration();

            _newServiceHttpClient.Setup(x => x.PostJsonEncodedAsync(It.IsAny<UpdateUserDetailsRequestBody>(), It.IsAny<string>())).
                Returns(MediatrMockReturns(configuration.Url, HttpMethod.Post, YodleeEndpoints.Register));

            RegisterUserCommandHandler commandHandler = new RegisterUserCommandHandler(
               _mockUnitOfWork.Object,
               _newServiceHttpClient.Object, _logger.Object);

            var token = await GetToken();
            var command = new RegisterUserCommand(new UserRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", YodleeEndpoints.User)
            }, configuration, token.Token.Map(), CreateUpdateUserDetailsRequestBody());

            var response = await commandHandler.Handle(command, CancellationToken.None);

            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [Test]
        public async Task Test_RegisterUserCommand_SuccessUserResponse()
        {
            var configuration = await GetConfiguration();

            _newServiceHttpClient.Setup(x => x.PostJsonEncodedAsync(It.IsAny<UpdateUserDetailsRequestBody>(), It.IsAny<string>())).
                Returns(MediatrMockReturns(configuration.Url, HttpMethod.Post, YodleeEndpoints.Register,
                new StringContent(JsonConvert.SerializeObject(CreateUpdateUserDetailsRequestBody()))));

            RegisterUserCommandHandler commandHandler = new RegisterUserCommandHandler(
               _mockUnitOfWork.Object,
               _newServiceHttpClient.Object, _logger.Object);

            var token = await GetToken();
            var command = new RegisterUserCommand(new UserRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", YodleeEndpoints.User)
            }, configuration, token.Token.Map(), CreateUpdateUserDetailsRequestBody());

            var response = await commandHandler.Handle(command, CancellationToken.None);

            var userResponse =
                    JsonConvert.DeserializeObject<UserResponse>(
                        await response.Content.ReadAsStringAsync());

            Assert.IsNotNull(userResponse.User);
        }

        private static UpdateUserDetailsRequestBody CreateUpdateUserDetailsRequestBody()
        {
            return
                new UpdateUserDetailsRequestBody()
                {
                    User = new Users
                    {
                        Address = new Address()
                        {
                            Address1 = "address",
                            Address2 = "address",
                            Address3 = "address",
                            City = "address",
                            Country = "address",
                            State = "address",
                            Zip = "address"
                        },
                        Email = "Email",
                        Name = new Name()
                        {
                            First = "Name",
                            FullName = "Name",
                            Last = "Name",
                            Middle = "Name"
                        },
                        Preferences = new Preference()
                        {
                            Currency = "$",
                            DateFormat = "YYYY/MM/DD",
                            Locale = "Locale",
                            TimeZone = "TimeZone"
                        },
                        SegmentName = "name"
                    }
                };
        }
    }
}