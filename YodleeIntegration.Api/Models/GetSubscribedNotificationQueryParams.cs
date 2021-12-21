using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace YodleeIntegration.Api.Models
{
    public class GetSubscribedNotificationQueryParams
    {
        [FromQuery(Name = "eventName")]
        public string EventName { get; set; }

        public IEnumerable<KeyValuePair<string, string>> GetQueryParamsList()
        {
            var parameters = new List<KeyValuePair<string, string>>();
            if (!string.IsNullOrWhiteSpace(EventName))
            {
                parameters.Add(new KeyValuePair<string, string>("eventName", EventName));
            }

            return parameters;
        }
    }

}
