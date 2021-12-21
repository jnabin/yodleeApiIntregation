using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;

namespace YodleeIntegration.Api.Models
{
    public class GetLatestBalancesQueryParams
    {
        [BindRequired]
        [FromQuery(Name = "accountId")]
        public string AccountId { get; set; }

        [BindRequired]
        [FromQuery(Name = "providerAccountId")]
        public string ProviderAccountId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> GetQueryParamsList()
        {
            var parameters = new List<KeyValuePair<string, string>>();

            if (!string.IsNullOrWhiteSpace(AccountId))
            {
                parameters.Add(new KeyValuePair<string, string>("accountId", AccountId));
            }
            if (!string.IsNullOrWhiteSpace(ProviderAccountId))
            {
                parameters.Add(new KeyValuePair<string, string>("providerAccountId", ProviderAccountId));
            }

            return parameters;
        }
    }
}