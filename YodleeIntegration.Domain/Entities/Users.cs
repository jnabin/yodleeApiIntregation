using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    [Table("YodleeUser")]
    public class Users : FullAuditedEntity
    {
        public Preference Preferences { get; set; }

        public Address Address { get; set; }

        public string LoginName { get; set; }

        public Name Name { get; set; }

        public string RoleType { get; set; }

        public string Email { get; set; }

        public string SegmentName { get; set; }

        [JsonPropertyName("id")]

        public long YodleeUserId { get; set; }
    }
}