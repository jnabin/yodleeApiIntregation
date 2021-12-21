using System.Collections.Generic;
using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.Response
{
    public class AccessToken
    {
        [JsonPropertyName("accessTokens")]
        public List<AccessTokens> AccessTokens { get; set; }
    }
}
