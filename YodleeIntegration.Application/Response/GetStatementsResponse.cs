using System.Collections.Generic;
using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.Response
{
    public class GetStatementsResponse
    {
        [JsonPropertyName("statement")]
        public List<Statement> Statement { get; set; }
    }
}
