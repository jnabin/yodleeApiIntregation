using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class HistoricalBalance : FullAuditedEntity
    {
        public string Date { get; set; }
        public int AccountId { get; set; }
        public bool IsAsset { get; set; }
        public RunningBalance Balance { get; set; }
        public string AsOfDate { get; set; }
        public string DataSourceType { get; set; }
    }
}