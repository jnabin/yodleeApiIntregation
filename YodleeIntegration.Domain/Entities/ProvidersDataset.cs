using System.Collections.Generic;
using YodleeIntegration.Domain.Model.FullAuditedEntity;


namespace YodleeIntegration.Domain.Entities
{
    public class ProvidersDataset : FullAuditedEntity
    {
        public string Name { get; set; }
        public List<Attribute> Attribute { get; set; }
    }
}
