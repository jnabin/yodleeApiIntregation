using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class UpdateProviderAccountField : FullAuditedEntity
    {
        public string Image { get; set; }

        [JsonPropertyName("id")]
        public string YodleeUpdateProviderAccountFieldsId { get; set; }

        public string Value { get; set; }
    }
}