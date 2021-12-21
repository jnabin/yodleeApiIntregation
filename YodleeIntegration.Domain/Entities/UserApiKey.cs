using System;
using YodleeIntegration.Common.Mappers;
using YodleeIntegration.Domain.Model.Authorizations;

namespace YodleeIntegration.Domain.Entities
{
    public class UserApiKey : IMapper<YodleeApiKey, UserApiKey>
    {
        public int ExpiresIn { get; set; }

        public DateTime CreatedDate { get; set; }

        public string PublicKey { get; set; }

        public string Key { get; set; }

        public YodleeApiKey Map()
        {
            return new YodleeApiKey
            {
                ExpiresIn = ExpiresIn,
                CreatedDate = CreatedDate,
                PublicKey = PublicKey,
                Key = Key
            };
        }
    }
}