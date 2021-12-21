using System.Collections.Generic;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class AssetClassificationList : FullAuditedEntity
    {
        public string ClassificationType { get; set; }

        public List<string> ClassificationValue { get; set; }
    }
}