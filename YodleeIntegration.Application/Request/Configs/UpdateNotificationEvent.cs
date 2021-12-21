using System.Text.Json.Serialization;

namespace YodleeIntegration.Domain.Entities.Configs
{
    public class UpdateNotificationEvent
    {
        public string CallBackUrl { get; set; }
    }
}