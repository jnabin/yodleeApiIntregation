using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Entities.UpdateTransaction;

namespace YodleeIntegration.Application.Request
{
    public class UpdateTransactionRequestBody
    {
        [JsonPropertyName("transaction")]
        
        [Required(ErrorMessage = "Transaction is empty.")]
        public Transaction Transaction { get; set; }
    }
}