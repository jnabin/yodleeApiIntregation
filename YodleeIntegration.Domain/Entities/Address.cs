using System.ComponentModel.DataAnnotations;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class Address : FullAuditedEntity
    {
        public string Zip { get; set; }

        public string Country { get; set; }

        public string Address3 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string SourceType { get; set; }

        public string Address1 { get; set; }
        [Required(ErrorMessage = "Street is empty.")]
        public string Street { get; set; }

        public string State { get; set; }

        public string Type { get; set; }
    }
}