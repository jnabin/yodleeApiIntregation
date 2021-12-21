using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using YodleeIntegration.Api.BaseControllerService;
using YodleeIntegration.Api.Extensions;
using YodleeIntegration.Api.Models;
using YodleeIntegration.Application.Accounts.AddManualAccount;
using YodleeIntegration.Application.Accounts.DeleteAccount;
using YodleeIntegration.Application.Accounts.EvaluateAddress;
using YodleeIntegration.Application.Accounts.GetAccounts;
using YodleeIntegration.Application.Accounts.GetHistoricalAccounts;
using YodleeIntegration.Application.Accounts.GetLatestBalances;
using YodleeIntegration.Application.Accounts.UpdateAccount;
using YodleeIntegration.Application.Request;
using YodleeIntegration.Application.Response;

namespace YodleeIntegration.Api.Controllers.Accounts
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IBaseControllerService _baseControllerService;

        public AccountsController(IMediator mediator, IBaseControllerService baseControllerService)
        {
            _mediator = mediator;
            _baseControllerService = baseControllerService;
        }

        [HttpGet(nameof(GetAccounts))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.RequestTimeout)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAccounts([FromQuery] GetAccountsQueryParams queryParams)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrors());

            var yodleeConfigureSettings = await _baseControllerService.GetYodleeConfigureSettings();

            var response = await _mediator.Send(new GetAccountsQuery(new AccountsRequest
            {
                Endpoint = $"{yodleeConfigureSettings.yodleeConfiguration.Url}{YodleeEndpoints.GetAccounts}",
                QueryParameters = queryParams.GetQueryParamsList()
            }, yodleeConfigureSettings.yodleeConfiguration, yodleeConfigureSettings.yodleeAccessToken));
            return await response.GetActionResultAsync<AccountResponse>();
        }

        [HttpGet("GetAccountDetail/{accountId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.RequestTimeout)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAccountDetail([FromQuery] GetAccountsDetailQueryParams queryParams, string accountId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrors());
            var yodleeConfigureSettings = await _baseControllerService.GetYodleeConfigureSettings();
            var response = await _mediator.Send(new GetAccountsQuery(new AccountsRequest
            {
                Endpoint = $"{yodleeConfigureSettings.yodleeConfiguration.Url}{YodleeEndpoints.GetAccounts}/{accountId}",
                QueryParameters = queryParams.GetQueryParamsList()
            }, yodleeConfigureSettings.yodleeConfiguration, yodleeConfigureSettings.yodleeAccessToken));
            return await response.GetActionResultAsync<AccountResponse>();
        }

        [HttpGet(nameof(GetHistoricalBalances))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.RequestTimeout)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetHistoricalBalances([FromQuery] GetHistoricalBalancesQueryParams queryParams)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrors());
            var yodleeConfigureSettings = await _baseControllerService.GetYodleeConfigureSettings();
            var response = await _mediator.Send(new GetHistoricalAccountsQuery(new AccountsRequest
            {
                Endpoint = $"{yodleeConfigureSettings.yodleeConfiguration.Url}{YodleeEndpoints.GetHistoricalBalances}",
                QueryParameters = queryParams.GetQueryParamsList()
            }, yodleeConfigureSettings.yodleeConfiguration, yodleeConfigureSettings.yodleeAccessToken));
            return await response.GetActionResultAsync<HistoricalAccountResponseBody>();
        }

        [HttpGet(nameof(GetLatestBalances))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.RequestTimeout)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetLatestBalances([FromQuery] GetLatestBalancesQueryParams queryParams)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrors());
            var yodleeConfigureSettings = await _baseControllerService.GetYodleeConfigureSettings();
            var response = await _mediator.Send(new GetLatestBalancesQuery(new AccountsRequest
            {
                Endpoint = $"{yodleeConfigureSettings.yodleeConfiguration.Url}{YodleeEndpoints.GetLatestBalances}",
                QueryParameters = queryParams.GetQueryParamsList()
            }, yodleeConfigureSettings.yodleeConfiguration, yodleeConfigureSettings.yodleeAccessToken));
            return await response.GetActionResultAsync<GetLatestBalancesResponseBody>();
        }

        [HttpPost(nameof(EvaluateAddress))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.RequestTimeout)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> EvaluateAddress(EvaluateAddressRequestBody evaluateAddressRequestBody)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrors());

            var yodleeConfigureSettings = await _baseControllerService.GetYodleeConfigureSettings();
            var response = await _mediator.Send(new EvaluateAddressCommand(new EvaluateAddressRequest
            {
                Endpoint = $"{yodleeConfigureSettings.yodleeConfiguration.Url}{YodleeEndpoints.EvaluateAddress}",
            }, yodleeConfigureSettings.yodleeConfiguration, yodleeConfigureSettings.yodleeAccessToken, evaluateAddressRequestBody));
            return await response.GetActionResultAsync<EvaluateAddressResponse>();
        }

        [HttpPost(nameof(AddManualAccount))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.RequestTimeout)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> AddManualAccount(AddManualAccountRequestBody addManualAccountRequestBody)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrors());
            var yodleeConfigureSettings = await _baseControllerService.GetYodleeConfigureSettings();
            var response = await _mediator.Send(new AddManualAccountCommand(new AccountsRequest
            {
                Endpoint = $"{yodleeConfigureSettings.yodleeConfiguration.Url}{YodleeEndpoints.AddManualAccount}",
            }, yodleeConfigureSettings.yodleeConfiguration, yodleeConfigureSettings.yodleeAccessToken, addManualAccountRequestBody));
            return await response.GetActionResultAsync<AddManualAccountResponseBody>();
        }

        [HttpPut("UpdateAccount/{accountId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.RequestTimeout)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> UpdateAccount(string accountId, UpdateAccountRequestBody updateAccountRequestBody)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrors());
            var yodleeConfigureSettings = await _baseControllerService.GetYodleeConfigureSettings();
            var response = await _mediator.Send(new UpdateAccountCommand(new AccountsRequest
            {
                Endpoint = $"{yodleeConfigureSettings.yodleeConfiguration.Url}{YodleeEndpoints.UpdateAccount}{accountId}",
            }, yodleeConfigureSettings.yodleeConfiguration, yodleeConfigureSettings.yodleeAccessToken, updateAccountRequestBody));
            return await response.GetActionResultAsync<string>();
        }

        [HttpDelete("DeleteAccount/{accountId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.RequestTimeout)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> DeleteAccount(string accountId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrors());
            var yodleeConfigureSettings = await _baseControllerService.GetYodleeConfigureSettings();
            var response = await _mediator.Send(new DeleteAccountCommand(new AccountsRequest
            {
                Endpoint = $"{yodleeConfigureSettings.yodleeConfiguration.Url}{YodleeEndpoints.DeleteAccount}/{accountId}",
            }, yodleeConfigureSettings.yodleeConfiguration, yodleeConfigureSettings.yodleeAccessToken));
            return await response.GetActionResultAsync<string>();
        }
    }
}