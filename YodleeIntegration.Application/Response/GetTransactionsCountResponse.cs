using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.Response
{
    public class GetTransactionsCountResponse
    {
        [JsonPropertyName("transaction")]
        public Transaction Transaction { get; set; }
    }
}
