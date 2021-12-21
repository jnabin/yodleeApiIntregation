using System.Collections.Generic;
using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class TransactionCategory : FullAuditedEntity
    {
        public string HighLevelCategoryName { get; set; }

        public string DefaultHighLevelCategoryName { get; set; }

        public int HighLevelCategoryId { get; set; }

        public List<DetailCategory> DetailCategory { get; set; }

        [JsonPropertyName("id")]
        public int YodleeTransactionCategoryId { get; set; }

        public string Source { get; set; }

        public string Category { get; set; }

        public string Classification { get; set; }

        public string Type { get; set; }

        public string DefaultCategoryName { get; set; }
    }
}