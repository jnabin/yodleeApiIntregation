using Microsoft.Extensions.Configuration;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using YodleeIntegration.Api.BaseControllerService;
using YodleeIntegration.Api.Extensions;
using YodleeIntegration.Api.Models;
using YodleeIntegration.Api.Models.Authorization;
using YodleeIntegration.Application.Authorization.DeleteAccessToken;
using YodleeIntegration.Application.Authorization.DeleteApiKey;
using YodleeIntegration.Application.Authorization.GenerateApiKey;
using YodleeIntegration.Application.Authorization.GetApiKey;
using YodleeIntegration.Application.Request;
using YodleeIntegration.Application.Response;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Domain.Model.Authorizations;
using Newtonsoft.Json;

namespace YodleeIntegration.Api.Controllers.Authorization
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthorizationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;
        private readonly IBaseControllerService _baseControllerService;


        public AuthorizationController(IConfiguration configuration, IMediator mediator, IBaseControllerService baseControllerService)
        {
            _mediator = mediator;
            _configuration = configuration;
            _baseControllerService = baseControllerService;
        }
        [AllowAnonymous]
        [HttpPost("token")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.RequestTimeout)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> PostToken(TokenParams tokenParams)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrors());
             
            var response = await GetAuthTokenFromYodleeApi(tokenParams);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var tokenformYodleeApi = JsonConvert.DeserializeObject<AuthorizationUserTokenResponse>(content);
                var tokenString = GenerateJwtToken(tokenParams.Username, tokenformYodleeApi.Token);
                return Ok(new { Token = tokenString, Message = "Success" });
            }
            return BadRequest("Please pass the valid Username");

        }
        private string GenerateJwtToken(string userName, UserToken usertoken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim("LoginUsername", userName),
                    new Claim("token",usertoken.AccessToken),
                    new Claim("IssueAt",usertoken.IssuedAt.ToString()),
                    new Claim("expirein",usertoken.ExpiresIn.ToString()),

                }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
        private async Task<HttpResponseMessage> GetAuthTokenFromYodleeApi(TokenParams tokenParams)
        {
            var response =
                await _baseControllerService.GetAuthTokenFromApi(await _baseControllerService.GetConfigurations(), tokenParams.Username);

            return  response;
        }

        [HttpDelete("token")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.RequestTimeout)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> DeleteToken()
        {

            var yodleeConfigureSettings = await _baseControllerService.GetYodleeConfigureSettings();

            var response = await _mediator.Send(new DeleteAccessTokenCommand(new AuthorizationUserTokenRequest
            {
                Endpoint = $"{yodleeConfigureSettings.yodleeConfiguration.Url}{YodleeEndpoints.AuthToken}",
            }, yodleeConfigureSettings.yodleeConfiguration, yodleeConfigureSettings.yodleeAccessToken));
            return await response.GetActionResultAsync<object>();
        }

        [HttpGet("apiKey")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.RequestTimeout)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetApiKey()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrors());

            var yodleeConfigureSettings = await _baseControllerService.GetYodleeConfigureSettings();

            var response = await _mediator.Send(new GetApiKeyQuery(new AuthorizationUserApiKeyRequest
            {
                Endpoint = $"{yodleeConfigureSettings.yodleeConfiguration.Url}{YodleeEndpoints.ApiKey}",
            }, yodleeConfigureSettings.yodleeConfiguration, yodleeConfigureSettings.yodleeAccessToken));
            return await response.GetActionResultAsync<YodleeApiKey>();
        }

        [HttpDelete("apiKey")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.RequestTimeout)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> DeleteApiKey()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrors());

            var yodleeConfigureSettings = await _baseControllerService.GetYodleeConfigureSettings();

            var response = await _mediator.Send(new DeleteApiKeyCommand(new AuthorizationUserApiKeyRequest
            {
                Endpoint = $"{yodleeConfigureSettings.yodleeConfiguration.Url}{YodleeEndpoints.ApiKey}",
            }, yodleeConfigureSettings.yodleeConfiguration, yodleeConfigureSettings.yodleeAccessToken));
            return await response.GetActionResultAsync<YodleeApiKey>();
        }

        [HttpPost("apiKey")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.RequestTimeout)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> PostApiKey([FromQuery] ApiKeyQueryParams queryParams)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrors());

            var yodleeConfigureSettings = await _baseControllerService.GetYodleeConfigureSettings();

            var response = await _mediator.Send(new GenerateApiKeyCommand(new AuthorizationUserApiKeyRequest
            {
                Endpoint = $"{yodleeConfigureSettings.yodleeConfiguration.Url}{YodleeEndpoints.ApiKey}",
                QueryParameters = queryParams.GetQueryParamsList()
            }, yodleeConfigureSettings.yodleeConfiguration, yodleeConfigureSettings.yodleeAccessToken));
            return await response.GetActionResultAsync<YodleeApiKey>();
        }
    }
}