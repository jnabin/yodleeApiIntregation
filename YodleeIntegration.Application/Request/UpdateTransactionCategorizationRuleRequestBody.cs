using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.Request
{
    public class UpdateTransactionCategorizationRuleRequestBody
    {
        [JsonPropertyName("rule")]
        
        [Required(ErrorMessage = "Rule is empty.")]
        public Rule Rule { get; set; }
    }
}