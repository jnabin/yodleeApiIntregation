using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.Request
{
    public class UpdateAccountPreferencesRequestBody
    {
        [JsonPropertyName("preferences")]
        public ProviderAccountPreference Preferences { get; set; }
    }
}
