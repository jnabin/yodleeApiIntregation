using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using YodleeIntegration.Api.BaseControllerService;
using YodleeIntegration.Api.Extensions;
using YodleeIntegration.Api.Models;
using YodleeIntegration.Application.Request.Statements;
using YodleeIntegration.Application.Response;
using YodleeIntegration.Application.Statements.GetStatements;

namespace YodleeIntegration.Api.Controllers.Statements
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class StatementsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IBaseControllerService _baseControllerService;

        public StatementsController(IMediator mediator,
            IBaseControllerService baseControllerService)
        {
            _mediator = mediator;
            _baseControllerService = baseControllerService;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.RequestTimeout)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetStatements([FromQuery] Models.Statements.GetStatementsParam queryParams)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrors());

            var yodleeConfigureSettings = await _baseControllerService.GetYodleeConfigureSettings();

            var response = await _mediator.Send(new GetStatementsQuery(new StatementsRequest
            {
                Endpoint = $"{yodleeConfigureSettings.yodleeConfiguration.Url}{YodleeEndpoints.GetStatements}",
                QueryParameters = queryParams.GetQueryParamsList()
            }, yodleeConfigureSettings.yodleeConfiguration, yodleeConfigureSettings.yodleeAccessToken));
            return await response.GetActionResultAsync<GetStatementsResponse>();
        }
    }
}