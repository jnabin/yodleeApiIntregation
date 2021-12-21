using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class RunningBalance : FullAuditedEntity
    {
        public string Currency { get; set; }

        public double Amount { get; set; }
    }
}