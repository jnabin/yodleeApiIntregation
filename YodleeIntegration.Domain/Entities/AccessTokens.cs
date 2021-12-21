using System.ComponentModel.DataAnnotations.Schema;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    [Table("YodleeAccessTokens")]
    public class AccessTokens : FullAuditedEntity
    {
        public string AppId { get; set; }

        public string Value { get; set; }

        public string Url { get; set; }
    }
}