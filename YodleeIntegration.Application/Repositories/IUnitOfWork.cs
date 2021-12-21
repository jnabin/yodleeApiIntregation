using System.Threading.Tasks;

namespace YodleeIntegration.Application.Repositories
{
    public interface IUnitOfWork
    {
        public IYodleeConfigurationRepository YodleeConfigurationRepository { get;   }

        public IYodleeAccessTokenRepository YodleeAccessTokenRepository { get;   }

        public IYodleeApiKeyRepository YodleeApiKeyRepository { get;   }

        public IRequestLogRepository RequestLogRepository { get;   }

        public IYodleeStatementRepository YodleeStatementRepository { get;   }

        public IYodleeTransactionRepository YodleeTransactionRepository { get;   }
        public IYodleeAccountRepository YodleeAccountRepository { get;   }

        public IYodleeAddManualAccountRepository YodleeAddManualAccountRepository { get;   }
        public IYodleeAddManualResponseAccountRepository YodleeAddManualResponseAccountRepository { get;   }
        public IYodleeHistoricalAccountRepository YodleeHistoricalAccountRepository { get;   }
        public IYodleeHistoricalBalanceAccountRepository YodleeHistoricalBalanceAccountRepository { get;   }
        public IYodleeAccountBalanceRepository YodleeAccountBalanceRepository { get;   }
        public IYodleeUpdateAccountDetailsRepository YodleeUpdateAccountDetailsRepository { get;   }
        public IYodleeBankTransferCodeRepository YodleeBankTransferCodeRepository { get;   }
        public IYodleeAccountsDataSetRepository YodleeAccountsDataSetRepository { get;   }
        public IYodleeAddressRepository YodleeAddressRepository { get;   }
        public IYodleeUserRepository YodleeUserRepository { get;   }
        public IYodleeAccessTokensRepository YodleeAccessTokensRepository { get;   }
        public IYodleeVerifiedAccountRepository YodleeVerifiedAccountRepository { get;   }
        public IYodleeVerificationAccountRepository YodleeVerificationAccountRepository { get;   }
        public IYodleeVerificationsRepository YodleeVerificationsRepository { get;   }
        public IYodleeAttributeRepository YodleeAttributeRepository { get;   }
        public IYodleeNotificationEventRepository YodleeNotificationEventRepository { get;   }
        public IYodleePublicKeyRepository YodleePublicKeyRepository { get;   }
        public IYodleeDataRepository YodleeDataRepository { get;   }
        public IYodleeEventRepository YodleeEventRepository { get;   }
        public IYodleeUserDataRepository YodleeUserDataRepository { get;   }
        public IYodleeLinkRepository YodleeLinkRepository { get;   }
        public IYodleeDataExtractAccountRepository YodleeDataExtractAccountRepository { get;   }
        public IYodleeDataExtractAmountRepository YodleeDataExtractAmountRepository { get;   }
        public IYodleeDataExtractDatasetRepository YodleeDataExtractDatasetRepository { get;   }
        public IYodleeLoanPayoffDetailsRepository YodleeLoanPayoffDetailsRepository { get;   }
        public IYodleeDataExtractProviderAccountRepository YodleeDataExtractProviderAccountRepository { get;   }
        public IYodleeRewardBalanceRepository YodleeRewardBalanceRepository { get;   }
        public IYodleeDataExtractUserRepository YodleeDataExtractUserRepository { get;   }
        public IYodleeDataExtractUserDataRepository YodleeDataExtractUserDataRepository { get;   }
        public IYodleeSummaryRepository YodleeSummaryRepository { get;   }
        public IYodleeSummaryDetailsRepository YodleeSummaryDetailsRepository { get;   }
        public IYodleeHoldingsAccountRepository YodleeHoldingsAccountRepository { get;   }
        public IYodleeHoldingsSummaryRepository YodleeHoldingsSummaryRepository { get;   }
        public IYodleeNetworthDetailRepository YodleeNetworthDetailRepository { get;   }
        public IYodleeTransactionsLinkRepository YodleeTransactionsLinkRepository { get;   }
        public IYodleeTransactionsSummaryRepository YodleeTransactionsSummaryRepository { get;   }
        public IYodleeAssetClassificationRepository YodleeAssetClassificationRepository { get;   }
        public IYodleeAssetClassificationListRepository YodleeAssetClassificationListRepository { get;   }
        public IYodleeBankRepository YodleeBankRepository { get;   }
        public IYodleeCapabilityRepository YodleeCapabilityRepository { get;   }
        public IYodleeCardDetailRepository YodleeCardDetailRepository { get;   }
        public IYodleeContactRepository YodleeContactRepository { get;   }
        public IYodleeContainerAttributeRepository YodleeContainerAttributeRepository { get;   }
        public IYodleeCoordinatesRepository YodleeCoordinatesRepository { get;   }
        public IYodleeProviderAccountRepository YodleeProviderAccountRepository { get;   }
        public IYodleeDescriptionRepository YodleeDescriptionRepository { get;   }
        public IYodleeDetailCategoryRepository YodleeDetailCategoryRepository { get;   }
        public IYodleeEmailRepository YodleeEmailRepository { get;   }
        public IYodleeFieldRepository YodleeFieldRepository { get;   }
        public IYodleeFullAccountNumberListRepository YodleeFullAccountNumberListRepository { get;   }
        public IYodleeHistoricalBalanceRepository YodleeHistoricalBalanceRepository { get;   }
        public IYodleeHolderRepository YodleeHolderRepository { get;   }
        public IYodleeHoldingRepository YodleeHoldingRepository { get;   }
        public IYodleeIdentifierRepository YodleeIdentifierRepository { get;   }
        public IYodleeIntermediaryRepository YodleeIntermediaryRepository { get;   }
        public IYodleeLoginFormRepository YodleeLoginFormRepository { get;   }
        public IYodleeMerchantRepository YodleeMerchantRepository { get;   }
        public IYodleeNameRepository YodleeNameRepository { get;   }
        public IYodleePreferenceRepository YodleePreferenceRepository { get;   }
        public IYodleePrincipalRepository YodleePrincipalRepository { get;   }
        public IYodleeProfileRepository YodleeProfileRepository { get;   }
        public IYodleeProviderRepository YodleeProviderRepository { get;   }
        public IYodleeProviderAccountPreferenceRepository YodleeProviderAccountPreferenceRepository { get;   }
        public IYodleeProviderCountRepository YodleeProviderCountRepository { get;   }
        public IYodleeProvidersDatasetRepository YodleeProvidersDatasetRepository { get;   }
        public IYodleeRowRepository YodleeRowRepository { get;   }
        public IYodleeRuleRepository YodleeRuleRepository { get;   }
        public IYodleeRuleClausRepository YodleeRuleClausRepository { get;   }
        public IYodleeRuleClauseRepository YodleeRuleClauseRepository { get;   }
        public IYodleeRunningBalanceRepository YodleeRunningBalanceRepository { get;   }
        public IYodleeSecurityHoldingRepository YodleeSecurityHoldingRepository { get;   }
        public IYodleeStockExchangeDetailRepository YodleeStockExchangeDetailRepository { get;   }
        public IYodleeTotalRepository YodleeTotalRepository { get;   }
        public IYodleeTransactionCategorizationRuleRepository YodleeTransactionCategorizationRuleRepository { get;   }
        public IYodleeTransactionCategoryRepository YodleeTransactionCategoryRepository { get;   }
        public IYodleeTransactionCriteriaRepository YodleeTransactionCriteriaRepository { get;   }
        public IYodleeTypeRepository YodleeTypeRepository { get;   }
        public IYodleeUpdateProviderAccountAttributeRepository YodleeUpdateProviderAccountAttributeRepository { get;   }
        public IYodleeUpdateProviderAccountDataSetRepository YodleeUpdateProviderAccountDataSetRepository { get;   }
        public IYodleeUpdateProviderAccountFieldRepository YodleeUpdateProviderAccountFieldRepository { get;   }
        public IYodleeVerifyAccountDTORepository YodleeVerifyAccountDTORepository { get;   }
        public IYodleeVerifyAccountTransactionCriteriaRepository YodleeVerifyAccountTransactionCriteriaRepository { get;   }
        public IYodleeProviderAccountProfileRepository YodleeProviderAccountProfileRepository { get;   }
        public IYodleePhoneNumberRepository YodleePhoneNumberRepository { get;   }
        public IYodleeHoldingTypeRepository YodleeHoldingTypeRepository { get;   }

        Task CompleteAsync();
    }
}