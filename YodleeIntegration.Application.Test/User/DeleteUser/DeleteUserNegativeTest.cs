using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using YodleeIntegration.Api.Models;
using YodleeIntegration.Application.Request;
using YodleeIntegration.Application.User.DeleteUser;

namespace YodleeIntegration.Application.Test.User.DeleteUser
{
    public class DeleteUserNegativeTest : BaseTest
    {
        private Mock<ILogger<DeleteUserQueryHandler>> _logger;

        [SetUp]
        public void Setup()
        {
            _logger = new Mock<ILogger<DeleteUserQueryHandler>>();
        }

        [Test]
        public async Task DeleteUser()
        {
            DeleteUserQueryHandler queryHandler = new DeleteUserQueryHandler(
                _mockUnitOfWork.Object,
                _newServiceHttpClient.Object, _logger.Object);

            var configuration = await GetConfiguration();

            _newServiceHttpClient.Setup(x => x.DeleteAsync(It.IsAny<string>())).
               Returns(MediatrMockReturns(configuration.Url, HttpMethod.Delete, YodleeEndpoints.DeleteUser));

            var token = await GetToken();
            var command = new DeleteUserQuery(new BaseRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", YodleeEndpoints.DeleteUser)
            }, configuration, token.Token.Map());

            var response = await queryHandler.Handle(command, CancellationToken.None);

            Assert.IsFalse(!response.IsSuccessStatusCode);
        }
    }
}