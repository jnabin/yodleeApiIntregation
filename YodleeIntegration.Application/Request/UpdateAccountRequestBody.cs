using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.Request
{
    public class UpdateAccountRequestBody : BaseRequest
    {
        [JsonPropertyName("event")]
        public NotificationEvent Event { get; set; }

        [JsonPropertyName("account")]
        [Required(ErrorMessage = "Account is empty.")]
        public UpdateAccountDetails Account { get; set; }
    }
}