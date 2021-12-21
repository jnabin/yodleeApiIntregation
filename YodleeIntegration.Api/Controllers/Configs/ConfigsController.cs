using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using YodleeIntegration.Api.BaseControllerService;
using YodleeIntegration.Api.Extensions;
using YodleeIntegration.Api.Models;
using YodleeIntegration.Application.Configs.DeleteSubscriptionNotification;
using YodleeIntegration.Application.Configs.GetPublicKey;
using YodleeIntegration.Application.Configs.GetSubscribedNotifications;
using YodleeIntegration.Application.Configs.SubscribeNotificationEvent;
using YodleeIntegration.Application.Configs.UpdateNotificationEvent;
using YodleeIntegration.Application.Request;
using YodleeIntegration.Application.Response;

namespace YodleeIntegration.Api.Controllers.Configs
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class ConfigsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IBaseControllerService _baseControllerService;

        public ConfigsController(IMediator mediator,
            IBaseControllerService baseControllerService)
        {
            _mediator = mediator;
            _baseControllerService = baseControllerService;
        }

        [HttpGet("Notifications/Events")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.RequestTimeout)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetSubscribedNotification([FromQuery] GetSubscribedNotificationQueryParams queryParams)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrors());

            var yodleeConfigureSettings = await _baseControllerService.GetYodleeConfigureSettings();

            var response = await _mediator.Send(new GetSubscribedNotificationsQuery(new ConfigsRequest
            {
                Endpoint = $"{yodleeConfigureSettings.yodleeConfiguration.Url}{YodleeEndpoints.GetSubscribedNotification}",
                QueryParameters = queryParams.GetQueryParamsList()
            }, yodleeConfigureSettings.yodleeConfiguration, yodleeConfigureSettings.yodleeAccessToken));

            return await response.GetActionResultAsync<GetNotificationsEventResponse>();
        }

        [HttpGet("PublicKey")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.RequestTimeout)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetPublcKey()
        {
            var yodleeConfigureSettings = await _baseControllerService.GetYodleeConfigureSettings();

            var response = await _mediator.Send(new GetPublicKeyQuery(new PublicKeyRequest
            {
                Endpoint = $"{yodleeConfigureSettings.yodleeConfiguration.Url}{YodleeEndpoints.GetSubscribedNotification}"
            }, yodleeConfigureSettings.yodleeConfiguration, yodleeConfigureSettings.yodleeAccessToken));

            return await response.GetActionResultAsync<GetPublicKeyResponse>();
        }

        [HttpPut("UpdateNotificationEvent/{eventName}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.RequestTimeout)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> UpdateNotificationEvent(string eventName, UpdateNotificationEventRequestBody updateNotificationEventRequestBody)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrors());
            var yodleeConfigureSettings = await _baseControllerService.GetYodleeConfigureSettings();
            var response = await _mediator.Send(new UpdateNotificationEventCommand(new ConfigsRequest
            {
                Endpoint = $"{yodleeConfigureSettings.yodleeConfiguration.Url}{YodleeEndpoints.UpdateNotificationEvent}{eventName}",
            }, yodleeConfigureSettings.yodleeConfiguration, yodleeConfigureSettings.yodleeAccessToken, updateNotificationEventRequestBody));
            return await response.GetActionResultAsync<string>();
        }

        [HttpPost("SubscribeNotificationEvent/{eventName}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.RequestTimeout)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> SubscribeNotificationEvent(string eventName, SubscribeNotificationEventRequestBody updateNotificationEventRequestBody)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrors());
            var yodleeConfigureSettings = await _baseControllerService.GetYodleeConfigureSettings();
            var response = await _mediator.Send(new SubscribeNotificationEventCommand(new ConfigsRequest
            {
                Endpoint = $"{yodleeConfigureSettings.yodleeConfiguration.Url}{YodleeEndpoints.SubscribeNotificationEvent}/{eventName}",
            }, yodleeConfigureSettings.yodleeConfiguration, yodleeConfigureSettings.yodleeAccessToken, updateNotificationEventRequestBody));
            return await response.GetActionResultAsync<string>();
        }

        [HttpDelete("DeleteSubscriptionNotification/{eventName}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.RequestTimeout)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> DeleteNotificationSubscribe(string eventName)
        {
            if (eventName == null)
            {
                ModelState.AddModelError(string.Empty, "event name required");
                return BadRequest(ModelState.GetErrors());
            }
            var yodleeConfigureSettings = await _baseControllerService.GetYodleeConfigureSettings();
            var response = await _mediator.Send(new DeleteSubscriptionNotificationCommand(new ConfigsRequest
            {
                Endpoint = $"{yodleeConfigureSettings.yodleeConfiguration.Url}{YodleeEndpoints.GetSubscribedNotification}/{eventName}",
            }, yodleeConfigureSettings.yodleeConfiguration, yodleeConfigureSettings.yodleeAccessToken));
            return await response.GetActionResultAsync<string>();
        }
    }
}