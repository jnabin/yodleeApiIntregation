using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace YodleeIntegration.Api.Models
{
    public class GetAccountsDetailQueryParams
    {
        [FromQuery(Name = "container")]
        public string Container { get; set; }

        [FromQuery(Name = "include")]
        public string Include { get; set; }

        public IEnumerable<KeyValuePair<string, string>> GetQueryParamsList()
        {
            var parameters = new List<KeyValuePair<string, string>>();

            if (!string.IsNullOrWhiteSpace(Container))
            {
                parameters.Add(new KeyValuePair<string, string>("container", Container));
            }

            if (!string.IsNullOrWhiteSpace(Include))
            {
                parameters.Add(new KeyValuePair<string, string>("include", Include));
            }
            return parameters;
        }
    }
}