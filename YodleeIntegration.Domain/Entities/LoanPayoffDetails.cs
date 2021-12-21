using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class LoanPayoffDetails : FullAuditedEntity
   {
        public string PayByDate { get; set; }
        public RunningBalance PayoffAmount { get; set; }
        public RunningBalance OutstandingBalance { get; set; }
    }
}