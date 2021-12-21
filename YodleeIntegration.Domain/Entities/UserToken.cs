using System;
using System.Text.Json.Serialization;
using YodleeIntegration.Common.Mappers;
using YodleeIntegration.Domain.Model.Authorizations;

namespace YodleeIntegration.Domain.Entities
{
    public class UserToken : IMapper<YodleeAccessToken, UserToken>
    {
        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }
        [JsonPropertyName("issuedAt")]
        public DateTime IssuedAt { get; set; }
        [JsonPropertyName("expiresIn")]
        public int ExpiresIn { get; set; }

        public YodleeAccessToken Map()
        {
            return new YodleeAccessToken()
            {
                AccessToken = AccessToken,
                IssuedAt = IssuedAt,
                CreatedAt = DateTime.Now,
                ExpiresIn = ExpiresIn
            };
        }
    }
}