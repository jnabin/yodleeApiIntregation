using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace YodleeIntegration.Api.Models.Document
{
    public class GetDocumentParam
    {
        [FromQuery(Name = "documentId")]
        public string DocumentId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> GetQueryParamsList()
        {
            var parameters = new List<KeyValuePair<string, string>>();

            if (!string.IsNullOrWhiteSpace(DocumentId))
            {
                parameters.Add(new KeyValuePair<string, string>("DocumentId", DocumentId));
            }

            return parameters;
        }
    }
}