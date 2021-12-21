using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace YodleeIntegration.Api.Models.Statements
{
    public class GetStatementsParam
    {
        [FromQuery(Name = "accountId")]
        public string AccountId { get; set; }

        [FromQuery(Name = "container")]
        public string Container { get; set; }

        [FromQuery(Name = "fromDate")]
        public string FromDate { get; set; }

        [FromQuery(Name = "isLatest")]
        public string IsLatest { get; set; }

        [FromQuery(Name = "status")]
        public string Status { get; set; }

        public IEnumerable<KeyValuePair<string, string>> GetQueryParamsList()
        {
            var parameters = new List<KeyValuePair<string, string>>();
            if (!string.IsNullOrWhiteSpace(AccountId))
            {
                parameters.Add(new KeyValuePair<string, string>("accountId", AccountId));
            }

            if (!string.IsNullOrWhiteSpace(Container))
            {
                parameters.Add(new KeyValuePair<string, string>("container", Container));
            }

            parameters.Add(new KeyValuePair<string, string>("fromDate", FromDate));

            if (!string.IsNullOrWhiteSpace(IsLatest))
            {
                parameters.Add(new KeyValuePair<string, string>("providerAccountId", IsLatest));
            }

            if (!string.IsNullOrWhiteSpace(Status))
            {
                parameters.Add(new KeyValuePair<string, string>("requestId", Status));
            }

            return parameters;
        }
    }
}