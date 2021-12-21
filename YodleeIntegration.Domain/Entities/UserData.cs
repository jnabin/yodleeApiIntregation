using System.Collections.Generic;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class UserData : FullAuditedEntity
    {
        public List<Link> Links { get; set; }
        public DataExtractUser User { get; set; }
    }
}