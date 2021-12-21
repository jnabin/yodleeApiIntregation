using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using YodleeIntegration.Api.Models;
using YodleeIntegration.Application.Configs.DeleteSubscriptionNotification;
using YodleeIntegration.Application.Configs.GetPublicKey;
using YodleeIntegration.Application.Configs.GetSubscribedNotifications;
using YodleeIntegration.Application.Configs.SubscribeNotificationEvent;
using YodleeIntegration.Application.Configs.UpdateNotificationEvent;
using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Application.Request;
using YodleeIntegration.Common.ServiceClient;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.Test.Configs
{
    public class ConfigsIMediatorTest : BaseTest
    {


        [SetUp]
        public void Setup()
        {
            _serviceHttpClient = _serviceProvider.GetService<IServiceHttpClient>();
            _mockYodleeConfigurationRepository = new Mock<IYodleeConfigurationRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
        }

        [Test]
        public async Task GetSubscribedNotificationsQueryWithGetSubscribedNotifications()
        {
            var mock = new Mock<ILogger<GetSubscribedNotificationsHandler>>();
            ILogger<GetSubscribedNotificationsHandler> logger = mock.Object;
            var configuration = await GetConfiguration(); var Token = await GetToken();
            var getSubscribedNotificationQueryParams = new GetSubscribedNotificationQueryParams();
            var command = new GetSubscribedNotificationsQuery(new ConfigsRequest
            {
                Endpoint = $"{configuration.Url}/configs/notifications/events",
                QueryParameters = getSubscribedNotificationQueryParams.GetQueryParamsList()
            }, configuration, Token.Token.Map());

            var handler = new GetSubscribedNotificationsHandler(_mockUnitOfWork.Object, _serviceHttpClient, logger);
            var responseMessage = await handler.Handle(command, CancellationToken.None);
            Assert.IsNotNull(responseMessage);
            Assert.IsTrue(responseMessage.IsSuccessStatusCode);
        }

        [Test]
        public async Task GetPublcKeyQueryWithGetPublcKey()
        {
            var mock = new Mock<ILogger<GetPublicKeyQueryHandler>>();
            ILogger<GetPublicKeyQueryHandler> logger = mock.Object;
            var configuration = await GetConfiguration(); var Token = await GetToken();
            var command = new GetPublicKeyQuery(new PublicKeyRequest
            {
                Endpoint = $"{configuration.Url}/configs/publicKey"
            }, configuration, Token.Token.Map());

            var handler = new GetPublicKeyQueryHandler(_mockUnitOfWork.Object, _serviceHttpClient, logger);
            var responseMessage = await handler.Handle(command, CancellationToken.None);
            Assert.IsNotNull(responseMessage);
            Assert.IsTrue(responseMessage.IsSuccessStatusCode);
        }

        [Test]
        public async Task UpdateNotificationEventCommand()
        {
            var mock = new Mock<ILogger<UpdateNotificationEventHandler>>();
            ILogger<UpdateNotificationEventHandler> logger = mock.Object;
            var configuration = await GetConfiguration(); var Token = await GetToken();
            var updateNotificationEventRequestBody = CreateUpdateNotificationEventRequestBody();
            var command = new UpdateNotificationEventCommand(new ConfigsRequest
            {
                Endpoint = $"{configuration.Url}/configs/notifications/events/string",
            }, configuration, Token.Token.Map(), updateNotificationEventRequestBody);

            var handler = new UpdateNotificationEventHandler(_mockUnitOfWork.Object, _serviceHttpClient, logger);
            var responseMessage = await handler.Handle(command, CancellationToken.None);
            Assert.IsNotNull(responseMessage);
            Assert.IsTrue(responseMessage.IsSuccessStatusCode);
        }

        [Test]
        public async Task SubscribeNotificationEventCommand()
        {
            var mock = new Mock<ILogger<SubscribeNotificationEventHandler>>();
            ILogger<SubscribeNotificationEventHandler> logger = mock.Object;
            var configuration = await GetConfiguration(); var Token = await GetToken();
            var subscribeNotificationEventRequestBody = CreateSubscribeNotificationEventRequestBody();
            var command = new SubscribeNotificationEventCommand(new ConfigsRequest
            {
                Endpoint = $"{configuration.Url}/configs/notifications/events/string",
            }, configuration, Token.Token.Map(), subscribeNotificationEventRequestBody);

            var handler = new SubscribeNotificationEventHandler(_mockUnitOfWork.Object, _serviceHttpClient, logger);
            var responseMessage = await handler.Handle(command, CancellationToken.None);
            Assert.IsNotNull(responseMessage);
            Assert.IsTrue(responseMessage.IsSuccessStatusCode);
        }

        private static SubscribeNotificationEventRequestBody CreateSubscribeNotificationEventRequestBody()
        {
            return
                new SubscribeNotificationEventRequestBody
                {
                    Event = new NotificationEvent
                    {
                        CallBackUrl = "string"
                    }
                };
        }

        private static UpdateNotificationEventRequestBody CreateUpdateNotificationEventRequestBody()
        {
            var updateAccountRequestBody =
                new UpdateNotificationEventRequestBody()
                {
                    Event = new NotificationEvent()
                    {
                        CallBackUrl = "string",
                    }
                };
            return updateAccountRequestBody;
        }

        [Test]
        public async Task DeleteNotificationSubscribeCommand()
        {
            var mock = new Mock<ILogger<DeleteSubscriptionNotificationHandler>>();
            ILogger<DeleteSubscriptionNotificationHandler> logger = mock.Object;
            var configuration = await GetConfiguration(); var Token = await GetToken();
            var command = new DeleteSubscriptionNotificationCommand(new ConfigsRequest
            {
                Endpoint = $"{configuration.Url}/configs/notifications/events/string",
            }, configuration, Token.Token.Map());

            var handler = new DeleteSubscriptionNotificationHandler(_mockUnitOfWork.Object, _serviceHttpClient, logger);
            var responseMessage = await handler.Handle(command, CancellationToken.None);
            Assert.IsNotNull(responseMessage);
            Assert.IsTrue(responseMessage.StatusCode.Equals(HttpStatusCode.NoContent));
        }


    }
}