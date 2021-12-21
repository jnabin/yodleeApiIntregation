using Newtonsoft.Json;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.Response
{
    public class UserResponse
    {
        [JsonProperty("user")]
        public Users User { get; set; }
    }
}
