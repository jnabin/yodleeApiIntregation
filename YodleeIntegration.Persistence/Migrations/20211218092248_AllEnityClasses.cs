using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace YodleeIntegration.Infrastructure.Migrations
{
    public partial class AllEnityClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountBalances_RunningBalances_AvailableBalanceId",
                table: "AccountBalances");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountBalances_RunningBalances_BalanceId",
                table: "AccountBalances");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountBalances_RunningBalances_CashId",
                table: "AccountBalances");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountBalances_RunningBalances_CurrentBalanceId",
                table: "AccountBalances");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountBalances_RunningBalances_TotalBalanceId",
                table: "AccountBalances");

            migrationBuilder.DropForeignKey(
                name: "FK_AddManualAccounts_Addresses_AddressId",
                table: "AddManualAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_AddManualAccounts_RunningBalances_AmountDueId",
                table: "AddManualAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_AddManualAccounts_RunningBalances_BalanceId",
                table: "AddManualAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_AddManualAccounts_RunningBalances_HomeValueId",
                table: "AddManualAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Profiles_ProfileId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetClassifications_Holdings_HoldingId",
                table: "AssetClassifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Attributes_ContainerAttributes_ContainerAttributesId",
                table: "Attributes");

            migrationBuilder.DropForeignKey(
                name: "FK_Attributes_ProvidersDatasets_ProvidersDatasetId",
                table: "Attributes");

            migrationBuilder.DropForeignKey(
                name: "FK_BankTransferCodes_DataExtractAccounts_DataExtractAccountId",
                table: "BankTransferCodes");

            migrationBuilder.DropForeignKey(
                name: "FK_BankTransferCodes_YodleeAccounts_AccountId",
                table: "BankTransferCodes");

            migrationBuilder.DropForeignKey(
                name: "FK_BankTransferCodes_YodleeVerifiedAccount_VerifiedAccountId",
                table: "BankTransferCodes");

            migrationBuilder.DropForeignKey(
                name: "FK_Capabilities_Providers_ProviderId",
                table: "Capabilities");

            migrationBuilder.DropForeignKey(
                name: "FK_ContainerAttributes_Banks_BANKId",
                table: "ContainerAttributes");

            migrationBuilder.DropForeignKey(
                name: "FK_ContainerAttributes_CardDetails_CREDITCARDId",
                table: "ContainerAttributes");

            migrationBuilder.DropForeignKey(
                name: "FK_ContainerAttributes_CardDetails_INSURANCEId",
                table: "ContainerAttributes");

            migrationBuilder.DropForeignKey(
                name: "FK_ContainerAttributes_CardDetails_INVESTMENTId",
                table: "ContainerAttributes");

            migrationBuilder.DropForeignKey(
                name: "FK_ContainerAttributes_CardDetails_LOANId",
                table: "ContainerAttributes");

            migrationBuilder.DropForeignKey(
                name: "FK_Coverages_DataExtractAccounts_DataExtractAccountId",
                table: "Coverages");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_Addresses_AddressId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_LoanPayoffDetails_LoanPayoffDetailsId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances__401kLoanId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_AmountDueId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_AnnuityBalanceId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_AvailableBalanceId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_AvailableCashId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_AvailableCreditId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_BalanceId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_CashId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_CashValueId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_CurrentBalanceId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_DeathBenefitId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_EscrowBalanceId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_FaceAmountId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_HomeValueId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_InterestPaidLastYearId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_InterestPaidYTDId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_LastPaymentAmountId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_LastPaymentId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_LoanPayoffAmountId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_MarginBalanceId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_MaturityAmountId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_MinimumAmountDueId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_MoneyMarketBalanceId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_OriginalLoanAmountId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_OverDraftLimitId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_PremiumId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_PrincipalBalanceId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_RecurringPaymentId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_RemainingBalanceId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_RunningBalanceId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_ShortBalanceId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_TotalCashLimitId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_TotalCreditLimitId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_TotalCreditLineId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_TotalUnvestedBalanceId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_TotalVestedBalanceId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractDatasets_DataExtractAccounts_DataExtractAccountId",
                table: "DataExtractDatasets");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractUserDatas_DataExtractUsers_UserId",
                table: "DataExtractUserDatas");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractUserDatas_Datas_DataId",
                table: "DataExtractUserDatas");

            migrationBuilder.DropForeignKey(
                name: "FK_DataSets_ProviderAccounts_ProviderAccountId",
                table: "DataSets");

            migrationBuilder.DropForeignKey(
                name: "FK_DataSets_YodleeAccounts_AccountId",
                table: "DataSets");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailCategories_TransactionCategories_TransactionCategoryId",
                table: "DetailCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Emails_Profiles_ProfileId",
                table: "Emails");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Datas_dataId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Fields_Rows_RowId",
                table: "Fields");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoricalBalanceAccounts_RunningBalances_BalanceId",
                table: "HistoricalBalanceAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoricalBalances_Networths_NetworthDetailId",
                table: "HistoricalBalances");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoricalBalances_RunningBalances_BalanceId",
                table: "HistoricalBalances");

            migrationBuilder.DropForeignKey(
                name: "FK_Holders_Names_NameId",
                table: "Holders");

            migrationBuilder.DropForeignKey(
                name: "FK_Holders_YodleeVerifiedAccount_VerifiedAccountId",
                table: "Holders");

            migrationBuilder.DropForeignKey(
                name: "FK_Holdings_DataExtractUserDatas_DataExtractUserDataId",
                table: "Holdings");

            migrationBuilder.DropForeignKey(
                name: "FK_Holdings_HoldingsSummarys_HoldingsSummaryId",
                table: "Holdings");

            migrationBuilder.DropForeignKey(
                name: "FK_Holdings_RunningBalances_AccruedIncomeId",
                table: "Holdings");

            migrationBuilder.DropForeignKey(
                name: "FK_Holdings_RunningBalances_AccruedInterestId",
                table: "Holdings");

            migrationBuilder.DropForeignKey(
                name: "FK_Holdings_RunningBalances_CostBasisId",
                table: "Holdings");

            migrationBuilder.DropForeignKey(
                name: "FK_Holdings_RunningBalances_PriceId",
                table: "Holdings");

            migrationBuilder.DropForeignKey(
                name: "FK_Holdings_RunningBalances_SpreadId",
                table: "Holdings");

            migrationBuilder.DropForeignKey(
                name: "FK_Holdings_RunningBalances_StrikePriceId",
                table: "Holdings");

            migrationBuilder.DropForeignKey(
                name: "FK_Holdings_RunningBalances_UnvestedValueId",
                table: "Holdings");

            migrationBuilder.DropForeignKey(
                name: "FK_Holdings_RunningBalances_ValueId",
                table: "Holdings");

            migrationBuilder.DropForeignKey(
                name: "FK_Holdings_RunningBalances_VestedValueId",
                table: "Holdings");

            migrationBuilder.DropForeignKey(
                name: "FK_HoldingsAccounts_HoldingsSummarys_HoldingsSummaryId",
                table: "HoldingsAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_HoldingsAccounts_RunningBalances_ValueId",
                table: "HoldingsAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_HoldingsSummarys_RunningBalances_ValueId",
                table: "HoldingsSummarys");

            migrationBuilder.DropForeignKey(
                name: "FK_Identifiers_Holders_HolderId",
                table: "Identifiers");

            migrationBuilder.DropForeignKey(
                name: "FK_Identifiers_Profiles_ProfileId",
                table: "Identifiers");

            migrationBuilder.DropForeignKey(
                name: "FK_Links_UserDatas_UserDataId",
                table: "Links");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanPayoffDetails_RunningBalances_OutstandingBalanceId",
                table: "LoanPayoffDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanPayoffDetails_RunningBalances_PayoffAmountId",
                table: "LoanPayoffDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_LoginForms_ProviderAccounts_ProviderAccountId",
                table: "LoginForms");

            migrationBuilder.DropForeignKey(
                name: "FK_LoginForms_Providers_ProviderId",
                table: "LoginForms");

            migrationBuilder.DropForeignKey(
                name: "FK_Merchants_Addresses_AddressId",
                table: "Merchants");

            migrationBuilder.DropForeignKey(
                name: "FK_Merchants_Contacts_ContactId",
                table: "Merchants");

            migrationBuilder.DropForeignKey(
                name: "FK_Merchants_Coordinates_CoordinatesId",
                table: "Merchants");

            migrationBuilder.DropForeignKey(
                name: "FK_Networths_RunningBalances_AssetId",
                table: "Networths");

            migrationBuilder.DropForeignKey(
                name: "FK_Networths_RunningBalances_LiabilityId",
                table: "Networths");

            migrationBuilder.DropForeignKey(
                name: "FK_Networths_RunningBalances_NetworthId",
                table: "Networths");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumbers_Profiles_ProfileId",
                table: "PhoneNumbers");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Names_NameId",
                table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_ProviderAccounts_ProviderAccountPreference_PreferencesId",
                table: "ProviderAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProviderCounts_Totals_TotalId",
                table: "ProviderCounts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProvidersDatasets_Providers_ProviderId",
                table: "ProvidersDatasets");

            migrationBuilder.DropForeignKey(
                name: "FK_RewardBalances_DataExtractAccounts_DataExtractAccountId",
                table: "RewardBalances");

            migrationBuilder.DropForeignKey(
                name: "FK_Rows_LoginForms_LoginFormId",
                table: "Rows");

            migrationBuilder.DropForeignKey(
                name: "FK_RuleClauses_Rules_RuleId",
                table: "RuleClauses");

            migrationBuilder.DropForeignKey(
                name: "FK_SecurityHoldings_Security_SecurityId",
                table: "SecurityHoldings");

            migrationBuilder.DropForeignKey(
                name: "FK_StockExchangeDetails_Security_SecurityId",
                table: "StockExchangeDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SummaryDetails_RunningBalances_CreditTotalId",
                table: "SummaryDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SummaryDetails_RunningBalances_DebitTotalId",
                table: "SummaryDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SummaryDetails_Summarys_SummaryId",
                table: "SummaryDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Summarys_RunningBalances_CreditTotalId",
                table: "Summarys");

            migrationBuilder.DropForeignKey(
                name: "FK_Summarys_RunningBalances_DebitTotalId",
                table: "Summarys");

            migrationBuilder.DropForeignKey(
                name: "FK_Summarys_TransactionsLinks_LinksId",
                table: "Summarys");

            migrationBuilder.DropForeignKey(
                name: "FK_Summarys_TransactionsSummarys_TransactionsSummaryId",
                table: "Summarys");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionCriterias_VerifyAccountDTOs_VerifyAccountDTOId",
                table: "TransactionCriterias");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionsSummarys_RunningBalances_CreditTotalId",
                table: "TransactionsSummarys");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionsSummarys_RunningBalances_DebitTotalId",
                table: "TransactionsSummarys");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionsSummarys_TransactionsLinks_LinksId",
                table: "TransactionsSummarys");

            migrationBuilder.DropForeignKey(
                name: "FK_UpdateAccountDetails_Addresses_AddressId",
                table: "UpdateAccountDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_UpdateAccountDetails_RunningBalances_AmountDueId",
                table: "UpdateAccountDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_UpdateAccountDetails_RunningBalances_BalanceId",
                table: "UpdateAccountDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_UpdateAccountDetails_RunningBalances_HomeValueId",
                table: "UpdateAccountDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDatas_DataExtractUsers_UserId",
                table: "UserDatas");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_AmountDueId",
                table: "YodleeAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_AvailableBalanceId",
                table: "YodleeAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_AvailableCashId",
                table: "YodleeAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_AvailableCreditId",
                table: "YodleeAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_BalanceId",
                table: "YodleeAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_CashId",
                table: "YodleeAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_CurrentBalanceId",
                table: "YodleeAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_LastPaymentAmountId",
                table: "YodleeAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_MarginBalanceId",
                table: "YodleeAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_MinimumAmountDueId",
                table: "YodleeAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_OriginalLoanAmountId",
                table: "YodleeAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_PrincipalBalanceId",
                table: "YodleeAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_RunningBalanceId",
                table: "YodleeAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_TotalCashLimitId",
                table: "YodleeAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_TotalCreditLineId",
                table: "YodleeAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeAccounts_VerifyAccountDTOs_VerifyAccountDTOId",
                table: "YodleeAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeAmounts_Coverages_CoverageId",
                table: "YodleeAmounts");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeAmounts_RunningBalances_coverId",
                table: "YodleeAmounts");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeAmounts_RunningBalances_MetId",
                table: "YodleeAmounts");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeIntermediary_YodleeTransactions_TransactionId",
                table: "YodleeIntermediary");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeStatements_RunningBalances_AmountDueId",
                table: "YodleeStatements");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeStatements_RunningBalances_CashAdvanceId",
                table: "YodleeStatements");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeStatements_RunningBalances_InterestAmountId",
                table: "YodleeStatements");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeStatements_RunningBalances_LastPaymentAmountId",
                table: "YodleeStatements");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeStatements_RunningBalances_LoanBalanceId",
                table: "YodleeStatements");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeStatements_RunningBalances_MinimumPaymentId",
                table: "YodleeStatements");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeStatements_RunningBalances_NewChargesId",
                table: "YodleeStatements");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeStatements_RunningBalances_PrincipalAmountId",
                table: "YodleeStatements");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeTransactions_Descriptions_DescriptionId",
                table: "YodleeTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeTransactions_Merchants_MerchantId",
                table: "YodleeTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeTransactions_Principals_PrincipalId",
                table: "YodleeTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeTransactions_RunningBalances_AmountId",
                table: "YodleeTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeTransactions_RunningBalances_CommissionId",
                table: "YodleeTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeTransactions_RunningBalances_InterestId",
                table: "YodleeTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeTransactions_RunningBalances_PriceId",
                table: "YodleeTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeTransactions_RunningBalances_RunningBalanceId",
                table: "YodleeTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeUser_Addresses_AddressId",
                table: "YodleeUser");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeUser_Names_NameId",
                table: "YodleeUser");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeUser_Preferences_PreferencesId",
                table: "YodleeUser");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeVerifiedAccount_RunningBalances_AvailableBalanceId",
                table: "YodleeVerifiedAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeVerifiedAccount_RunningBalances_BalanceId",
                table: "YodleeVerifiedAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeVerifiedAccount_RunningBalances_CashId",
                table: "YodleeVerifiedAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeVerifiedAccount_RunningBalances_CurrentBalanceId",
                table: "YodleeVerifiedAccount");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "YodleeWrapperIntegrationRequestLog",
                newName: "EntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "YodleeWrapperIntegrationConfigurations",
                newName: "EntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "YodleeWrapperIntegrationAuthTokens",
                newName: "EntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "YodleeWrapperIntegrationApiKeys",
                newName: "EntityId");

            migrationBuilder.RenameColumn(
                name: "FullAccountNumberListId",
                table: "YodleeVerifiedAccount",
                newName: "FullAccountNumberListEntityId");

            migrationBuilder.RenameColumn(
                name: "CurrentBalanceId",
                table: "YodleeVerifiedAccount",
                newName: "CurrentBalanceEntityId");

            migrationBuilder.RenameColumn(
                name: "CashId",
                table: "YodleeVerifiedAccount",
                newName: "CashEntityId");

            migrationBuilder.RenameColumn(
                name: "BalanceId",
                table: "YodleeVerifiedAccount",
                newName: "BalanceEntityId");

            migrationBuilder.RenameColumn(
                name: "AvailableBalanceId",
                table: "YodleeVerifiedAccount",
                newName: "AvailableBalanceEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "YodleeVerifiedAccount",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeVerifiedAccount_FullAccountNumberListId",
                table: "YodleeVerifiedAccount",
                newName: "IX_YodleeVerifiedAccount_FullAccountNumberListEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeVerifiedAccount_CurrentBalanceId",
                table: "YodleeVerifiedAccount",
                newName: "IX_YodleeVerifiedAccount_CurrentBalanceEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeVerifiedAccount_CashId",
                table: "YodleeVerifiedAccount",
                newName: "IX_YodleeVerifiedAccount_CashEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeVerifiedAccount_BalanceId",
                table: "YodleeVerifiedAccount",
                newName: "IX_YodleeVerifiedAccount_BalanceEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeVerifiedAccount_AvailableBalanceId",
                table: "YodleeVerifiedAccount",
                newName: "IX_YodleeVerifiedAccount_AvailableBalanceEntityId");

            migrationBuilder.RenameColumn(
                name: "IdType",
                table: "YodleeVerificationAccount",
                newName: "AccountType");

            migrationBuilder.RenameColumn(
                name: "BankTransferCodeId",
                table: "YodleeVerificationAccount",
                newName: "BankTransferCodeEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "YodleeVerificationAccount",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeVerificationAccount_BankTransferCodeId",
                table: "YodleeVerificationAccount",
                newName: "IX_YodleeVerificationAccount_BankTransferCodeEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "YodleeVerification",
                newName: "EntityId");

            migrationBuilder.RenameColumn(
                name: "PreferencesId",
                table: "YodleeUser",
                newName: "PreferencesEntityId");

            migrationBuilder.RenameColumn(
                name: "NameId",
                table: "YodleeUser",
                newName: "NameEntityId");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "YodleeUser",
                newName: "AddressEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "YodleeUser",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeUser_PreferencesId",
                table: "YodleeUser",
                newName: "IX_YodleeUser_PreferencesEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeUser_NameId",
                table: "YodleeUser",
                newName: "IX_YodleeUser_NameEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeUser_AddressId",
                table: "YodleeUser",
                newName: "IX_YodleeUser_AddressEntityId");

            migrationBuilder.RenameColumn(
                name: "TransactionCriteriaId",
                table: "YodleeTransactions",
                newName: "TransactionCriteriaEntityId");

            migrationBuilder.RenameColumn(
                name: "RunningBalanceId",
                table: "YodleeTransactions",
                newName: "RunningBalanceEntityId");

            migrationBuilder.RenameColumn(
                name: "PrincipalId",
                table: "YodleeTransactions",
                newName: "PrincipalEntityId");

            migrationBuilder.RenameColumn(
                name: "PriceId",
                table: "YodleeTransactions",
                newName: "PriceEntityId");

            migrationBuilder.RenameColumn(
                name: "MerchantId",
                table: "YodleeTransactions",
                newName: "MerchantEntityId");

            migrationBuilder.RenameColumn(
                name: "InterestId",
                table: "YodleeTransactions",
                newName: "InterestEntityId");

            migrationBuilder.RenameColumn(
                name: "DescriptionId",
                table: "YodleeTransactions",
                newName: "DescriptionEntityId");

            migrationBuilder.RenameColumn(
                name: "DataExtractUserDataId",
                table: "YodleeTransactions",
                newName: "DataExtractUserDataEntityId");

            migrationBuilder.RenameColumn(
                name: "CommissionId",
                table: "YodleeTransactions",
                newName: "CommissionEntityId");

            migrationBuilder.RenameColumn(
                name: "AmountId",
                table: "YodleeTransactions",
                newName: "AmountEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "YodleeTransactions",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeTransactions_TransactionCriteriaId",
                table: "YodleeTransactions",
                newName: "IX_YodleeTransactions_TransactionCriteriaEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeTransactions_RunningBalanceId",
                table: "YodleeTransactions",
                newName: "IX_YodleeTransactions_RunningBalanceEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeTransactions_PrincipalId",
                table: "YodleeTransactions",
                newName: "IX_YodleeTransactions_PrincipalEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeTransactions_PriceId",
                table: "YodleeTransactions",
                newName: "IX_YodleeTransactions_PriceEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeTransactions_MerchantId",
                table: "YodleeTransactions",
                newName: "IX_YodleeTransactions_MerchantEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeTransactions_InterestId",
                table: "YodleeTransactions",
                newName: "IX_YodleeTransactions_InterestEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeTransactions_DescriptionId",
                table: "YodleeTransactions",
                newName: "IX_YodleeTransactions_DescriptionEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeTransactions_DataExtractUserDataId",
                table: "YodleeTransactions",
                newName: "IX_YodleeTransactions_DataExtractUserDataEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeTransactions_CommissionId",
                table: "YodleeTransactions",
                newName: "IX_YodleeTransactions_CommissionEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeTransactions_AmountId",
                table: "YodleeTransactions",
                newName: "IX_YodleeTransactions_AmountEntityId");

            migrationBuilder.RenameColumn(
                name: "PrincipalAmountId",
                table: "YodleeStatements",
                newName: "PrincipalAmountEntityId");

            migrationBuilder.RenameColumn(
                name: "NewChargesId",
                table: "YodleeStatements",
                newName: "NewChargesEntityId");

            migrationBuilder.RenameColumn(
                name: "MinimumPaymentId",
                table: "YodleeStatements",
                newName: "MinimumPaymentEntityId");

            migrationBuilder.RenameColumn(
                name: "LoanBalanceId",
                table: "YodleeStatements",
                newName: "LoanBalanceEntityId");

            migrationBuilder.RenameColumn(
                name: "LastPaymentAmountId",
                table: "YodleeStatements",
                newName: "LastPaymentAmountEntityId");

            migrationBuilder.RenameColumn(
                name: "InterestAmountId",
                table: "YodleeStatements",
                newName: "InterestAmountEntityId");

            migrationBuilder.RenameColumn(
                name: "CashAdvanceId",
                table: "YodleeStatements",
                newName: "CashAdvanceEntityId");

            migrationBuilder.RenameColumn(
                name: "AmountDueId",
                table: "YodleeStatements",
                newName: "AmountDueEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "YodleeStatements",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeStatements_PrincipalAmountId",
                table: "YodleeStatements",
                newName: "IX_YodleeStatements_PrincipalAmountEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeStatements_NewChargesId",
                table: "YodleeStatements",
                newName: "IX_YodleeStatements_NewChargesEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeStatements_MinimumPaymentId",
                table: "YodleeStatements",
                newName: "IX_YodleeStatements_MinimumPaymentEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeStatements_LoanBalanceId",
                table: "YodleeStatements",
                newName: "IX_YodleeStatements_LoanBalanceEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeStatements_LastPaymentAmountId",
                table: "YodleeStatements",
                newName: "IX_YodleeStatements_LastPaymentAmountEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeStatements_InterestAmountId",
                table: "YodleeStatements",
                newName: "IX_YodleeStatements_InterestAmountEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeStatements_CashAdvanceId",
                table: "YodleeStatements",
                newName: "IX_YodleeStatements_CashAdvanceEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeStatements_AmountDueId",
                table: "YodleeStatements",
                newName: "IX_YodleeStatements_AmountDueEntityId");

            migrationBuilder.RenameColumn(
                name: "TransactionCategorizationRuleId",
                table: "YodleeRuleClaus",
                newName: "TransactionCategorizationRuleEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "YodleeRuleClaus",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeRuleClaus_TransactionCategorizationRuleId",
                table: "YodleeRuleClaus",
                newName: "IX_YodleeRuleClaus_TransactionCategorizationRuleEntityId");

            migrationBuilder.RenameColumn(
                name: "TransactionId",
                table: "YodleeIntermediary",
                newName: "TransactionEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "YodleeIntermediary",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeIntermediary_TransactionId",
                table: "YodleeIntermediary",
                newName: "IX_YodleeIntermediary_TransactionEntityId");

            migrationBuilder.RenameColumn(
                name: "coverId",
                table: "YodleeAmounts",
                newName: "coverEntityId");

            migrationBuilder.RenameColumn(
                name: "MetId",
                table: "YodleeAmounts",
                newName: "MetEntityId");

            migrationBuilder.RenameColumn(
                name: "CoverageId",
                table: "YodleeAmounts",
                newName: "CoverageEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "YodleeAmounts",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeAmounts_MetId",
                table: "YodleeAmounts",
                newName: "IX_YodleeAmounts_MetEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeAmounts_coverId",
                table: "YodleeAmounts",
                newName: "IX_YodleeAmounts_coverEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeAmounts_CoverageId",
                table: "YodleeAmounts",
                newName: "IX_YodleeAmounts_CoverageEntityId");

            migrationBuilder.RenameColumn(
                name: "VerifyAccountDTOId",
                table: "YodleeAccounts",
                newName: "VerifyAccountDTOEntityId");

            migrationBuilder.RenameColumn(
                name: "TotalCreditLineId",
                table: "YodleeAccounts",
                newName: "TotalCreditLineEntityId");

            migrationBuilder.RenameColumn(
                name: "TotalCashLimitId",
                table: "YodleeAccounts",
                newName: "TotalCashLimitEntityId");

            migrationBuilder.RenameColumn(
                name: "RunningBalanceId",
                table: "YodleeAccounts",
                newName: "RunningBalanceEntityId");

            migrationBuilder.RenameColumn(
                name: "PrincipalBalanceId",
                table: "YodleeAccounts",
                newName: "PrincipalBalanceEntityId");

            migrationBuilder.RenameColumn(
                name: "OriginalLoanAmountId",
                table: "YodleeAccounts",
                newName: "OriginalLoanAmountEntityId");

            migrationBuilder.RenameColumn(
                name: "MinimumAmountDueId",
                table: "YodleeAccounts",
                newName: "MinimumAmountDueEntityId");

            migrationBuilder.RenameColumn(
                name: "MarginBalanceId",
                table: "YodleeAccounts",
                newName: "MarginBalanceEntityId");

            migrationBuilder.RenameColumn(
                name: "LastPaymentAmountId",
                table: "YodleeAccounts",
                newName: "LastPaymentAmountEntityId");

            migrationBuilder.RenameColumn(
                name: "LastEmployeeContributionAmountId",
                table: "YodleeAccounts",
                newName: "LastEmployeeContributionAmountEntityId");

            migrationBuilder.RenameColumn(
                name: "CurrentBalanceId",
                table: "YodleeAccounts",
                newName: "CurrentBalanceEntityId");

            migrationBuilder.RenameColumn(
                name: "CashId",
                table: "YodleeAccounts",
                newName: "CashEntityId");

            migrationBuilder.RenameColumn(
                name: "BalanceId",
                table: "YodleeAccounts",
                newName: "BalanceEntityId");

            migrationBuilder.RenameColumn(
                name: "AvailableCreditId",
                table: "YodleeAccounts",
                newName: "AvailableCreditEntityId");

            migrationBuilder.RenameColumn(
                name: "AvailableCashId",
                table: "YodleeAccounts",
                newName: "AvailableCashEntityId");

            migrationBuilder.RenameColumn(
                name: "AvailableBalanceId",
                table: "YodleeAccounts",
                newName: "AvailableBalanceEntityId");

            migrationBuilder.RenameColumn(
                name: "AmountDueId",
                table: "YodleeAccounts",
                newName: "AmountDueEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "YodleeAccounts",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeAccounts_VerifyAccountDTOId",
                table: "YodleeAccounts",
                newName: "IX_YodleeAccounts_VerifyAccountDTOEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeAccounts_TotalCreditLineId",
                table: "YodleeAccounts",
                newName: "IX_YodleeAccounts_TotalCreditLineEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeAccounts_TotalCashLimitId",
                table: "YodleeAccounts",
                newName: "IX_YodleeAccounts_TotalCashLimitEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeAccounts_RunningBalanceId",
                table: "YodleeAccounts",
                newName: "IX_YodleeAccounts_RunningBalanceEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeAccounts_PrincipalBalanceId",
                table: "YodleeAccounts",
                newName: "IX_YodleeAccounts_PrincipalBalanceEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeAccounts_OriginalLoanAmountId",
                table: "YodleeAccounts",
                newName: "IX_YodleeAccounts_OriginalLoanAmountEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeAccounts_MinimumAmountDueId",
                table: "YodleeAccounts",
                newName: "IX_YodleeAccounts_MinimumAmountDueEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeAccounts_MarginBalanceId",
                table: "YodleeAccounts",
                newName: "IX_YodleeAccounts_MarginBalanceEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeAccounts_LastPaymentAmountId",
                table: "YodleeAccounts",
                newName: "IX_YodleeAccounts_LastPaymentAmountEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeAccounts_LastEmployeeContributionAmountId",
                table: "YodleeAccounts",
                newName: "IX_YodleeAccounts_LastEmployeeContributionAmountEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeAccounts_CurrentBalanceId",
                table: "YodleeAccounts",
                newName: "IX_YodleeAccounts_CurrentBalanceEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeAccounts_CashId",
                table: "YodleeAccounts",
                newName: "IX_YodleeAccounts_CashEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeAccounts_BalanceId",
                table: "YodleeAccounts",
                newName: "IX_YodleeAccounts_BalanceEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeAccounts_AvailableCreditId",
                table: "YodleeAccounts",
                newName: "IX_YodleeAccounts_AvailableCreditEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeAccounts_AvailableCashId",
                table: "YodleeAccounts",
                newName: "IX_YodleeAccounts_AvailableCashEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeAccounts_AvailableBalanceId",
                table: "YodleeAccounts",
                newName: "IX_YodleeAccounts_AvailableBalanceEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeAccounts_AmountDueId",
                table: "YodleeAccounts",
                newName: "IX_YodleeAccounts_AmountDueEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "YodleeAccessTokens",
                newName: "EntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "VerifyAccountTransactionCriterias",
                newName: "EntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "VerifyAccountDTOs",
                newName: "EntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserProfileDetailProviderAccounts",
                newName: "EntityId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserDatas",
                newName: "UserEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserDatas",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_UserDatas_UserId",
                table: "UserDatas",
                newName: "IX_UserDatas_UserEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UpdateProviderAccountFields",
                newName: "EntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UpdateProviderAccountDataSets",
                newName: "EntityId");

            migrationBuilder.RenameColumn(
                name: "UpdateProviderAccountDataSetId",
                table: "UpdateProviderAccountAttributes",
                newName: "UpdateProviderAccountDataSetEntityId");

            migrationBuilder.RenameColumn(
                name: "ContainerAttributesId",
                table: "UpdateProviderAccountAttributes",
                newName: "ContainerAttributesEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UpdateProviderAccountAttributes",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_UpdateProviderAccountAttributes_ContainerAttributesId",
                table: "UpdateProviderAccountAttributes",
                newName: "IX_UpdateProviderAccountAttributes_ContainerAttributesEntityId");

            migrationBuilder.RenameColumn(
                name: "HomeValueId",
                table: "UpdateAccountDetails",
                newName: "HomeValueEntityId");

            migrationBuilder.RenameColumn(
                name: "BalanceId",
                table: "UpdateAccountDetails",
                newName: "BalanceEntityId");

            migrationBuilder.RenameColumn(
                name: "AmountDueId",
                table: "UpdateAccountDetails",
                newName: "AmountDueEntityId");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "UpdateAccountDetails",
                newName: "AddressEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UpdateAccountDetails",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_UpdateAccountDetails_HomeValueId",
                table: "UpdateAccountDetails",
                newName: "IX_UpdateAccountDetails_HomeValueEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_UpdateAccountDetails_BalanceId",
                table: "UpdateAccountDetails",
                newName: "IX_UpdateAccountDetails_BalanceEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_UpdateAccountDetails_AmountDueId",
                table: "UpdateAccountDetails",
                newName: "IX_UpdateAccountDetails_AmountDueEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_UpdateAccountDetails_AddressId",
                table: "UpdateAccountDetails",
                newName: "IX_UpdateAccountDetails_AddressEntityId");

            migrationBuilder.RenameColumn(
                name: "LinksId",
                table: "TransactionsSummarys",
                newName: "LinksEntityId");

            migrationBuilder.RenameColumn(
                name: "DebitTotalId",
                table: "TransactionsSummarys",
                newName: "DebitTotalEntityId");

            migrationBuilder.RenameColumn(
                name: "CreditTotalId",
                table: "TransactionsSummarys",
                newName: "CreditTotalEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TransactionsSummarys",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionsSummarys_LinksId",
                table: "TransactionsSummarys",
                newName: "IX_TransactionsSummarys_LinksEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionsSummarys_DebitTotalId",
                table: "TransactionsSummarys",
                newName: "IX_TransactionsSummarys_DebitTotalEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionsSummarys_CreditTotalId",
                table: "TransactionsSummarys",
                newName: "IX_TransactionsSummarys_CreditTotalEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TransactionsLinks",
                newName: "EntityId");

            migrationBuilder.RenameColumn(
                name: "VerifyAccountDTOId",
                table: "TransactionCriterias",
                newName: "VerifyAccountDTOEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TransactionCriterias",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionCriterias_VerifyAccountDTOId",
                table: "TransactionCriterias",
                newName: "IX_TransactionCriterias_VerifyAccountDTOEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TransactionCategorizationRules",
                newName: "EntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TransactionCategories",
                newName: "EntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Totals",
                newName: "EntityId");

            migrationBuilder.RenameColumn(
                name: "TransactionsSummaryId",
                table: "Summarys",
                newName: "TransactionsSummaryEntityId");

            migrationBuilder.RenameColumn(
                name: "LinksId",
                table: "Summarys",
                newName: "LinksEntityId");

            migrationBuilder.RenameColumn(
                name: "DebitTotalId",
                table: "Summarys",
                newName: "DebitTotalEntityId");

            migrationBuilder.RenameColumn(
                name: "CreditTotalId",
                table: "Summarys",
                newName: "CreditTotalEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Summarys",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Summarys_TransactionsSummaryId",
                table: "Summarys",
                newName: "IX_Summarys_TransactionsSummaryEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Summarys_LinksId",
                table: "Summarys",
                newName: "IX_Summarys_LinksEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Summarys_DebitTotalId",
                table: "Summarys",
                newName: "IX_Summarys_DebitTotalEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Summarys_CreditTotalId",
                table: "Summarys",
                newName: "IX_Summarys_CreditTotalEntityId");

            migrationBuilder.RenameColumn(
                name: "SummaryId",
                table: "SummaryDetails",
                newName: "SummaryEntityId");

            migrationBuilder.RenameColumn(
                name: "DebitTotalId",
                table: "SummaryDetails",
                newName: "DebitTotalEntityId");

            migrationBuilder.RenameColumn(
                name: "CreditTotalId",
                table: "SummaryDetails",
                newName: "CreditTotalEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SummaryDetails",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_SummaryDetails_SummaryId",
                table: "SummaryDetails",
                newName: "IX_SummaryDetails_SummaryEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_SummaryDetails_DebitTotalId",
                table: "SummaryDetails",
                newName: "IX_SummaryDetails_DebitTotalEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_SummaryDetails_CreditTotalId",
                table: "SummaryDetails",
                newName: "IX_SummaryDetails_CreditTotalEntityId");

            migrationBuilder.RenameColumn(
                name: "SecurityId",
                table: "StockExchangeDetails",
                newName: "SecurityEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "StockExchangeDetails",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_StockExchangeDetails_SecurityId",
                table: "StockExchangeDetails",
                newName: "IX_StockExchangeDetails_SecurityEntityId");

            migrationBuilder.RenameColumn(
                name: "SecurityId",
                table: "SecurityHoldings",
                newName: "SecurityEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SecurityHoldings",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_SecurityHoldings_SecurityId",
                table: "SecurityHoldings",
                newName: "IX_SecurityHoldings_SecurityEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Security",
                newName: "EntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "RunningBalances",
                newName: "EntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Rules",
                newName: "EntityId");

            migrationBuilder.RenameColumn(
                name: "RuleId",
                table: "RuleClauses",
                newName: "RuleEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "RuleClauses",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_RuleClauses_RuleId",
                table: "RuleClauses",
                newName: "IX_RuleClauses_RuleEntityId");

            migrationBuilder.RenameColumn(
                name: "LoginFormId",
                table: "Rows",
                newName: "LoginFormEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Rows",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Rows_LoginFormId",
                table: "Rows",
                newName: "IX_Rows_LoginFormEntityId");

            migrationBuilder.RenameColumn(
                name: "DataExtractAccountId",
                table: "RewardBalances",
                newName: "DataExtractAccountEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "RewardBalances",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_RewardBalances_DataExtractAccountId",
                table: "RewardBalances",
                newName: "IX_RewardBalances_DataExtractAccountEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PublicKeys",
                newName: "EntityId");

            migrationBuilder.RenameColumn(
                name: "ProviderId",
                table: "ProvidersDatasets",
                newName: "ProviderEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ProvidersDatasets",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_ProvidersDatasets_ProviderId",
                table: "ProvidersDatasets",
                newName: "IX_ProvidersDatasets_ProviderEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Providers",
                newName: "EntityId");

            migrationBuilder.RenameColumn(
                name: "TotalId",
                table: "ProviderCounts",
                newName: "TotalEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ProviderCounts",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_ProviderCounts_TotalId",
                table: "ProviderCounts",
                newName: "IX_ProviderCounts_TotalEntityId");

            migrationBuilder.RenameColumn(
                name: "PreferencesId",
                table: "ProviderAccounts",
                newName: "PreferencesEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ProviderAccounts",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_ProviderAccounts_PreferencesId",
                table: "ProviderAccounts",
                newName: "IX_ProviderAccounts_PreferencesEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ProviderAccountPreference",
                newName: "EntityId");

            migrationBuilder.RenameColumn(
                name: "ProviderAccountProfileId",
                table: "Profiles",
                newName: "ProviderAccountProfileEntityId");

            migrationBuilder.RenameColumn(
                name: "NameId",
                table: "Profiles",
                newName: "NameEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Profiles",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Profiles_ProviderAccountProfileId",
                table: "Profiles",
                newName: "IX_Profiles_ProviderAccountProfileEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Profiles_NameId",
                table: "Profiles",
                newName: "IX_Profiles_NameEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Principals",
                newName: "EntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Preferences",
                newName: "EntityId");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "PhoneNumbers",
                newName: "ProfileEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PhoneNumbers",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_PhoneNumbers_ProfileId",
                table: "PhoneNumbers",
                newName: "IX_PhoneNumbers_ProfileEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "NotificationEvent",
                newName: "EntityId");

            migrationBuilder.RenameColumn(
                name: "NetworthId",
                table: "Networths",
                newName: "NetworthEntityId");

            migrationBuilder.RenameColumn(
                name: "LiabilityId",
                table: "Networths",
                newName: "LiabilityEntityId");

            migrationBuilder.RenameColumn(
                name: "AssetId",
                table: "Networths",
                newName: "AssetEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Networths",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Networths_NetworthId",
                table: "Networths",
                newName: "IX_Networths_NetworthEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Networths_LiabilityId",
                table: "Networths",
                newName: "IX_Networths_LiabilityEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Networths_AssetId",
                table: "Networths",
                newName: "IX_Networths_AssetEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Names",
                newName: "EntityId");

            migrationBuilder.RenameColumn(
                name: "CoordinatesId",
                table: "Merchants",
                newName: "CoordinatesEntityId");

            migrationBuilder.RenameColumn(
                name: "ContactId",
                table: "Merchants",
                newName: "ContactEntityId");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Merchants",
                newName: "AddressEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Merchants",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Merchants_CoordinatesId",
                table: "Merchants",
                newName: "IX_Merchants_CoordinatesEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Merchants_ContactId",
                table: "Merchants",
                newName: "IX_Merchants_ContactEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Merchants_AddressId",
                table: "Merchants",
                newName: "IX_Merchants_AddressEntityId");

            migrationBuilder.RenameColumn(
                name: "ProviderId",
                table: "LoginForms",
                newName: "ProviderEntityId");

            migrationBuilder.RenameColumn(
                name: "ProviderAccountId",
                table: "LoginForms",
                newName: "ProviderAccountEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "LoginForms",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_LoginForms_ProviderId",
                table: "LoginForms",
                newName: "IX_LoginForms_ProviderEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_LoginForms_ProviderAccountId",
                table: "LoginForms",
                newName: "IX_LoginForms_ProviderAccountEntityId");

            migrationBuilder.RenameColumn(
                name: "PayoffAmountId",
                table: "LoanPayoffDetails",
                newName: "PayoffAmountEntityId");

            migrationBuilder.RenameColumn(
                name: "OutstandingBalanceId",
                table: "LoanPayoffDetails",
                newName: "OutstandingBalanceEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "LoanPayoffDetails",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_LoanPayoffDetails_PayoffAmountId",
                table: "LoanPayoffDetails",
                newName: "IX_LoanPayoffDetails_PayoffAmountEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_LoanPayoffDetails_OutstandingBalanceId",
                table: "LoanPayoffDetails",
                newName: "IX_LoanPayoffDetails_OutstandingBalanceEntityId");

            migrationBuilder.RenameColumn(
                name: "UserDataId",
                table: "Links",
                newName: "UserDataEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Links",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Links_UserDataId",
                table: "Links",
                newName: "IX_Links_UserDataEntityId");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "Identifiers",
                newName: "ProfileEntityId");

            migrationBuilder.RenameColumn(
                name: "HolderId",
                table: "Identifiers",
                newName: "HolderEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Identifiers",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Identifiers_ProfileId",
                table: "Identifiers",
                newName: "IX_Identifiers_ProfileEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Identifiers_HolderId",
                table: "Identifiers",
                newName: "IX_Identifiers_HolderEntityId");

            migrationBuilder.RenameColumn(
                name: "ValueId",
                table: "HoldingsSummarys",
                newName: "ValueEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "HoldingsSummarys",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_HoldingsSummarys_ValueId",
                table: "HoldingsSummarys",
                newName: "IX_HoldingsSummarys_ValueEntityId");

            migrationBuilder.RenameColumn(
                name: "ValueId",
                table: "HoldingsAccounts",
                newName: "ValueEntityId");

            migrationBuilder.RenameColumn(
                name: "HoldingsSummaryId",
                table: "HoldingsAccounts",
                newName: "HoldingsSummaryEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "HoldingsAccounts",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_HoldingsAccounts_ValueId",
                table: "HoldingsAccounts",
                newName: "IX_HoldingsAccounts_ValueEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_HoldingsAccounts_HoldingsSummaryId",
                table: "HoldingsAccounts",
                newName: "IX_HoldingsAccounts_HoldingsSummaryEntityId");

            migrationBuilder.RenameColumn(
                name: "VestedValueId",
                table: "Holdings",
                newName: "VestedValueEntityId");

            migrationBuilder.RenameColumn(
                name: "ValueId",
                table: "Holdings",
                newName: "ValueEntityId");

            migrationBuilder.RenameColumn(
                name: "UnvestedValueId",
                table: "Holdings",
                newName: "UnvestedValueEntityId");

            migrationBuilder.RenameColumn(
                name: "StrikePriceId",
                table: "Holdings",
                newName: "StrikePriceEntityId");

            migrationBuilder.RenameColumn(
                name: "SpreadId",
                table: "Holdings",
                newName: "SpreadEntityId");

            migrationBuilder.RenameColumn(
                name: "PriceId",
                table: "Holdings",
                newName: "PriceEntityId");

            migrationBuilder.RenameColumn(
                name: "HoldingsSummaryId",
                table: "Holdings",
                newName: "HoldingsSummaryEntityId");

            migrationBuilder.RenameColumn(
                name: "DataExtractUserDataId",
                table: "Holdings",
                newName: "DataExtractUserDataEntityId");

            migrationBuilder.RenameColumn(
                name: "CostBasisId",
                table: "Holdings",
                newName: "CostBasisEntityId");

            migrationBuilder.RenameColumn(
                name: "AccruedInterestId",
                table: "Holdings",
                newName: "AccruedInterestEntityId");

            migrationBuilder.RenameColumn(
                name: "AccruedIncomeId",
                table: "Holdings",
                newName: "AccruedIncomeEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Holdings",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Holdings_VestedValueId",
                table: "Holdings",
                newName: "IX_Holdings_VestedValueEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Holdings_ValueId",
                table: "Holdings",
                newName: "IX_Holdings_ValueEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Holdings_UnvestedValueId",
                table: "Holdings",
                newName: "IX_Holdings_UnvestedValueEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Holdings_StrikePriceId",
                table: "Holdings",
                newName: "IX_Holdings_StrikePriceEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Holdings_SpreadId",
                table: "Holdings",
                newName: "IX_Holdings_SpreadEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Holdings_PriceId",
                table: "Holdings",
                newName: "IX_Holdings_PriceEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Holdings_HoldingsSummaryId",
                table: "Holdings",
                newName: "IX_Holdings_HoldingsSummaryEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Holdings_DataExtractUserDataId",
                table: "Holdings",
                newName: "IX_Holdings_DataExtractUserDataEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Holdings_CostBasisId",
                table: "Holdings",
                newName: "IX_Holdings_CostBasisEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Holdings_AccruedInterestId",
                table: "Holdings",
                newName: "IX_Holdings_AccruedInterestEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Holdings_AccruedIncomeId",
                table: "Holdings",
                newName: "IX_Holdings_AccruedIncomeEntityId");

            migrationBuilder.RenameColumn(
                name: "VerifiedAccountId",
                table: "Holders",
                newName: "VerifiedAccountEntityId");

            migrationBuilder.RenameColumn(
                name: "NameId",
                table: "Holders",
                newName: "NameEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Holders",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Holders_VerifiedAccountId",
                table: "Holders",
                newName: "IX_Holders_VerifiedAccountEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Holders_NameId",
                table: "Holders",
                newName: "IX_Holders_NameEntityId");

            migrationBuilder.RenameColumn(
                name: "NetworthDetailId",
                table: "HistoricalBalances",
                newName: "NetworthDetailEntityId");

            migrationBuilder.RenameColumn(
                name: "BalanceId",
                table: "HistoricalBalances",
                newName: "BalanceEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "HistoricalBalances",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_HistoricalBalances_NetworthDetailId",
                table: "HistoricalBalances",
                newName: "IX_HistoricalBalances_NetworthDetailEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_HistoricalBalances_BalanceId",
                table: "HistoricalBalances",
                newName: "IX_HistoricalBalances_BalanceEntityId");

            migrationBuilder.RenameColumn(
                name: "HistoricalAccountId",
                table: "HistoricalBalanceAccounts",
                newName: "HistoricalAccountEntityId");

            migrationBuilder.RenameColumn(
                name: "BalanceId",
                table: "HistoricalBalanceAccounts",
                newName: "BalanceEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "HistoricalBalanceAccounts",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_HistoricalBalanceAccounts_HistoricalAccountId",
                table: "HistoricalBalanceAccounts",
                newName: "IX_HistoricalBalanceAccounts_HistoricalAccountEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_HistoricalBalanceAccounts_BalanceId",
                table: "HistoricalBalanceAccounts",
                newName: "IX_HistoricalBalanceAccounts_BalanceEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "HistoricalAccounts",
                newName: "EntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "FullAccountNumberLists",
                newName: "EntityId");

            migrationBuilder.RenameColumn(
                name: "RowId",
                table: "Fields",
                newName: "RowEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Fields",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Fields_RowId",
                table: "Fields",
                newName: "IX_Fields_RowEntityId");

            migrationBuilder.RenameColumn(
                name: "dataId",
                table: "Events",
                newName: "dataEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Events",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Events_dataId",
                table: "Events",
                newName: "IX_Events_dataEntityId");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "Emails",
                newName: "ProfileEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Emails",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Emails_ProfileId",
                table: "Emails",
                newName: "IX_Emails_ProfileEntityId");

            migrationBuilder.RenameColumn(
                name: "TransactionCategoryId",
                table: "DetailCategories",
                newName: "TransactionCategoryEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "DetailCategories",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_DetailCategories_TransactionCategoryId",
                table: "DetailCategories",
                newName: "IX_DetailCategories_TransactionCategoryEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Descriptions",
                newName: "EntityId");

            migrationBuilder.RenameColumn(
                name: "ProviderAccountId",
                table: "DataSets",
                newName: "ProviderAccountEntityId");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "DataSets",
                newName: "AccountEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "DataSets",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_DataSets_ProviderAccountId",
                table: "DataSets",
                newName: "IX_DataSets_ProviderAccountEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_DataSets_AccountId",
                table: "DataSets",
                newName: "IX_DataSets_AccountEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Datas",
                newName: "EntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "DataExtractUsers",
                newName: "EntityId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "DataExtractUserDatas",
                newName: "UserEntityId");

            migrationBuilder.RenameColumn(
                name: "DataId",
                table: "DataExtractUserDatas",
                newName: "DataEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "DataExtractUserDatas",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractUserDatas_UserId",
                table: "DataExtractUserDatas",
                newName: "IX_DataExtractUserDatas_UserEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractUserDatas_DataId",
                table: "DataExtractUserDatas",
                newName: "IX_DataExtractUserDatas_DataEntityId");

            migrationBuilder.RenameColumn(
                name: "DataExtractUserDataId",
                table: "DataExtractProviderAccounts",
                newName: "DataExtractUserDataEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "DataExtractProviderAccounts",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractProviderAccounts_DataExtractUserDataId",
                table: "DataExtractProviderAccounts",
                newName: "IX_DataExtractProviderAccounts_DataExtractUserDataEntityId");

            migrationBuilder.RenameColumn(
                name: "DataExtractProviderAccountId",
                table: "DataExtractDatasets",
                newName: "DataExtractProviderAccountEntityId");

            migrationBuilder.RenameColumn(
                name: "DataExtractAccountId",
                table: "DataExtractDatasets",
                newName: "DataExtractAccountEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "DataExtractDatasets",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractDatasets_DataExtractProviderAccountId",
                table: "DataExtractDatasets",
                newName: "IX_DataExtractDatasets_DataExtractProviderAccountEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractDatasets_DataExtractAccountId",
                table: "DataExtractDatasets",
                newName: "IX_DataExtractDatasets_DataExtractAccountEntityId");

            migrationBuilder.RenameColumn(
                name: "_401kLoanId",
                table: "DataExtractAccounts",
                newName: "_401kLoanEntityId");

            migrationBuilder.RenameColumn(
                name: "TotalVestedBalanceId",
                table: "DataExtractAccounts",
                newName: "TotalVestedBalanceEntityId");

            migrationBuilder.RenameColumn(
                name: "TotalUnvestedBalanceId",
                table: "DataExtractAccounts",
                newName: "TotalUnvestedBalanceEntityId");

            migrationBuilder.RenameColumn(
                name: "TotalCreditLineId",
                table: "DataExtractAccounts",
                newName: "TotalCreditLineEntityId");

            migrationBuilder.RenameColumn(
                name: "TotalCreditLimitId",
                table: "DataExtractAccounts",
                newName: "TotalCreditLimitEntityId");

            migrationBuilder.RenameColumn(
                name: "TotalCashLimitId",
                table: "DataExtractAccounts",
                newName: "TotalCashLimitEntityId");

            migrationBuilder.RenameColumn(
                name: "ShortBalanceId",
                table: "DataExtractAccounts",
                newName: "ShortBalanceEntityId");

            migrationBuilder.RenameColumn(
                name: "RunningBalanceId",
                table: "DataExtractAccounts",
                newName: "RunningBalanceEntityId");

            migrationBuilder.RenameColumn(
                name: "RemainingBalanceId",
                table: "DataExtractAccounts",
                newName: "RemainingBalanceEntityId");

            migrationBuilder.RenameColumn(
                name: "RecurringPaymentId",
                table: "DataExtractAccounts",
                newName: "RecurringPaymentEntityId");

            migrationBuilder.RenameColumn(
                name: "PrincipalBalanceId",
                table: "DataExtractAccounts",
                newName: "PrincipalBalanceEntityId");

            migrationBuilder.RenameColumn(
                name: "PremiumId",
                table: "DataExtractAccounts",
                newName: "PremiumEntityId");

            migrationBuilder.RenameColumn(
                name: "OverDraftLimitId",
                table: "DataExtractAccounts",
                newName: "OverDraftLimitEntityId");

            migrationBuilder.RenameColumn(
                name: "OriginalLoanAmountId",
                table: "DataExtractAccounts",
                newName: "OriginalLoanAmountEntityId");

            migrationBuilder.RenameColumn(
                name: "MoneyMarketBalanceId",
                table: "DataExtractAccounts",
                newName: "MoneyMarketBalanceEntityId");

            migrationBuilder.RenameColumn(
                name: "MinimumAmountDueId",
                table: "DataExtractAccounts",
                newName: "MinimumAmountDueEntityId");

            migrationBuilder.RenameColumn(
                name: "MaturityAmountId",
                table: "DataExtractAccounts",
                newName: "MaturityAmountEntityId");

            migrationBuilder.RenameColumn(
                name: "MarginBalanceId",
                table: "DataExtractAccounts",
                newName: "MarginBalanceEntityId");

            migrationBuilder.RenameColumn(
                name: "LoanPayoffDetailsId",
                table: "DataExtractAccounts",
                newName: "LoanPayoffDetailsEntityId");

            migrationBuilder.RenameColumn(
                name: "LoanPayoffAmountId",
                table: "DataExtractAccounts",
                newName: "LoanPayoffAmountEntityId");

            migrationBuilder.RenameColumn(
                name: "LastPaymentId",
                table: "DataExtractAccounts",
                newName: "LastPaymentEntityId");

            migrationBuilder.RenameColumn(
                name: "LastPaymentAmountId",
                table: "DataExtractAccounts",
                newName: "LastPaymentAmountEntityId");

            migrationBuilder.RenameColumn(
                name: "LastEmployeeContributionAmountId",
                table: "DataExtractAccounts",
                newName: "LastEmployeeContributionAmountEntityId");

            migrationBuilder.RenameColumn(
                name: "InterestPaidYTDId",
                table: "DataExtractAccounts",
                newName: "InterestPaidYTDEntityId");

            migrationBuilder.RenameColumn(
                name: "InterestPaidLastYearId",
                table: "DataExtractAccounts",
                newName: "InterestPaidLastYearEntityId");

            migrationBuilder.RenameColumn(
                name: "HomeValueId",
                table: "DataExtractAccounts",
                newName: "HomeValueEntityId");

            migrationBuilder.RenameColumn(
                name: "FaceAmountId",
                table: "DataExtractAccounts",
                newName: "FaceAmountEntityId");

            migrationBuilder.RenameColumn(
                name: "EscrowBalanceId",
                table: "DataExtractAccounts",
                newName: "EscrowBalanceEntityId");

            migrationBuilder.RenameColumn(
                name: "DeathBenefitId",
                table: "DataExtractAccounts",
                newName: "DeathBenefitEntityId");

            migrationBuilder.RenameColumn(
                name: "DataExtractUserDataId",
                table: "DataExtractAccounts",
                newName: "DataExtractUserDataEntityId");

            migrationBuilder.RenameColumn(
                name: "CurrentBalanceId",
                table: "DataExtractAccounts",
                newName: "CurrentBalanceEntityId");

            migrationBuilder.RenameColumn(
                name: "CashValueId",
                table: "DataExtractAccounts",
                newName: "CashValueEntityId");

            migrationBuilder.RenameColumn(
                name: "CashId",
                table: "DataExtractAccounts",
                newName: "CashEntityId");

            migrationBuilder.RenameColumn(
                name: "BalanceId",
                table: "DataExtractAccounts",
                newName: "BalanceEntityId");

            migrationBuilder.RenameColumn(
                name: "AvailableCreditId",
                table: "DataExtractAccounts",
                newName: "AvailableCreditEntityId");

            migrationBuilder.RenameColumn(
                name: "AvailableCashId",
                table: "DataExtractAccounts",
                newName: "AvailableCashEntityId");

            migrationBuilder.RenameColumn(
                name: "AvailableBalanceId",
                table: "DataExtractAccounts",
                newName: "AvailableBalanceEntityId");

            migrationBuilder.RenameColumn(
                name: "AnnuityBalanceId",
                table: "DataExtractAccounts",
                newName: "AnnuityBalanceEntityId");

            migrationBuilder.RenameColumn(
                name: "AmountDueId",
                table: "DataExtractAccounts",
                newName: "AmountDueEntityId");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "DataExtractAccounts",
                newName: "AddressEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "DataExtractAccounts",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_TotalVestedBalanceId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_TotalVestedBalanceEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_TotalUnvestedBalanceId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_TotalUnvestedBalanceEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_TotalCreditLineId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_TotalCreditLineEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_TotalCreditLimitId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_TotalCreditLimitEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_TotalCashLimitId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_TotalCashLimitEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_ShortBalanceId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_ShortBalanceEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_RunningBalanceId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_RunningBalanceEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_RemainingBalanceId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_RemainingBalanceEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_RecurringPaymentId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_RecurringPaymentEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_PrincipalBalanceId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_PrincipalBalanceEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_PremiumId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_PremiumEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_OverDraftLimitId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_OverDraftLimitEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_OriginalLoanAmountId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_OriginalLoanAmountEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_MoneyMarketBalanceId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_MoneyMarketBalanceEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_MinimumAmountDueId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_MinimumAmountDueEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_MaturityAmountId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_MaturityAmountEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_MarginBalanceId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_MarginBalanceEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_LoanPayoffDetailsId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_LoanPayoffDetailsEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_LoanPayoffAmountId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_LoanPayoffAmountEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_LastPaymentId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_LastPaymentEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_LastPaymentAmountId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_LastPaymentAmountEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_LastEmployeeContributionAmountId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_LastEmployeeContributionAmountEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_InterestPaidYTDId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_InterestPaidYTDEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_InterestPaidLastYearId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_InterestPaidLastYearEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_HomeValueId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_HomeValueEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_FaceAmountId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_FaceAmountEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_EscrowBalanceId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_EscrowBalanceEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_DeathBenefitId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_DeathBenefitEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_DataExtractUserDataId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_DataExtractUserDataEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_CurrentBalanceId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_CurrentBalanceEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_CashValueId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_CashValueEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_CashId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_CashEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_BalanceId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_BalanceEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_AvailableCreditId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_AvailableCreditEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_AvailableCashId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_AvailableCashEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_AvailableBalanceId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_AvailableBalanceEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_AnnuityBalanceId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_AnnuityBalanceEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_AmountDueId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_AmountDueEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_AddressId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_AddressEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts__401kLoanId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts__401kLoanEntityId");

            migrationBuilder.RenameColumn(
                name: "DataExtractAccountId",
                table: "Coverages",
                newName: "DataExtractAccountEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Coverages",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Coverages_DataExtractAccountId",
                table: "Coverages",
                newName: "IX_Coverages_DataExtractAccountEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Coordinates",
                newName: "EntityId");

            migrationBuilder.RenameColumn(
                name: "LOANId",
                table: "ContainerAttributes",
                newName: "LOANEntityId");

            migrationBuilder.RenameColumn(
                name: "INVESTMENTId",
                table: "ContainerAttributes",
                newName: "INVESTMENTEntityId");

            migrationBuilder.RenameColumn(
                name: "INSURANCEId",
                table: "ContainerAttributes",
                newName: "INSURANCEEntityId");

            migrationBuilder.RenameColumn(
                name: "CREDITCARDId",
                table: "ContainerAttributes",
                newName: "CREDITCARDEntityId");

            migrationBuilder.RenameColumn(
                name: "BANKId",
                table: "ContainerAttributes",
                newName: "BANKEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ContainerAttributes",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_ContainerAttributes_LOANId",
                table: "ContainerAttributes",
                newName: "IX_ContainerAttributes_LOANEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_ContainerAttributes_INVESTMENTId",
                table: "ContainerAttributes",
                newName: "IX_ContainerAttributes_INVESTMENTEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_ContainerAttributes_INSURANCEId",
                table: "ContainerAttributes",
                newName: "IX_ContainerAttributes_INSURANCEEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_ContainerAttributes_CREDITCARDId",
                table: "ContainerAttributes",
                newName: "IX_ContainerAttributes_CREDITCARDEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_ContainerAttributes_BANKId",
                table: "ContainerAttributes",
                newName: "IX_ContainerAttributes_BANKEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Contacts",
                newName: "EntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CardDetails",
                newName: "EntityId");

            migrationBuilder.RenameColumn(
                name: "ProviderId",
                table: "Capabilities",
                newName: "ProviderEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Capabilities",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Capabilities_ProviderId",
                table: "Capabilities",
                newName: "IX_Capabilities_ProviderEntityId");

            migrationBuilder.RenameColumn(
                name: "VerifiedAccountId",
                table: "BankTransferCodes",
                newName: "VerifiedAccountEntityId");

            migrationBuilder.RenameColumn(
                name: "DataExtractAccountId",
                table: "BankTransferCodes",
                newName: "DataExtractAccountEntityId");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "BankTransferCodes",
                newName: "AccountEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BankTransferCodes",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_BankTransferCodes_VerifiedAccountId",
                table: "BankTransferCodes",
                newName: "IX_BankTransferCodes_VerifiedAccountEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_BankTransferCodes_DataExtractAccountId",
                table: "BankTransferCodes",
                newName: "IX_BankTransferCodes_DataExtractAccountEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_BankTransferCodes_AccountId",
                table: "BankTransferCodes",
                newName: "IX_BankTransferCodes_AccountEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Banks",
                newName: "EntityId");

            migrationBuilder.RenameColumn(
                name: "ProvidersDatasetId",
                table: "Attributes",
                newName: "ProvidersDatasetEntityId");

            migrationBuilder.RenameColumn(
                name: "ContainerAttributesId",
                table: "Attributes",
                newName: "ContainerAttributesEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Attributes",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Attributes_ProvidersDatasetId",
                table: "Attributes",
                newName: "IX_Attributes_ProvidersDatasetEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Attributes_ContainerAttributesId",
                table: "Attributes",
                newName: "IX_Attributes_ContainerAttributesEntityId");

            migrationBuilder.RenameColumn(
                name: "HoldingId",
                table: "AssetClassifications",
                newName: "HoldingEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AssetClassifications",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_AssetClassifications_HoldingId",
                table: "AssetClassifications",
                newName: "IX_AssetClassifications_HoldingEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AssetClassificationLists",
                newName: "EntityId");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "Addresses",
                newName: "ProfileEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Addresses",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_ProfileId",
                table: "Addresses",
                newName: "IX_Addresses_ProfileEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AddManualResponseAccounts",
                newName: "EntityId");

            migrationBuilder.RenameColumn(
                name: "HomeValueId",
                table: "AddManualAccounts",
                newName: "HomeValueEntityId");

            migrationBuilder.RenameColumn(
                name: "BalanceId",
                table: "AddManualAccounts",
                newName: "BalanceEntityId");

            migrationBuilder.RenameColumn(
                name: "AmountDueId",
                table: "AddManualAccounts",
                newName: "AmountDueEntityId");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "AddManualAccounts",
                newName: "AddressEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AddManualAccounts",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_AddManualAccounts_HomeValueId",
                table: "AddManualAccounts",
                newName: "IX_AddManualAccounts_HomeValueEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_AddManualAccounts_BalanceId",
                table: "AddManualAccounts",
                newName: "IX_AddManualAccounts_BalanceEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_AddManualAccounts_AmountDueId",
                table: "AddManualAccounts",
                newName: "IX_AddManualAccounts_AmountDueEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_AddManualAccounts_AddressId",
                table: "AddManualAccounts",
                newName: "IX_AddManualAccounts_AddressEntityId");

            migrationBuilder.RenameColumn(
                name: "TotalBalanceId",
                table: "AccountBalances",
                newName: "TotalBalanceEntityId");

            migrationBuilder.RenameColumn(
                name: "CurrentBalanceId",
                table: "AccountBalances",
                newName: "CurrentBalanceEntityId");

            migrationBuilder.RenameColumn(
                name: "CashId",
                table: "AccountBalances",
                newName: "CashEntityId");

            migrationBuilder.RenameColumn(
                name: "BalanceId",
                table: "AccountBalances",
                newName: "BalanceEntityId");

            migrationBuilder.RenameColumn(
                name: "AvailableBalanceId",
                table: "AccountBalances",
                newName: "AvailableBalanceEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AccountBalances",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountBalances_TotalBalanceId",
                table: "AccountBalances",
                newName: "IX_AccountBalances_TotalBalanceEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountBalances_CurrentBalanceId",
                table: "AccountBalances",
                newName: "IX_AccountBalances_CurrentBalanceEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountBalances_CashId",
                table: "AccountBalances",
                newName: "IX_AccountBalances_CashEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountBalances_BalanceId",
                table: "AccountBalances",
                newName: "IX_AccountBalances_BalanceEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountBalances_AvailableBalanceId",
                table: "AccountBalances",
                newName: "IX_AccountBalances_AvailableBalanceEntityId");

            migrationBuilder.CreateTable(
                name: "HoldingTypes",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    holdingType = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoldingTypes", x => x.EntityId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AccountBalances_RunningBalances_AvailableBalanceEntityId",
                table: "AccountBalances",
                column: "AvailableBalanceEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountBalances_RunningBalances_BalanceEntityId",
                table: "AccountBalances",
                column: "BalanceEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountBalances_RunningBalances_CashEntityId",
                table: "AccountBalances",
                column: "CashEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountBalances_RunningBalances_CurrentBalanceEntityId",
                table: "AccountBalances",
                column: "CurrentBalanceEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountBalances_RunningBalances_TotalBalanceEntityId",
                table: "AccountBalances",
                column: "TotalBalanceEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AddManualAccounts_Addresses_AddressEntityId",
                table: "AddManualAccounts",
                column: "AddressEntityId",
                principalTable: "Addresses",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AddManualAccounts_RunningBalances_AmountDueEntityId",
                table: "AddManualAccounts",
                column: "AmountDueEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AddManualAccounts_RunningBalances_BalanceEntityId",
                table: "AddManualAccounts",
                column: "BalanceEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AddManualAccounts_RunningBalances_HomeValueEntityId",
                table: "AddManualAccounts",
                column: "HomeValueEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Profiles_ProfileEntityId",
                table: "Addresses",
                column: "ProfileEntityId",
                principalTable: "Profiles",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetClassifications_Holdings_HoldingEntityId",
                table: "AssetClassifications",
                column: "HoldingEntityId",
                principalTable: "Holdings",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attributes_ContainerAttributes_ContainerAttributesEntityId",
                table: "Attributes",
                column: "ContainerAttributesEntityId",
                principalTable: "ContainerAttributes",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attributes_ProvidersDatasets_ProvidersDatasetEntityId",
                table: "Attributes",
                column: "ProvidersDatasetEntityId",
                principalTable: "ProvidersDatasets",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BankTransferCodes_DataExtractAccounts_DataExtractAccountEnt~",
                table: "BankTransferCodes",
                column: "DataExtractAccountEntityId",
                principalTable: "DataExtractAccounts",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BankTransferCodes_YodleeAccounts_AccountEntityId",
                table: "BankTransferCodes",
                column: "AccountEntityId",
                principalTable: "YodleeAccounts",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BankTransferCodes_YodleeVerifiedAccount_VerifiedAccountEnti~",
                table: "BankTransferCodes",
                column: "VerifiedAccountEntityId",
                principalTable: "YodleeVerifiedAccount",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Capabilities_Providers_ProviderEntityId",
                table: "Capabilities",
                column: "ProviderEntityId",
                principalTable: "Providers",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContainerAttributes_Banks_BANKEntityId",
                table: "ContainerAttributes",
                column: "BANKEntityId",
                principalTable: "Banks",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContainerAttributes_CardDetails_CREDITCARDEntityId",
                table: "ContainerAttributes",
                column: "CREDITCARDEntityId",
                principalTable: "CardDetails",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContainerAttributes_CardDetails_INSURANCEEntityId",
                table: "ContainerAttributes",
                column: "INSURANCEEntityId",
                principalTable: "CardDetails",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContainerAttributes_CardDetails_INVESTMENTEntityId",
                table: "ContainerAttributes",
                column: "INVESTMENTEntityId",
                principalTable: "CardDetails",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContainerAttributes_CardDetails_LOANEntityId",
                table: "ContainerAttributes",
                column: "LOANEntityId",
                principalTable: "CardDetails",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Coverages_DataExtractAccounts_DataExtractAccountEntityId",
                table: "Coverages",
                column: "DataExtractAccountEntityId",
                principalTable: "DataExtractAccounts",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_Addresses_AddressEntityId",
                table: "DataExtractAccounts",
                column: "AddressEntityId",
                principalTable: "Addresses",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_LoanPayoffDetails_LoanPayoffDetailsEnti~",
                table: "DataExtractAccounts",
                column: "LoanPayoffDetailsEntityId",
                principalTable: "LoanPayoffDetails",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances__401kLoanEntityId",
                table: "DataExtractAccounts",
                column: "_401kLoanEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_AmountDueEntityId",
                table: "DataExtractAccounts",
                column: "AmountDueEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_AnnuityBalanceEntityId",
                table: "DataExtractAccounts",
                column: "AnnuityBalanceEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_AvailableBalanceEntityId",
                table: "DataExtractAccounts",
                column: "AvailableBalanceEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_AvailableCashEntityId",
                table: "DataExtractAccounts",
                column: "AvailableCashEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_AvailableCreditEntityId",
                table: "DataExtractAccounts",
                column: "AvailableCreditEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_BalanceEntityId",
                table: "DataExtractAccounts",
                column: "BalanceEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_CashEntityId",
                table: "DataExtractAccounts",
                column: "CashEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_CashValueEntityId",
                table: "DataExtractAccounts",
                column: "CashValueEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_CurrentBalanceEntityId",
                table: "DataExtractAccounts",
                column: "CurrentBalanceEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_DeathBenefitEntityId",
                table: "DataExtractAccounts",
                column: "DeathBenefitEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_EscrowBalanceEntityId",
                table: "DataExtractAccounts",
                column: "EscrowBalanceEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_FaceAmountEntityId",
                table: "DataExtractAccounts",
                column: "FaceAmountEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_HomeValueEntityId",
                table: "DataExtractAccounts",
                column: "HomeValueEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_InterestPaidLastYearEnt~",
                table: "DataExtractAccounts",
                column: "InterestPaidLastYearEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_InterestPaidYTDEntityId",
                table: "DataExtractAccounts",
                column: "InterestPaidYTDEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_LastPaymentAmountEntity~",
                table: "DataExtractAccounts",
                column: "LastPaymentAmountEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_LastPaymentEntityId",
                table: "DataExtractAccounts",
                column: "LastPaymentEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_LoanPayoffAmountEntityId",
                table: "DataExtractAccounts",
                column: "LoanPayoffAmountEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_MarginBalanceEntityId",
                table: "DataExtractAccounts",
                column: "MarginBalanceEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_MaturityAmountEntityId",
                table: "DataExtractAccounts",
                column: "MaturityAmountEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_MinimumAmountDueEntityId",
                table: "DataExtractAccounts",
                column: "MinimumAmountDueEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_MoneyMarketBalanceEntit~",
                table: "DataExtractAccounts",
                column: "MoneyMarketBalanceEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_OriginalLoanAmountEntit~",
                table: "DataExtractAccounts",
                column: "OriginalLoanAmountEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_OverDraftLimitEntityId",
                table: "DataExtractAccounts",
                column: "OverDraftLimitEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_PremiumEntityId",
                table: "DataExtractAccounts",
                column: "PremiumEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_PrincipalBalanceEntityId",
                table: "DataExtractAccounts",
                column: "PrincipalBalanceEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_RecurringPaymentEntityId",
                table: "DataExtractAccounts",
                column: "RecurringPaymentEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_RemainingBalanceEntityId",
                table: "DataExtractAccounts",
                column: "RemainingBalanceEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_RunningBalanceEntityId",
                table: "DataExtractAccounts",
                column: "RunningBalanceEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_ShortBalanceEntityId",
                table: "DataExtractAccounts",
                column: "ShortBalanceEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_TotalCashLimitEntityId",
                table: "DataExtractAccounts",
                column: "TotalCashLimitEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_TotalCreditLimitEntityId",
                table: "DataExtractAccounts",
                column: "TotalCreditLimitEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_TotalCreditLineEntityId",
                table: "DataExtractAccounts",
                column: "TotalCreditLineEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_TotalUnvestedBalanceEnt~",
                table: "DataExtractAccounts",
                column: "TotalUnvestedBalanceEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_TotalVestedBalanceEntit~",
                table: "DataExtractAccounts",
                column: "TotalVestedBalanceEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractDatasets_DataExtractAccounts_DataExtractAccountE~",
                table: "DataExtractDatasets",
                column: "DataExtractAccountEntityId",
                principalTable: "DataExtractAccounts",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractUserDatas_DataExtractUsers_UserEntityId",
                table: "DataExtractUserDatas",
                column: "UserEntityId",
                principalTable: "DataExtractUsers",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractUserDatas_Datas_DataEntityId",
                table: "DataExtractUserDatas",
                column: "DataEntityId",
                principalTable: "Datas",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataSets_ProviderAccounts_ProviderAccountEntityId",
                table: "DataSets",
                column: "ProviderAccountEntityId",
                principalTable: "ProviderAccounts",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataSets_YodleeAccounts_AccountEntityId",
                table: "DataSets",
                column: "AccountEntityId",
                principalTable: "YodleeAccounts",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailCategories_TransactionCategories_TransactionCategoryE~",
                table: "DetailCategories",
                column: "TransactionCategoryEntityId",
                principalTable: "TransactionCategories",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_Profiles_ProfileEntityId",
                table: "Emails",
                column: "ProfileEntityId",
                principalTable: "Profiles",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Datas_dataEntityId",
                table: "Events",
                column: "dataEntityId",
                principalTable: "Datas",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fields_Rows_RowEntityId",
                table: "Fields",
                column: "RowEntityId",
                principalTable: "Rows",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricalBalanceAccounts_RunningBalances_BalanceEntityId",
                table: "HistoricalBalanceAccounts",
                column: "BalanceEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricalBalances_Networths_NetworthDetailEntityId",
                table: "HistoricalBalances",
                column: "NetworthDetailEntityId",
                principalTable: "Networths",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricalBalances_RunningBalances_BalanceEntityId",
                table: "HistoricalBalances",
                column: "BalanceEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Holders_Names_NameEntityId",
                table: "Holders",
                column: "NameEntityId",
                principalTable: "Names",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Holders_YodleeVerifiedAccount_VerifiedAccountEntityId",
                table: "Holders",
                column: "VerifiedAccountEntityId",
                principalTable: "YodleeVerifiedAccount",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Holdings_DataExtractUserDatas_DataExtractUserDataEntityId",
                table: "Holdings",
                column: "DataExtractUserDataEntityId",
                principalTable: "DataExtractUserDatas",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Holdings_HoldingsSummarys_HoldingsSummaryEntityId",
                table: "Holdings",
                column: "HoldingsSummaryEntityId",
                principalTable: "HoldingsSummarys",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Holdings_RunningBalances_AccruedIncomeEntityId",
                table: "Holdings",
                column: "AccruedIncomeEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Holdings_RunningBalances_AccruedInterestEntityId",
                table: "Holdings",
                column: "AccruedInterestEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Holdings_RunningBalances_CostBasisEntityId",
                table: "Holdings",
                column: "CostBasisEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Holdings_RunningBalances_PriceEntityId",
                table: "Holdings",
                column: "PriceEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Holdings_RunningBalances_SpreadEntityId",
                table: "Holdings",
                column: "SpreadEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Holdings_RunningBalances_StrikePriceEntityId",
                table: "Holdings",
                column: "StrikePriceEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Holdings_RunningBalances_UnvestedValueEntityId",
                table: "Holdings",
                column: "UnvestedValueEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Holdings_RunningBalances_ValueEntityId",
                table: "Holdings",
                column: "ValueEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Holdings_RunningBalances_VestedValueEntityId",
                table: "Holdings",
                column: "VestedValueEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HoldingsAccounts_HoldingsSummarys_HoldingsSummaryEntityId",
                table: "HoldingsAccounts",
                column: "HoldingsSummaryEntityId",
                principalTable: "HoldingsSummarys",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HoldingsAccounts_RunningBalances_ValueEntityId",
                table: "HoldingsAccounts",
                column: "ValueEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HoldingsSummarys_RunningBalances_ValueEntityId",
                table: "HoldingsSummarys",
                column: "ValueEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Identifiers_Holders_HolderEntityId",
                table: "Identifiers",
                column: "HolderEntityId",
                principalTable: "Holders",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Identifiers_Profiles_ProfileEntityId",
                table: "Identifiers",
                column: "ProfileEntityId",
                principalTable: "Profiles",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Links_UserDatas_UserDataEntityId",
                table: "Links",
                column: "UserDataEntityId",
                principalTable: "UserDatas",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanPayoffDetails_RunningBalances_OutstandingBalanceEntityId",
                table: "LoanPayoffDetails",
                column: "OutstandingBalanceEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanPayoffDetails_RunningBalances_PayoffAmountEntityId",
                table: "LoanPayoffDetails",
                column: "PayoffAmountEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoginForms_ProviderAccounts_ProviderAccountEntityId",
                table: "LoginForms",
                column: "ProviderAccountEntityId",
                principalTable: "ProviderAccounts",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoginForms_Providers_ProviderEntityId",
                table: "LoginForms",
                column: "ProviderEntityId",
                principalTable: "Providers",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Merchants_Addresses_AddressEntityId",
                table: "Merchants",
                column: "AddressEntityId",
                principalTable: "Addresses",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Merchants_Contacts_ContactEntityId",
                table: "Merchants",
                column: "ContactEntityId",
                principalTable: "Contacts",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Merchants_Coordinates_CoordinatesEntityId",
                table: "Merchants",
                column: "CoordinatesEntityId",
                principalTable: "Coordinates",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Networths_RunningBalances_AssetEntityId",
                table: "Networths",
                column: "AssetEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Networths_RunningBalances_LiabilityEntityId",
                table: "Networths",
                column: "LiabilityEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Networths_RunningBalances_NetworthEntityId",
                table: "Networths",
                column: "NetworthEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumbers_Profiles_ProfileEntityId",
                table: "PhoneNumbers",
                column: "ProfileEntityId",
                principalTable: "Profiles",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Names_NameEntityId",
                table: "Profiles",
                column: "NameEntityId",
                principalTable: "Names",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderAccounts_ProviderAccountPreference_PreferencesEntit~",
                table: "ProviderAccounts",
                column: "PreferencesEntityId",
                principalTable: "ProviderAccountPreference",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderCounts_Totals_TotalEntityId",
                table: "ProviderCounts",
                column: "TotalEntityId",
                principalTable: "Totals",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProvidersDatasets_Providers_ProviderEntityId",
                table: "ProvidersDatasets",
                column: "ProviderEntityId",
                principalTable: "Providers",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RewardBalances_DataExtractAccounts_DataExtractAccountEntity~",
                table: "RewardBalances",
                column: "DataExtractAccountEntityId",
                principalTable: "DataExtractAccounts",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rows_LoginForms_LoginFormEntityId",
                table: "Rows",
                column: "LoginFormEntityId",
                principalTable: "LoginForms",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RuleClauses_Rules_RuleEntityId",
                table: "RuleClauses",
                column: "RuleEntityId",
                principalTable: "Rules",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SecurityHoldings_Security_SecurityEntityId",
                table: "SecurityHoldings",
                column: "SecurityEntityId",
                principalTable: "Security",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StockExchangeDetails_Security_SecurityEntityId",
                table: "StockExchangeDetails",
                column: "SecurityEntityId",
                principalTable: "Security",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SummaryDetails_RunningBalances_CreditTotalEntityId",
                table: "SummaryDetails",
                column: "CreditTotalEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SummaryDetails_RunningBalances_DebitTotalEntityId",
                table: "SummaryDetails",
                column: "DebitTotalEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SummaryDetails_Summarys_SummaryEntityId",
                table: "SummaryDetails",
                column: "SummaryEntityId",
                principalTable: "Summarys",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Summarys_RunningBalances_CreditTotalEntityId",
                table: "Summarys",
                column: "CreditTotalEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Summarys_RunningBalances_DebitTotalEntityId",
                table: "Summarys",
                column: "DebitTotalEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Summarys_TransactionsLinks_LinksEntityId",
                table: "Summarys",
                column: "LinksEntityId",
                principalTable: "TransactionsLinks",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Summarys_TransactionsSummarys_TransactionsSummaryEntityId",
                table: "Summarys",
                column: "TransactionsSummaryEntityId",
                principalTable: "TransactionsSummarys",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionCriterias_VerifyAccountDTOs_VerifyAccountDTOEnti~",
                table: "TransactionCriterias",
                column: "VerifyAccountDTOEntityId",
                principalTable: "VerifyAccountDTOs",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionsSummarys_RunningBalances_CreditTotalEntityId",
                table: "TransactionsSummarys",
                column: "CreditTotalEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionsSummarys_RunningBalances_DebitTotalEntityId",
                table: "TransactionsSummarys",
                column: "DebitTotalEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionsSummarys_TransactionsLinks_LinksEntityId",
                table: "TransactionsSummarys",
                column: "LinksEntityId",
                principalTable: "TransactionsLinks",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UpdateAccountDetails_Addresses_AddressEntityId",
                table: "UpdateAccountDetails",
                column: "AddressEntityId",
                principalTable: "Addresses",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UpdateAccountDetails_RunningBalances_AmountDueEntityId",
                table: "UpdateAccountDetails",
                column: "AmountDueEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UpdateAccountDetails_RunningBalances_BalanceEntityId",
                table: "UpdateAccountDetails",
                column: "BalanceEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UpdateAccountDetails_RunningBalances_HomeValueEntityId",
                table: "UpdateAccountDetails",
                column: "HomeValueEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDatas_DataExtractUsers_UserEntityId",
                table: "UserDatas",
                column: "UserEntityId",
                principalTable: "DataExtractUsers",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_AmountDueEntityId",
                table: "YodleeAccounts",
                column: "AmountDueEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_AvailableBalanceEntityId",
                table: "YodleeAccounts",
                column: "AvailableBalanceEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_AvailableCashEntityId",
                table: "YodleeAccounts",
                column: "AvailableCashEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_AvailableCreditEntityId",
                table: "YodleeAccounts",
                column: "AvailableCreditEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_BalanceEntityId",
                table: "YodleeAccounts",
                column: "BalanceEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_CashEntityId",
                table: "YodleeAccounts",
                column: "CashEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_CurrentBalanceEntityId",
                table: "YodleeAccounts",
                column: "CurrentBalanceEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_LastPaymentAmountEntityId",
                table: "YodleeAccounts",
                column: "LastPaymentAmountEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_MarginBalanceEntityId",
                table: "YodleeAccounts",
                column: "MarginBalanceEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_MinimumAmountDueEntityId",
                table: "YodleeAccounts",
                column: "MinimumAmountDueEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_OriginalLoanAmountEntityId",
                table: "YodleeAccounts",
                column: "OriginalLoanAmountEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_PrincipalBalanceEntityId",
                table: "YodleeAccounts",
                column: "PrincipalBalanceEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_RunningBalanceEntityId",
                table: "YodleeAccounts",
                column: "RunningBalanceEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_TotalCashLimitEntityId",
                table: "YodleeAccounts",
                column: "TotalCashLimitEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_TotalCreditLineEntityId",
                table: "YodleeAccounts",
                column: "TotalCreditLineEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeAccounts_VerifyAccountDTOs_VerifyAccountDTOEntityId",
                table: "YodleeAccounts",
                column: "VerifyAccountDTOEntityId",
                principalTable: "VerifyAccountDTOs",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeAmounts_Coverages_CoverageEntityId",
                table: "YodleeAmounts",
                column: "CoverageEntityId",
                principalTable: "Coverages",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeAmounts_RunningBalances_coverEntityId",
                table: "YodleeAmounts",
                column: "coverEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeAmounts_RunningBalances_MetEntityId",
                table: "YodleeAmounts",
                column: "MetEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeIntermediary_YodleeTransactions_TransactionEntityId",
                table: "YodleeIntermediary",
                column: "TransactionEntityId",
                principalTable: "YodleeTransactions",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeStatements_RunningBalances_AmountDueEntityId",
                table: "YodleeStatements",
                column: "AmountDueEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeStatements_RunningBalances_CashAdvanceEntityId",
                table: "YodleeStatements",
                column: "CashAdvanceEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeStatements_RunningBalances_InterestAmountEntityId",
                table: "YodleeStatements",
                column: "InterestAmountEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeStatements_RunningBalances_LastPaymentAmountEntityId",
                table: "YodleeStatements",
                column: "LastPaymentAmountEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeStatements_RunningBalances_LoanBalanceEntityId",
                table: "YodleeStatements",
                column: "LoanBalanceEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeStatements_RunningBalances_MinimumPaymentEntityId",
                table: "YodleeStatements",
                column: "MinimumPaymentEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeStatements_RunningBalances_NewChargesEntityId",
                table: "YodleeStatements",
                column: "NewChargesEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeStatements_RunningBalances_PrincipalAmountEntityId",
                table: "YodleeStatements",
                column: "PrincipalAmountEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeTransactions_Descriptions_DescriptionEntityId",
                table: "YodleeTransactions",
                column: "DescriptionEntityId",
                principalTable: "Descriptions",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeTransactions_Merchants_MerchantEntityId",
                table: "YodleeTransactions",
                column: "MerchantEntityId",
                principalTable: "Merchants",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeTransactions_Principals_PrincipalEntityId",
                table: "YodleeTransactions",
                column: "PrincipalEntityId",
                principalTable: "Principals",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeTransactions_RunningBalances_AmountEntityId",
                table: "YodleeTransactions",
                column: "AmountEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeTransactions_RunningBalances_CommissionEntityId",
                table: "YodleeTransactions",
                column: "CommissionEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeTransactions_RunningBalances_InterestEntityId",
                table: "YodleeTransactions",
                column: "InterestEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeTransactions_RunningBalances_PriceEntityId",
                table: "YodleeTransactions",
                column: "PriceEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeTransactions_RunningBalances_RunningBalanceEntityId",
                table: "YodleeTransactions",
                column: "RunningBalanceEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeUser_Addresses_AddressEntityId",
                table: "YodleeUser",
                column: "AddressEntityId",
                principalTable: "Addresses",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeUser_Names_NameEntityId",
                table: "YodleeUser",
                column: "NameEntityId",
                principalTable: "Names",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeUser_Preferences_PreferencesEntityId",
                table: "YodleeUser",
                column: "PreferencesEntityId",
                principalTable: "Preferences",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeVerifiedAccount_RunningBalances_AvailableBalanceEntit~",
                table: "YodleeVerifiedAccount",
                column: "AvailableBalanceEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeVerifiedAccount_RunningBalances_BalanceEntityId",
                table: "YodleeVerifiedAccount",
                column: "BalanceEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeVerifiedAccount_RunningBalances_CashEntityId",
                table: "YodleeVerifiedAccount",
                column: "CashEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeVerifiedAccount_RunningBalances_CurrentBalanceEntityId",
                table: "YodleeVerifiedAccount",
                column: "CurrentBalanceEntityId",
                principalTable: "RunningBalances",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountBalances_RunningBalances_AvailableBalanceEntityId",
                table: "AccountBalances");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountBalances_RunningBalances_BalanceEntityId",
                table: "AccountBalances");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountBalances_RunningBalances_CashEntityId",
                table: "AccountBalances");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountBalances_RunningBalances_CurrentBalanceEntityId",
                table: "AccountBalances");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountBalances_RunningBalances_TotalBalanceEntityId",
                table: "AccountBalances");

            migrationBuilder.DropForeignKey(
                name: "FK_AddManualAccounts_Addresses_AddressEntityId",
                table: "AddManualAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_AddManualAccounts_RunningBalances_AmountDueEntityId",
                table: "AddManualAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_AddManualAccounts_RunningBalances_BalanceEntityId",
                table: "AddManualAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_AddManualAccounts_RunningBalances_HomeValueEntityId",
                table: "AddManualAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Profiles_ProfileEntityId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetClassifications_Holdings_HoldingEntityId",
                table: "AssetClassifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Attributes_ContainerAttributes_ContainerAttributesEntityId",
                table: "Attributes");

            migrationBuilder.DropForeignKey(
                name: "FK_Attributes_ProvidersDatasets_ProvidersDatasetEntityId",
                table: "Attributes");

            migrationBuilder.DropForeignKey(
                name: "FK_BankTransferCodes_DataExtractAccounts_DataExtractAccountEnt~",
                table: "BankTransferCodes");

            migrationBuilder.DropForeignKey(
                name: "FK_BankTransferCodes_YodleeAccounts_AccountEntityId",
                table: "BankTransferCodes");

            migrationBuilder.DropForeignKey(
                name: "FK_BankTransferCodes_YodleeVerifiedAccount_VerifiedAccountEnti~",
                table: "BankTransferCodes");

            migrationBuilder.DropForeignKey(
                name: "FK_Capabilities_Providers_ProviderEntityId",
                table: "Capabilities");

            migrationBuilder.DropForeignKey(
                name: "FK_ContainerAttributes_Banks_BANKEntityId",
                table: "ContainerAttributes");

            migrationBuilder.DropForeignKey(
                name: "FK_ContainerAttributes_CardDetails_CREDITCARDEntityId",
                table: "ContainerAttributes");

            migrationBuilder.DropForeignKey(
                name: "FK_ContainerAttributes_CardDetails_INSURANCEEntityId",
                table: "ContainerAttributes");

            migrationBuilder.DropForeignKey(
                name: "FK_ContainerAttributes_CardDetails_INVESTMENTEntityId",
                table: "ContainerAttributes");

            migrationBuilder.DropForeignKey(
                name: "FK_ContainerAttributes_CardDetails_LOANEntityId",
                table: "ContainerAttributes");

            migrationBuilder.DropForeignKey(
                name: "FK_Coverages_DataExtractAccounts_DataExtractAccountEntityId",
                table: "Coverages");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_Addresses_AddressEntityId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_LoanPayoffDetails_LoanPayoffDetailsEnti~",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances__401kLoanEntityId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_AmountDueEntityId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_AnnuityBalanceEntityId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_AvailableBalanceEntityId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_AvailableCashEntityId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_AvailableCreditEntityId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_BalanceEntityId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_CashEntityId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_CashValueEntityId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_CurrentBalanceEntityId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_DeathBenefitEntityId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_EscrowBalanceEntityId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_FaceAmountEntityId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_HomeValueEntityId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_InterestPaidLastYearEnt~",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_InterestPaidYTDEntityId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_LastPaymentAmountEntity~",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_LastPaymentEntityId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_LoanPayoffAmountEntityId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_MarginBalanceEntityId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_MaturityAmountEntityId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_MinimumAmountDueEntityId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_MoneyMarketBalanceEntit~",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_OriginalLoanAmountEntit~",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_OverDraftLimitEntityId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_PremiumEntityId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_PrincipalBalanceEntityId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_RecurringPaymentEntityId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_RemainingBalanceEntityId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_RunningBalanceEntityId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_ShortBalanceEntityId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_TotalCashLimitEntityId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_TotalCreditLimitEntityId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_TotalCreditLineEntityId",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_TotalUnvestedBalanceEnt~",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_TotalVestedBalanceEntit~",
                table: "DataExtractAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractDatasets_DataExtractAccounts_DataExtractAccountE~",
                table: "DataExtractDatasets");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractUserDatas_DataExtractUsers_UserEntityId",
                table: "DataExtractUserDatas");

            migrationBuilder.DropForeignKey(
                name: "FK_DataExtractUserDatas_Datas_DataEntityId",
                table: "DataExtractUserDatas");

            migrationBuilder.DropForeignKey(
                name: "FK_DataSets_ProviderAccounts_ProviderAccountEntityId",
                table: "DataSets");

            migrationBuilder.DropForeignKey(
                name: "FK_DataSets_YodleeAccounts_AccountEntityId",
                table: "DataSets");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailCategories_TransactionCategories_TransactionCategoryE~",
                table: "DetailCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Emails_Profiles_ProfileEntityId",
                table: "Emails");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Datas_dataEntityId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Fields_Rows_RowEntityId",
                table: "Fields");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoricalBalanceAccounts_RunningBalances_BalanceEntityId",
                table: "HistoricalBalanceAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoricalBalances_Networths_NetworthDetailEntityId",
                table: "HistoricalBalances");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoricalBalances_RunningBalances_BalanceEntityId",
                table: "HistoricalBalances");

            migrationBuilder.DropForeignKey(
                name: "FK_Holders_Names_NameEntityId",
                table: "Holders");

            migrationBuilder.DropForeignKey(
                name: "FK_Holders_YodleeVerifiedAccount_VerifiedAccountEntityId",
                table: "Holders");

            migrationBuilder.DropForeignKey(
                name: "FK_Holdings_DataExtractUserDatas_DataExtractUserDataEntityId",
                table: "Holdings");

            migrationBuilder.DropForeignKey(
                name: "FK_Holdings_HoldingsSummarys_HoldingsSummaryEntityId",
                table: "Holdings");

            migrationBuilder.DropForeignKey(
                name: "FK_Holdings_RunningBalances_AccruedIncomeEntityId",
                table: "Holdings");

            migrationBuilder.DropForeignKey(
                name: "FK_Holdings_RunningBalances_AccruedInterestEntityId",
                table: "Holdings");

            migrationBuilder.DropForeignKey(
                name: "FK_Holdings_RunningBalances_CostBasisEntityId",
                table: "Holdings");

            migrationBuilder.DropForeignKey(
                name: "FK_Holdings_RunningBalances_PriceEntityId",
                table: "Holdings");

            migrationBuilder.DropForeignKey(
                name: "FK_Holdings_RunningBalances_SpreadEntityId",
                table: "Holdings");

            migrationBuilder.DropForeignKey(
                name: "FK_Holdings_RunningBalances_StrikePriceEntityId",
                table: "Holdings");

            migrationBuilder.DropForeignKey(
                name: "FK_Holdings_RunningBalances_UnvestedValueEntityId",
                table: "Holdings");

            migrationBuilder.DropForeignKey(
                name: "FK_Holdings_RunningBalances_ValueEntityId",
                table: "Holdings");

            migrationBuilder.DropForeignKey(
                name: "FK_Holdings_RunningBalances_VestedValueEntityId",
                table: "Holdings");

            migrationBuilder.DropForeignKey(
                name: "FK_HoldingsAccounts_HoldingsSummarys_HoldingsSummaryEntityId",
                table: "HoldingsAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_HoldingsAccounts_RunningBalances_ValueEntityId",
                table: "HoldingsAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_HoldingsSummarys_RunningBalances_ValueEntityId",
                table: "HoldingsSummarys");

            migrationBuilder.DropForeignKey(
                name: "FK_Identifiers_Holders_HolderEntityId",
                table: "Identifiers");

            migrationBuilder.DropForeignKey(
                name: "FK_Identifiers_Profiles_ProfileEntityId",
                table: "Identifiers");

            migrationBuilder.DropForeignKey(
                name: "FK_Links_UserDatas_UserDataEntityId",
                table: "Links");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanPayoffDetails_RunningBalances_OutstandingBalanceEntityId",
                table: "LoanPayoffDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanPayoffDetails_RunningBalances_PayoffAmountEntityId",
                table: "LoanPayoffDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_LoginForms_ProviderAccounts_ProviderAccountEntityId",
                table: "LoginForms");

            migrationBuilder.DropForeignKey(
                name: "FK_LoginForms_Providers_ProviderEntityId",
                table: "LoginForms");

            migrationBuilder.DropForeignKey(
                name: "FK_Merchants_Addresses_AddressEntityId",
                table: "Merchants");

            migrationBuilder.DropForeignKey(
                name: "FK_Merchants_Contacts_ContactEntityId",
                table: "Merchants");

            migrationBuilder.DropForeignKey(
                name: "FK_Merchants_Coordinates_CoordinatesEntityId",
                table: "Merchants");

            migrationBuilder.DropForeignKey(
                name: "FK_Networths_RunningBalances_AssetEntityId",
                table: "Networths");

            migrationBuilder.DropForeignKey(
                name: "FK_Networths_RunningBalances_LiabilityEntityId",
                table: "Networths");

            migrationBuilder.DropForeignKey(
                name: "FK_Networths_RunningBalances_NetworthEntityId",
                table: "Networths");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumbers_Profiles_ProfileEntityId",
                table: "PhoneNumbers");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Names_NameEntityId",
                table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_ProviderAccounts_ProviderAccountPreference_PreferencesEntit~",
                table: "ProviderAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProviderCounts_Totals_TotalEntityId",
                table: "ProviderCounts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProvidersDatasets_Providers_ProviderEntityId",
                table: "ProvidersDatasets");

            migrationBuilder.DropForeignKey(
                name: "FK_RewardBalances_DataExtractAccounts_DataExtractAccountEntity~",
                table: "RewardBalances");

            migrationBuilder.DropForeignKey(
                name: "FK_Rows_LoginForms_LoginFormEntityId",
                table: "Rows");

            migrationBuilder.DropForeignKey(
                name: "FK_RuleClauses_Rules_RuleEntityId",
                table: "RuleClauses");

            migrationBuilder.DropForeignKey(
                name: "FK_SecurityHoldings_Security_SecurityEntityId",
                table: "SecurityHoldings");

            migrationBuilder.DropForeignKey(
                name: "FK_StockExchangeDetails_Security_SecurityEntityId",
                table: "StockExchangeDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SummaryDetails_RunningBalances_CreditTotalEntityId",
                table: "SummaryDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SummaryDetails_RunningBalances_DebitTotalEntityId",
                table: "SummaryDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SummaryDetails_Summarys_SummaryEntityId",
                table: "SummaryDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Summarys_RunningBalances_CreditTotalEntityId",
                table: "Summarys");

            migrationBuilder.DropForeignKey(
                name: "FK_Summarys_RunningBalances_DebitTotalEntityId",
                table: "Summarys");

            migrationBuilder.DropForeignKey(
                name: "FK_Summarys_TransactionsLinks_LinksEntityId",
                table: "Summarys");

            migrationBuilder.DropForeignKey(
                name: "FK_Summarys_TransactionsSummarys_TransactionsSummaryEntityId",
                table: "Summarys");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionCriterias_VerifyAccountDTOs_VerifyAccountDTOEnti~",
                table: "TransactionCriterias");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionsSummarys_RunningBalances_CreditTotalEntityId",
                table: "TransactionsSummarys");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionsSummarys_RunningBalances_DebitTotalEntityId",
                table: "TransactionsSummarys");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionsSummarys_TransactionsLinks_LinksEntityId",
                table: "TransactionsSummarys");

            migrationBuilder.DropForeignKey(
                name: "FK_UpdateAccountDetails_Addresses_AddressEntityId",
                table: "UpdateAccountDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_UpdateAccountDetails_RunningBalances_AmountDueEntityId",
                table: "UpdateAccountDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_UpdateAccountDetails_RunningBalances_BalanceEntityId",
                table: "UpdateAccountDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_UpdateAccountDetails_RunningBalances_HomeValueEntityId",
                table: "UpdateAccountDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDatas_DataExtractUsers_UserEntityId",
                table: "UserDatas");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_AmountDueEntityId",
                table: "YodleeAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_AvailableBalanceEntityId",
                table: "YodleeAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_AvailableCashEntityId",
                table: "YodleeAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_AvailableCreditEntityId",
                table: "YodleeAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_BalanceEntityId",
                table: "YodleeAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_CashEntityId",
                table: "YodleeAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_CurrentBalanceEntityId",
                table: "YodleeAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_LastPaymentAmountEntityId",
                table: "YodleeAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_MarginBalanceEntityId",
                table: "YodleeAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_MinimumAmountDueEntityId",
                table: "YodleeAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_OriginalLoanAmountEntityId",
                table: "YodleeAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_PrincipalBalanceEntityId",
                table: "YodleeAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_RunningBalanceEntityId",
                table: "YodleeAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_TotalCashLimitEntityId",
                table: "YodleeAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_TotalCreditLineEntityId",
                table: "YodleeAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeAccounts_VerifyAccountDTOs_VerifyAccountDTOEntityId",
                table: "YodleeAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeAmounts_Coverages_CoverageEntityId",
                table: "YodleeAmounts");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeAmounts_RunningBalances_coverEntityId",
                table: "YodleeAmounts");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeAmounts_RunningBalances_MetEntityId",
                table: "YodleeAmounts");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeIntermediary_YodleeTransactions_TransactionEntityId",
                table: "YodleeIntermediary");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeStatements_RunningBalances_AmountDueEntityId",
                table: "YodleeStatements");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeStatements_RunningBalances_CashAdvanceEntityId",
                table: "YodleeStatements");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeStatements_RunningBalances_InterestAmountEntityId",
                table: "YodleeStatements");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeStatements_RunningBalances_LastPaymentAmountEntityId",
                table: "YodleeStatements");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeStatements_RunningBalances_LoanBalanceEntityId",
                table: "YodleeStatements");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeStatements_RunningBalances_MinimumPaymentEntityId",
                table: "YodleeStatements");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeStatements_RunningBalances_NewChargesEntityId",
                table: "YodleeStatements");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeStatements_RunningBalances_PrincipalAmountEntityId",
                table: "YodleeStatements");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeTransactions_Descriptions_DescriptionEntityId",
                table: "YodleeTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeTransactions_Merchants_MerchantEntityId",
                table: "YodleeTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeTransactions_Principals_PrincipalEntityId",
                table: "YodleeTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeTransactions_RunningBalances_AmountEntityId",
                table: "YodleeTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeTransactions_RunningBalances_CommissionEntityId",
                table: "YodleeTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeTransactions_RunningBalances_InterestEntityId",
                table: "YodleeTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeTransactions_RunningBalances_PriceEntityId",
                table: "YodleeTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeTransactions_RunningBalances_RunningBalanceEntityId",
                table: "YodleeTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeUser_Addresses_AddressEntityId",
                table: "YodleeUser");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeUser_Names_NameEntityId",
                table: "YodleeUser");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeUser_Preferences_PreferencesEntityId",
                table: "YodleeUser");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeVerifiedAccount_RunningBalances_AvailableBalanceEntit~",
                table: "YodleeVerifiedAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeVerifiedAccount_RunningBalances_BalanceEntityId",
                table: "YodleeVerifiedAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeVerifiedAccount_RunningBalances_CashEntityId",
                table: "YodleeVerifiedAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_YodleeVerifiedAccount_RunningBalances_CurrentBalanceEntityId",
                table: "YodleeVerifiedAccount");

            migrationBuilder.DropTable(
                name: "HoldingTypes");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "YodleeWrapperIntegrationRequestLog",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "YodleeWrapperIntegrationConfigurations",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "YodleeWrapperIntegrationAuthTokens",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "YodleeWrapperIntegrationApiKeys",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "FullAccountNumberListEntityId",
                table: "YodleeVerifiedAccount",
                newName: "FullAccountNumberListId");

            migrationBuilder.RenameColumn(
                name: "CurrentBalanceEntityId",
                table: "YodleeVerifiedAccount",
                newName: "CurrentBalanceId");

            migrationBuilder.RenameColumn(
                name: "CashEntityId",
                table: "YodleeVerifiedAccount",
                newName: "CashId");

            migrationBuilder.RenameColumn(
                name: "BalanceEntityId",
                table: "YodleeVerifiedAccount",
                newName: "BalanceId");

            migrationBuilder.RenameColumn(
                name: "AvailableBalanceEntityId",
                table: "YodleeVerifiedAccount",
                newName: "AvailableBalanceId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "YodleeVerifiedAccount",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeVerifiedAccount_FullAccountNumberListEntityId",
                table: "YodleeVerifiedAccount",
                newName: "IX_YodleeVerifiedAccount_FullAccountNumberListId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeVerifiedAccount_CurrentBalanceEntityId",
                table: "YodleeVerifiedAccount",
                newName: "IX_YodleeVerifiedAccount_CurrentBalanceId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeVerifiedAccount_CashEntityId",
                table: "YodleeVerifiedAccount",
                newName: "IX_YodleeVerifiedAccount_CashId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeVerifiedAccount_BalanceEntityId",
                table: "YodleeVerifiedAccount",
                newName: "IX_YodleeVerifiedAccount_BalanceId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeVerifiedAccount_AvailableBalanceEntityId",
                table: "YodleeVerifiedAccount",
                newName: "IX_YodleeVerifiedAccount_AvailableBalanceId");

            migrationBuilder.RenameColumn(
                name: "BankTransferCodeEntityId",
                table: "YodleeVerificationAccount",
                newName: "BankTransferCodeId");

            migrationBuilder.RenameColumn(
                name: "AccountType",
                table: "YodleeVerificationAccount",
                newName: "IdType");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "YodleeVerificationAccount",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeVerificationAccount_BankTransferCodeEntityId",
                table: "YodleeVerificationAccount",
                newName: "IX_YodleeVerificationAccount_BankTransferCodeId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "YodleeVerification",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PreferencesEntityId",
                table: "YodleeUser",
                newName: "PreferencesId");

            migrationBuilder.RenameColumn(
                name: "NameEntityId",
                table: "YodleeUser",
                newName: "NameId");

            migrationBuilder.RenameColumn(
                name: "AddressEntityId",
                table: "YodleeUser",
                newName: "AddressId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "YodleeUser",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeUser_PreferencesEntityId",
                table: "YodleeUser",
                newName: "IX_YodleeUser_PreferencesId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeUser_NameEntityId",
                table: "YodleeUser",
                newName: "IX_YodleeUser_NameId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeUser_AddressEntityId",
                table: "YodleeUser",
                newName: "IX_YodleeUser_AddressId");

            migrationBuilder.RenameColumn(
                name: "TransactionCriteriaEntityId",
                table: "YodleeTransactions",
                newName: "TransactionCriteriaId");

            migrationBuilder.RenameColumn(
                name: "RunningBalanceEntityId",
                table: "YodleeTransactions",
                newName: "RunningBalanceId");

            migrationBuilder.RenameColumn(
                name: "PrincipalEntityId",
                table: "YodleeTransactions",
                newName: "PrincipalId");

            migrationBuilder.RenameColumn(
                name: "PriceEntityId",
                table: "YodleeTransactions",
                newName: "PriceId");

            migrationBuilder.RenameColumn(
                name: "MerchantEntityId",
                table: "YodleeTransactions",
                newName: "MerchantId");

            migrationBuilder.RenameColumn(
                name: "InterestEntityId",
                table: "YodleeTransactions",
                newName: "InterestId");

            migrationBuilder.RenameColumn(
                name: "DescriptionEntityId",
                table: "YodleeTransactions",
                newName: "DescriptionId");

            migrationBuilder.RenameColumn(
                name: "DataExtractUserDataEntityId",
                table: "YodleeTransactions",
                newName: "DataExtractUserDataId");

            migrationBuilder.RenameColumn(
                name: "CommissionEntityId",
                table: "YodleeTransactions",
                newName: "CommissionId");

            migrationBuilder.RenameColumn(
                name: "AmountEntityId",
                table: "YodleeTransactions",
                newName: "AmountId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "YodleeTransactions",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeTransactions_TransactionCriteriaEntityId",
                table: "YodleeTransactions",
                newName: "IX_YodleeTransactions_TransactionCriteriaId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeTransactions_RunningBalanceEntityId",
                table: "YodleeTransactions",
                newName: "IX_YodleeTransactions_RunningBalanceId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeTransactions_PrincipalEntityId",
                table: "YodleeTransactions",
                newName: "IX_YodleeTransactions_PrincipalId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeTransactions_PriceEntityId",
                table: "YodleeTransactions",
                newName: "IX_YodleeTransactions_PriceId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeTransactions_MerchantEntityId",
                table: "YodleeTransactions",
                newName: "IX_YodleeTransactions_MerchantId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeTransactions_InterestEntityId",
                table: "YodleeTransactions",
                newName: "IX_YodleeTransactions_InterestId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeTransactions_DescriptionEntityId",
                table: "YodleeTransactions",
                newName: "IX_YodleeTransactions_DescriptionId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeTransactions_DataExtractUserDataEntityId",
                table: "YodleeTransactions",
                newName: "IX_YodleeTransactions_DataExtractUserDataId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeTransactions_CommissionEntityId",
                table: "YodleeTransactions",
                newName: "IX_YodleeTransactions_CommissionId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeTransactions_AmountEntityId",
                table: "YodleeTransactions",
                newName: "IX_YodleeTransactions_AmountId");

            migrationBuilder.RenameColumn(
                name: "PrincipalAmountEntityId",
                table: "YodleeStatements",
                newName: "PrincipalAmountId");

            migrationBuilder.RenameColumn(
                name: "NewChargesEntityId",
                table: "YodleeStatements",
                newName: "NewChargesId");

            migrationBuilder.RenameColumn(
                name: "MinimumPaymentEntityId",
                table: "YodleeStatements",
                newName: "MinimumPaymentId");

            migrationBuilder.RenameColumn(
                name: "LoanBalanceEntityId",
                table: "YodleeStatements",
                newName: "LoanBalanceId");

            migrationBuilder.RenameColumn(
                name: "LastPaymentAmountEntityId",
                table: "YodleeStatements",
                newName: "LastPaymentAmountId");

            migrationBuilder.RenameColumn(
                name: "InterestAmountEntityId",
                table: "YodleeStatements",
                newName: "InterestAmountId");

            migrationBuilder.RenameColumn(
                name: "CashAdvanceEntityId",
                table: "YodleeStatements",
                newName: "CashAdvanceId");

            migrationBuilder.RenameColumn(
                name: "AmountDueEntityId",
                table: "YodleeStatements",
                newName: "AmountDueId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "YodleeStatements",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeStatements_PrincipalAmountEntityId",
                table: "YodleeStatements",
                newName: "IX_YodleeStatements_PrincipalAmountId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeStatements_NewChargesEntityId",
                table: "YodleeStatements",
                newName: "IX_YodleeStatements_NewChargesId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeStatements_MinimumPaymentEntityId",
                table: "YodleeStatements",
                newName: "IX_YodleeStatements_MinimumPaymentId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeStatements_LoanBalanceEntityId",
                table: "YodleeStatements",
                newName: "IX_YodleeStatements_LoanBalanceId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeStatements_LastPaymentAmountEntityId",
                table: "YodleeStatements",
                newName: "IX_YodleeStatements_LastPaymentAmountId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeStatements_InterestAmountEntityId",
                table: "YodleeStatements",
                newName: "IX_YodleeStatements_InterestAmountId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeStatements_CashAdvanceEntityId",
                table: "YodleeStatements",
                newName: "IX_YodleeStatements_CashAdvanceId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeStatements_AmountDueEntityId",
                table: "YodleeStatements",
                newName: "IX_YodleeStatements_AmountDueId");

            migrationBuilder.RenameColumn(
                name: "TransactionCategorizationRuleEntityId",
                table: "YodleeRuleClaus",
                newName: "TransactionCategorizationRuleId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "YodleeRuleClaus",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeRuleClaus_TransactionCategorizationRuleEntityId",
                table: "YodleeRuleClaus",
                newName: "IX_YodleeRuleClaus_TransactionCategorizationRuleId");

            migrationBuilder.RenameColumn(
                name: "TransactionEntityId",
                table: "YodleeIntermediary",
                newName: "TransactionId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "YodleeIntermediary",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeIntermediary_TransactionEntityId",
                table: "YodleeIntermediary",
                newName: "IX_YodleeIntermediary_TransactionId");

            migrationBuilder.RenameColumn(
                name: "coverEntityId",
                table: "YodleeAmounts",
                newName: "coverId");

            migrationBuilder.RenameColumn(
                name: "MetEntityId",
                table: "YodleeAmounts",
                newName: "MetId");

            migrationBuilder.RenameColumn(
                name: "CoverageEntityId",
                table: "YodleeAmounts",
                newName: "CoverageId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "YodleeAmounts",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeAmounts_MetEntityId",
                table: "YodleeAmounts",
                newName: "IX_YodleeAmounts_MetId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeAmounts_coverEntityId",
                table: "YodleeAmounts",
                newName: "IX_YodleeAmounts_coverId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeAmounts_CoverageEntityId",
                table: "YodleeAmounts",
                newName: "IX_YodleeAmounts_CoverageId");

            migrationBuilder.RenameColumn(
                name: "VerifyAccountDTOEntityId",
                table: "YodleeAccounts",
                newName: "VerifyAccountDTOId");

            migrationBuilder.RenameColumn(
                name: "TotalCreditLineEntityId",
                table: "YodleeAccounts",
                newName: "TotalCreditLineId");

            migrationBuilder.RenameColumn(
                name: "TotalCashLimitEntityId",
                table: "YodleeAccounts",
                newName: "TotalCashLimitId");

            migrationBuilder.RenameColumn(
                name: "RunningBalanceEntityId",
                table: "YodleeAccounts",
                newName: "RunningBalanceId");

            migrationBuilder.RenameColumn(
                name: "PrincipalBalanceEntityId",
                table: "YodleeAccounts",
                newName: "PrincipalBalanceId");

            migrationBuilder.RenameColumn(
                name: "OriginalLoanAmountEntityId",
                table: "YodleeAccounts",
                newName: "OriginalLoanAmountId");

            migrationBuilder.RenameColumn(
                name: "MinimumAmountDueEntityId",
                table: "YodleeAccounts",
                newName: "MinimumAmountDueId");

            migrationBuilder.RenameColumn(
                name: "MarginBalanceEntityId",
                table: "YodleeAccounts",
                newName: "MarginBalanceId");

            migrationBuilder.RenameColumn(
                name: "LastPaymentAmountEntityId",
                table: "YodleeAccounts",
                newName: "LastPaymentAmountId");

            migrationBuilder.RenameColumn(
                name: "LastEmployeeContributionAmountEntityId",
                table: "YodleeAccounts",
                newName: "LastEmployeeContributionAmountId");

            migrationBuilder.RenameColumn(
                name: "CurrentBalanceEntityId",
                table: "YodleeAccounts",
                newName: "CurrentBalanceId");

            migrationBuilder.RenameColumn(
                name: "CashEntityId",
                table: "YodleeAccounts",
                newName: "CashId");

            migrationBuilder.RenameColumn(
                name: "BalanceEntityId",
                table: "YodleeAccounts",
                newName: "BalanceId");

            migrationBuilder.RenameColumn(
                name: "AvailableCreditEntityId",
                table: "YodleeAccounts",
                newName: "AvailableCreditId");

            migrationBuilder.RenameColumn(
                name: "AvailableCashEntityId",
                table: "YodleeAccounts",
                newName: "AvailableCashId");

            migrationBuilder.RenameColumn(
                name: "AvailableBalanceEntityId",
                table: "YodleeAccounts",
                newName: "AvailableBalanceId");

            migrationBuilder.RenameColumn(
                name: "AmountDueEntityId",
                table: "YodleeAccounts",
                newName: "AmountDueId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "YodleeAccounts",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeAccounts_VerifyAccountDTOEntityId",
                table: "YodleeAccounts",
                newName: "IX_YodleeAccounts_VerifyAccountDTOId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeAccounts_TotalCreditLineEntityId",
                table: "YodleeAccounts",
                newName: "IX_YodleeAccounts_TotalCreditLineId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeAccounts_TotalCashLimitEntityId",
                table: "YodleeAccounts",
                newName: "IX_YodleeAccounts_TotalCashLimitId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeAccounts_RunningBalanceEntityId",
                table: "YodleeAccounts",
                newName: "IX_YodleeAccounts_RunningBalanceId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeAccounts_PrincipalBalanceEntityId",
                table: "YodleeAccounts",
                newName: "IX_YodleeAccounts_PrincipalBalanceId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeAccounts_OriginalLoanAmountEntityId",
                table: "YodleeAccounts",
                newName: "IX_YodleeAccounts_OriginalLoanAmountId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeAccounts_MinimumAmountDueEntityId",
                table: "YodleeAccounts",
                newName: "IX_YodleeAccounts_MinimumAmountDueId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeAccounts_MarginBalanceEntityId",
                table: "YodleeAccounts",
                newName: "IX_YodleeAccounts_MarginBalanceId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeAccounts_LastPaymentAmountEntityId",
                table: "YodleeAccounts",
                newName: "IX_YodleeAccounts_LastPaymentAmountId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeAccounts_LastEmployeeContributionAmountEntityId",
                table: "YodleeAccounts",
                newName: "IX_YodleeAccounts_LastEmployeeContributionAmountId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeAccounts_CurrentBalanceEntityId",
                table: "YodleeAccounts",
                newName: "IX_YodleeAccounts_CurrentBalanceId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeAccounts_CashEntityId",
                table: "YodleeAccounts",
                newName: "IX_YodleeAccounts_CashId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeAccounts_BalanceEntityId",
                table: "YodleeAccounts",
                newName: "IX_YodleeAccounts_BalanceId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeAccounts_AvailableCreditEntityId",
                table: "YodleeAccounts",
                newName: "IX_YodleeAccounts_AvailableCreditId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeAccounts_AvailableCashEntityId",
                table: "YodleeAccounts",
                newName: "IX_YodleeAccounts_AvailableCashId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeAccounts_AvailableBalanceEntityId",
                table: "YodleeAccounts",
                newName: "IX_YodleeAccounts_AvailableBalanceId");

            migrationBuilder.RenameIndex(
                name: "IX_YodleeAccounts_AmountDueEntityId",
                table: "YodleeAccounts",
                newName: "IX_YodleeAccounts_AmountDueId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "YodleeAccessTokens",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "VerifyAccountTransactionCriterias",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "VerifyAccountDTOs",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "UserProfileDetailProviderAccounts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserEntityId",
                table: "UserDatas",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "UserDatas",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_UserDatas_UserEntityId",
                table: "UserDatas",
                newName: "IX_UserDatas_UserId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "UpdateProviderAccountFields",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "UpdateProviderAccountDataSets",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UpdateProviderAccountDataSetEntityId",
                table: "UpdateProviderAccountAttributes",
                newName: "UpdateProviderAccountDataSetId");

            migrationBuilder.RenameColumn(
                name: "ContainerAttributesEntityId",
                table: "UpdateProviderAccountAttributes",
                newName: "ContainerAttributesId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "UpdateProviderAccountAttributes",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_UpdateProviderAccountAttributes_ContainerAttributesEntityId",
                table: "UpdateProviderAccountAttributes",
                newName: "IX_UpdateProviderAccountAttributes_ContainerAttributesId");

            migrationBuilder.RenameColumn(
                name: "HomeValueEntityId",
                table: "UpdateAccountDetails",
                newName: "HomeValueId");

            migrationBuilder.RenameColumn(
                name: "BalanceEntityId",
                table: "UpdateAccountDetails",
                newName: "BalanceId");

            migrationBuilder.RenameColumn(
                name: "AmountDueEntityId",
                table: "UpdateAccountDetails",
                newName: "AmountDueId");

            migrationBuilder.RenameColumn(
                name: "AddressEntityId",
                table: "UpdateAccountDetails",
                newName: "AddressId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "UpdateAccountDetails",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_UpdateAccountDetails_HomeValueEntityId",
                table: "UpdateAccountDetails",
                newName: "IX_UpdateAccountDetails_HomeValueId");

            migrationBuilder.RenameIndex(
                name: "IX_UpdateAccountDetails_BalanceEntityId",
                table: "UpdateAccountDetails",
                newName: "IX_UpdateAccountDetails_BalanceId");

            migrationBuilder.RenameIndex(
                name: "IX_UpdateAccountDetails_AmountDueEntityId",
                table: "UpdateAccountDetails",
                newName: "IX_UpdateAccountDetails_AmountDueId");

            migrationBuilder.RenameIndex(
                name: "IX_UpdateAccountDetails_AddressEntityId",
                table: "UpdateAccountDetails",
                newName: "IX_UpdateAccountDetails_AddressId");

            migrationBuilder.RenameColumn(
                name: "LinksEntityId",
                table: "TransactionsSummarys",
                newName: "LinksId");

            migrationBuilder.RenameColumn(
                name: "DebitTotalEntityId",
                table: "TransactionsSummarys",
                newName: "DebitTotalId");

            migrationBuilder.RenameColumn(
                name: "CreditTotalEntityId",
                table: "TransactionsSummarys",
                newName: "CreditTotalId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "TransactionsSummarys",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionsSummarys_LinksEntityId",
                table: "TransactionsSummarys",
                newName: "IX_TransactionsSummarys_LinksId");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionsSummarys_DebitTotalEntityId",
                table: "TransactionsSummarys",
                newName: "IX_TransactionsSummarys_DebitTotalId");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionsSummarys_CreditTotalEntityId",
                table: "TransactionsSummarys",
                newName: "IX_TransactionsSummarys_CreditTotalId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "TransactionsLinks",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "VerifyAccountDTOEntityId",
                table: "TransactionCriterias",
                newName: "VerifyAccountDTOId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "TransactionCriterias",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionCriterias_VerifyAccountDTOEntityId",
                table: "TransactionCriterias",
                newName: "IX_TransactionCriterias_VerifyAccountDTOId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "TransactionCategorizationRules",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "TransactionCategories",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "Totals",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TransactionsSummaryEntityId",
                table: "Summarys",
                newName: "TransactionsSummaryId");

            migrationBuilder.RenameColumn(
                name: "LinksEntityId",
                table: "Summarys",
                newName: "LinksId");

            migrationBuilder.RenameColumn(
                name: "DebitTotalEntityId",
                table: "Summarys",
                newName: "DebitTotalId");

            migrationBuilder.RenameColumn(
                name: "CreditTotalEntityId",
                table: "Summarys",
                newName: "CreditTotalId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "Summarys",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Summarys_TransactionsSummaryEntityId",
                table: "Summarys",
                newName: "IX_Summarys_TransactionsSummaryId");

            migrationBuilder.RenameIndex(
                name: "IX_Summarys_LinksEntityId",
                table: "Summarys",
                newName: "IX_Summarys_LinksId");

            migrationBuilder.RenameIndex(
                name: "IX_Summarys_DebitTotalEntityId",
                table: "Summarys",
                newName: "IX_Summarys_DebitTotalId");

            migrationBuilder.RenameIndex(
                name: "IX_Summarys_CreditTotalEntityId",
                table: "Summarys",
                newName: "IX_Summarys_CreditTotalId");

            migrationBuilder.RenameColumn(
                name: "SummaryEntityId",
                table: "SummaryDetails",
                newName: "SummaryId");

            migrationBuilder.RenameColumn(
                name: "DebitTotalEntityId",
                table: "SummaryDetails",
                newName: "DebitTotalId");

            migrationBuilder.RenameColumn(
                name: "CreditTotalEntityId",
                table: "SummaryDetails",
                newName: "CreditTotalId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "SummaryDetails",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_SummaryDetails_SummaryEntityId",
                table: "SummaryDetails",
                newName: "IX_SummaryDetails_SummaryId");

            migrationBuilder.RenameIndex(
                name: "IX_SummaryDetails_DebitTotalEntityId",
                table: "SummaryDetails",
                newName: "IX_SummaryDetails_DebitTotalId");

            migrationBuilder.RenameIndex(
                name: "IX_SummaryDetails_CreditTotalEntityId",
                table: "SummaryDetails",
                newName: "IX_SummaryDetails_CreditTotalId");

            migrationBuilder.RenameColumn(
                name: "SecurityEntityId",
                table: "StockExchangeDetails",
                newName: "SecurityId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "StockExchangeDetails",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_StockExchangeDetails_SecurityEntityId",
                table: "StockExchangeDetails",
                newName: "IX_StockExchangeDetails_SecurityId");

            migrationBuilder.RenameColumn(
                name: "SecurityEntityId",
                table: "SecurityHoldings",
                newName: "SecurityId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "SecurityHoldings",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_SecurityHoldings_SecurityEntityId",
                table: "SecurityHoldings",
                newName: "IX_SecurityHoldings_SecurityId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "Security",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "RunningBalances",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "Rules",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "RuleEntityId",
                table: "RuleClauses",
                newName: "RuleId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "RuleClauses",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_RuleClauses_RuleEntityId",
                table: "RuleClauses",
                newName: "IX_RuleClauses_RuleId");

            migrationBuilder.RenameColumn(
                name: "LoginFormEntityId",
                table: "Rows",
                newName: "LoginFormId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "Rows",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Rows_LoginFormEntityId",
                table: "Rows",
                newName: "IX_Rows_LoginFormId");

            migrationBuilder.RenameColumn(
                name: "DataExtractAccountEntityId",
                table: "RewardBalances",
                newName: "DataExtractAccountId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "RewardBalances",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_RewardBalances_DataExtractAccountEntityId",
                table: "RewardBalances",
                newName: "IX_RewardBalances_DataExtractAccountId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "PublicKeys",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProviderEntityId",
                table: "ProvidersDatasets",
                newName: "ProviderId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "ProvidersDatasets",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_ProvidersDatasets_ProviderEntityId",
                table: "ProvidersDatasets",
                newName: "IX_ProvidersDatasets_ProviderId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "Providers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TotalEntityId",
                table: "ProviderCounts",
                newName: "TotalId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "ProviderCounts",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_ProviderCounts_TotalEntityId",
                table: "ProviderCounts",
                newName: "IX_ProviderCounts_TotalId");

            migrationBuilder.RenameColumn(
                name: "PreferencesEntityId",
                table: "ProviderAccounts",
                newName: "PreferencesId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "ProviderAccounts",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_ProviderAccounts_PreferencesEntityId",
                table: "ProviderAccounts",
                newName: "IX_ProviderAccounts_PreferencesId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "ProviderAccountPreference",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProviderAccountProfileEntityId",
                table: "Profiles",
                newName: "ProviderAccountProfileId");

            migrationBuilder.RenameColumn(
                name: "NameEntityId",
                table: "Profiles",
                newName: "NameId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "Profiles",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Profiles_ProviderAccountProfileEntityId",
                table: "Profiles",
                newName: "IX_Profiles_ProviderAccountProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Profiles_NameEntityId",
                table: "Profiles",
                newName: "IX_Profiles_NameId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "Principals",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "Preferences",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProfileEntityId",
                table: "PhoneNumbers",
                newName: "ProfileId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "PhoneNumbers",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_PhoneNumbers_ProfileEntityId",
                table: "PhoneNumbers",
                newName: "IX_PhoneNumbers_ProfileId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "NotificationEvent",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "NetworthEntityId",
                table: "Networths",
                newName: "NetworthId");

            migrationBuilder.RenameColumn(
                name: "LiabilityEntityId",
                table: "Networths",
                newName: "LiabilityId");

            migrationBuilder.RenameColumn(
                name: "AssetEntityId",
                table: "Networths",
                newName: "AssetId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "Networths",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Networths_NetworthEntityId",
                table: "Networths",
                newName: "IX_Networths_NetworthId");

            migrationBuilder.RenameIndex(
                name: "IX_Networths_LiabilityEntityId",
                table: "Networths",
                newName: "IX_Networths_LiabilityId");

            migrationBuilder.RenameIndex(
                name: "IX_Networths_AssetEntityId",
                table: "Networths",
                newName: "IX_Networths_AssetId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "Names",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CoordinatesEntityId",
                table: "Merchants",
                newName: "CoordinatesId");

            migrationBuilder.RenameColumn(
                name: "ContactEntityId",
                table: "Merchants",
                newName: "ContactId");

            migrationBuilder.RenameColumn(
                name: "AddressEntityId",
                table: "Merchants",
                newName: "AddressId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "Merchants",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Merchants_CoordinatesEntityId",
                table: "Merchants",
                newName: "IX_Merchants_CoordinatesId");

            migrationBuilder.RenameIndex(
                name: "IX_Merchants_ContactEntityId",
                table: "Merchants",
                newName: "IX_Merchants_ContactId");

            migrationBuilder.RenameIndex(
                name: "IX_Merchants_AddressEntityId",
                table: "Merchants",
                newName: "IX_Merchants_AddressId");

            migrationBuilder.RenameColumn(
                name: "ProviderEntityId",
                table: "LoginForms",
                newName: "ProviderId");

            migrationBuilder.RenameColumn(
                name: "ProviderAccountEntityId",
                table: "LoginForms",
                newName: "ProviderAccountId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "LoginForms",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_LoginForms_ProviderEntityId",
                table: "LoginForms",
                newName: "IX_LoginForms_ProviderId");

            migrationBuilder.RenameIndex(
                name: "IX_LoginForms_ProviderAccountEntityId",
                table: "LoginForms",
                newName: "IX_LoginForms_ProviderAccountId");

            migrationBuilder.RenameColumn(
                name: "PayoffAmountEntityId",
                table: "LoanPayoffDetails",
                newName: "PayoffAmountId");

            migrationBuilder.RenameColumn(
                name: "OutstandingBalanceEntityId",
                table: "LoanPayoffDetails",
                newName: "OutstandingBalanceId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "LoanPayoffDetails",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_LoanPayoffDetails_PayoffAmountEntityId",
                table: "LoanPayoffDetails",
                newName: "IX_LoanPayoffDetails_PayoffAmountId");

            migrationBuilder.RenameIndex(
                name: "IX_LoanPayoffDetails_OutstandingBalanceEntityId",
                table: "LoanPayoffDetails",
                newName: "IX_LoanPayoffDetails_OutstandingBalanceId");

            migrationBuilder.RenameColumn(
                name: "UserDataEntityId",
                table: "Links",
                newName: "UserDataId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "Links",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Links_UserDataEntityId",
                table: "Links",
                newName: "IX_Links_UserDataId");

            migrationBuilder.RenameColumn(
                name: "ProfileEntityId",
                table: "Identifiers",
                newName: "ProfileId");

            migrationBuilder.RenameColumn(
                name: "HolderEntityId",
                table: "Identifiers",
                newName: "HolderId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "Identifiers",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Identifiers_ProfileEntityId",
                table: "Identifiers",
                newName: "IX_Identifiers_ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Identifiers_HolderEntityId",
                table: "Identifiers",
                newName: "IX_Identifiers_HolderId");

            migrationBuilder.RenameColumn(
                name: "ValueEntityId",
                table: "HoldingsSummarys",
                newName: "ValueId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "HoldingsSummarys",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_HoldingsSummarys_ValueEntityId",
                table: "HoldingsSummarys",
                newName: "IX_HoldingsSummarys_ValueId");

            migrationBuilder.RenameColumn(
                name: "ValueEntityId",
                table: "HoldingsAccounts",
                newName: "ValueId");

            migrationBuilder.RenameColumn(
                name: "HoldingsSummaryEntityId",
                table: "HoldingsAccounts",
                newName: "HoldingsSummaryId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "HoldingsAccounts",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_HoldingsAccounts_ValueEntityId",
                table: "HoldingsAccounts",
                newName: "IX_HoldingsAccounts_ValueId");

            migrationBuilder.RenameIndex(
                name: "IX_HoldingsAccounts_HoldingsSummaryEntityId",
                table: "HoldingsAccounts",
                newName: "IX_HoldingsAccounts_HoldingsSummaryId");

            migrationBuilder.RenameColumn(
                name: "VestedValueEntityId",
                table: "Holdings",
                newName: "VestedValueId");

            migrationBuilder.RenameColumn(
                name: "ValueEntityId",
                table: "Holdings",
                newName: "ValueId");

            migrationBuilder.RenameColumn(
                name: "UnvestedValueEntityId",
                table: "Holdings",
                newName: "UnvestedValueId");

            migrationBuilder.RenameColumn(
                name: "StrikePriceEntityId",
                table: "Holdings",
                newName: "StrikePriceId");

            migrationBuilder.RenameColumn(
                name: "SpreadEntityId",
                table: "Holdings",
                newName: "SpreadId");

            migrationBuilder.RenameColumn(
                name: "PriceEntityId",
                table: "Holdings",
                newName: "PriceId");

            migrationBuilder.RenameColumn(
                name: "HoldingsSummaryEntityId",
                table: "Holdings",
                newName: "HoldingsSummaryId");

            migrationBuilder.RenameColumn(
                name: "DataExtractUserDataEntityId",
                table: "Holdings",
                newName: "DataExtractUserDataId");

            migrationBuilder.RenameColumn(
                name: "CostBasisEntityId",
                table: "Holdings",
                newName: "CostBasisId");

            migrationBuilder.RenameColumn(
                name: "AccruedInterestEntityId",
                table: "Holdings",
                newName: "AccruedInterestId");

            migrationBuilder.RenameColumn(
                name: "AccruedIncomeEntityId",
                table: "Holdings",
                newName: "AccruedIncomeId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "Holdings",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Holdings_VestedValueEntityId",
                table: "Holdings",
                newName: "IX_Holdings_VestedValueId");

            migrationBuilder.RenameIndex(
                name: "IX_Holdings_ValueEntityId",
                table: "Holdings",
                newName: "IX_Holdings_ValueId");

            migrationBuilder.RenameIndex(
                name: "IX_Holdings_UnvestedValueEntityId",
                table: "Holdings",
                newName: "IX_Holdings_UnvestedValueId");

            migrationBuilder.RenameIndex(
                name: "IX_Holdings_StrikePriceEntityId",
                table: "Holdings",
                newName: "IX_Holdings_StrikePriceId");

            migrationBuilder.RenameIndex(
                name: "IX_Holdings_SpreadEntityId",
                table: "Holdings",
                newName: "IX_Holdings_SpreadId");

            migrationBuilder.RenameIndex(
                name: "IX_Holdings_PriceEntityId",
                table: "Holdings",
                newName: "IX_Holdings_PriceId");

            migrationBuilder.RenameIndex(
                name: "IX_Holdings_HoldingsSummaryEntityId",
                table: "Holdings",
                newName: "IX_Holdings_HoldingsSummaryId");

            migrationBuilder.RenameIndex(
                name: "IX_Holdings_DataExtractUserDataEntityId",
                table: "Holdings",
                newName: "IX_Holdings_DataExtractUserDataId");

            migrationBuilder.RenameIndex(
                name: "IX_Holdings_CostBasisEntityId",
                table: "Holdings",
                newName: "IX_Holdings_CostBasisId");

            migrationBuilder.RenameIndex(
                name: "IX_Holdings_AccruedInterestEntityId",
                table: "Holdings",
                newName: "IX_Holdings_AccruedInterestId");

            migrationBuilder.RenameIndex(
                name: "IX_Holdings_AccruedIncomeEntityId",
                table: "Holdings",
                newName: "IX_Holdings_AccruedIncomeId");

            migrationBuilder.RenameColumn(
                name: "VerifiedAccountEntityId",
                table: "Holders",
                newName: "VerifiedAccountId");

            migrationBuilder.RenameColumn(
                name: "NameEntityId",
                table: "Holders",
                newName: "NameId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "Holders",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Holders_VerifiedAccountEntityId",
                table: "Holders",
                newName: "IX_Holders_VerifiedAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Holders_NameEntityId",
                table: "Holders",
                newName: "IX_Holders_NameId");

            migrationBuilder.RenameColumn(
                name: "NetworthDetailEntityId",
                table: "HistoricalBalances",
                newName: "NetworthDetailId");

            migrationBuilder.RenameColumn(
                name: "BalanceEntityId",
                table: "HistoricalBalances",
                newName: "BalanceId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "HistoricalBalances",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_HistoricalBalances_NetworthDetailEntityId",
                table: "HistoricalBalances",
                newName: "IX_HistoricalBalances_NetworthDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_HistoricalBalances_BalanceEntityId",
                table: "HistoricalBalances",
                newName: "IX_HistoricalBalances_BalanceId");

            migrationBuilder.RenameColumn(
                name: "HistoricalAccountEntityId",
                table: "HistoricalBalanceAccounts",
                newName: "HistoricalAccountId");

            migrationBuilder.RenameColumn(
                name: "BalanceEntityId",
                table: "HistoricalBalanceAccounts",
                newName: "BalanceId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "HistoricalBalanceAccounts",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_HistoricalBalanceAccounts_HistoricalAccountEntityId",
                table: "HistoricalBalanceAccounts",
                newName: "IX_HistoricalBalanceAccounts_HistoricalAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_HistoricalBalanceAccounts_BalanceEntityId",
                table: "HistoricalBalanceAccounts",
                newName: "IX_HistoricalBalanceAccounts_BalanceId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "HistoricalAccounts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "FullAccountNumberLists",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "RowEntityId",
                table: "Fields",
                newName: "RowId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "Fields",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Fields_RowEntityId",
                table: "Fields",
                newName: "IX_Fields_RowId");

            migrationBuilder.RenameColumn(
                name: "dataEntityId",
                table: "Events",
                newName: "dataId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "Events",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Events_dataEntityId",
                table: "Events",
                newName: "IX_Events_dataId");

            migrationBuilder.RenameColumn(
                name: "ProfileEntityId",
                table: "Emails",
                newName: "ProfileId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "Emails",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Emails_ProfileEntityId",
                table: "Emails",
                newName: "IX_Emails_ProfileId");

            migrationBuilder.RenameColumn(
                name: "TransactionCategoryEntityId",
                table: "DetailCategories",
                newName: "TransactionCategoryId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "DetailCategories",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_DetailCategories_TransactionCategoryEntityId",
                table: "DetailCategories",
                newName: "IX_DetailCategories_TransactionCategoryId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "Descriptions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProviderAccountEntityId",
                table: "DataSets",
                newName: "ProviderAccountId");

            migrationBuilder.RenameColumn(
                name: "AccountEntityId",
                table: "DataSets",
                newName: "AccountId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "DataSets",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_DataSets_ProviderAccountEntityId",
                table: "DataSets",
                newName: "IX_DataSets_ProviderAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_DataSets_AccountEntityId",
                table: "DataSets",
                newName: "IX_DataSets_AccountId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "Datas",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "DataExtractUsers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserEntityId",
                table: "DataExtractUserDatas",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "DataEntityId",
                table: "DataExtractUserDatas",
                newName: "DataId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "DataExtractUserDatas",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractUserDatas_UserEntityId",
                table: "DataExtractUserDatas",
                newName: "IX_DataExtractUserDatas_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractUserDatas_DataEntityId",
                table: "DataExtractUserDatas",
                newName: "IX_DataExtractUserDatas_DataId");

            migrationBuilder.RenameColumn(
                name: "DataExtractUserDataEntityId",
                table: "DataExtractProviderAccounts",
                newName: "DataExtractUserDataId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "DataExtractProviderAccounts",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractProviderAccounts_DataExtractUserDataEntityId",
                table: "DataExtractProviderAccounts",
                newName: "IX_DataExtractProviderAccounts_DataExtractUserDataId");

            migrationBuilder.RenameColumn(
                name: "DataExtractProviderAccountEntityId",
                table: "DataExtractDatasets",
                newName: "DataExtractProviderAccountId");

            migrationBuilder.RenameColumn(
                name: "DataExtractAccountEntityId",
                table: "DataExtractDatasets",
                newName: "DataExtractAccountId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "DataExtractDatasets",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractDatasets_DataExtractProviderAccountEntityId",
                table: "DataExtractDatasets",
                newName: "IX_DataExtractDatasets_DataExtractProviderAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractDatasets_DataExtractAccountEntityId",
                table: "DataExtractDatasets",
                newName: "IX_DataExtractDatasets_DataExtractAccountId");

            migrationBuilder.RenameColumn(
                name: "_401kLoanEntityId",
                table: "DataExtractAccounts",
                newName: "_401kLoanId");

            migrationBuilder.RenameColumn(
                name: "TotalVestedBalanceEntityId",
                table: "DataExtractAccounts",
                newName: "TotalVestedBalanceId");

            migrationBuilder.RenameColumn(
                name: "TotalUnvestedBalanceEntityId",
                table: "DataExtractAccounts",
                newName: "TotalUnvestedBalanceId");

            migrationBuilder.RenameColumn(
                name: "TotalCreditLineEntityId",
                table: "DataExtractAccounts",
                newName: "TotalCreditLineId");

            migrationBuilder.RenameColumn(
                name: "TotalCreditLimitEntityId",
                table: "DataExtractAccounts",
                newName: "TotalCreditLimitId");

            migrationBuilder.RenameColumn(
                name: "TotalCashLimitEntityId",
                table: "DataExtractAccounts",
                newName: "TotalCashLimitId");

            migrationBuilder.RenameColumn(
                name: "ShortBalanceEntityId",
                table: "DataExtractAccounts",
                newName: "ShortBalanceId");

            migrationBuilder.RenameColumn(
                name: "RunningBalanceEntityId",
                table: "DataExtractAccounts",
                newName: "RunningBalanceId");

            migrationBuilder.RenameColumn(
                name: "RemainingBalanceEntityId",
                table: "DataExtractAccounts",
                newName: "RemainingBalanceId");

            migrationBuilder.RenameColumn(
                name: "RecurringPaymentEntityId",
                table: "DataExtractAccounts",
                newName: "RecurringPaymentId");

            migrationBuilder.RenameColumn(
                name: "PrincipalBalanceEntityId",
                table: "DataExtractAccounts",
                newName: "PrincipalBalanceId");

            migrationBuilder.RenameColumn(
                name: "PremiumEntityId",
                table: "DataExtractAccounts",
                newName: "PremiumId");

            migrationBuilder.RenameColumn(
                name: "OverDraftLimitEntityId",
                table: "DataExtractAccounts",
                newName: "OverDraftLimitId");

            migrationBuilder.RenameColumn(
                name: "OriginalLoanAmountEntityId",
                table: "DataExtractAccounts",
                newName: "OriginalLoanAmountId");

            migrationBuilder.RenameColumn(
                name: "MoneyMarketBalanceEntityId",
                table: "DataExtractAccounts",
                newName: "MoneyMarketBalanceId");

            migrationBuilder.RenameColumn(
                name: "MinimumAmountDueEntityId",
                table: "DataExtractAccounts",
                newName: "MinimumAmountDueId");

            migrationBuilder.RenameColumn(
                name: "MaturityAmountEntityId",
                table: "DataExtractAccounts",
                newName: "MaturityAmountId");

            migrationBuilder.RenameColumn(
                name: "MarginBalanceEntityId",
                table: "DataExtractAccounts",
                newName: "MarginBalanceId");

            migrationBuilder.RenameColumn(
                name: "LoanPayoffDetailsEntityId",
                table: "DataExtractAccounts",
                newName: "LoanPayoffDetailsId");

            migrationBuilder.RenameColumn(
                name: "LoanPayoffAmountEntityId",
                table: "DataExtractAccounts",
                newName: "LoanPayoffAmountId");

            migrationBuilder.RenameColumn(
                name: "LastPaymentEntityId",
                table: "DataExtractAccounts",
                newName: "LastPaymentId");

            migrationBuilder.RenameColumn(
                name: "LastPaymentAmountEntityId",
                table: "DataExtractAccounts",
                newName: "LastPaymentAmountId");

            migrationBuilder.RenameColumn(
                name: "LastEmployeeContributionAmountEntityId",
                table: "DataExtractAccounts",
                newName: "LastEmployeeContributionAmountId");

            migrationBuilder.RenameColumn(
                name: "InterestPaidYTDEntityId",
                table: "DataExtractAccounts",
                newName: "InterestPaidYTDId");

            migrationBuilder.RenameColumn(
                name: "InterestPaidLastYearEntityId",
                table: "DataExtractAccounts",
                newName: "InterestPaidLastYearId");

            migrationBuilder.RenameColumn(
                name: "HomeValueEntityId",
                table: "DataExtractAccounts",
                newName: "HomeValueId");

            migrationBuilder.RenameColumn(
                name: "FaceAmountEntityId",
                table: "DataExtractAccounts",
                newName: "FaceAmountId");

            migrationBuilder.RenameColumn(
                name: "EscrowBalanceEntityId",
                table: "DataExtractAccounts",
                newName: "EscrowBalanceId");

            migrationBuilder.RenameColumn(
                name: "DeathBenefitEntityId",
                table: "DataExtractAccounts",
                newName: "DeathBenefitId");

            migrationBuilder.RenameColumn(
                name: "DataExtractUserDataEntityId",
                table: "DataExtractAccounts",
                newName: "DataExtractUserDataId");

            migrationBuilder.RenameColumn(
                name: "CurrentBalanceEntityId",
                table: "DataExtractAccounts",
                newName: "CurrentBalanceId");

            migrationBuilder.RenameColumn(
                name: "CashValueEntityId",
                table: "DataExtractAccounts",
                newName: "CashValueId");

            migrationBuilder.RenameColumn(
                name: "CashEntityId",
                table: "DataExtractAccounts",
                newName: "CashId");

            migrationBuilder.RenameColumn(
                name: "BalanceEntityId",
                table: "DataExtractAccounts",
                newName: "BalanceId");

            migrationBuilder.RenameColumn(
                name: "AvailableCreditEntityId",
                table: "DataExtractAccounts",
                newName: "AvailableCreditId");

            migrationBuilder.RenameColumn(
                name: "AvailableCashEntityId",
                table: "DataExtractAccounts",
                newName: "AvailableCashId");

            migrationBuilder.RenameColumn(
                name: "AvailableBalanceEntityId",
                table: "DataExtractAccounts",
                newName: "AvailableBalanceId");

            migrationBuilder.RenameColumn(
                name: "AnnuityBalanceEntityId",
                table: "DataExtractAccounts",
                newName: "AnnuityBalanceId");

            migrationBuilder.RenameColumn(
                name: "AmountDueEntityId",
                table: "DataExtractAccounts",
                newName: "AmountDueId");

            migrationBuilder.RenameColumn(
                name: "AddressEntityId",
                table: "DataExtractAccounts",
                newName: "AddressId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "DataExtractAccounts",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_TotalVestedBalanceEntityId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_TotalVestedBalanceId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_TotalUnvestedBalanceEntityId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_TotalUnvestedBalanceId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_TotalCreditLineEntityId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_TotalCreditLineId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_TotalCreditLimitEntityId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_TotalCreditLimitId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_TotalCashLimitEntityId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_TotalCashLimitId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_ShortBalanceEntityId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_ShortBalanceId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_RunningBalanceEntityId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_RunningBalanceId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_RemainingBalanceEntityId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_RemainingBalanceId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_RecurringPaymentEntityId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_RecurringPaymentId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_PrincipalBalanceEntityId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_PrincipalBalanceId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_PremiumEntityId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_PremiumId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_OverDraftLimitEntityId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_OverDraftLimitId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_OriginalLoanAmountEntityId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_OriginalLoanAmountId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_MoneyMarketBalanceEntityId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_MoneyMarketBalanceId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_MinimumAmountDueEntityId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_MinimumAmountDueId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_MaturityAmountEntityId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_MaturityAmountId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_MarginBalanceEntityId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_MarginBalanceId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_LoanPayoffDetailsEntityId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_LoanPayoffDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_LoanPayoffAmountEntityId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_LoanPayoffAmountId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_LastPaymentEntityId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_LastPaymentId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_LastPaymentAmountEntityId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_LastPaymentAmountId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_LastEmployeeContributionAmountEntityId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_LastEmployeeContributionAmountId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_InterestPaidYTDEntityId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_InterestPaidYTDId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_InterestPaidLastYearEntityId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_InterestPaidLastYearId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_HomeValueEntityId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_HomeValueId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_FaceAmountEntityId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_FaceAmountId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_EscrowBalanceEntityId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_EscrowBalanceId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_DeathBenefitEntityId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_DeathBenefitId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_DataExtractUserDataEntityId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_DataExtractUserDataId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_CurrentBalanceEntityId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_CurrentBalanceId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_CashValueEntityId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_CashValueId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_CashEntityId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_CashId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_BalanceEntityId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_BalanceId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_AvailableCreditEntityId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_AvailableCreditId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_AvailableCashEntityId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_AvailableCashId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_AvailableBalanceEntityId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_AvailableBalanceId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_AnnuityBalanceEntityId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_AnnuityBalanceId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_AmountDueEntityId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_AmountDueId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts_AddressEntityId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts_AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_DataExtractAccounts__401kLoanEntityId",
                table: "DataExtractAccounts",
                newName: "IX_DataExtractAccounts__401kLoanId");

            migrationBuilder.RenameColumn(
                name: "DataExtractAccountEntityId",
                table: "Coverages",
                newName: "DataExtractAccountId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "Coverages",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Coverages_DataExtractAccountEntityId",
                table: "Coverages",
                newName: "IX_Coverages_DataExtractAccountId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "Coordinates",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "LOANEntityId",
                table: "ContainerAttributes",
                newName: "LOANId");

            migrationBuilder.RenameColumn(
                name: "INVESTMENTEntityId",
                table: "ContainerAttributes",
                newName: "INVESTMENTId");

            migrationBuilder.RenameColumn(
                name: "INSURANCEEntityId",
                table: "ContainerAttributes",
                newName: "INSURANCEId");

            migrationBuilder.RenameColumn(
                name: "CREDITCARDEntityId",
                table: "ContainerAttributes",
                newName: "CREDITCARDId");

            migrationBuilder.RenameColumn(
                name: "BANKEntityId",
                table: "ContainerAttributes",
                newName: "BANKId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "ContainerAttributes",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_ContainerAttributes_LOANEntityId",
                table: "ContainerAttributes",
                newName: "IX_ContainerAttributes_LOANId");

            migrationBuilder.RenameIndex(
                name: "IX_ContainerAttributes_INVESTMENTEntityId",
                table: "ContainerAttributes",
                newName: "IX_ContainerAttributes_INVESTMENTId");

            migrationBuilder.RenameIndex(
                name: "IX_ContainerAttributes_INSURANCEEntityId",
                table: "ContainerAttributes",
                newName: "IX_ContainerAttributes_INSURANCEId");

            migrationBuilder.RenameIndex(
                name: "IX_ContainerAttributes_CREDITCARDEntityId",
                table: "ContainerAttributes",
                newName: "IX_ContainerAttributes_CREDITCARDId");

            migrationBuilder.RenameIndex(
                name: "IX_ContainerAttributes_BANKEntityId",
                table: "ContainerAttributes",
                newName: "IX_ContainerAttributes_BANKId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "Contacts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "CardDetails",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProviderEntityId",
                table: "Capabilities",
                newName: "ProviderId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "Capabilities",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Capabilities_ProviderEntityId",
                table: "Capabilities",
                newName: "IX_Capabilities_ProviderId");

            migrationBuilder.RenameColumn(
                name: "VerifiedAccountEntityId",
                table: "BankTransferCodes",
                newName: "VerifiedAccountId");

            migrationBuilder.RenameColumn(
                name: "DataExtractAccountEntityId",
                table: "BankTransferCodes",
                newName: "DataExtractAccountId");

            migrationBuilder.RenameColumn(
                name: "AccountEntityId",
                table: "BankTransferCodes",
                newName: "AccountId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "BankTransferCodes",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_BankTransferCodes_VerifiedAccountEntityId",
                table: "BankTransferCodes",
                newName: "IX_BankTransferCodes_VerifiedAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_BankTransferCodes_DataExtractAccountEntityId",
                table: "BankTransferCodes",
                newName: "IX_BankTransferCodes_DataExtractAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_BankTransferCodes_AccountEntityId",
                table: "BankTransferCodes",
                newName: "IX_BankTransferCodes_AccountId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "Banks",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProvidersDatasetEntityId",
                table: "Attributes",
                newName: "ProvidersDatasetId");

            migrationBuilder.RenameColumn(
                name: "ContainerAttributesEntityId",
                table: "Attributes",
                newName: "ContainerAttributesId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "Attributes",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Attributes_ProvidersDatasetEntityId",
                table: "Attributes",
                newName: "IX_Attributes_ProvidersDatasetId");

            migrationBuilder.RenameIndex(
                name: "IX_Attributes_ContainerAttributesEntityId",
                table: "Attributes",
                newName: "IX_Attributes_ContainerAttributesId");

            migrationBuilder.RenameColumn(
                name: "HoldingEntityId",
                table: "AssetClassifications",
                newName: "HoldingId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "AssetClassifications",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_AssetClassifications_HoldingEntityId",
                table: "AssetClassifications",
                newName: "IX_AssetClassifications_HoldingId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "AssetClassificationLists",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProfileEntityId",
                table: "Addresses",
                newName: "ProfileId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "Addresses",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_ProfileEntityId",
                table: "Addresses",
                newName: "IX_Addresses_ProfileId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "AddManualResponseAccounts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "HomeValueEntityId",
                table: "AddManualAccounts",
                newName: "HomeValueId");

            migrationBuilder.RenameColumn(
                name: "BalanceEntityId",
                table: "AddManualAccounts",
                newName: "BalanceId");

            migrationBuilder.RenameColumn(
                name: "AmountDueEntityId",
                table: "AddManualAccounts",
                newName: "AmountDueId");

            migrationBuilder.RenameColumn(
                name: "AddressEntityId",
                table: "AddManualAccounts",
                newName: "AddressId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "AddManualAccounts",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_AddManualAccounts_HomeValueEntityId",
                table: "AddManualAccounts",
                newName: "IX_AddManualAccounts_HomeValueId");

            migrationBuilder.RenameIndex(
                name: "IX_AddManualAccounts_BalanceEntityId",
                table: "AddManualAccounts",
                newName: "IX_AddManualAccounts_BalanceId");

            migrationBuilder.RenameIndex(
                name: "IX_AddManualAccounts_AmountDueEntityId",
                table: "AddManualAccounts",
                newName: "IX_AddManualAccounts_AmountDueId");

            migrationBuilder.RenameIndex(
                name: "IX_AddManualAccounts_AddressEntityId",
                table: "AddManualAccounts",
                newName: "IX_AddManualAccounts_AddressId");

            migrationBuilder.RenameColumn(
                name: "TotalBalanceEntityId",
                table: "AccountBalances",
                newName: "TotalBalanceId");

            migrationBuilder.RenameColumn(
                name: "CurrentBalanceEntityId",
                table: "AccountBalances",
                newName: "CurrentBalanceId");

            migrationBuilder.RenameColumn(
                name: "CashEntityId",
                table: "AccountBalances",
                newName: "CashId");

            migrationBuilder.RenameColumn(
                name: "BalanceEntityId",
                table: "AccountBalances",
                newName: "BalanceId");

            migrationBuilder.RenameColumn(
                name: "AvailableBalanceEntityId",
                table: "AccountBalances",
                newName: "AvailableBalanceId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "AccountBalances",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_AccountBalances_TotalBalanceEntityId",
                table: "AccountBalances",
                newName: "IX_AccountBalances_TotalBalanceId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountBalances_CurrentBalanceEntityId",
                table: "AccountBalances",
                newName: "IX_AccountBalances_CurrentBalanceId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountBalances_CashEntityId",
                table: "AccountBalances",
                newName: "IX_AccountBalances_CashId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountBalances_BalanceEntityId",
                table: "AccountBalances",
                newName: "IX_AccountBalances_BalanceId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountBalances_AvailableBalanceEntityId",
                table: "AccountBalances",
                newName: "IX_AccountBalances_AvailableBalanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountBalances_RunningBalances_AvailableBalanceId",
                table: "AccountBalances",
                column: "AvailableBalanceId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountBalances_RunningBalances_BalanceId",
                table: "AccountBalances",
                column: "BalanceId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountBalances_RunningBalances_CashId",
                table: "AccountBalances",
                column: "CashId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountBalances_RunningBalances_CurrentBalanceId",
                table: "AccountBalances",
                column: "CurrentBalanceId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountBalances_RunningBalances_TotalBalanceId",
                table: "AccountBalances",
                column: "TotalBalanceId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AddManualAccounts_Addresses_AddressId",
                table: "AddManualAccounts",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AddManualAccounts_RunningBalances_AmountDueId",
                table: "AddManualAccounts",
                column: "AmountDueId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AddManualAccounts_RunningBalances_BalanceId",
                table: "AddManualAccounts",
                column: "BalanceId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AddManualAccounts_RunningBalances_HomeValueId",
                table: "AddManualAccounts",
                column: "HomeValueId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Profiles_ProfileId",
                table: "Addresses",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetClassifications_Holdings_HoldingId",
                table: "AssetClassifications",
                column: "HoldingId",
                principalTable: "Holdings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attributes_ContainerAttributes_ContainerAttributesId",
                table: "Attributes",
                column: "ContainerAttributesId",
                principalTable: "ContainerAttributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attributes_ProvidersDatasets_ProvidersDatasetId",
                table: "Attributes",
                column: "ProvidersDatasetId",
                principalTable: "ProvidersDatasets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BankTransferCodes_DataExtractAccounts_DataExtractAccountId",
                table: "BankTransferCodes",
                column: "DataExtractAccountId",
                principalTable: "DataExtractAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BankTransferCodes_YodleeAccounts_AccountId",
                table: "BankTransferCodes",
                column: "AccountId",
                principalTable: "YodleeAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BankTransferCodes_YodleeVerifiedAccount_VerifiedAccountId",
                table: "BankTransferCodes",
                column: "VerifiedAccountId",
                principalTable: "YodleeVerifiedAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Capabilities_Providers_ProviderId",
                table: "Capabilities",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContainerAttributes_Banks_BANKId",
                table: "ContainerAttributes",
                column: "BANKId",
                principalTable: "Banks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContainerAttributes_CardDetails_CREDITCARDId",
                table: "ContainerAttributes",
                column: "CREDITCARDId",
                principalTable: "CardDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContainerAttributes_CardDetails_INSURANCEId",
                table: "ContainerAttributes",
                column: "INSURANCEId",
                principalTable: "CardDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContainerAttributes_CardDetails_INVESTMENTId",
                table: "ContainerAttributes",
                column: "INVESTMENTId",
                principalTable: "CardDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContainerAttributes_CardDetails_LOANId",
                table: "ContainerAttributes",
                column: "LOANId",
                principalTable: "CardDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Coverages_DataExtractAccounts_DataExtractAccountId",
                table: "Coverages",
                column: "DataExtractAccountId",
                principalTable: "DataExtractAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_Addresses_AddressId",
                table: "DataExtractAccounts",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_LoanPayoffDetails_LoanPayoffDetailsId",
                table: "DataExtractAccounts",
                column: "LoanPayoffDetailsId",
                principalTable: "LoanPayoffDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances__401kLoanId",
                table: "DataExtractAccounts",
                column: "_401kLoanId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_AmountDueId",
                table: "DataExtractAccounts",
                column: "AmountDueId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_AnnuityBalanceId",
                table: "DataExtractAccounts",
                column: "AnnuityBalanceId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_AvailableBalanceId",
                table: "DataExtractAccounts",
                column: "AvailableBalanceId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_AvailableCashId",
                table: "DataExtractAccounts",
                column: "AvailableCashId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_AvailableCreditId",
                table: "DataExtractAccounts",
                column: "AvailableCreditId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_BalanceId",
                table: "DataExtractAccounts",
                column: "BalanceId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_CashId",
                table: "DataExtractAccounts",
                column: "CashId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_CashValueId",
                table: "DataExtractAccounts",
                column: "CashValueId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_CurrentBalanceId",
                table: "DataExtractAccounts",
                column: "CurrentBalanceId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_DeathBenefitId",
                table: "DataExtractAccounts",
                column: "DeathBenefitId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_EscrowBalanceId",
                table: "DataExtractAccounts",
                column: "EscrowBalanceId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_FaceAmountId",
                table: "DataExtractAccounts",
                column: "FaceAmountId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_HomeValueId",
                table: "DataExtractAccounts",
                column: "HomeValueId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_InterestPaidLastYearId",
                table: "DataExtractAccounts",
                column: "InterestPaidLastYearId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_InterestPaidYTDId",
                table: "DataExtractAccounts",
                column: "InterestPaidYTDId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_LastPaymentAmountId",
                table: "DataExtractAccounts",
                column: "LastPaymentAmountId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_LastPaymentId",
                table: "DataExtractAccounts",
                column: "LastPaymentId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_LoanPayoffAmountId",
                table: "DataExtractAccounts",
                column: "LoanPayoffAmountId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_MarginBalanceId",
                table: "DataExtractAccounts",
                column: "MarginBalanceId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_MaturityAmountId",
                table: "DataExtractAccounts",
                column: "MaturityAmountId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_MinimumAmountDueId",
                table: "DataExtractAccounts",
                column: "MinimumAmountDueId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_MoneyMarketBalanceId",
                table: "DataExtractAccounts",
                column: "MoneyMarketBalanceId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_OriginalLoanAmountId",
                table: "DataExtractAccounts",
                column: "OriginalLoanAmountId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_OverDraftLimitId",
                table: "DataExtractAccounts",
                column: "OverDraftLimitId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_PremiumId",
                table: "DataExtractAccounts",
                column: "PremiumId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_PrincipalBalanceId",
                table: "DataExtractAccounts",
                column: "PrincipalBalanceId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_RecurringPaymentId",
                table: "DataExtractAccounts",
                column: "RecurringPaymentId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_RemainingBalanceId",
                table: "DataExtractAccounts",
                column: "RemainingBalanceId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_RunningBalanceId",
                table: "DataExtractAccounts",
                column: "RunningBalanceId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_ShortBalanceId",
                table: "DataExtractAccounts",
                column: "ShortBalanceId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_TotalCashLimitId",
                table: "DataExtractAccounts",
                column: "TotalCashLimitId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_TotalCreditLimitId",
                table: "DataExtractAccounts",
                column: "TotalCreditLimitId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_TotalCreditLineId",
                table: "DataExtractAccounts",
                column: "TotalCreditLineId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_TotalUnvestedBalanceId",
                table: "DataExtractAccounts",
                column: "TotalUnvestedBalanceId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractAccounts_RunningBalances_TotalVestedBalanceId",
                table: "DataExtractAccounts",
                column: "TotalVestedBalanceId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractDatasets_DataExtractAccounts_DataExtractAccountId",
                table: "DataExtractDatasets",
                column: "DataExtractAccountId",
                principalTable: "DataExtractAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractUserDatas_DataExtractUsers_UserId",
                table: "DataExtractUserDatas",
                column: "UserId",
                principalTable: "DataExtractUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataExtractUserDatas_Datas_DataId",
                table: "DataExtractUserDatas",
                column: "DataId",
                principalTable: "Datas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataSets_ProviderAccounts_ProviderAccountId",
                table: "DataSets",
                column: "ProviderAccountId",
                principalTable: "ProviderAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataSets_YodleeAccounts_AccountId",
                table: "DataSets",
                column: "AccountId",
                principalTable: "YodleeAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailCategories_TransactionCategories_TransactionCategoryId",
                table: "DetailCategories",
                column: "TransactionCategoryId",
                principalTable: "TransactionCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_Profiles_ProfileId",
                table: "Emails",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Datas_dataId",
                table: "Events",
                column: "dataId",
                principalTable: "Datas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fields_Rows_RowId",
                table: "Fields",
                column: "RowId",
                principalTable: "Rows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricalBalanceAccounts_RunningBalances_BalanceId",
                table: "HistoricalBalanceAccounts",
                column: "BalanceId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricalBalances_Networths_NetworthDetailId",
                table: "HistoricalBalances",
                column: "NetworthDetailId",
                principalTable: "Networths",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricalBalances_RunningBalances_BalanceId",
                table: "HistoricalBalances",
                column: "BalanceId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Holders_Names_NameId",
                table: "Holders",
                column: "NameId",
                principalTable: "Names",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Holders_YodleeVerifiedAccount_VerifiedAccountId",
                table: "Holders",
                column: "VerifiedAccountId",
                principalTable: "YodleeVerifiedAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Holdings_DataExtractUserDatas_DataExtractUserDataId",
                table: "Holdings",
                column: "DataExtractUserDataId",
                principalTable: "DataExtractUserDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Holdings_HoldingsSummarys_HoldingsSummaryId",
                table: "Holdings",
                column: "HoldingsSummaryId",
                principalTable: "HoldingsSummarys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Holdings_RunningBalances_AccruedIncomeId",
                table: "Holdings",
                column: "AccruedIncomeId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Holdings_RunningBalances_AccruedInterestId",
                table: "Holdings",
                column: "AccruedInterestId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Holdings_RunningBalances_CostBasisId",
                table: "Holdings",
                column: "CostBasisId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Holdings_RunningBalances_PriceId",
                table: "Holdings",
                column: "PriceId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Holdings_RunningBalances_SpreadId",
                table: "Holdings",
                column: "SpreadId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Holdings_RunningBalances_StrikePriceId",
                table: "Holdings",
                column: "StrikePriceId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Holdings_RunningBalances_UnvestedValueId",
                table: "Holdings",
                column: "UnvestedValueId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Holdings_RunningBalances_ValueId",
                table: "Holdings",
                column: "ValueId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Holdings_RunningBalances_VestedValueId",
                table: "Holdings",
                column: "VestedValueId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HoldingsAccounts_HoldingsSummarys_HoldingsSummaryId",
                table: "HoldingsAccounts",
                column: "HoldingsSummaryId",
                principalTable: "HoldingsSummarys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HoldingsAccounts_RunningBalances_ValueId",
                table: "HoldingsAccounts",
                column: "ValueId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HoldingsSummarys_RunningBalances_ValueId",
                table: "HoldingsSummarys",
                column: "ValueId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Identifiers_Holders_HolderId",
                table: "Identifiers",
                column: "HolderId",
                principalTable: "Holders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Identifiers_Profiles_ProfileId",
                table: "Identifiers",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Links_UserDatas_UserDataId",
                table: "Links",
                column: "UserDataId",
                principalTable: "UserDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanPayoffDetails_RunningBalances_OutstandingBalanceId",
                table: "LoanPayoffDetails",
                column: "OutstandingBalanceId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanPayoffDetails_RunningBalances_PayoffAmountId",
                table: "LoanPayoffDetails",
                column: "PayoffAmountId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoginForms_ProviderAccounts_ProviderAccountId",
                table: "LoginForms",
                column: "ProviderAccountId",
                principalTable: "ProviderAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoginForms_Providers_ProviderId",
                table: "LoginForms",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Merchants_Addresses_AddressId",
                table: "Merchants",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Merchants_Contacts_ContactId",
                table: "Merchants",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Merchants_Coordinates_CoordinatesId",
                table: "Merchants",
                column: "CoordinatesId",
                principalTable: "Coordinates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Networths_RunningBalances_AssetId",
                table: "Networths",
                column: "AssetId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Networths_RunningBalances_LiabilityId",
                table: "Networths",
                column: "LiabilityId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Networths_RunningBalances_NetworthId",
                table: "Networths",
                column: "NetworthId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumbers_Profiles_ProfileId",
                table: "PhoneNumbers",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Names_NameId",
                table: "Profiles",
                column: "NameId",
                principalTable: "Names",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderAccounts_ProviderAccountPreference_PreferencesId",
                table: "ProviderAccounts",
                column: "PreferencesId",
                principalTable: "ProviderAccountPreference",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderCounts_Totals_TotalId",
                table: "ProviderCounts",
                column: "TotalId",
                principalTable: "Totals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProvidersDatasets_Providers_ProviderId",
                table: "ProvidersDatasets",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RewardBalances_DataExtractAccounts_DataExtractAccountId",
                table: "RewardBalances",
                column: "DataExtractAccountId",
                principalTable: "DataExtractAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rows_LoginForms_LoginFormId",
                table: "Rows",
                column: "LoginFormId",
                principalTable: "LoginForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RuleClauses_Rules_RuleId",
                table: "RuleClauses",
                column: "RuleId",
                principalTable: "Rules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SecurityHoldings_Security_SecurityId",
                table: "SecurityHoldings",
                column: "SecurityId",
                principalTable: "Security",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StockExchangeDetails_Security_SecurityId",
                table: "StockExchangeDetails",
                column: "SecurityId",
                principalTable: "Security",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SummaryDetails_RunningBalances_CreditTotalId",
                table: "SummaryDetails",
                column: "CreditTotalId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SummaryDetails_RunningBalances_DebitTotalId",
                table: "SummaryDetails",
                column: "DebitTotalId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SummaryDetails_Summarys_SummaryId",
                table: "SummaryDetails",
                column: "SummaryId",
                principalTable: "Summarys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Summarys_RunningBalances_CreditTotalId",
                table: "Summarys",
                column: "CreditTotalId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Summarys_RunningBalances_DebitTotalId",
                table: "Summarys",
                column: "DebitTotalId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Summarys_TransactionsLinks_LinksId",
                table: "Summarys",
                column: "LinksId",
                principalTable: "TransactionsLinks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Summarys_TransactionsSummarys_TransactionsSummaryId",
                table: "Summarys",
                column: "TransactionsSummaryId",
                principalTable: "TransactionsSummarys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionCriterias_VerifyAccountDTOs_VerifyAccountDTOId",
                table: "TransactionCriterias",
                column: "VerifyAccountDTOId",
                principalTable: "VerifyAccountDTOs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionsSummarys_RunningBalances_CreditTotalId",
                table: "TransactionsSummarys",
                column: "CreditTotalId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionsSummarys_RunningBalances_DebitTotalId",
                table: "TransactionsSummarys",
                column: "DebitTotalId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionsSummarys_TransactionsLinks_LinksId",
                table: "TransactionsSummarys",
                column: "LinksId",
                principalTable: "TransactionsLinks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UpdateAccountDetails_Addresses_AddressId",
                table: "UpdateAccountDetails",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UpdateAccountDetails_RunningBalances_AmountDueId",
                table: "UpdateAccountDetails",
                column: "AmountDueId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UpdateAccountDetails_RunningBalances_BalanceId",
                table: "UpdateAccountDetails",
                column: "BalanceId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UpdateAccountDetails_RunningBalances_HomeValueId",
                table: "UpdateAccountDetails",
                column: "HomeValueId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDatas_DataExtractUsers_UserId",
                table: "UserDatas",
                column: "UserId",
                principalTable: "DataExtractUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_AmountDueId",
                table: "YodleeAccounts",
                column: "AmountDueId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_AvailableBalanceId",
                table: "YodleeAccounts",
                column: "AvailableBalanceId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_AvailableCashId",
                table: "YodleeAccounts",
                column: "AvailableCashId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_AvailableCreditId",
                table: "YodleeAccounts",
                column: "AvailableCreditId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_BalanceId",
                table: "YodleeAccounts",
                column: "BalanceId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_CashId",
                table: "YodleeAccounts",
                column: "CashId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_CurrentBalanceId",
                table: "YodleeAccounts",
                column: "CurrentBalanceId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_LastPaymentAmountId",
                table: "YodleeAccounts",
                column: "LastPaymentAmountId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_MarginBalanceId",
                table: "YodleeAccounts",
                column: "MarginBalanceId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_MinimumAmountDueId",
                table: "YodleeAccounts",
                column: "MinimumAmountDueId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_OriginalLoanAmountId",
                table: "YodleeAccounts",
                column: "OriginalLoanAmountId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_PrincipalBalanceId",
                table: "YodleeAccounts",
                column: "PrincipalBalanceId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_RunningBalanceId",
                table: "YodleeAccounts",
                column: "RunningBalanceId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_TotalCashLimitId",
                table: "YodleeAccounts",
                column: "TotalCashLimitId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeAccounts_RunningBalances_TotalCreditLineId",
                table: "YodleeAccounts",
                column: "TotalCreditLineId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeAccounts_VerifyAccountDTOs_VerifyAccountDTOId",
                table: "YodleeAccounts",
                column: "VerifyAccountDTOId",
                principalTable: "VerifyAccountDTOs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeAmounts_Coverages_CoverageId",
                table: "YodleeAmounts",
                column: "CoverageId",
                principalTable: "Coverages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeAmounts_RunningBalances_coverId",
                table: "YodleeAmounts",
                column: "coverId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeAmounts_RunningBalances_MetId",
                table: "YodleeAmounts",
                column: "MetId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeIntermediary_YodleeTransactions_TransactionId",
                table: "YodleeIntermediary",
                column: "TransactionId",
                principalTable: "YodleeTransactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeStatements_RunningBalances_AmountDueId",
                table: "YodleeStatements",
                column: "AmountDueId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeStatements_RunningBalances_CashAdvanceId",
                table: "YodleeStatements",
                column: "CashAdvanceId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeStatements_RunningBalances_InterestAmountId",
                table: "YodleeStatements",
                column: "InterestAmountId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeStatements_RunningBalances_LastPaymentAmountId",
                table: "YodleeStatements",
                column: "LastPaymentAmountId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeStatements_RunningBalances_LoanBalanceId",
                table: "YodleeStatements",
                column: "LoanBalanceId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeStatements_RunningBalances_MinimumPaymentId",
                table: "YodleeStatements",
                column: "MinimumPaymentId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeStatements_RunningBalances_NewChargesId",
                table: "YodleeStatements",
                column: "NewChargesId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeStatements_RunningBalances_PrincipalAmountId",
                table: "YodleeStatements",
                column: "PrincipalAmountId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeTransactions_Descriptions_DescriptionId",
                table: "YodleeTransactions",
                column: "DescriptionId",
                principalTable: "Descriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeTransactions_Merchants_MerchantId",
                table: "YodleeTransactions",
                column: "MerchantId",
                principalTable: "Merchants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeTransactions_Principals_PrincipalId",
                table: "YodleeTransactions",
                column: "PrincipalId",
                principalTable: "Principals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeTransactions_RunningBalances_AmountId",
                table: "YodleeTransactions",
                column: "AmountId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeTransactions_RunningBalances_CommissionId",
                table: "YodleeTransactions",
                column: "CommissionId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeTransactions_RunningBalances_InterestId",
                table: "YodleeTransactions",
                column: "InterestId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeTransactions_RunningBalances_PriceId",
                table: "YodleeTransactions",
                column: "PriceId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeTransactions_RunningBalances_RunningBalanceId",
                table: "YodleeTransactions",
                column: "RunningBalanceId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeUser_Addresses_AddressId",
                table: "YodleeUser",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeUser_Names_NameId",
                table: "YodleeUser",
                column: "NameId",
                principalTable: "Names",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeUser_Preferences_PreferencesId",
                table: "YodleeUser",
                column: "PreferencesId",
                principalTable: "Preferences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeVerifiedAccount_RunningBalances_AvailableBalanceId",
                table: "YodleeVerifiedAccount",
                column: "AvailableBalanceId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeVerifiedAccount_RunningBalances_BalanceId",
                table: "YodleeVerifiedAccount",
                column: "BalanceId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeVerifiedAccount_RunningBalances_CashId",
                table: "YodleeVerifiedAccount",
                column: "CashId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YodleeVerifiedAccount_RunningBalances_CurrentBalanceId",
                table: "YodleeVerifiedAccount",
                column: "CurrentBalanceId",
                principalTable: "RunningBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
