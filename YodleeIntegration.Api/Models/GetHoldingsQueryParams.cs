using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace YodleeIntegration.Api.Models
{
    public class GetHoldingsQueryParams
    {
        [FromQuery(Name = "accountId")]
        public string AccountId { get; set; }

        [FromQuery(Name = "assetClassification.classificationType")]
        public string AssetClassificationClassificationType { get; set; }

        [FromQuery(Name = "classificationValue")]
        public string ClassificationValue { get; set; }

        [FromQuery(Name = "include")]
        public string Include { get; set; }

        [FromQuery(Name = "providerAccountId")]
        public string ProviderAccountId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> GetQueryParamsList()
        {
            var parameters = new List<KeyValuePair<string, string>>();

            if (!string.IsNullOrWhiteSpace(AccountId))
            {
                parameters.Add(new KeyValuePair<string, string>("accountId", AccountId));
            }
            if (!string.IsNullOrWhiteSpace(AssetClassificationClassificationType))
            {
                parameters.Add(new KeyValuePair<string, string>("assetClassification.classificationType", AssetClassificationClassificationType));
            }
            if (!string.IsNullOrWhiteSpace(ClassificationValue))
            {
                parameters.Add(new KeyValuePair<string, string>("classificationValue", ClassificationValue));
            }
            if (!string.IsNullOrWhiteSpace(Include))
            {
                parameters.Add(new KeyValuePair<string, string>("include", Include));
            }
            if (!string.IsNullOrWhiteSpace(ProviderAccountId))
            {
                parameters.Add(new KeyValuePair<string, string>("providerAccountId", ProviderAccountId));
            }

            return parameters;
        }
    }
}