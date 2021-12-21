using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace YodleeIntegration.Api.Models
{
    public class GetTransactionsCountsQueryParams
    {
        [FromQuery(Name = "accountId")]
        public string AccountId { get; set; }

        [FromQuery(Name = "baseType")]
        public string BaseType { get; set; }

        [FromQuery(Name = "categoryId")]
        public string CategoryId { get; set; }

        [FromQuery(Name = "categoryType")]
        public string CategoryType { get; set; }

        [FromQuery(Name = "container")]
        public string Container { get; set; }

        [FromQuery(Name = "detailCategoryId")]
        public string DetailCategoryId { get; set; }

        [FromQuery(Name = "fromDate")]
        public string FromDate { get; set; }

        [FromQuery(Name = "highLevelCategoryId")]
        public string HighLevelCategoryId { get; set; }

        [FromQuery(Name = "keyword")]
        public string Keyword { get; set; }

        [FromQuery(Name = "toDate")]
        public string ToDate { get; set; }

        [FromQuery(Name = "type")]
        public string Type { get; set; }

        public IEnumerable<KeyValuePair<string, string>> GetQueryParamsList()
        {
            var parameters = new List<KeyValuePair<string, string>>();
            if (!string.IsNullOrWhiteSpace(AccountId))
            {
                parameters.Add(new KeyValuePair<string, string>("accountId", AccountId));
            }
            if (!string.IsNullOrWhiteSpace(BaseType))
            {
                parameters.Add(new KeyValuePair<string, string>("baseType", BaseType));
            }
            if (!string.IsNullOrWhiteSpace(CategoryId))
            {
                parameters.Add(new KeyValuePair<string, string>
                    ("categoryId", CategoryId));
            }
            if (!string.IsNullOrWhiteSpace(CategoryType))
            {
                parameters.Add(new KeyValuePair<string, string>("categoryType", CategoryType));
            }
            if (!string.IsNullOrWhiteSpace(Container))
            {
                parameters.Add(new KeyValuePair<string, string>("container", Container));
            }
            if (!string.IsNullOrWhiteSpace(DetailCategoryId))
            {
                parameters.Add(new KeyValuePair<string, string>("detailCategoryId", DetailCategoryId));
            }
            if (!string.IsNullOrWhiteSpace(FromDate))
            {
                parameters.Add(new KeyValuePair<string, string>("fromDate", FromDate));
            }
            if (!string.IsNullOrWhiteSpace(HighLevelCategoryId))
            {
                parameters.Add(new KeyValuePair<string, string>("highLevelCategoryId", HighLevelCategoryId));
            }
            if (!string.IsNullOrWhiteSpace(ToDate))
            {
                parameters.Add(new KeyValuePair<string, string>("toDate", ToDate));
            }
            if (!string.IsNullOrWhiteSpace(Type))
            {
                parameters.Add(new KeyValuePair<string, string>("type", Type));
            }
            return parameters;
        }
    }
}
