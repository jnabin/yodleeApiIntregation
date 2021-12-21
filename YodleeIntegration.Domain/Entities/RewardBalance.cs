using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class RewardBalance : FullAuditedEntity
  {
        public string ExpiryDate { get; set; }
        public string BalanceToReward { get; set; }
        public string BalanceType { get; set; }
        public int Balance { get; set; }
        public string Description { get; set; }
        public string BalanceToLevel { get; set; }
        public string Units { get; set; }
    }
}