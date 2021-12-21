using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace YodleeIntegration.Api.Models
{
    public class GetUserProfileDetailsParams
    {
        [FromQuery(Name = "providerAccountId")] public string ProviderAccountId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> GetQueryParamsList()
        {
            var parameters = new List<KeyValuePair<string, string>>();
            if (!string.IsNullOrWhiteSpace(ProviderAccountId))
            {
                parameters.Add(new KeyValuePair<string, string>("providerAccountId", ProviderAccountId));
            }
            return parameters;
        }
    }
}
