using System.Collections.Generic;
using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.Response
{
    public class TransactionResponse
    {
        [JsonPropertyName("transaction")]
        public List<Transaction> Transaction { get; set; }
    }
}
