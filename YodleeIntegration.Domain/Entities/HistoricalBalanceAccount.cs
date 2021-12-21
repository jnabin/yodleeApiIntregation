using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class HistoricalBalanceAccount : FullAuditedEntity
    {
        public string Date { get; set; }

        public bool IsAsset { get; set; }

        public RunningBalance Balance { get; set; }

        public string AsOfDate { get; set; }

        public string DataSourceType { get; set; }
    }
}