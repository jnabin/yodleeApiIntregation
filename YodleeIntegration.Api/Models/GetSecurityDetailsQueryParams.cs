using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace YodleeIntegration.Api.Models
{
    public class GetSecurityDetailsQueryParams
    {
        [FromQuery(Name = "holdingId")]
        public string HoldingId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> GetQueryParamsList()
        {
            var parameters = new List<KeyValuePair<string, string>>();
            if (!string.IsNullOrWhiteSpace(HoldingId))
            {
                parameters.Add(new KeyValuePair<string, string>("holdingId", HoldingId));
            }
            return parameters;
        }
    }
}
