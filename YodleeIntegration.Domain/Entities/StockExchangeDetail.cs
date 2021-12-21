using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class StockExchangeDetail : FullAuditedEntity
    {
        public string Symbol { get; set; }

        public string CountryCode { get; set; }

        public string CurrencyCode { get; set; }

        public string ExchangeCode { get; set; }
    }
}