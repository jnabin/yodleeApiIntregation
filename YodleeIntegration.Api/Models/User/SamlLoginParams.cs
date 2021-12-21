using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace YodleeIntegration.Api.Models.User
{
    public class SamlLoginParams
    {
        [FromQuery(Name = "issuer")]
        public string Issuer { get; set; }

        [FromQuery(Name = "samlResponse")]
        public string SamlResponse { get; set; }

        [FromQuery(Name = "source")]
        public string Source { get; set; }

        public IEnumerable<KeyValuePair<string, string>> GetQueryParamsList()
        {
            var parameters = new List<KeyValuePair<string, string>>();
            if (!string.IsNullOrWhiteSpace(Issuer))
            {
                parameters.Add(new KeyValuePair<string, string>("issuer", Issuer));
            }

            if (!string.IsNullOrWhiteSpace(SamlResponse))
            {
                parameters.Add(new KeyValuePair<string, string>("samlResponse", SamlResponse));
            }

            if (!string.IsNullOrWhiteSpace(Source))
            {
                parameters.Add(new KeyValuePair<string, string>("source", Source));
            }

            return parameters;
        }
    }
}