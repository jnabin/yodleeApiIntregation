using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace YodleeIntegration.Api.Models
{
    public class GetAccountsQueryParams
    {
        [FromQuery(Name = "accountId")]
        public string AccountId { get; set; }

        [FromQuery(Name = "container")]
        public string Container { get; set; }

        [FromQuery(Name = "include")]
        public string Include { get; set; }

        [FromQuery(Name = "providerAccountId")]
        public string ProviderAccountId { get; set; }

        [FromQuery(Name = "requestId")]
        public string RequestId { get; set; }

        [FromQuery(Name = "status")]
        public string Status { get; set; }

        public IEnumerable<KeyValuePair<string, string>> GetQueryParamsList()
        {
            var parameters = new List<KeyValuePair<string, string>>();
            if (!string.IsNullOrWhiteSpace(AccountId))
            {
                parameters.Add(new KeyValuePair<string, string>("accountId", AccountId));
            }

            if (!string.IsNullOrWhiteSpace(Container))
            {
                parameters.Add(new KeyValuePair<string, string>("container", Container));
            }

            if (!string.IsNullOrWhiteSpace(Include))
            {
                parameters.Add(new KeyValuePair<string, string>("include", AccountId));
            }

            if (!string.IsNullOrWhiteSpace(ProviderAccountId))
            {
                parameters.Add(new KeyValuePair<string, string>("providerAccountId", ProviderAccountId));
            }

            if (!string.IsNullOrWhiteSpace(RequestId))
            {
                parameters.Add(new KeyValuePair<string, string>("requestId", RequestId));
            }

            if (!string.IsNullOrWhiteSpace(Status))
            {
                parameters.Add(new KeyValuePair<string, string>("status", Status));
            }
            return parameters;
        }
    }
}