using System.Collections.Generic;
using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.Response
{
    public class AuthorizationUserApiKeyResponse
    {
        [JsonPropertyName("apiKey")]
        public IEnumerable<UserApiKey> UserApiKey { get; set; }
    }
}
