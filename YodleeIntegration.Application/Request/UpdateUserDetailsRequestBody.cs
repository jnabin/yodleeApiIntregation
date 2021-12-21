using System.Text.Json.Serialization;

namespace YodleeIntegration.Application.Request
{
    public class UpdateUserDetailsRequestBody
    {
        [JsonPropertyName("user")]
        public Domain.Entities.Users User { get; set; }
    }
}
