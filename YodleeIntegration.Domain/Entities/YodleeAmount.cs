using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class YodleeAmount : FullAuditedEntity
    {
        public RunningBalance cover { get; set; }
        public string UnitType { get; set; }
        public string Type { get; set; }
        public string LimitType { get; set; }
        public RunningBalance Met { get; set; }
        public int Amount { get; set; }
        public string Currency { get; set; }
    }
}