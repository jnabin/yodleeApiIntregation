using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.Request
{
    public class AddManualAccountRequestBody : BaseRequest
    {
        [JsonPropertyName("account")]
        [Required(ErrorMessage = "Account is empty.")]
        public AddManualAccount Account { get; set; }
    }
}