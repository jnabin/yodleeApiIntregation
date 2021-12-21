using System.Net.Http;
using System.Threading.Tasks;
using YodleeIntegration.Domain.Model.Authorizations;
using YodleeIntegration.Domain.Model.Configurations;

namespace YodleeIntegration.Api.BaseControllerService
{
    public interface IBaseControllerService
    {
        public Task<(YodleeConfiguration yodleeConfiguration, YodleeAccessToken yodleeAccessToken, string username)> GetYodleeConfigureSettings();

        public Task<YodleeConfiguration> GetConfigurations();

        public Task<YodleeAccessToken> GetAccessToken();

        public Task GenerateNewToken();

        public Task<HttpResponseMessage> GetAuthTokenFromApi(YodleeConfiguration yodleeConfiguration, string username);

        public string GetCurrentUserInformation();
    }
}