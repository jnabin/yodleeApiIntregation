using System;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class DataSet : FullAuditedEntity
    {
        public string Name { get; set; }

        public string AdditionalStatus { get; set; }

        public string UpdateEligibility { get; set; }

        public DateTime LastUpdated { get; set; }

        public DateTime LastUpdateAttempt { get; set; }

        public DateTime? NextUpdateScheduled { get; set; }
    }
}