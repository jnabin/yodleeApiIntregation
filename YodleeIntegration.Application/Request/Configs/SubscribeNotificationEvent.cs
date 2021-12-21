using System.Text.Json.Serialization;

namespace YodleeIntegration.Domain.Entities.Configs
{
    public class SubscribeNotificationEvent
    {
        public string CallBackUrl { get; set; }
    }
}