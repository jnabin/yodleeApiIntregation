using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using YodleeIntegration.Api.BaseControllerService;
using YodleeIntegration.Api.Extensions;
using YodleeIntegration.Api.Models;
using YodleeIntegration.Application.Request;
using YodleeIntegration.Application.Request.Derived;
using YodleeIntegration.Application.Response;
using YodleeIntegration.Application.Transactions.CreateOrRunTransactionCategorizationRule;
using YodleeIntegration.Application.Transactions.CreateTransactionCategory;
using YodleeIntegration.Application.Transactions.DeleteTransactionCategorization;
using YodleeIntegration.Application.Transactions.GetTransactionCategoryList;
using YodleeIntegration.Application.Transactions.GetTransactions;
using YodleeIntegration.Application.Transactions.GetTransactionsWithoutQueryParams;
using YodleeIntegration.Application.Transactions.UpdateTransactionCategorizationRule;

namespace YodleeIntegration.Api.Controllers.Transactions
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class TransactionsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IBaseControllerService _baseControllerService;

        public TransactionsController(IMediator mediator,
            IBaseControllerService baseControllerService)
        {
            _mediator = mediator;
            _baseControllerService = baseControllerService;
        }

        [HttpGet(nameof(GetTransactions))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.RequestTimeout)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetTransactions([FromQuery] GetTransactionsQueryParams queryParams)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrors());

            var yodleeConfigureSettings = await _baseControllerService.GetYodleeConfigureSettings();

            var response = await _mediator.Send(new GetTransactionsQuery(new TransactionsRequest
            {
                Endpoint = $"{yodleeConfigureSettings.yodleeConfiguration.Url}{YodleeEndpoints.GetTransactions}",
                QueryParameters = queryParams.GetQueryParamsList()
            }, yodleeConfigureSettings.yodleeConfiguration, yodleeConfigureSettings.yodleeAccessToken));
            return await response.GetActionResultAsync<TransactionResponse>();
        }

        [HttpGet(nameof(GetTransactionsCount))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.RequestTimeout)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetTransactionsCount([FromQuery] GetTransactionsCountsQueryParams queryParams)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrors());

            var yodleeConfigureSettings = await _baseControllerService.GetYodleeConfigureSettings();

            var response = await _mediator.Send(new GetTransactionsCountQuery(new TransactionsRequest
            {
                Endpoint = $"{yodleeConfigureSettings.yodleeConfiguration.Url}{YodleeEndpoints.GetTransactionsCount}",
                QueryParameters = queryParams.GetQueryParamsList()
            }, yodleeConfigureSettings.yodleeConfiguration, yodleeConfigureSettings.yodleeAccessToken));
            return await response.GetActionResultAsync<GetTransactionsCountResponse>();
        }

        [HttpGet(nameof(GetTransactionCategorizationRules))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.RequestTimeout)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetTransactionCategorizationRules()
        {
            var yodleeConfigureSettings = await _baseControllerService.GetYodleeConfigureSettings();

            var response = await _mediator.Send(new GetTransactionsWithoutParamsQuery(new TransactionsRequest
            {
                Endpoint =
                    $"{yodleeConfigureSettings.yodleeConfiguration.Url}{YodleeEndpoints.GetTransactionCategorizationRules}"
            }, yodleeConfigureSettings.yodleeConfiguration, yodleeConfigureSettings.yodleeAccessToken));
            return await response.GetActionResultAsync<GetTransactionCategorizationRulesResponse>();
        }

        [HttpGet(nameof(GetTransactionCategoryList))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.RequestTimeout)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetTransactionCategoryList()
        {

            var yodleeConfigureSettings = await _baseControllerService.GetYodleeConfigureSettings();

            var response = await _mediator.Send(new GetTransactionsCategoryListQuery(new TransactionsRequest
            {
                Endpoint =
                    $"{yodleeConfigureSettings.yodleeConfiguration.Url}{YodleeEndpoints.GetTransactionCategoryList}"
            }, yodleeConfigureSettings.yodleeConfiguration, yodleeConfigureSettings.yodleeAccessToken));
            return await response.GetActionResultAsync<GetTransactionCategoryListResponse>();
        }

        [HttpPut("UpdateTransactionCategorizationRule/{ruleId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.RequestTimeout)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> UpdateTransactionCategorizationRule(
            UpdateTransactionCategorizationRuleRequestBody updateTransactionCategorizationRuleRequestBody,
            string ruleId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrors());
            var yodleeConfigureSettings = await _baseControllerService.GetYodleeConfigureSettings();

            var response = await _mediator.Send(new UpdateTransactionCommand(new TransactionsRequest
            {
                Endpoint =
                        $"{yodleeConfigureSettings.yodleeConfiguration.Url}{YodleeEndpoints.UpdateTransactionCategorizationRule}{ruleId}"
            }, yodleeConfigureSettings.yodleeConfiguration, yodleeConfigureSettings.yodleeAccessToken,
                updateTransactionCategorizationRuleRequestBody));
            return await response.GetActionResultAsync<string>();
        }

        [HttpPut(nameof(UpdateCategory))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.RequestTimeout)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryRequestBody updateCategoryRequestBody)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrors());
            var yodleeConfigureSettings = await _baseControllerService.GetYodleeConfigureSettings();
            var response = await _mediator.Send(new UpdateTransactionCommand(new TransactionsRequest
            {
                Endpoint = $"{yodleeConfigureSettings.yodleeConfiguration.Url}{YodleeEndpoints.UpdateCategory}"
            }, yodleeConfigureSettings.yodleeConfiguration, yodleeConfigureSettings.yodleeAccessToken,
                updateCategoryRequestBody)
            );
            return await response.GetActionResultAsync<string>();
        }

        [HttpPut("UpdateTransaction/{transactionId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.RequestTimeout)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> UpdateTransaction(UpdateTransactionRequestBody updateTransactionRequestBody,
            string transactionId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrors());
            var yodleeConfigureSettings = await _baseControllerService.GetYodleeConfigureSettings();
            var response = await _mediator.Send(new UpdateTransactionCommand(new TransactionsRequest
            {
                Endpoint =
                        $"{yodleeConfigureSettings.yodleeConfiguration.Url}{YodleeEndpoints.UpdateTransaction}{transactionId}"
            }, yodleeConfigureSettings.yodleeConfiguration, yodleeConfigureSettings.yodleeAccessToken,
                updateTransactionRequestBody));
            return await response.GetActionResultAsync<string>();
        }

        [HttpPost(nameof(CreateCategory))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.RequestTimeout)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequestBody createCategoryRequestBody)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrors());
            var yodleeConfigureSettings = await _baseControllerService.GetYodleeConfigureSettings();
            var response = await _mediator.Send(new CreateTransactionCategoryCommand(new TransactionsRequest
            {
                Endpoint = $"{yodleeConfigureSettings.yodleeConfiguration.Url}{YodleeEndpoints.CreateCategory}"
            }, yodleeConfigureSettings.yodleeConfiguration, yodleeConfigureSettings.yodleeAccessToken,
                createCategoryRequestBody));
            return await response.GetActionResultAsync<string>();
        }

        [HttpPost(nameof(CreateOrRunTransactionCategorizationRule))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.RequestTimeout)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> CreateOrRunTransactionCategorizationRule(
            [FromQuery] TransactionCategorizationRuleQueryParams queryParams
        )
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrors());

            var yodleeConfigureSettings = await _baseControllerService.GetYodleeConfigureSettings();
            var response = await _mediator.Send(new CreateOrRunTransactionCategorizationRuleCommand(
                new TransactionsRequest
                {
                    Endpoint =
                        $"{yodleeConfigureSettings.yodleeConfiguration.Url}{YodleeEndpoints.CreateOrRunTransactionCategorizationRule}",
                    QueryParameters = queryParams.GetQueryParamsList()
                }, yodleeConfigureSettings.yodleeConfiguration, yodleeConfigureSettings.yodleeAccessToken));

            return await response.GetActionResultAsync<string>();
        }

        [HttpPost("RunTransactionCategorizationRule/{ruleId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.RequestTimeout)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> RunTransactionCategorizationRule(
            [FromQuery] RunTransactionCategorizationParams queryParams, string ruleId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrors());
            var yodleeConfigureSettings = await _baseControllerService.GetYodleeConfigureSettings();
            var response = await _mediator.Send(new CreateOrRunTransactionCategorizationRuleCommand(
                new TransactionsRequest
                {
                    Endpoint = $"{yodleeConfigureSettings.yodleeConfiguration.Url}{YodleeEndpoints.RunTransactionCategorization}{ruleId}",
                    QueryParameters = queryParams.GetQueryParamsList()
                }, yodleeConfigureSettings.yodleeConfiguration, yodleeConfigureSettings.yodleeAccessToken)
            );
            return await response.GetActionResultAsync<string>();
        }

        [HttpDelete("DeleteTransactionCategorizationRule/{ruleId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.RequestTimeout)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> DeleteTransactionCategorizationRule(string ruleId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrors());
            var yodleeConfigureSettings = await _baseControllerService.GetYodleeConfigureSettings();

            var response = await _mediator.Send(new DeleteTransactionCategorizationCommand(new TransactionsRequest
            {
                Endpoint = $"{yodleeConfigureSettings.yodleeConfiguration.Url}{YodleeEndpoints.DeleteTransactionCategorizationRule}{ruleId}"
            }, yodleeConfigureSettings.yodleeConfiguration, yodleeConfigureSettings.yodleeAccessToken));

            return await response.GetActionResultAsync<string>();
        }

        [HttpDelete("DeleteCategory/{categoryId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.RequestTimeout)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> DeleteCategory(string categoryId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrors());
            var yodleeConfigureSettings = await _baseControllerService.GetYodleeConfigureSettings();
            var response = await _mediator.Send(new DeleteTransactionCategorizationCommand(new TransactionsRequest
            {
                Endpoint = $"{yodleeConfigureSettings.yodleeConfiguration.Url}{YodleeEndpoints.DeleteCategory}{categoryId}"
            }, yodleeConfigureSettings.yodleeConfiguration, yodleeConfigureSettings.yodleeAccessToken));
            return await response.GetActionResultAsync<string>();
        }
    }
}