using System.Collections.Generic;
using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class DataExtractProviderAccount : FullAuditedEntity
   {
        public int DestinationProviderAccountId { get; set; }
        public string OauthMigrationStatus { get; set; }
        public bool IsManual { get; set; }
        public string LastUpdated { get; set; }
        public string CreatedDate { get; set; }
        public string AggregationSource { get; set; }
        public bool IsDeleted { get; set; }
        public int ProviderId { get; set; }
        public string RequestId { get; set; }
        public List<int> SourceProviderAccountIds { get; set; }
        
        public List<DataExtractDataset> Dataset { get; set; }

        [JsonPropertyName("id")]
        public long YodleeDataExtractsProviderAccountId { get; set; }
        
        public string Status { get; set; }
    }
}