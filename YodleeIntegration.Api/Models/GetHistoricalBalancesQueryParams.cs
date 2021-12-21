using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace YodleeIntegration.Api.Models
{
    public class GetHistoricalBalancesQueryParams
    {
        [FromQuery(Name = "accountId")]
        public string AccountId { get; set; }

        [FromQuery(Name = "includeCf")]
        public string IncludeCf { get; set; }

        [FromQuery(Name = "fromDate")]
        public string FromDate { get; set; }

        [FromQuery(Name = "toDate")]
        public string ToDate { get; set; }

        [FromQuery(Name = "interval")]
        public string Interval { get; set; }

        [FromQuery(Name = "accountReconType")]
        public string AccountReconType { get; set; }

        [FromQuery(Name = "skip")]
        public string Skip { get; set; }

        [FromQuery(Name = "top")]
        public string Top { get; set; }

        public IEnumerable<KeyValuePair<string, string>> GetQueryParamsList()
        {
            var parameters = new List<KeyValuePair<string, string>>();

            if (!string.IsNullOrWhiteSpace(AccountId))
            {
                parameters.Add(new KeyValuePair<string, string>("accountId", AccountId));
            }
            if (!string.IsNullOrWhiteSpace(IncludeCf))
            {
                parameters.Add(new KeyValuePair<string, string>("includeCf", IncludeCf));
            }
            if (!string.IsNullOrWhiteSpace(FromDate))
            {
                parameters.Add(new KeyValuePair<string, string>("fromDate", FromDate));
            }
            if (!string.IsNullOrWhiteSpace(ToDate))
            {
                parameters.Add(new KeyValuePair<string, string>("toDate", ToDate));
            }
            if (!string.IsNullOrWhiteSpace(Interval))
            {
                parameters.Add(new KeyValuePair<string, string>("interval", Interval));
            }
            if (!string.IsNullOrWhiteSpace(AccountReconType))
            {
                parameters.Add(new KeyValuePair<string, string>("accountReconType", AccountReconType));
            }
            if (!string.IsNullOrWhiteSpace(Skip))
            {
                parameters.Add(new KeyValuePair<string, string>("skip", Skip));
            }
            if (!string.IsNullOrWhiteSpace(Top))
            {
                parameters.Add(new KeyValuePair<string, string>("top", Top));
            }
            return parameters;
        }
    }
}