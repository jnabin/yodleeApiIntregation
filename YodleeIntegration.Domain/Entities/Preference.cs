using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class Preference : FullAuditedEntity
    {
        public string DateFormat { get; set; }

        public string TimeZone { get; set; }

        public string Currency { get; set; }

        public string Locale { get; set; }
    }
}