using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace YodleeIntegration.Application.Request.User
{
    public class SamlLoginRequest : BaseRequest
    {
        [JsonProperty("issuer")]
        
        [Required(ErrorMessage = "Issuer is empty.")]
        public string Issuer { get; set; }

        [JsonProperty("samlResponse")]
        
        [Required(ErrorMessage = "Saml Response is empty.")]
        public string SamlResponse { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }
    }
}