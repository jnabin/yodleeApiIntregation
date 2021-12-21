using System.Collections.Generic;
using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.Request
{
    public class VerifyAccountRequestBody
    {
        [JsonPropertyName("container")]
        public string Container { get; set; }

        [JsonPropertyName("accountId")]
        public int AccountId { get; set; }

        [JsonPropertyName("transactionCriteria")]
        public List<VerifyAccountTransactionCriteria> TransactionCriteria { get; set; }
    }
}
