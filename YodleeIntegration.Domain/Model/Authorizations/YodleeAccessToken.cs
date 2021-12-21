using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace YodleeIntegration.Domain.Model.Authorizations
{
    [Table("YodleeWrapperIntegrationAuthTokens")]
    public class YodleeAccessToken : Entity.Entity
    {
        public string AccessToken { get; set; }

        public DateTime IssuedAt { get; set; }

        public DateTime CreatedAt { get; set; }

        public int ExpiresIn { get; set; }

        public bool IsExpired => DateTime.Now.Subtract(CreatedAt).TotalSeconds >= ExpiresIn;
    }
}