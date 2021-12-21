using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class Description : FullAuditedEntity
    {
        public string Security { get; set; }

        public string Original { get; set; }

        public string Simple { get; set; }

        public string Consumer { get; set; }
    }
}