using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace YodleeIntegration.Domain.Model.Configurations
{
    [Table("YodleeWrapperIntegrationConfigurations")]
    public class YodleeConfiguration : Entity.Entity
    {
        public string Url { get; set; } = string.Empty;

        public string AdminUsername { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;

        public string ClientId { get; set; } = string.Empty;

        public string Secret { get; set; } = string.Empty;

        public string ProviderId { get; set; } = string.Empty;

        public string ProviderAccountId { get; set; } = string.Empty;

        public string AccountId { get; set; } = string.Empty;

        public string RequestId { get; set; } = string.Empty;

        public string ApiVersion { get; set; } = string.Empty;

        public static implicit operator Task<object>(YodleeConfiguration v)
        {
            throw new NotImplementedException();
        }
    }
}
