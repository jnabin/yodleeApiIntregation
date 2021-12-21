using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class ContainerAttribute : FullAuditedEntity
    {
        public Bank BANK { get; set; }

        public CardDetail LOAN { get; set; }

        public CardDetail CREDITCARD { get; set; }

        public CardDetail INVESTMENT { get; set; }

        public CardDetail INSURANCE { get; set; }
    }
}