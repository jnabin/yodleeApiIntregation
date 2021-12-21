using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using YodleeIntegration.Api.BaseControllerService;
using YodleeIntegration.Api.Extensions;
using YodleeIntegration.Api.Models;
using YodleeIntegration.Application.Request;
using YodleeIntegration.Application.Response;
using YodleeIntegration.Application.VerifyAccounts;

namespace YodleeIntegration.Api.Controllers.VerifyAccounts
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class VerifyAccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IBaseControllerService _baseControllerService;

        public VerifyAccountController(IMediator mediator,
            IBaseControllerService baseControllerService)
        {
            _mediator = mediator;
            _baseControllerService = baseControllerService;
        }

        [HttpPost("VerifyAccountsUsingTransactions/{providerAccountId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.RequestTimeout)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> VerifyAccountsUsingTransactions(string providerAccountId,
            VerifyAccountRequestBody verifyAccountRequestBody)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrors());
            var yodleeConfigureSettings = await _baseControllerService.GetYodleeConfigureSettings();
            var response = await _mediator.Send(new VerifyAccountCommand(new VerifyAccountRequest
            {
                Endpoint =
                        $"{yodleeConfigureSettings.yodleeConfiguration.Url}{YodleeEndpoints.VerifyAccount}/{providerAccountId}"
            }, yodleeConfigureSettings.yodleeConfiguration, yodleeConfigureSettings.yodleeAccessToken,
                verifyAccountRequestBody));

            return await response.GetActionResultAsync<VerifyAccountResponseBody>();
        }
    }
}