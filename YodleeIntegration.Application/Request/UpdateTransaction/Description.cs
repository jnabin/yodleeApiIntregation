using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Application.Request.UpdateTransaction
{
    public class Description : FullAuditedEntity
    {
        public string Consumer { get; set; }
    }
}