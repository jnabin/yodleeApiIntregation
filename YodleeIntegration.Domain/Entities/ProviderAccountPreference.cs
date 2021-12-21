using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class ProviderAccountPreference : FullAuditedEntity
    {
        public bool IsDataExtractsEnabled { get; set; }

        public int LinkedProviderAccountId { get; set; }

        public bool IsAutoRefreshEnabled { get; set; }
    }
}