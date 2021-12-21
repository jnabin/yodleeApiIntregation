using Newtonsoft.Json;

namespace YodleeIntegration.Application.Request.User
{
    public class AccessTokensRequest : BaseRequest
    {
        [JsonProperty("appIds")]
        public string AppIds { get; set; }
    }
}