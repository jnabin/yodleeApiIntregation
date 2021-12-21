using System.Collections.Generic;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class UpdateProviderAccountAttribute : FullAuditedEntity
    {
        public List<string> Container { get; set; }

        public ContainerAttribute ContainerAttributes { get; set; }

        public string Name { get; set; }
    }
}