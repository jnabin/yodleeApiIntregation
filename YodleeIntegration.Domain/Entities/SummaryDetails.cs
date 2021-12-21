using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class SummaryDetails : FullAuditedEntity
    {
        public string Date { get; set; }
        public RunningBalance CreditTotal { get; set; }
        public RunningBalance DebitTotal { get; set; }
    }
}
