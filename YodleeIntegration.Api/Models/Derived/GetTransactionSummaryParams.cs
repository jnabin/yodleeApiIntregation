using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace YodleeIntegration.Api.Models.Derived
{
    public class GetTransactionSummaryParams
    {
        [FromQuery(Name = "accountId")]
        public string AccountId { get; set; }

        [FromQuery(Name = "categoryId")]
        public string CategoryId { get; set; }

        [FromQuery(Name = "categoryType")]
        public string CategoryType { get; set; }

        [FromQuery(Name = "fromDate")]
        public string FromDate { get; set; }

        [FromQuery(Name = "groupBy")]
        public string GroupBy { get; set; }

        [FromQuery(Name = "include")]
        public string Include { get; set; }

        [FromQuery(Name = "includeUserCategory")]
        public bool IncludeUserCategory { get; set; }

        [FromQuery(Name = "interval")]
        public string Interval { get; set; }

        [FromQuery(Name = "toDate")]
        public string ToDate { get; set; }

        public IEnumerable<KeyValuePair<string, string>> GetQueryParamsList()
        {
            var parameters = new List<KeyValuePair<string, string>>();

            if (!string.IsNullOrWhiteSpace(AccountId))
            {
                parameters.Add(new KeyValuePair<string, string>("accountId", AccountId));
            }
            if (!string.IsNullOrWhiteSpace(CategoryId))
            {
                parameters.Add(new KeyValuePair<string, string>("categoryId", CategoryId));
            }
            if (!string.IsNullOrWhiteSpace(CategoryType))
            {
                parameters.Add(new KeyValuePair<string, string>("CategoryType", CategoryType));
            }
            if (!string.IsNullOrWhiteSpace(FromDate))
            {
                parameters.Add(new KeyValuePair<string, string>("fromDate", FromDate));
            }
            if (!string.IsNullOrWhiteSpace(GroupBy))
            {
                parameters.Add(new KeyValuePair<string, string>("groupBy", GroupBy));
            }
            if (!string.IsNullOrWhiteSpace(Include))
            {
                parameters.Add(new KeyValuePair<string, string>("include", Include));
            }

            parameters.Add(new KeyValuePair<string, string>("includeUserCategory", IncludeUserCategory.ToString()));

            if (!string.IsNullOrWhiteSpace(Interval))
            {
                parameters.Add(new KeyValuePair<string, string>("top", Interval));
            }
            if (!string.IsNullOrWhiteSpace(ToDate))
            {
                parameters.Add(new KeyValuePair<string, string>("toDate", ToDate));
            }
            return parameters;
        }
    }
}