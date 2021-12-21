using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YodleeIntegration.Application.Response
{
    public class UserAccessToken
    {
        [JsonPropertyName("user")]
        public AccessToken AccessToken { get; set; }
    }
}
