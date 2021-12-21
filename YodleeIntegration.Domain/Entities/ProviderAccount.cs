using System.Collections.Generic;
using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class ProviderAccount : FullAuditedEntity
    {
        public ProviderAccountPreference Preferences { get; set; }

        public string OauthMigrationStatus { get; set; }

        public bool IsManual { get; set; }

        public string LastUpdated { get; set; }

        public int ConsentId { get; set; }

        public List<LoginForm> LoginForm { get; set; }

        public string CreatedDate { get; set; }

        public string AggregationSource { get; set; }

        public int ProviderId { get; set; }

        public string RequestId { get; set; }

        [JsonPropertyName("id")]
        public long YodleeProviderAccountId { get; set; }

        public List<DataSet> DataSet { get; set; }

        public string Status { get; set; }
    }
}