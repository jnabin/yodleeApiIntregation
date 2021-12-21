using YodleeIntegration.Domain.Model.FullAuditedEntity;


namespace YodleeIntegration.Domain.Entities
{
    public class NotificationEvent : FullAuditedEntity
    {
        public string Name { get; set; }

        public string CallBackUrl { get; set; }
    }
}