using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using YodleeIntegration.Api.BaseControllerService;
using YodleeIntegration.Api.Extensions;
using YodleeIntegration.Api.Models;
using YodleeIntegration.Application.ProvidersAccounts;
using YodleeIntegration.Application.ProvidersAccounts.DeleteProviderAccount;
using YodleeIntegration.Application.ProvidersAccounts.GetUserProfileDetails;
using YodleeIntegration.Application.ProvidersAccounts.UpdateAccountPreferences;
using YodleeIntegration.Application.ProvidersAccounts.UpdateProviderAccount;
using YodleeIntegration.Application.Request;
using YodleeIntegration.Application.Response;

namespace YodleeIntegration.Api.Controllers.ProviderAccounts
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class ProviderAccountsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IBaseControllerService _baseControllerService;

        public ProviderAccountsController(IMediator mediator,
            IBaseControllerService baseControllerService)
        {
            _mediator = mediator;
            _baseControllerService = baseControllerService;
        }

        [HttpGet(nameof(GetProviderAccounts))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.RequestTimeout)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetProviderAccounts([FromQuery] GetProviderAccountsParams queryParams)
        {
            var yodleeConfigureSettings = await _baseControllerService.GetYodleeConfigureSettings();
            var response = await _mediator.Send(new GetProvidersAccountQuery(new ProvidersAccountRequest
            {
                Endpoint = $"{yodleeConfigureSettings.yodleeConfiguration.Url}{YodleeEndpoints.GetProviderAccounts}",
                QueryParameters = queryParams.GetQueryParamsList()
            }, yodleeConfigureSettings.yodleeConfiguration, yodleeConfigureSettings.yodleeAccessToken));
            return await response.GetActionResultAsync<ProviderAccountResponseList>();
        }

        [HttpGet("GetProviderAccountDetails/{providerAccountId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.RequestTimeout)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetProviderAccountDetails(string providerAccountId, [FromQuery] GetProviderAccountsDetailParams queryParams)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrors());
            var yodleeConfigureSettings = await _baseControllerService.GetYodleeConfigureSettings();
            var response = await _mediator.Send(new GetProvidersAccountQuery(new ProvidersAccountRequest
            {
                Endpoint = $"{yodleeConfigureSettings.yodleeConfiguration.Url}{YodleeEndpoints.GetProviderAccountsDetails}{providerAccountId}",
                QueryParameters = queryParams.GetQueryParamsList()
            }, yodleeConfigureSettings.yodleeConfiguration, yodleeConfigureSettings.yodleeAccessToken));

            return await response.GetActionResultAsync<ProviderAccountResponseList>();
        }

        [HttpGet("GetUserProfileDetails")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.RequestTimeout)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetUserProfileDetails([FromQuery] GetUserProfileDetailsParams queryParams)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrors());
            var yodleeConfigureSettings = await _baseControllerService.GetYodleeConfigureSettings();
            var response = await _mediator.Send(new GetUserProfileDetailsQuery(new ProvidersAccountRequest
            {
                Endpoint = $"{yodleeConfigureSettings.yodleeConfiguration.Url}{YodleeEndpoints.GetUserProfileDetails}",
                QueryParameters = queryParams.GetQueryParamsList()
            }, yodleeConfigureSettings.yodleeConfiguration, yodleeConfigureSettings.yodleeAccessToken));

            return await response.GetActionResultAsync<UserProfileDetailsResponse>();
        }

        [HttpPut("UpdateAccounts")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.RequestTimeout)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> UpdateAccounts([FromQuery] GetUpdateAccountsQueryParams queryParams, 
            ProviderAccountRequestBody providerAccountRequestBody)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrors());

            var yodleeConfigureSettings = await _baseControllerService.GetYodleeConfigureSettings();

            var response = await _mediator.Send(new UpdateProviderAccountCommand(new ProvidersAccountRequest
            {
                Endpoint = $"{yodleeConfigureSettings.yodleeConfiguration.Url}{YodleeEndpoints.UpdateProviderAccount}",
                QueryParameters = queryParams.GetQueryParamsList()
            }, yodleeConfigureSettings.yodleeConfiguration, yodleeConfigureSettings.yodleeAccessToken,
            providerAccountRequestBody));

            return await response.GetActionResultAsync<ProviderAccountResponseList>();
        }

        [HttpPut("UpdatePreferences/{providerAccountId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.RequestTimeout)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> UpdatePreferences(string providerAccountId,
            UpdateAccountPreferencesRequestBody preferencesRequestBody)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrors());

            var yodleeConfigureSettings = await _baseControllerService.GetYodleeConfigureSettings();

            var response = await _mediator.Send(new UpdateAccountPreferencesCommand
            (new ProvidersAccountRequest
            {
                Endpoint = $"{yodleeConfigureSettings.yodleeConfiguration.Url}{YodleeEndpoints.UpdateAccountPreferences}{providerAccountId}/preferences",
            }, yodleeConfigureSettings.yodleeConfiguration, yodleeConfigureSettings.yodleeAccessToken, preferencesRequestBody));

            return await response.GetActionResultAsync<string>();
        }

        [HttpDelete("DeleteProviderAccount/{providerAccountId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.RequestTimeout)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> AccountDeleteAccount(string providerAccountId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrors());

            var yodleeConfigureSettings = await _baseControllerService.GetYodleeConfigureSettings();

            var response = await _mediator.Send(new DeleteProviderAccountCommand(new ProvidersAccountRequest
            {
                Endpoint = $"{yodleeConfigureSettings.yodleeConfiguration.Url}{YodleeEndpoints.DeleteProviderAccount}{providerAccountId}",
            }, yodleeConfigureSettings.yodleeConfiguration, yodleeConfigureSettings.yodleeAccessToken));

            return await response.GetActionResultAsync<string>();
        }
    }
}