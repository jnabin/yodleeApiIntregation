using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    [Table("YodleeTransactions")]
    public class Transaction : FullAuditedEntity
    {
        public string Date { get; set; }

        public string SourceId { get; set; }

        public string Symbol { get; set; }

        public string CusIpNumber { get; set; }

        public int HighLevelCategoryId { get; set; }

        public int DetailCategoryId { get; set; }

        public Description Description { get; set; }

        public virtual List<Intermediary> Intermediaries { get; set; }

        public string Memo { get; set; }

        public string SettleDate { get; set; }

        public string Type { get; set; }

        public string BaseType { get; set; }

        public string CategorySource { get; set; }

        public Principal Principal { get; set; }

        public string LastUpdated { get; set; }

        public RunningBalance Interest { get; set; }

        public RunningBalance Price { get; set; }

        public RunningBalance Commission { get; set; }

        public long YodleeTransactionId { get; set; }

        public RunningBalance Amount { get; set; }

        public string CheckNumber { get; set; }

        public int Quantity { get; set; }

        public string Valoren { get; set; }

        public bool IsManual { get; set; }

        public Merchant Merchant { get; set; }

        public string SeDol { get; set; }

        public string TransactionDate { get; set; }

        public string CategoryType { get; set; }

        public int AccountId { get; set; }

        public string CreatedDate { get; set; }

        public string SourceType { get; set; }

        public string Container { get; set; }

        public string PostDate { get; set; }

        public int ParentCategoryId { get; set; }

        public string SubType { get; set; }
        public string Category { get; set; }

        public RunningBalance RunningBalance { get; set; }
        public int CategoryId { get; set; }

        public string HoldingDescription { get; set; }

        public string Isin { get; set; }

        public string Status { get; set; }
    }
}