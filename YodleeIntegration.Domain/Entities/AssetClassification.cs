using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class AssetClassification : FullAuditedEntity
    {
        public int Allocation { get; set; }
        public string ClassificationType { get; set; }
        public string ClassificationValue { get; set; }
    }
}