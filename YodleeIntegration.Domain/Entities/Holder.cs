using System.Collections.Generic;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class Holder : FullAuditedEntity
    {
        public List<Identifier> Identifier { get; set; }

        public string Gender { get; set; }

        public string Ownership { get; set; }

        public Name Name { get; set; }
    }
}