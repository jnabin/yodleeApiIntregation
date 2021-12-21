using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.Response
{
    public class GetPublicKeyResponse
    {
        [JsonPropertyName("publicKey")]
        public PublicKey PublicKey { get; set; }
    }
}
