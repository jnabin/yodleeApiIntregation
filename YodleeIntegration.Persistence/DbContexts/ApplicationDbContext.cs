using Microsoft.EntityFrameworkCore;
using System;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Domain.Model.Authorizations;
using YodleeIntegration.Domain.Model.Configurations;
using YodleeIntegration.Domain.Model.RequestLog;

namespace YodleeIntegration.Persistence.DbContexts
{
    public class ApplicationDbContext : DbContext, IDisposable
    {
        // Add your DbSets here
        public DbSet<YodleeConfiguration> YodleeConfigurations { get; set; }
        public DbSet<YodleeAccessToken> YodleeAccessTokens { get; set; }
        public DbSet<YodleeApiKey> YodleeApiKeys { get; set; }
        public DbSet<RequestLog> RequestLogs { get; set; }
        public DbSet<Statement> Statements { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AddManualAccount> AddManualAccounts { get; set; }
        public DbSet<AddManualResponseAccount> AddManualResponseAccounts { get; set; }
        public DbSet<HistoricalAccount> HistoricalAccounts { get; set; }
        public DbSet<HistoricalBalanceAccount> HistoricalBalanceAccounts { get; set; }
        public DbSet<AccountBalance> AccountBalances { get; set; }
        public DbSet<UpdateAccountDetails> UpdateAccountDetails { get; set; }
        public DbSet<BankTransferCode> BankTransferCodes { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Domain.Entities.Attribute> Attributes { get; set; }
        public DbSet<NotificationEvent> NotificationEvent { get; set; }
        public DbSet<PublicKey> PublicKeys { get; set; }
        public DbSet<DataSet> DataSets { get; set; }
        public DbSet<VerifiedAccount> VerifiedAccounts { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<AccessTokens> AccessTokens { get; set; }
        public DbSet<Verifications> VerificationStatuses { get; set; }
        public DbSet<VerificationAccount> VerificationAccounts { get; set; }
        public DbSet<Data> Datas { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<UserData> UserDatas { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<DataExtractAccount> DataExtractAccounts { get; set; }
        public DbSet<YodleeAmount> YodleeAmounts { get; set; }
        public DbSet<DataExtractDataset> DataExtractDatasets { get; set; }
        public DbSet<LoanPayoffDetails> LoanPayoffDetails { get; set; }
        public DbSet<DataExtractProviderAccount> DataExtractProviderAccounts { get; set; }
        public DbSet<RewardBalance> RewardBalances { get; set; }
        public DbSet<DataExtractUser> DataExtractUsers { get; set; }
        public DbSet<DataExtractUserData> DataExtractUserDatas { get; set; }
        public DbSet<Summary> Summarys { get; set; }
        public DbSet<SummaryDetails> SummaryDetails { get; set; }
        public DbSet<HoldingsAccount> HoldingsAccounts { get; set; }
        public DbSet<HoldingsSummary> HoldingsSummarys { get; set; }
        public DbSet<NetworthDetail> Networths { get; set; }
        public DbSet<TransactionsLink> TransactionsLinks { get; set; }
        public DbSet<TransactionsSummary> TransactionsSummarys { get; set; }
        public DbSet<AssetClassification> AssetClassifications { get; set; }
        public DbSet<AssetClassificationList> AssetClassificationLists { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Capability> Capabilities { get; set; }
        public DbSet<CardDetail> CardDetails { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContainerAttribute> ContainerAttributes { get; set; }
        public DbSet<Coordinates> Coordinates { get; set; }
        public DbSet<Coverage> Coverages { get; set; }
        public DbSet<Description> Descriptions { get; set; }
        public DbSet<ProviderAccount> ProviderAccounts { get; set; }
        public DbSet<DetailCategory> DetailCategories { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<FullAccountNumberList> FullAccountNumberLists { get; set; }
        public DbSet<HistoricalBalance> HistoricalBalances { get; set; }
        public DbSet<Holder> Holders { get; set; }
        public DbSet<Holding> Holdings { get; set; }
        public DbSet<Identifier> Identifiers { get; set; }
        public DbSet<Intermediary> Intermediaries { get; set; }
        public DbSet<LoginForm> LoginForms { get; set; }
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<Name> Names { get; set; }
        public DbSet<Preference> Preferences { get; set; }
        public DbSet<Principal> Principals { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<ProviderCount> ProviderCounts { get; set; }
        public DbSet<ProvidersDataset> ProvidersDatasets { get; set; }
        public DbSet<Row> Rows { get; set; }
        public DbSet<Rule> Rules { get; set; }
        public DbSet<RuleClaus> RuleClaus { get; set; }
        public DbSet<RuleClause> RuleClauses { get; set; }
        public DbSet<RunningBalance> RunningBalances { get; set; }
        public DbSet<SecurityHolding> SecurityHoldings { get; set; }
        public DbSet<StockExchangeDetail> StockExchangeDetails { get; set; }
        public DbSet<Total> Totals { get; set; }
        public DbSet<TransactionCategorizationRule> TransactionCategorizationRules { get; set; }
        public DbSet<TransactionCategory> TransactionCategories { get; set; }
        public DbSet<TransactionCriteria> TransactionCriterias { get; set; }
        public DbSet<UpdateProviderAccountAttribute> UpdateProviderAccountAttributes { get; set; }
        public DbSet<UpdateProviderAccountDataSet> UpdateProviderAccountDataSets { get; set; }
        public DbSet<UpdateProviderAccountField> UpdateProviderAccountFields { get; set; }
        public DbSet<VerifyAccountDTO> VerifyAccountDTOs { get; set; }
        public DbSet<VerifyAccountTransactionCriteria> VerifyAccountTransactionCriterias { get; set; }
        public DbSet<ProviderAccountProfile> UserProfileDetailProviderAccounts { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<HoldingType> HoldingTypes { get; set; }

        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public new void Dispose()
        {
            base.Dispose();
        }
    }
}