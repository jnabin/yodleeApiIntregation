using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using YodleeIntegration.Api.Models;
using YodleeIntegration.Application.Authorization.GenerateAccessToken;
using YodleeIntegration.Application.Authorization.GetAccessToken;
using YodleeIntegration.Application.Configurations.GetYodleeConfiguration;
using YodleeIntegration.Application.Request;
using YodleeIntegration.Domain.Model.Authorizations;
using YodleeIntegration.Domain.Model.Configurations;

namespace YodleeIntegration.Api.BaseControllerService
{
    public class BaseControllerService : IBaseControllerService
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly IMediator _mediator;

        public BaseControllerService(IMediator mediator, IHttpContextAccessor accessor)
        {
            _mediator = mediator;
            _accessor = accessor;
        }

        public async Task<(YodleeConfiguration yodleeConfiguration, YodleeAccessToken yodleeAccessToken, string username)>
            GetYodleeConfigureSettings()
        {
            return (await GetConfigurations(), await GetAccessToken(), GetCurrentUserInformation());
        }

        public async Task<YodleeConfiguration> GetConfigurations()
        {
            var result = await _mediator.Send(new GetYodleeConfigurationQuery());
            return result;
        }

        public async Task<YodleeAccessToken> GetAccessToken()
        {
            var yodleeAccessToken = await _mediator.Send(new GetAccessTokenQuery());
            if (yodleeAccessToken is { IsExpired: false })
                return yodleeAccessToken;

            await GenerateNewToken();
            return await _mediator.Send(new GetAccessTokenQuery());
        }

        public async Task GenerateNewToken()
        {
            await GetAuthTokenFromApi(await GetConfigurations(), GetCurrentUserInformation());
        }

        public async Task<HttpResponseMessage> GetAuthTokenFromApi(YodleeConfiguration yodleeConfiguration,
            string username)
        {
            yodleeConfiguration.Username = username;
            return await _mediator.Send(new GenerateAccessTokenDataCommand(new AuthorizationUserTokenRequest
            {
                Endpoint = $"{yodleeConfiguration.Url}{YodleeEndpoints.AuthToken}",
                ClientId = yodleeConfiguration.ClientId,
                Secret = yodleeConfiguration.Secret
            }, yodleeConfiguration, username));
        }

        public string GetCurrentUserInformation()
        {
            return _accessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "LoginUsername").Value;
        }
    }
}