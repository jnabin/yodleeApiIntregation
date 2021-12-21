using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace YodleeIntegration.Api.Models
{
    public class GetProviderAccountsParams
    {
        [FromQuery(Name = "include")] 
        public string Include { get; set; }

        [FromQuery(Name = "providerIds")] 
        public string ProviderIds { get; set; }

        public IEnumerable<KeyValuePair<string, string>> GetQueryParamsList()
        {
            var parameters = new List<KeyValuePair<string, string>>();
            if (!string.IsNullOrWhiteSpace(Include))
            {
                parameters.Add(new KeyValuePair<string, string>("accountId", Include));
            }

            if (!string.IsNullOrWhiteSpace(ProviderIds))
            {
                parameters.Add(new KeyValuePair<string, string>("providerIds", ProviderIds));
            }

            return parameters;
        }
    }
}