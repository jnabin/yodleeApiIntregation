using System.Collections.Generic;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class NetworthDetail : FullAuditedEntity
    {
        public int Amount { get; set; }
        public string Currency { get; set; }
        public string Date { get; set; }
        public RunningBalance Liability { get; set; }
        public List<HistoricalBalance> HistoricalBalances { get; set; }
        public RunningBalance Networth { get; set; }
        public RunningBalance Asset { get; set; }
    }
}