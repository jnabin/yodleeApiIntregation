using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class TransactionsLink : FullAuditedEntity
    {
        public string Transactions { get; set; }
    }
}