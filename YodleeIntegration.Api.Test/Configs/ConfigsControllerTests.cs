using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using YodleeIntegration.Api.Controllers.Configs;
using YodleeIntegration.Api.Models;
using YodleeIntegration.Application.Configs.DeleteSubscriptionNotification;
using YodleeIntegration.Application.Configs.GetPublicKey;
using YodleeIntegration.Application.Configs.GetSubscribedNotifications;
using YodleeIntegration.Application.Configs.SubscribeNotificationEvent;
using YodleeIntegration.Application.Configs.UpdateNotificationEvent;
using YodleeIntegration.Application.Request;
using YodleeIntegration.Domain.Entities;
using Assert = NUnit.Framework.Assert;

namespace YodleeIntegration.Api.Test.Configs
{
    public class ConfigsControllerTests : BaseApiTest
    {

        [Test]
        public async Task GetSubscribedNotificationSucceeds()
        {
            _mockMediatr.Setup(m =>
               m.Send(It.IsAny<GetSubscribedNotificationsQuery>(),
                   It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(
                       HttpStatusCode.OK, HttpMethod.Get));

            var configController = new ConfigsController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await configController.GetSubscribedNotification(
                GetSubscribedNotificationParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task GetSubscribedNotificationUnauthorize()
        {
            _mockMediatr.Setup(m =>
               m.Send(It.IsAny<GetSubscribedNotificationsQuery>(),
                   It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(
                       HttpStatusCode.Unauthorized, HttpMethod.Get));

            var configController = new ConfigsController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await configController.GetSubscribedNotification(
                GetSubscribedNotificationParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(401, okResult.StatusCode);
        }

        [Test]
        public async Task GetSubscribedNotificationBadRequest()
        {
            _mockMediatr.Setup(m =>
               m.Send(It.IsAny<GetSubscribedNotificationsQuery>(),
                   It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(
                       HttpStatusCode.BadRequest, HttpMethod.Get));

            var configController = new ConfigsController(_mockMediatr.Object, _baseControllerMock.Object);
            configController.ModelState.AddModelError(string.Empty, "Eventname is required");

            IActionResult result = await configController.GetSubscribedNotification(
                new GetSubscribedNotificationQueryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task GetSubscribedNotificationNotFound()
        {
            _mockMediatr.Setup(m =>
               m.Send(It.IsAny<GetSubscribedNotificationsQuery>(),
                   It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(
                       HttpStatusCode.NotFound, HttpMethod.Get));

            var configController = new ConfigsController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await configController.GetSubscribedNotification(
                new GetSubscribedNotificationQueryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(404, okResult.StatusCode);
        }

        private GetSubscribedNotificationQueryParams GetSubscribedNotificationParams()
        {
            return new GetSubscribedNotificationQueryParams
            {
                EventName = "string"
            };
        }

        [Test]
        public async Task GetPublcKeySucceeds()
        {
            _mockMediatr.Setup(m =>
              m.Send(It.IsAny<GetPublicKeyQuery>(),
                  It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(
                      HttpStatusCode.OK, HttpMethod.Get));

            var configController = new ConfigsController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await configController.GetPublcKey();

            var okResult = result as ObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task GetPublcKeyUnauthorized()
        {
            _mockMediatr.Setup(m =>
              m.Send(It.IsAny<GetPublicKeyQuery>(),
                  It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(
                      HttpStatusCode.Unauthorized, HttpMethod.Get));

            var configController = new ConfigsController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await configController.GetPublcKey();

            var okResult = result as ObjectResult;

            Assert.AreEqual(401, okResult.StatusCode);
        }

        [Test]
        public async Task GetPublcKeyNotFound()
        {
            _mockMediatr.Setup(m =>
              m.Send(It.IsAny<GetPublicKeyQuery>(),
                  It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(
                      HttpStatusCode.NotFound, HttpMethod.Post));

            var configController = new ConfigsController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await configController.GetPublcKey();

            var okResult = result as ObjectResult;

            Assert.AreEqual(404, okResult.StatusCode);
        }

        [Test]
        public async Task TestUpdateNotificationEventSucceeds()
        {
            _mockMediatr.Setup(m =>
               m.Send(It.IsAny<UpdateNotificationEventCommand>(),
                   It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(
                       HttpStatusCode.NoContent, HttpMethod.Put));

            var configsController = new ConfigsController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await configsController.UpdateNotificationEvent("REFRESH",
                GetUpdateNotificationEventRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(204, okResult.StatusCode);
        }

        [Test]
        public async Task TestUpdateNotificationEventNameRequired()
        {
            _mockMediatr.Setup(m =>
               m.Send(It.IsAny<UpdateNotificationEventCommand>(),
                   It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(
                       HttpStatusCode.BadRequest, HttpMethod.Put));

            var configsController = new ConfigsController(_mockMediatr.Object, _baseControllerMock.Object);
            configsController.ModelState.AddModelError(string.Empty, "Event Name Required");

            IActionResult result = await configsController.UpdateNotificationEvent(string.Empty,
                GetUpdateNotificationEventRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task TestUpdateNotificationEventUrlRequired()
        {
            _mockMediatr.Setup(m =>
               m.Send(It.IsAny<UpdateNotificationEventCommand>(),
                   It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(
                       HttpStatusCode.BadRequest, HttpMethod.Put));

            var configsController = new ConfigsController(_mockMediatr.Object, _baseControllerMock.Object);
            configsController.ModelState.AddModelError(string.Empty, "Event Uri Required");

            IActionResult result = await configsController.UpdateNotificationEvent(string.Empty,
                new UpdateNotificationEventRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task TestUpdateNotificationEventUnaurhorize()
        {
            _mockMediatr.Setup(m =>
               m.Send(It.IsAny<UpdateNotificationEventCommand>(),
                   It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(
                       HttpStatusCode.Unauthorized, HttpMethod.Put));

            var configsController = new ConfigsController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await configsController.UpdateNotificationEvent(string.Empty,
                GetUpdateNotificationEventRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(401, okResult.StatusCode);
        }

        [Test]
        public async Task TestUpdateNotificationEventNotFound()
        {
            _mockMediatr.Setup(m =>
               m.Send(It.IsAny<UpdateNotificationEventCommand>(),
                   It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(
                       HttpStatusCode.NotFound, HttpMethod.Put));

            var configsController = new ConfigsController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await configsController.UpdateNotificationEvent(string.Empty,
                new UpdateNotificationEventRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(404, okResult.StatusCode);
        }

        private static UpdateNotificationEventRequestBody GetUpdateNotificationEventRequestBody()
        {
            return new UpdateNotificationEventRequestBody
            {
                Event = new NotificationEvent
                {
                    CallBackUrl = "string"
                }
            };
        }

        [Test]
        public async Task TestSubscribeNotificationEventSucceeds()
        {
            _mockMediatr.Setup(m =>
                m.Send(It.IsAny<SubscribeNotificationEventCommand>(),
                    It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(
                        HttpStatusCode.Created, HttpMethod.Post));

            var configsController = new ConfigsController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await configsController.SubscribeNotificationEvent("REFRESH",
                CreateSubscribeNotificationEventRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(201, okResult.StatusCode);
        }

        [Test]
        public async Task TestSubscribeNotificationEventNameRequired()
        {
            _mockMediatr.Setup(m =>
                m.Send(It.IsAny<SubscribeNotificationEventCommand>(),
                    It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(
                        HttpStatusCode.BadRequest, HttpMethod.Post));

            var configsController = new ConfigsController(_mockMediatr.Object, _baseControllerMock.Object);
            configsController.ModelState.AddModelError(string.Empty, "Event name required");

            IActionResult result = await configsController.SubscribeNotificationEvent(string.Empty,
                CreateSubscribeNotificationEventRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task TestSubscribeNotificationEventUrlRequired()
        {
            _mockMediatr.Setup(m =>
                m.Send(It.IsAny<SubscribeNotificationEventCommand>(),
                    It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(
                        HttpStatusCode.BadRequest, HttpMethod.Post));

            var configsController = new ConfigsController(_mockMediatr.Object, _baseControllerMock.Object);
            configsController.ModelState.AddModelError(string.Empty, "Event url required");

            IActionResult result = await configsController.SubscribeNotificationEvent(string.Empty,
                new SubscribeNotificationEventRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task TestSubscribeNotificationUnauthorize()
        {
            _mockMediatr.Setup(m =>
                m.Send(It.IsAny<SubscribeNotificationEventCommand>(),
                    It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(
                        HttpStatusCode.Unauthorized, HttpMethod.Post));

            var configsController = new ConfigsController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await configsController.SubscribeNotificationEvent("REFRESH",
                CreateSubscribeNotificationEventRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(401, okResult.StatusCode);
        }

        [Test]
        public async Task TestSubscribeNotificationNotFound()
        {
            _mockMediatr.Setup(m =>
                m.Send(It.IsAny<SubscribeNotificationEventCommand>(),
                    It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(
                        HttpStatusCode.NotFound, HttpMethod.Post));

            var configsController = new ConfigsController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await configsController.SubscribeNotificationEvent("REFRESH",
                new SubscribeNotificationEventRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(404, okResult.StatusCode);
        }

        private static SubscribeNotificationEventRequestBody CreateSubscribeNotificationEventRequestBody()
        {
            return new SubscribeNotificationEventRequestBody
            {
                Event = new NotificationEvent
                {
                    CallBackUrl = "string"
                }
            };
        }

        [Test]
        public async Task TestDeleteNotificationSubscribeSucceeds()
        {
            _mockMediatr.Setup(m =>
                m.Send(It.IsAny<DeleteSubscriptionNotificationCommand>(),
                    It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(
                        HttpStatusCode.NoContent, HttpMethod.Delete));

            var configsController = new ConfigsController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await configsController.DeleteNotificationSubscribe("REFRESH");

            var okResult = result as ObjectResult;

            Assert.AreEqual(204, okResult.StatusCode);
        }

        [Test]
        public async Task TestDeleteNotificationSubscribeEventNameRequired()
        {
            _mockMediatr.Setup(m =>
                m.Send(It.IsAny<DeleteSubscriptionNotificationCommand>(),
                    It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(
                        HttpStatusCode.BadRequest, HttpMethod.Delete));

            var configsController = new ConfigsController(_mockMediatr.Object, _baseControllerMock.Object);
            configsController.ModelState.AddModelError(string.Empty, "Event Name required");

            IActionResult result = await configsController.DeleteNotificationSubscribe(null);

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task TestDeleteNotificationSubscribeNotFound()
        {
            _mockMediatr.Setup(m =>
                m.Send(It.IsAny<DeleteSubscriptionNotificationCommand>(),
                    It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(
                        HttpStatusCode.NotFound, HttpMethod.Delete));

            var configsController = new ConfigsController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await configsController.DeleteNotificationSubscribe("");

            var okResult = result as ObjectResult;

            Assert.AreEqual(404, okResult.StatusCode);
        }

        [Test]
        public async Task TestDeleteNotificationSubscribeUnauthorize()
        {
            _mockMediatr.Setup(m =>
                m.Send(It.IsAny<DeleteSubscriptionNotificationCommand>(),
                    It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(
                        HttpStatusCode.Unauthorized, HttpMethod.Delete));

            var configsController = new ConfigsController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await configsController.DeleteNotificationSubscribe("REFRESH");

            var okResult = result as ObjectResult;

            Assert.AreEqual(401, okResult.StatusCode);
        }
    }
}