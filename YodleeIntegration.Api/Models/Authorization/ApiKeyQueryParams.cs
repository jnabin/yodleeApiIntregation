using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace YodleeIntegration.Api.Models.Authorization
{
    public class ApiKeyQueryParams
    {
        [FromQuery(Name = "publicKey")]
        public string PublicKey { get; set; }

        public IEnumerable<KeyValuePair<string, string>> GetQueryParamsList()
        {
            var parameters = new List<KeyValuePair<string, string>>();

            if (!string.IsNullOrWhiteSpace(PublicKey))
            {
                parameters.Add(new KeyValuePair<string, string>("publicKey", PublicKey));
            }

            return parameters;
        }
    }
}