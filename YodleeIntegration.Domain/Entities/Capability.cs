using System.Collections.Generic;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class Capability : FullAuditedEntity
    {
        public List<string> Container { get; set; }

        public string Name { get; set; }
    }
}