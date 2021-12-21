using System.Collections.Generic;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class Attribute : FullAuditedEntity
    {
        public List<string> Container { get; set; }

        public string FromDate { get; set; }

        public string ToFinYear { get; set; }

        public string FromFinYear { get; set; }

        public ContainerAttribute ContainerAttributes { get; set; }

        public string ToDate { get; set; }

        public string Name { get; set; }
    }
}