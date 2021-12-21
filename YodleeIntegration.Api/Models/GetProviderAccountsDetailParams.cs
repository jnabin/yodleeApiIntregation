using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace YodleeIntegration.Api.Models
{
    public class GetProviderAccountsDetailParams
    {
        [FromQuery(Name = "include")] public string Include { get; set; }

        [FromQuery(Name = "requestId")] public string RequestId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> GetQueryParamsList()
        {
            var parameters = new List<KeyValuePair<string, string>>();
            if (!string.IsNullOrWhiteSpace(Include))
            {
                parameters.Add(new KeyValuePair<string, string>("accountId", Include));
            }

            if (!string.IsNullOrWhiteSpace(RequestId))
            {
                parameters.Add(new KeyValuePair<string, string>("requestId", RequestId));
            }

            return parameters;
        }
    }
}