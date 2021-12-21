using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.Request
{
    public class UpdateNotificationEventRequestBody
    {
        [JsonPropertyName("event")]
        
        [Required(ErrorMessage = "Event is empty.")]
        public NotificationEvent Event { get; set; }
    }
}