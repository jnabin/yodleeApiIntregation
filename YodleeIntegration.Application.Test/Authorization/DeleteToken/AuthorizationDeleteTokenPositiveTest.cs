using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using YodleeIntegration.Application.Authorization.DeleteAccessToken;
using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Application.Request;
using YodleeIntegration.Common.ServiceClient;

namespace YodleeIntegration.Application.Test.Authorization.DeleteToken
{
    public class AuthorizationDeleteTokenPositiveTest : BaseTest
    {
        private Mock<ILogger<DeleteAccessTokenCommandHandler>> _logger;

        [SetUp]
        public void Setup()
        {
            _serviceHttpClient = _serviceProvider.GetService<IServiceHttpClient>(); ;
            _mockYodleeConfigurationRepository = new Mock<IYodleeConfigurationRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _logger = new Mock<ILogger<DeleteAccessTokenCommandHandler>>();
        }

        [Test]
        public async Task DeleteAccessToken()
        {
            var configuration = await GetConfiguration();
            var Token = await GetToken();
            var command = new DeleteAccessTokenCommand(new BaseRequest()
            {
                Endpoint = $"{configuration.Url}/auth/token"
            }, configuration, Token.Token.Map());

            var handler = new DeleteAccessTokenCommandHandler(_mockUnitOfWork.Object, _serviceHttpClient, _logger.Object);
            var responseMessage = await handler.Handle(command, CancellationToken.None);
            Assert.AreEqual(responseMessage.StatusCode, HttpStatusCode.NoContent);
            // Arrange
        }
    }
}