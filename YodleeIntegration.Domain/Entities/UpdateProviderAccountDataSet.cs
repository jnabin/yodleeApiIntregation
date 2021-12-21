using System.Collections.Generic;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class UpdateProviderAccountDataSet : FullAuditedEntity
    {
        public string Name { get; set; }

        public List<UpdateProviderAccountAttribute> Attribute { get; set; }
    }
}