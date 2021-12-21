using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    [Table("YodleeAccounts")]
    public class Account : FullAuditedEntity
    {
        public string Container { get; set; }
        public int ProviderAccountId { get; set; }
        public string AccountName { get; set; }
        public string AccountStatus { get; set; }
        public string AccountNumber { get; set; }
        public string AggregationSource { get; set; }
        public bool IsAsset { get; set; }
        public RunningBalance Balance { get; set; }

        [JsonPropertyName("id")]
        public int YodleeAccountId { get; set; }
        public bool IncludeInNetWorth { get; set; }
        public string ProviderId { get; set; }
        public string ProviderName { get; set; }
        public bool IsManual { get; set; }
        public RunningBalance CurrentBalance { get; set; }
        public string AccountType { get; set; }
        public string DisplayedName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdated { get; set; }
        public List<BankTransferCode> BankTransferCode { get; set; }
        public List<DataSet> DataSet { get; set; }
        public RunningBalance AvailableBalance { get; set; }
        public string Classification { get; set; }
        public string DueDate { get; set; }
        public string InterestRateType { get; set; }
        public string LastPaymentDate { get; set; }
        public string MaturityDate { get; set; }
        public RunningBalance OriginalLoanAmount { get; set; }
        public RunningBalance PrincipalBalance { get; set; }
        public string OriginationDate { get; set; }
        public string Frequency { get; set; }
        public RunningBalance Cash { get; set; }
        public RunningBalance MarginBalance { get; set; }
        public RunningBalance LastEmployeeContributionAmount { get; set; }
        public string LastEmployeeContributionDate { get; set; }
        public double? CashApr { get; set; }
        public RunningBalance AvailableCash { get; set; }
        public RunningBalance AvailableCredit { get; set; }
        public RunningBalance LastPaymentAmount { get; set; }
        public RunningBalance RunningBalance { get; set; }
        public RunningBalance TotalCashLimit { get; set; }
        public RunningBalance TotalCreditLine { get; set; }
        public RunningBalance AmountDue { get; set; }
        public RunningBalance MinimumAmountDue { get; set; }
        public double? AnnualPercentageYield { get; set; }
        public double? InterestRate { get; set; }
        public double? Apr { get; set; }
    }
}