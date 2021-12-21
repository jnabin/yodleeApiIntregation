using System.Collections.Generic;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class Coverage : FullAuditedEntity
    {
        public List<YodleeAmount> Amount { get; set; }
        public string PlanType { get; set; }
        public string EndDate { get; set; }
        public string Type { get; set; }
        public string StartDate { get; set; }
    }
}