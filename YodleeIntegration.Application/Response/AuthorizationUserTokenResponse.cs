using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.Response
{
    public class AuthorizationUserTokenResponse
    {
        [JsonPropertyName("token")]
        public UserToken Token { get; set; }
    }
}
