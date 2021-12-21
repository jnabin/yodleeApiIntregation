using System.Collections.Generic;
using Newtonsoft.Json;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class DataExtractAccount : FullAuditedEntity
    {
        public RunningBalance AvailableCash { get; set; }
        public bool IncludeInNetWorth { get; set; }
        public RunningBalance MoneyMarketBalance { get; set; }
        public string EnrollmentDate { get; set; }
        public string EstimatedDate { get; set; }
        public string Memo { get; set; }
        public string Guarantor { get; set; }
        public RunningBalance InterestPaidLastYear { get; set; }
        public string LastUpdated { get; set; }
        public RunningBalance Balance { get; set; }
        public string HomeInsuranceType { get; set; }

        [JsonProperty("id")]
        public long YodleeDataExtractsAccountId { get; set; }
        public RunningBalance Cash { get; set; }
        public RunningBalance TotalCreditLine { get; set; }
        public string ProviderName { get; set; }
        public string ValuationType { get; set; }
        public RunningBalance MarginBalance { get; set; }
        public int Apr { get; set; }
        public RunningBalance AvailableCredit { get; set; }
        public RunningBalance CurrentBalance { get; set; }
        public bool IsManual { get; set; }
        public RunningBalance EscrowBalance { get; set; }
        public string NextLevel { get; set; }
        public string Classification { get; set; }
        public RunningBalance LoanPayoffAmount { get; set; }
        public string InterestRateType { get; set; }
        public string LoanPayByDate { get; set; }
        public RunningBalance FaceAmount { get; set; }
        public string PolicyFromDate { get; set; }
        public string PremiumPaymentTerm { get; set; }
        public string PolicyTerm { get; set; }
        public string RepaymentPlanType { get; set; }
        public RunningBalance AvailableBalance { get; set; }
        public string AccountStatus { get; set; }
        public string LifeInsuranceType { get; set; }
        public RunningBalance Premium { get; set; }
        public string AggregationSource { get; set; }
        public bool IsDeleted { get; set; }
        public RunningBalance OverDraftLimit { get; set; }
        public string Nickname { get; set; }
        public string Term { get; set; }
        public int InterestRate { get; set; }
        public RunningBalance DeathBenefit { get; set; }
        public Address Address { get; set; }
        public RunningBalance CashValue { get; set; }
        public RunningBalance _401kLoan { get; set; }
        public RunningBalance HomeValue { get; set; }
        public string AccountNumber { get; set; }
        public string CreatedDate { get; set; }
        public RunningBalance InterestPaidYTD { get; set; }
        public int ProviderAccountId { get; set; }
        public string Collateral { get; set; }
        public List<DataExtractDataset> Dataset { get; set; }
        public RunningBalance RunningBalance { get; set; }
        public string SourceId { get; set; }
        public string DueDate { get; set; }
        public string Frequency { get; set; }
        public RunningBalance MaturityAmount { get; set; }
        public List<int> AssociatedProviderAccountId { get; set; }
        public bool IsAsset { get; set; }
        public RunningBalance PrincipalBalance { get; set; }
        public RunningBalance TotalCashLimit { get; set; }
        public string MaturityDate { get; set; }
        public RunningBalance MinimumAmountDue { get; set; }
        public int AnnualPercentageYield { get; set; }
        public string AccountType { get; set; }
        public string OriginationDate { get; set; }
        public RunningBalance TotalVestedBalance { get; set; }
        public List<RewardBalance> RewardBalance { get; set; }
        public string SourceAccountStatus { get; set; }
        public int DerivedApr { get; set; }
        public string PolicyEffectiveDate { get; set; }
        public RunningBalance TotalUnvestedBalance { get; set; }
        public RunningBalance AnnuityBalance { get; set; }
        public string AccountName { get; set; }
        public RunningBalance TotalCreditLimit { get; set; }
        public string PolicyStatus { get; set; }
        public RunningBalance ShortBalance { get; set; }
        public string Lender { get; set; }
        public RunningBalance LastEmployeeContributionAmount { get; set; }
        public string ProviderId { get; set; }
        public string LastPaymentDate { get; set; }
        public string PrimaryRewardUnit { get; set; }
        public RunningBalance LastPaymentAmount { get; set; }
        public RunningBalance RemainingBalance { get; set; }
        public string UserClassification { get; set; }
        public List<BankTransferCode> BankTransferCode { get; set; }
        public string ExpirationDate { get; set; }
        public List<Coverage> Coverage { get; set; }
        public int CashApr { get; set; }
        public string OauthMigrationStatus { get; set; }
        public string DisplayedName { get; set; }
        public int SourceProviderAccountId { get; set; }
        public RunningBalance AmountDue { get; set; }
        public string CurrentLevel { get; set; }
        public RunningBalance OriginalLoanAmount { get; set; }
        public string PolicyToDate { get; set; }
        public LoanPayoffDetails LoanPayoffDetails { get; set; }
        public string Container { get; set; }
        public string LastEmployeeContributionDate { get; set; }
        public RunningBalance LastPayment { get; set; }
        public RunningBalance RecurringPayment { get; set; }
    }
}