using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.Response
{
    public class VerifyAccountResponseBody
    {
        [JsonPropertyName("verifyAccount")]
        public VerifyAccountDTO VerifyAccount { get; set; }
    }
}
