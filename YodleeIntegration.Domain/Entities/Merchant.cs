using System.Collections.Generic;
using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class Merchant : FullAuditedEntity
    {
        public string Website { get; set; }

        public Address Address { get; set; }

        public Contact Contact { get; set; }

        public List<string> CategoryLabel { get; set; }

        public Coordinates Coordinates { get; set; }

        public string Name { get; set; }

        [JsonPropertyName("id")]
        public string YodleeMerchantId { get; set; }

        public string Source { get; set; }

        public string LogoUrl { get; set; }
    }
}