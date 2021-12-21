using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class DataExtractDataset : FullAuditedEntity
    {
        public string LastUpdated { get; set; }
        public string UpdateEligibility { get; set; }
        public string AdditionalStatus { get; set; }
        public string NextUpdateScheduled { get; set; }
        public string Name { get; set; }
        public string LastUpdateAttempt { get; set; }
    }
}