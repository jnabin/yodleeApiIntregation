using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace YodleeIntegration.Api.Models.Derived
{
    public class GetNetworthSummaryParams
    {
        [FromQuery(Name = "accountId")]
        public string AccountIds { get; set; }

        [FromQuery(Name = "container")]
        public string Container { get; set; }

        [FromQuery(Name = "fromDate")]
        public string FromDate { get; set; }

        [FromQuery(Name = "include")]
        public string Include { get; set; }

        [FromQuery(Name = "interval")]
        public string Interval { get; set; }

        [FromQuery(Name = "skip")]
        public int Skip { get; set; }

        [FromQuery(Name = "toDate")]
        public string ToDate { get; set; }

        [FromQuery(Name = "top")]
        public int Top { get; set; }

        public IEnumerable<KeyValuePair<string, string>> GetQueryParamsList()
        {
            var parameters = new List<KeyValuePair<string, string>>();

            if (!string.IsNullOrWhiteSpace(AccountIds))
            {
                parameters.Add(new KeyValuePair<string, string>("accountId", AccountIds));
            }
            if (!string.IsNullOrWhiteSpace(Container))
            {
                parameters.Add(new KeyValuePair<string, string>("includeCf", Container));
            }
            if (!string.IsNullOrWhiteSpace(FromDate))
            {
                parameters.Add(new KeyValuePair<string, string>("fromDate", FromDate));
            }
            if (!string.IsNullOrWhiteSpace(Include))
            {
                parameters.Add(new KeyValuePair<string, string>("toDate", Include));
            }
            if (!string.IsNullOrWhiteSpace(Interval))
            {
                parameters.Add(new KeyValuePair<string, string>("interval", Interval));
            }
            if (!string.IsNullOrWhiteSpace(Skip.ToString()))
            {
                parameters.Add(new KeyValuePair<string, string>("accountReconType", Skip.ToString()));
            }
            if (!string.IsNullOrWhiteSpace(ToDate))
            {
                parameters.Add(new KeyValuePair<string, string>("skip", ToDate));
            }
            if (!string.IsNullOrWhiteSpace(Top.ToString()))
            {
                parameters.Add(new KeyValuePair<string, string>("top", Top.ToString()));
            }
            return parameters;
        }
    }
}