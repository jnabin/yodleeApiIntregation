using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;

namespace YodleeIntegration.Api.Models
{
    public class RunTransactionCategorizationParams
    {
        [BindRequired]
        [FromQuery(Name = "action")]
        public string Action { get; set; }

        public IEnumerable<KeyValuePair<string, string>> GetQueryParamsList()
        {
            var parameters = new List<KeyValuePair<string, string>>();
            if (!string.IsNullOrWhiteSpace(Action))
            {
                parameters.Add(new KeyValuePair<string, string>("action", Action));
            }
            return parameters;
        }
    }
}
