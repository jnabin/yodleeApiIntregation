using YodleeIntegration.Domain.Model.FullAuditedEntity;
using System.Collections.Generic;

namespace YodleeIntegration.Domain.Entities
{
    public class Profile : FullAuditedEntity
    {
        public List<Identifier> Identifier { get; set; }

        public List<Address> Address { get; set; }

        public List<PhoneNumber> PhoneNumber { get; set; }

        public string Gender { get; set; }

        public Name Name { get; set; }

        public List<Email> Email { get; set; }
    }
}