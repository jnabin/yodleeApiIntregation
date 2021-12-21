using System.Collections.Generic;
using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class ProviderAccountProfile: FullAuditedEntity
    {
        public List<Profile> Profile { get; set; }

        [JsonPropertyName("id")]
        public int YodleeUserProfileDetailProviderAccountId { get; set; }
    }
}