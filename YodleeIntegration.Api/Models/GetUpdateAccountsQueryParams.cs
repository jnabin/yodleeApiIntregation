using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace YodleeIntegration.Api.Models
{
    public class GetUpdateAccountsQueryParams
    {
        [FromQuery(Name = "providerAccountIds")]
        public string ProviderAccountIds { get; set; }

        public IEnumerable<KeyValuePair<string, string>> GetQueryParamsList()
        {
            var parameters = new List<KeyValuePair<string, string>>();
            if (!string.IsNullOrWhiteSpace(ProviderAccountIds))
            {
                parameters.Add(new KeyValuePair<string, string>("providerAccountIds", ProviderAccountIds));
            }

            return parameters;
        }
    }
}
