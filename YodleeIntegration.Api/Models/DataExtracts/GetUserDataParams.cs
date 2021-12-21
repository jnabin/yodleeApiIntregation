using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace YodleeIntegration.Api.Models.DataExtracts
{
    public class GetUserDataParams
    {
        [FromQuery(Name = "fromDate")]
        public string FromDate { get; set; }

        [FromQuery(Name = "loginName")]
        public string LoginName { get; set; }

        [FromQuery(Name = "toDate")]
        public string ToDate { get; set; }

        public IEnumerable<KeyValuePair<string, string>> GetQueryParamsList()
        {
            var parameters = new List<KeyValuePair<string, string>>();
            if (!string.IsNullOrWhiteSpace(FromDate))
            {
                parameters.Add(new KeyValuePair<string, string>("fromDate", FromDate));
            }

            if (!string.IsNullOrWhiteSpace(LoginName))
            {
                parameters.Add(new KeyValuePair<string, string>("loginName", LoginName));
            }

            if (!string.IsNullOrWhiteSpace(ToDate))
            {
                parameters.Add(new KeyValuePair<string, string>("toDate", ToDate));
            }

            return parameters;
        }
    }
}