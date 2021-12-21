using System.Collections.Generic;
using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.Response
{
    public class GetTransactionCategoryListResponse
    {
        [JsonPropertyName("transactionCategory")]
        public List<TransactionCategory> TransactionCategory { get; set; }
    }
}
