using System.Text.Json.Serialization;

namespace YodleeIntegration.Application.Request
{
    public class AuthorizationUserApiKeyRequest : BaseRequest
    {
        [JsonPropertyName("publicKey")]
        public string PublicKey { get; set; }
    }
}