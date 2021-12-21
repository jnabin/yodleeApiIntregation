using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;
using YodleeIntegration.Application.Authorization.GenerateAccessToken;
using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Application.Request;
using YodleeIntegration.Common.ServiceClient;

namespace YodleeIntegration.Application.Test.Authorization.GetToken
{
    public class AuthorizationGetTokenNegetiveTest : BaseTest
    {
        private Mock<ILogger<GenerateAccessTokenCommandHandler>> _logger;

        [SetUp]
        public void Setup()
        {
            _serviceHttpClient = _serviceProvider.GetService<IServiceHttpClient>(); ;
            _mockYodleeConfigurationRepository = new Mock<IYodleeConfigurationRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _logger = new Mock<ILogger<GenerateAccessTokenCommandHandler>>();
        }

        [Test]
        public async Task GetAccessToken()
        {
            var configuration = await GetConfiguration();

            _mockUnitOfWork.Setup(x => x.RequestLogRepository)
                .Returns(_mockRequestLogRepository.Object).Verifiable();
            Assert.IsNotNull(configuration);
            Assert.IsNotNull(configuration.EntityId);
            Assert.Greater(configuration.EntityId, 0);

            var command = new GenerateAccessTokenDataCommand(new AuthorizationUserTokenRequest
            {
                ClientId = configuration.ClientId,
                Secret = configuration.Secret,
                Endpoint = $"{configuration.Url}/auth/token"
            }, configuration, configuration.Username);

            var handler = new GenerateAccessTokenCommandHandler(_mockUnitOfWork.Object, _serviceHttpClient, _logger.Object);
            var responseMessage = await handler.Handle(command, CancellationToken.None);

            Assert.IsNotNull(responseMessage);
            Assert.IsTrue(responseMessage.IsSuccessStatusCode);
        }
    }
}