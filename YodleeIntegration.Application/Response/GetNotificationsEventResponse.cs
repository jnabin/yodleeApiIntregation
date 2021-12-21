using System.Collections.Generic;
using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.Response
{
    public class GetNotificationsEventResponse
    {
        [JsonPropertyName("event")]
        public List<NotificationEvent> Event { get; set; }
    }
}
