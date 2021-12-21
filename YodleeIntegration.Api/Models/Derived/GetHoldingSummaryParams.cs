using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace YodleeIntegration.Api.Models.Derived
{
    public class GetHoldingSummaryParams
    {
        [FromQuery(Name = "accountIds")]
        public string AccountIds { get; set; }

        [FromQuery(Name = "classificationType")]
        public string ClassificationType { get; set; }

        [FromQuery(Name = "include")]
        public string Include { get; set; }

        public IEnumerable<KeyValuePair<string, string>> GetQueryParamsList()
        {
            var parameters = new List<KeyValuePair<string, string>>();

            if (!string.IsNullOrWhiteSpace(AccountIds))
            {
                parameters.Add(new KeyValuePair<string, string>("accountId", AccountIds));
            }
            if (!string.IsNullOrWhiteSpace(ClassificationType))
            {
                parameters.Add(new KeyValuePair<string, string>("ClassificationType", ClassificationType));
            }
            if (!string.IsNullOrWhiteSpace(Include))
            {
                parameters.Add(new KeyValuePair<string, string>("toDate", Include));
            }

            return parameters;
        }
    }
}