using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class Security : FullAuditedEntity
    {
        public List<StockExchangeDetail> StockExchangeDetails { get; set; }

        public int IssueTypeMultiplier { get; set; }

        public bool StateTaxable { get; set; }

        public string CallDate { get; set; }

        public bool CdscFundFlag { get; set; }

        public string Cusip { get; set; }

        public bool FederalTaxable { get; set; }

        public string SAndPRating { get; set; }

        public string ShareClass { get; set; }

        public bool IsEnvestnetDummySecurity { get; set; }

        public string Description { get; set; }

        public int MinimumPurchase { get; set; }

        public string Type { get; set; }

        public string FirstCouponDate { get; set; }

        public int Frequency { get; set; }

        public string AccrualMethod { get; set; }

        public string IncomeCurrency { get; set; }

        public string MaturityDate { get; set; }

        public int CallPrice { get; set; }

        [JsonProperty("id")]
        public int YodleeSecurityId { get; set; }

        public string IssueDate { get; set; }

        public string Sector { get; set; }

        public int AgencyFactor { get; set; }

        public int InterestRate { get; set; }

        public string LastModifiedDate { get; set; }

        public string GicsSector { get; set; }

        public bool ClosedFlag { get; set; }

        public string Sedol { get; set; }

        public string SubSector { get; set; }

        public string LastCouponDate { get; set; }

        public bool IsSyntheticSecurity { get; set; }

        public string TradeCurrencyCode { get; set; }

        public bool IsDummySecurity { get; set; }

        public string MoodyRating { get; set; }

        public string Style { get; set; }

        public string FirmEligible { get; set; }

        public string FundFamily { get; set; }

        public string Isin { get; set; }
    }
}