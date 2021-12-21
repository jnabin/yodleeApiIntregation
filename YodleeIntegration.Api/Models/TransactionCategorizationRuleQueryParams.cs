using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace YodleeIntegration.Api.Models
{
    public class TransactionCategorizationRuleQueryParams
    {

        [FromQuery(Name = "action")]
        public string Action { get; set; }

        [FromQuery(Name = "ruleParam")]
        public string RuleParam { get; set; }

        public IEnumerable<KeyValuePair<string, string>> GetQueryParamsList()
        {
            var parameters = new List<KeyValuePair<string, string>>();
            if (!string.IsNullOrWhiteSpace(Action))
            {
                parameters.Add(new KeyValuePair<string, string>("action", Action));
            }
            if (!string.IsNullOrWhiteSpace(RuleParam))
            {
                parameters.Add(new KeyValuePair<string, string>("ruleParam", RuleParam));
            }
            return parameters;
        }
    }
}
