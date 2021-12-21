using System.Collections.Generic;
using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.Response
{
    public class GetTransactionCategorizationRulesResponse
    {
        [JsonPropertyName("txnRules")]
        public List<TransactionCategorizationRule> TxnRules { get; set; }
    }
}
