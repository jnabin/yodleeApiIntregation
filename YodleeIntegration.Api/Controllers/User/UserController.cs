using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using YodleeIntegration.Api.BaseControllerService;
using YodleeIntegration.Api.Extensions;
using YodleeIntegration.Api.Models;
using YodleeIntegration.Api.Models.User;
using YodleeIntegration.Application.Request;
using YodleeIntegration.Application.Request.User;
using YodleeIntegration.Application.Response;
using YodleeIntegration.Application.User.DeleteUser;
using YodleeIntegration.Application.User.GetAccessTokens;
using YodleeIntegration.Application.User.GetUserDetails;
using YodleeIntegration.Application.User.RegisterUser;
using YodleeIntegration.Application.User.SamlLogin;
using YodleeIntegration.Application.User.UpdateUserDetails;

namespace YodleeIntegration.Api.Controllers.User
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IBaseControllerService _baseControllerService;

        public UserController(IMediator mediator, IBaseControllerService baseControllerService)
        {
            _mediator = mediator;
            _baseControllerService = baseControllerService;
        }

        [HttpPost(nameof(SamlLogin))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.RequestTimeout)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> SamlLogin([FromQuery] SamlLoginParams queryParams)
        {

            var yodleeConfigureSettings = await _baseControllerService.GetYodleeConfigureSettings();

            var response = await _mediator.Send(new SamlLoginQuery(new SamlLoginRequest()
            {
                Endpoint = $"{yodleeConfigureSettings.yodleeConfiguration.Url}{YodleeEndpoints.SamlLogin}",
                QueryParameters = queryParams.GetQueryParamsList()
            }, yodleeConfigureSettings.yodleeConfiguration, yodleeConfigureSettings.yodleeAccessToken));
            return await response.GetActionResultAsync<UserResponse>();
        }

        [HttpGet(nameof(GetAccessTokens))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.RequestTimeout)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAccessTokens([FromQuery] AccessTokensParams queryParams)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrors());

            var yodleeConfigureSettings = await _baseControllerService.GetYodleeConfigureSettings();

            var response = await _mediator.Send(new GetAccessTokensQuery(new AccessTokensRequest()
            {
                Endpoint = $"{yodleeConfigureSettings.yodleeConfiguration.Url}{YodleeEndpoints.AccessTokens}",
                QueryParameters = queryParams.GetQueryParamsList()
            }, yodleeConfigureSettings.yodleeConfiguration, yodleeConfigureSettings.yodleeAccessToken));
            return await response.GetActionResultAsync<UserAccessToken>();
        }

        [HttpGet(nameof(GetUserDetails))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.RequestTimeout)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetUserDetails()
        {

            var yodleeConfigureSettings = await _baseControllerService.GetYodleeConfigureSettings();

            var response = await _mediator.Send(new GetUserDetailsQuery(new UserRequest
            {
                Endpoint = $"{yodleeConfigureSettings.yodleeConfiguration.Url}{YodleeEndpoints.User}"
            }, yodleeConfigureSettings.yodleeConfiguration, yodleeConfigureSettings.yodleeAccessToken));
            return await response.GetActionResultAsync<UserResponse>();
        }

        [HttpPut(nameof(UpdateUserDetails))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.RequestTimeout)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> UpdateUserDetails(UpdateUserDetailsRequestBody updateUserDetailsRequestBody)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrors());

            var yodleeConfigureSettings = await _baseControllerService.GetYodleeConfigureSettings();

            var response = await _mediator.Send(new UpdateUserDetailsCommand(new UserRequest()
            {
                Endpoint = $"{yodleeConfigureSettings.yodleeConfiguration.Url}{YodleeEndpoints.User}"
            }, yodleeConfigureSettings.yodleeConfiguration, yodleeConfigureSettings.yodleeAccessToken, updateUserDetailsRequestBody));
            return await response.GetActionResultAsync<string>();
        }

        [HttpDelete(nameof(DeleteUser))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.RequestTimeout)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> DeleteUser()
        {
            var yodleeConfigureSettings = await _baseControllerService.GetYodleeConfigureSettings();

            var response = await _mediator.Send(new DeleteUserQuery(new BaseRequest()
            {
                Endpoint = $"{yodleeConfigureSettings.yodleeConfiguration.Url}{YodleeEndpoints.DeleteUser}",
            }, yodleeConfigureSettings.yodleeConfiguration, yodleeConfigureSettings.yodleeAccessToken));
            return await response.GetActionResultAsync<string>();
        }

        [HttpPost(nameof(RegisterUser))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.RequestTimeout)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> RegisterUser(UpdateUserDetailsRequestBody updateUserDetailsRequestBody)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrors());

            var yodleeConfigureSettings = await _baseControllerService.GetYodleeConfigureSettings();

            var response = await _mediator.Send(new RegisterUserCommand(new UserRequest()
            {
                Endpoint = $"{yodleeConfigureSettings.yodleeConfiguration.Url}{YodleeEndpoints.Register}"
            }, yodleeConfigureSettings.yodleeConfiguration, yodleeConfigureSettings.yodleeAccessToken, updateUserDetailsRequestBody));

            return await response.GetActionResultAsync<UserResponse>();
        }
    }
}