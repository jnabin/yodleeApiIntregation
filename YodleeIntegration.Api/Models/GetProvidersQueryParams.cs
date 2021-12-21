using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace YodleeIntegration.Api.Models
{
    public class GetProvidersQueryParams
    {
        [FromQuery(Name = "capability")]
        public string Capability { get; set; }

        [FromQuery(Name = "dataset$filter")]
        public string DataSetsFilter { get; set; }

        [FromQuery(Name = "fullAccountNumberFields")]
        public string FullAccountNumberFields { get; set; }

        [FromQuery(Name = "institutionId")]
        public long InstitutionId { get; set; }

        [FromQuery(Name = "name")]
        public string Name { get; set; }

        [FromQuery(Name = "priority")]
        public string Priority { get; set; }

        [FromQuery(Name = "providerId")]
        public string ProviderId { get; set; }

        [FromQuery(Name = "skip")]
        public int Skip { get; set; }

        [FromQuery(Name = "top")]
        public int Top { get; set; }
        public IEnumerable<KeyValuePair<string, string>> GetQueryParamsList()
        {
            var parameters = new List<KeyValuePair<string, string>>();
            if (!string.IsNullOrWhiteSpace(Capability))
            {
                parameters.Add(new KeyValuePair<string, string>("capability", Capability));
            }
            if (!string.IsNullOrWhiteSpace(DataSetsFilter))
            {
                parameters.Add(new KeyValuePair<string, string>("dataset$filter", DataSetsFilter));
            }
            if (!string.IsNullOrWhiteSpace(FullAccountNumberFields))
            {
                parameters.Add(new KeyValuePair<string, string>("fullAccountNumberFields", FullAccountNumberFields));
            }
            if (!string.IsNullOrWhiteSpace(InstitutionId.ToString()))
            {
                parameters.Add(new KeyValuePair<string, string>("institutionId", InstitutionId.ToString()));
            }
            if (!string.IsNullOrWhiteSpace(Name))
            {
                parameters.Add(new KeyValuePair<string, string>("name", Name));
            }
            if (!string.IsNullOrWhiteSpace(Priority))
            {
                parameters.Add(new KeyValuePair<string, string>("priority", Priority));
            }
            if (!string.IsNullOrWhiteSpace(ProviderId))
            {
                parameters.Add(new KeyValuePair<string, string>("providerId", ProviderId));
            }
            if (!string.IsNullOrWhiteSpace(Skip.ToString()))
            {
                parameters.Add(new KeyValuePair<string, string>("skip", Skip.ToString()));
            }
            if (!string.IsNullOrWhiteSpace(Top.ToString()))
            {
                parameters.Add(new KeyValuePair<string, string>("top", Top.ToString()));
            }
            return parameters;
        }
    }
}
