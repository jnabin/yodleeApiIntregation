using System.Collections.Generic;
using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Model.FullAuditedEntity;


namespace YodleeIntegration.Domain.Entities
{
    public class Provider : FullAuditedEntity
    {
        public string LanguageISOCode { get; set; }
        
        public string Favicon { get; set; }
        
        public List<string> AccountType { get; set; }
        
        public string CountryISOCode { get; set; }
        
        public string IsAddedByUser { get; set; }
        
        public string PRIORITY { get; set; }
        
        public List<int> AssociatedProviderIds { get; set; }
        
        public string PrimaryLanguageISOCode { get; set; }
        
        public string Help { get; set; }
        
        public string BaseUrl { get; set; }
        
        public List<Capability> Capability { get; set; }
        
        public List<LoginForm> LoginForm { get; set; }
        
        public bool IsConsentRequired { get; set; }
        
        public string LoginUrl { get; set; }
        
        public bool IsAutoRefreshEnabled { get; set; }
        
        public string Name { get; set; }
        
        public string Logo { get; set; }

        [JsonPropertyName("id")]
        public int YodleeProviderId { get; set; }
        
        public string LastModified { get; set; }
        
        public List<string> AuthParameter { get; set; }
        
        public string AuthType { get; set; }
        
        public List<ProvidersDataset> Dataset { get; set; }
        
        public string Status { get; set; }
    }
}
