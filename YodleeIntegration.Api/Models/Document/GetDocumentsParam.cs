using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace YodleeIntegration.Api.Models.Document
{
    public class GetDocumentsParam
    {
        [FromQuery(Name = "Keyword")]
        public string Keyword { get; set; }

        [FromQuery(Name = "accountId")]
        public string AccountId { get; set; }

        [FromQuery(Name = "docType")]
        public string DocType { get; set; }

        [FromQuery(Name = "fromDate")]
        public string FromDate { get; set; }

        [FromQuery(Name = "toDate")]
        public string ToDate { get; set; }

        public IEnumerable<KeyValuePair<string, string>> GetQueryParamsList()
        {
            var parameters = new List<KeyValuePair<string, string>>();

            if (!string.IsNullOrWhiteSpace(Keyword))
            {
                parameters.Add(new KeyValuePair<string, string>("keyword", Keyword));
            }
            if (!string.IsNullOrWhiteSpace(AccountId))
            {
                parameters.Add(new KeyValuePair<string, string>("accountId", AccountId));
            }
            if (!string.IsNullOrWhiteSpace(DocType))
            {
                parameters.Add(new KeyValuePair<string, string>("docType", DocType));
            }
            if (!string.IsNullOrWhiteSpace(FromDate))
            {
                parameters.Add(new KeyValuePair<string, string>("fromDate", FromDate));
            }
            if (!string.IsNullOrWhiteSpace(ToDate))
            {
                parameters.Add(new KeyValuePair<string, string>("toDate", ToDate));
            }
            return parameters;
        }
    }
}