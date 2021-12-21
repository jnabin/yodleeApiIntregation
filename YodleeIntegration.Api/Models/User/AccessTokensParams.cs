using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace YodleeIntegration.Api.Models.User
{
    public class AccessTokensParams
    {
        [FromQuery(Name = "appIds")]
        public string AppIds { get; set; }

        public IEnumerable<KeyValuePair<string, string>> GetQueryParamsList()
        {
            var parameters = new List<KeyValuePair<string, string>>();
            if (!string.IsNullOrWhiteSpace(AppIds))
            {
                parameters.Add(new KeyValuePair<string, string>("appIds", AppIds));
            }

            return parameters;
        }
    }
}