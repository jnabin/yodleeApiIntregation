using System.Collections.Generic;
using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.Request
{
    public class ProviderAccountRequestBodyWithDataSet
    {
        [JsonPropertyName("consentId")]
        public int ConsentId { get; set; }

        [JsonPropertyName("preferences")]
        public ProviderAccountPreference Preferences { get; set; }

        [JsonPropertyName("aggregationSource")]
        public string AggregationSource { get; set; }

        [JsonPropertyName("field")]
        public List<UpdateProviderAccountField> Field { get; set; }

        [JsonPropertyName("dataset")]
        public List<UpdateProviderAccountDataSet> DataSet { get; set; }
    }
}
