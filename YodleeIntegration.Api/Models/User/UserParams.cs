using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace YodleeIntegration.Api.Models.User
{
    public class UserParams
    {
        [FromQuery(Name = "preferences")]
        public string Preferences { get; set; }

        [FromQuery(Name = "address")]
        public string Address { get; set; }

        [FromQuery(Name = "name")]
        public string Name { get; set; }

        [FromQuery(Name = "email")]
        public string Email { get; set; }

        [FromQuery(Name = "segmentName")]
        public string SegmentName { get; set; }

        public IEnumerable<KeyValuePair<string, string>> GetQueryParamsList()
        {
            var parameters = new List<KeyValuePair<string, string>>();
            if (!string.IsNullOrWhiteSpace(Preferences))
            {
                parameters.Add(new KeyValuePair<string, string>("preferences", Preferences));
            }

            if (!string.IsNullOrWhiteSpace(Address))
            {
                parameters.Add(new KeyValuePair<string, string>("address", Address));
            }

            if (!string.IsNullOrWhiteSpace(Name))
            {
                parameters.Add(new KeyValuePair<string, string>("name", Name));
            }
            if (!string.IsNullOrWhiteSpace(Email))
            {
                parameters.Add(new KeyValuePair<string, string>("email", Email));
            }

            if (!string.IsNullOrWhiteSpace(SegmentName))
            {
                parameters.Add(new KeyValuePair<string, string>("segmentName", SegmentName));
            }

            return parameters;
        }
    }
}