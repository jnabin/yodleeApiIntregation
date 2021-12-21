using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace YodleeIntegration.Domain.Model.Authorizations
{
    [Table("YodleeWrapperIntegrationApiKeys")]
    public class YodleeApiKey : Entity.Entity
    {
        public int ExpiresIn { get; set; }

        public DateTime CreatedDate { get; set; }

        public string PublicKey { get; set; }

        public string Key { get; set; }

        public YodleeApiKey()
        {
            this.CreatedDate = DateTime.UtcNow;
        }
    }
}