using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class Holding : FullAuditedEntity
    {
        public string Symbol { get; set; }

        public int ExercisedQuantity { get; set; }

        public string CusipNumber { get; set; }

        public List<AssetClassification> AssetClassification { get; set; }

        public int VestedQuantity { get; set; }

        public string Description { get; set; }

        public RunningBalance UnvestedValue { get; set; }

        public string SecurityStyle { get; set; }

        public RunningBalance VestedValue { get; set; }

        public string OptionType { get; set; }

        public string LastUpdated { get; set; }

        public string MatchStatus { get; set; }

        public string HoldingType { get; set; }

        public string MaturityDate { get; set; }

        public RunningBalance Price { get; set; }

        public string Term { get; set; }

        public int ContractQuantity { get; set; }

        [JsonProperty("id")]
        public int YodleeHoldingId { get; set; }

        public bool IsShort { get; set; }

        public RunningBalance Value { get; set; }

        public string ExpirationDate { get; set; }

        public int InterestRate { get; set; }

        public long Quantity { get; set; }

        public RunningBalance AccruedInterest { get; set; }

        public string GrantDate { get; set; }

        public string Sedol { get; set; }

        public int VestedSharesExercisable { get; set; }

        public RunningBalance Spread { get; set; }

        public int AccountId { get; set; }

        public string EnrichedDescription { get; set; }

        public int CouponRate { get; set; }

        public string CreatedDate { get; set; }
        public RunningBalance AccruedIncome { get; set; }

        public string SecurityType { get; set; }

        public int ProviderAccountId { get; set; }

        public int UnvestedQuantity { get; set; }

        public RunningBalance CostBasis { get; set; }

        public string VestingDate { get; set; }

        public string Isin { get; set; }

        public RunningBalance StrikePrice { get; set; }
    }
}