using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class DetailCategory : FullAuditedEntity
    {
        public string Name { get; set; }

        [JsonPropertyName("id")]
        public int DetailCategoryId { get; set; }
    }
}