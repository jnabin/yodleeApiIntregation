using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace YodleeIntegration.Api.Models.DataExtracts
{
    public class GetEventsParams
    {
        [FromQuery(Name = "fromDate ")]
        public string FromDate { get; set; }

        [FromQuery(Name = "eventName")]
        public string EventName { get; set; }

        [FromQuery(Name = "toDate")]
        public string ToDate { get; set; }

        public IEnumerable<KeyValuePair<string, string>> GetQueryParamsList()
        {
            var parameters = new List<KeyValuePair<string, string>>();
            if (!string.IsNullOrWhiteSpace(FromDate))
            {
                parameters.Add(new KeyValuePair<string, string>("fromDate", FromDate));
            }

            if (!string.IsNullOrWhiteSpace(EventName))
            {
                parameters.Add(new KeyValuePair<string, string>("eventName", EventName));
            }

            if (!string.IsNullOrWhiteSpace(ToDate))
            {
                parameters.Add(new KeyValuePair<string, string>("toDate", ToDate));
            }

            return parameters;
        }
    }
}