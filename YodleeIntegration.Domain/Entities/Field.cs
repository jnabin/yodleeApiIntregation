using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class Field : FullAuditedEntity
    {
        public string Image { get; set; }

        public string Prefix { get; set; }

        public int MinLength { get; set; }

        public bool ValueEditable { get; set; }

        public bool IsOptional { get; set; }

        public string Suffix { get; set; }

        public string Type { get; set; }

        public bool IsValueProvided { get; set; }

        public string Name { get; set; }

        [JsonPropertyName("id")]
        public int YodleeFieldId { get; set; }

        public string Value { get; set; }

        public int MaxLength { get; set; }
        [NotMapped]
        public List<object> Option { get; set; }
    }
}