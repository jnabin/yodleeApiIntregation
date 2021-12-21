using System;
using System.Threading.Tasks;
using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories;
using YodleeIntegration.Persistence.Repositories.RequestLogRepository;
using YodleeIntegration.Persistence.Repositories.YodleeAccessTokenRepository;
using YodleeIntegration.Persistence.Repositories.YodleeAccountRepository;
using YodleeIntegration.Persistence.Repositories.YodleeAccountsDataSetRepository;
using YodleeIntegration.Persistence.Repositories.YodleeAddManualAccountRepository;
using YodleeIntegration.Persistence.Repositories.YodleeAddManualResponseAccountRepository;
using YodleeIntegration.Persistence.Repositories.YodleeAddressRepository;
using YodleeIntegration.Persistence.Repositories.YodleeApiKey;
using YodleeIntegration.Persistence.Repositories.YodleeAssetClassificationListRepository;
using YodleeIntegration.Persistence.Repositories.YodleeAssetClassificationRepository;
using YodleeIntegration.Persistence.Repositories.YodleeAttributeRepository;
using YodleeIntegration.Persistence.Repositories.YodleeBankRepository;
using YodleeIntegration.Persistence.Repositories.YodleeBankTransferCodeRepository;
using YodleeIntegration.Persistence.Repositories.YodleeCapabilityRepository;
using YodleeIntegration.Persistence.Repositories.YodleeConfigurationRepository;
using YodleeIntegration.Persistence.Repositories.YodleeContactRepository;
using YodleeIntegration.Persistence.Repositories.YodleeContainerAttributeRepository;
using YodleeIntegration.Persistence.Repositories.YodleeCoordinatesRepository;
using YodleeIntegration.Persistence.Repositories.YodleeDataExtractAccountRepository;
using YodleeIntegration.Persistence.Repositories.YodleeDataExtractAmountRepository;
using YodleeIntegration.Persistence.Repositories.YodleeDataExtractDatasetRepository;
using YodleeIntegration.Persistence.Repositories.YodleeDataExtractProviderAccountRepository;
using YodleeIntegration.Persistence.Repositories.YodleeDataExtractUserDataRepository;
using YodleeIntegration.Persistence.Repositories.YodleeDataExtractUserRepository;
using YodleeIntegration.Persistence.Repositories.YodleeDataRepository;
using YodleeIntegration.Persistence.Repositories.YodleeDescriptionRepository;
using YodleeIntegration.Persistence.Repositories.YodleeDetailCategoryRepository;
using YodleeIntegration.Persistence.Repositories.YodleeEmailRepository;
using YodleeIntegration.Persistence.Repositories.YodleeEventRepository;
using YodleeIntegration.Persistence.Repositories.YodleeFieldRepository;
using YodleeIntegration.Persistence.Repositories.YodleeFullAccountNumberListRepository;
using YodleeIntegration.Persistence.Repositories.YodleeHistoricalAccountRepository;
using YodleeIntegration.Persistence.Repositories.YodleeHistoricalBalanceAccountRepository;
using YodleeIntegration.Persistence.Repositories.YodleeHistoricalBalanceRepository;
using YodleeIntegration.Persistence.Repositories.YodleeHolderRepository;
using YodleeIntegration.Persistence.Repositories.YodleeHoldingRepository;
using YodleeIntegration.Persistence.Repositories.YodleeHoldingsAccountRepository;
using YodleeIntegration.Persistence.Repositories.YodleeHoldingsSummaryRepository;
using YodleeIntegration.Persistence.Repositories.YodleeHoldingTypeRepository;
using YodleeIntegration.Persistence.Repositories.YodleeIdentifierRepository;
using YodleeIntegration.Persistence.Repositories.YodleeIntermediaryRepository;
using YodleeIntegration.Persistence.Repositories.YodleeLinkRepository;
using YodleeIntegration.Persistence.Repositories.YodleeLoanPayoffDetailsRepository;
using YodleeIntegration.Persistence.Repositories.YodleeLoginFormRepository;
using YodleeIntegration.Persistence.Repositories.YodleeMerchantRepository;
using YodleeIntegration.Persistence.Repositories.YodleeNameRepository;
using YodleeIntegration.Persistence.Repositories.YodleeNetworthDetailRepository;
using YodleeIntegration.Persistence.Repositories.YodleeNotificationEventRepository;
using YodleeIntegration.Persistence.Repositories.YodleePhoneNumberRepository;
using YodleeIntegration.Persistence.Repositories.YodleePreferenceRepository;
using YodleeIntegration.Persistence.Repositories.YodleePrincipalRepository;
using YodleeIntegration.Persistence.Repositories.YodleeProfileRepository;
using YodleeIntegration.Persistence.Repositories.YodleeProviderAccountPreferenceRepository;
using YodleeIntegration.Persistence.Repositories.YodleeProviderCountRepository;
using YodleeIntegration.Persistence.Repositories.YodleeProviderRepository;
using YodleeIntegration.Persistence.Repositories.YodleeProvidersDatasetRepository;
using YodleeIntegration.Persistence.Repositories.YodleePublicKeyRepository;
using YodleeIntegration.Persistence.Repositories.YodleeRewardBalanceRepository;
using YodleeIntegration.Persistence.Repositories.YodleeRowRepository;
using YodleeIntegration.Persistence.Repositories.YodleeRuleClauseRepository;
using YodleeIntegration.Persistence.Repositories.YodleeRuleClausRepository;
using YodleeIntegration.Persistence.Repositories.YodleeRuleRepository;
using YodleeIntegration.Persistence.Repositories.YodleeRunningBalanceRepository;
using YodleeIntegration.Persistence.Repositories.YodleeSecurityHoldingRepository;
using YodleeIntegration.Persistence.Repositories.YodleeStatementRepository;
using YodleeIntegration.Persistence.Repositories.YodleeStockExchangeDetailRepository;
using YodleeIntegration.Persistence.Repositories.YodleeSummaryDetailsRepository;
using YodleeIntegration.Persistence.Repositories.YodleeSummaryRepository;
using YodleeIntegration.Persistence.Repositories.YodleeTotalRepository;
using YodleeIntegration.Persistence.Repositories.YodleeTransactionCategorizationRuleRepository;
using YodleeIntegration.Persistence.Repositories.YodleeTransactionCategoryRepository;
using YodleeIntegration.Persistence.Repositories.YodleeTransactionCriteriaRepository;
using YodleeIntegration.Persistence.Repositories.YodleeTransactionRepository;
using YodleeIntegration.Persistence.Repositories.YodleeTransactionsLinkRepository;
using YodleeIntegration.Persistence.Repositories.YodleeTransactionsSummaryRepository;
using YodleeIntegration.Persistence.Repositories.YodleeTypeRepository;
using YodleeIntegration.Persistence.Repositories.YodleeUpdateAccountDetailsRepository;
using YodleeIntegration.Persistence.Repositories.YodleeUpdateProviderAccountAttributeRepository;
using YodleeIntegration.Persistence.Repositories.YodleeUpdateProviderAccountDataSetRepository;
using YodleeIntegration.Persistence.Repositories.YodleeUserDataRepository;

namespace YodleeIntegration.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;

        public IYodleeConfigurationRepository YodleeConfigurationRepository { get; private set; }

        public IYodleeAccessTokenRepository YodleeAccessTokenRepository { get; private set; }

        public IYodleeApiKeyRepository YodleeApiKeyRepository { get; private set; }

        public IRequestLogRepository RequestLogRepository { get; private set; }

        public IYodleeStatementRepository YodleeStatementRepository { get; private set; }

        public IYodleeTransactionRepository YodleeTransactionRepository { get; private set; }
        public IYodleeAccountRepository YodleeAccountRepository { get; private set; }
        
        public IYodleeAddManualAccountRepository YodleeAddManualAccountRepository { get; private set; }
        public IYodleeAddManualResponseAccountRepository YodleeAddManualResponseAccountRepository { get; private set; }
        public IYodleeHistoricalAccountRepository YodleeHistoricalAccountRepository { get; private set; }
        public IYodleeHistoricalBalanceAccountRepository YodleeHistoricalBalanceAccountRepository { get; private set; }
        public IYodleeAccountBalanceRepository YodleeAccountBalanceRepository { get; private set; }
        public IYodleeUpdateAccountDetailsRepository YodleeUpdateAccountDetailsRepository { get; private set; }
        public IYodleeBankTransferCodeRepository YodleeBankTransferCodeRepository { get; private set; }
        public IYodleeAccountsDataSetRepository YodleeAccountsDataSetRepository { get; private set; }
        public IYodleeAddressRepository YodleeAddressRepository { get; private set; }
        public IYodleeUserRepository YodleeUserRepository { get; set; }
        public IYodleeAccessTokensRepository YodleeAccessTokensRepository { get; private set; }
        public IYodleeVerifiedAccountRepository YodleeVerifiedAccountRepository { get; private set; }
        public IYodleeVerificationAccountRepository YodleeVerificationAccountRepository { get; private set; }
        public IYodleeVerificationsRepository YodleeVerificationsRepository { get; private set; }
        public IYodleeAttributeRepository YodleeAttributeRepository { get; private set; }
        public IYodleeNotificationEventRepository YodleeNotificationEventRepository { get; private set; }
        public IYodleePublicKeyRepository YodleePublicKeyRepository { get; private set; }
        public IYodleeDataRepository YodleeDataRepository { get; private set; }
        public IYodleeEventRepository YodleeEventRepository { get; private set; }
        public IYodleeUserDataRepository YodleeUserDataRepository { get; private set; }
        public IYodleeLinkRepository YodleeLinkRepository { get; private set; }
        public IYodleeDataExtractAccountRepository YodleeDataExtractAccountRepository { get; private set; }
        public IYodleeDataExtractAmountRepository YodleeDataExtractAmountRepository { get; private set; }
        public IYodleeDataExtractDatasetRepository YodleeDataExtractDatasetRepository { get; private set; }
        public IYodleeLoanPayoffDetailsRepository YodleeLoanPayoffDetailsRepository { get; private set; }
        public IYodleeDataExtractProviderAccountRepository YodleeDataExtractProviderAccountRepository { get; private set; }
        public IYodleeRewardBalanceRepository YodleeRewardBalanceRepository { get; private set; }
        public IYodleeDataExtractUserRepository YodleeDataExtractUserRepository { get; private set; }
        public IYodleeDataExtractUserDataRepository YodleeDataExtractUserDataRepository { get; private set; }
        public IYodleeSummaryRepository YodleeSummaryRepository { get; private set; }
        public IYodleeSummaryDetailsRepository YodleeSummaryDetailsRepository { get; private set; }
        public IYodleeHoldingsAccountRepository YodleeHoldingsAccountRepository { get; private set; }
        public IYodleeHoldingsSummaryRepository YodleeHoldingsSummaryRepository { get; private set; }
        public IYodleeNetworthDetailRepository YodleeNetworthDetailRepository { get; private set; }
        public IYodleeTransactionsLinkRepository YodleeTransactionsLinkRepository { get; private set; }
        public IYodleeTransactionsSummaryRepository YodleeTransactionsSummaryRepository { get; private set; }
        public IYodleeAssetClassificationRepository YodleeAssetClassificationRepository { get; private set; }
        public IYodleeAssetClassificationListRepository YodleeAssetClassificationListRepository { get; private set; }
        public IYodleeBankRepository YodleeBankRepository { get; private set; }
        public IYodleeCapabilityRepository YodleeCapabilityRepository { get; private set; }
        public IYodleeCardDetailRepository YodleeCardDetailRepository { get; private set; }
        public IYodleeContactRepository YodleeContactRepository { get; private set; }
        public IYodleeContainerAttributeRepository YodleeContainerAttributeRepository { get; private set; }
        public IYodleeCoordinatesRepository YodleeCoordinatesRepository { get; private set; }
        public IYodleeProviderAccountRepository YodleeProviderAccountRepository { get; private set; }
        public IYodleeDescriptionRepository YodleeDescriptionRepository { get; private set; }
        public IYodleeDetailCategoryRepository YodleeDetailCategoryRepository { get; private set; }
        public IYodleeEmailRepository YodleeEmailRepository { get; private set; }
        public IYodleeFieldRepository YodleeFieldRepository { get; private set; }
        public IYodleeFullAccountNumberListRepository YodleeFullAccountNumberListRepository { get; private set; }
        public IYodleeHistoricalBalanceRepository YodleeHistoricalBalanceRepository { get; private set; }
        public IYodleeHolderRepository YodleeHolderRepository { get; private set; }
        public IYodleeHoldingRepository YodleeHoldingRepository { get; private set; }
        public IYodleeIdentifierRepository YodleeIdentifierRepository { get; private set; }
        public IYodleeIntermediaryRepository YodleeIntermediaryRepository { get; private set; }
        public IYodleeLoginFormRepository YodleeLoginFormRepository { get; private set; }
        public IYodleeMerchantRepository YodleeMerchantRepository { get; private set; }
        public IYodleeNameRepository YodleeNameRepository { get; private set; }
        public IYodleePreferenceRepository YodleePreferenceRepository { get; private set; }
        public IYodleePrincipalRepository YodleePrincipalRepository { get; private set; }
        public IYodleeProfileRepository YodleeProfileRepository { get; private set; }
        public IYodleeProviderRepository YodleeProviderRepository { get; private set; }
        public IYodleeProviderAccountPreferenceRepository YodleeProviderAccountPreferenceRepository { get; private set; }
        public IYodleeProviderCountRepository YodleeProviderCountRepository { get; private set; }
        public IYodleeProvidersDatasetRepository YodleeProvidersDatasetRepository { get; private set; }
        public IYodleeRowRepository YodleeRowRepository { get; private set; }
        public IYodleeRuleRepository YodleeRuleRepository { get; private set; }
        public IYodleeRuleClausRepository YodleeRuleClausRepository { get; private set; }
        public IYodleeRuleClauseRepository YodleeRuleClauseRepository { get; private set; }
        public IYodleeRunningBalanceRepository YodleeRunningBalanceRepository { get; private set; }
        public IYodleeSecurityHoldingRepository YodleeSecurityHoldingRepository { get; private set; }
        public IYodleeStockExchangeDetailRepository YodleeStockExchangeDetailRepository { get; private set; }
        public IYodleeTotalRepository YodleeTotalRepository { get; private set; }
        public IYodleeTransactionCategorizationRuleRepository YodleeTransactionCategorizationRuleRepository { get; private set; }
        public IYodleeTransactionCategoryRepository YodleeTransactionCategoryRepository { get; private set; }
        public IYodleeTransactionCriteriaRepository YodleeTransactionCriteriaRepository { get; private set; }
        public IYodleeTypeRepository YodleeTypeRepository { get; private set; }
        public IYodleeUpdateProviderAccountAttributeRepository YodleeUpdateProviderAccountAttributeRepository { get; private set; }
        public IYodleeUpdateProviderAccountDataSetRepository YodleeUpdateProviderAccountDataSetRepository { get; private set; }
        public IYodleeUpdateProviderAccountFieldRepository YodleeUpdateProviderAccountFieldRepository { get; private set; }
        public IYodleeVerifyAccountDTORepository YodleeVerifyAccountDTORepository { get; private set; }
        public IYodleeVerifyAccountTransactionCriteriaRepository YodleeVerifyAccountTransactionCriteriaRepository { get; private set; }

        public IYodleeProviderAccountProfileRepository YodleeProviderAccountProfileRepository { get; private set; }
        public IYodleePhoneNumberRepository YodleePhoneNumberRepository { get; private set; }
        public IYodleeHoldingTypeRepository YodleeHoldingTypeRepository { get; private set; }

        
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            YodleeConfigurationRepository = new YodleeConfigurationRepository(_context);
            YodleeAccessTokenRepository = new YodleeAccessTokenRepository(_context);
            YodleeApiKeyRepository = new YodleeApiKeyRepository(_context);
            RequestLogRepository = new RequestLogRepository(_context);
            YodleeStatementRepository = new YodleeStatementRepository(_context);
            YodleeTransactionRepository = new YodleeTransactionRepository(_context);
            YodleeAccountRepository = new YodleeAccountRepository(_context);
            YodleeAddManualAccountRepository = new YodleeAddManualAccountRepository(_context);
            YodleeAddManualResponseAccountRepository = new YodleeAddManualResponseAccountRepository(_context);
            YodleeHistoricalAccountRepository = new YodleeHistoricalAccountRepository(_context);
            YodleeUserRepository = new YodleeUserRepository(_context);
            YodleeHistoricalBalanceAccountRepository = new YodleeHistoricalBalanceAccountRepository(_context);
            YodleeAccountBalanceRepository = new YodleeAccountBalanceRepository(_context);
            YodleeAccessTokensRepository = new YodleeAccessTokensRepository(_context);
            YodleeVerifiedAccountRepository = new YodleeVerifiedAccountRepository(_context);
            YodleeUpdateAccountDetailsRepository = new YodleeUpdateAccountDetailsRepository(_context);
            YodleeBankTransferCodeRepository = new YodleeBankTransferCodeRepository(_context);
            YodleeAccountsDataSetRepository = new YodleeAccountsDataSetRepository(_context);
            YodleeAddressRepository = new YodleeAddressRepository(_context);
            YodleeVerificationsRepository = new YodleeVerificationsRepository(_context);
            YodleeAttributeRepository = new YodleeAttributeRepository(_context);
            YodleeNotificationEventRepository = new YodleeNotificationEventRepository(_context);
            YodleePublicKeyRepository = new YodleePublicKeyRepository(_context);
            YodleeDataRepository = new YodleeDataRepository(_context);
            YodleeEventRepository = new YodleeEventRepository(_context);
            YodleeUserDataRepository = new YodleeUserDataRepository(_context);
            YodleeLinkRepository = new YodleeLinkRepository(_context);
            YodleeDataExtractAccountRepository = new YodleeDataExtractAccountRepository(_context);
            YodleeDataExtractAmountRepository = new YodleeDataExtractAmountRepository(_context);
            YodleeDataExtractDatasetRepository = new YodleeDataExtractDatasetRepository(_context);
            YodleeLoanPayoffDetailsRepository = new YodleeLoanPayoffDetailsRepository(_context);
            YodleeDataExtractProviderAccountRepository = new YodleeDataExtractProviderAccountRepository(_context);
            YodleeRewardBalanceRepository = new YodleeRewardBalanceRepository(_context);
            YodleeDataExtractUserRepository = new YodleeDataExtractUserRepository(_context);
            YodleeDataExtractUserDataRepository = new YodleeDataExtractUserDataRepository(_context);
            YodleeSummaryRepository = new YodleeSummaryRepository(_context);
            YodleeSummaryDetailsRepository = new YodleeSummaryDetailsRepository(_context);
            YodleeHoldingsAccountRepository = new YodleeHoldingsAccountRepository(_context);
            YodleeHoldingsSummaryRepository = new YodleeHoldingsSummaryRepository(_context);
            YodleeNetworthDetailRepository = new YodleeNetworthDetailRepository(_context);
            YodleeTransactionsLinkRepository = new YodleeTransactionsLinkRepository(_context);
            YodleeTransactionsSummaryRepository = new YodleeTransactionsSummaryRepository(_context);
            YodleeAssetClassificationRepository = new YodleeAssetClassificationRepository(_context);
            YodleeAssetClassificationListRepository = new YodleeAssetClassificationListRepository(_context);
            YodleeBankRepository = new YodleeBankRepository(_context);
            YodleeCapabilityRepository = new YodleeCapabilityRepository(_context);
            YodleeContactRepository = new YodleeContactRepository(_context);
            YodleeContainerAttributeRepository=new YodleeContainerAttributeRepository(_context);
            YodleeCoordinatesRepository = new YodleeCoordinatesRepository(_context);
            YodleeProviderAccountRepository = new YodleeProviderAccountRepository(_context);
            YodleeDescriptionRepository = new YodleeDescriptionRepository(_context);
            YodleeDetailCategoryRepository = new YodleeDetailCategoryRepository(_context);
            YodleeEmailRepository = new YodleeEmailRepository(_context);
            YodleeFieldRepository = new YodleeFieldRepository(_context);
            YodleeFullAccountNumberListRepository = new YodleeFullAccountNumberListRepository(_context);
            YodleeHistoricalBalanceRepository = new YodleeHistoricalBalanceRepository(_context);
            YodleeHolderRepository = new YodleeHolderRepository(_context);
            YodleeHoldingRepository = new YodleeHoldingRepository(_context);
            YodleeIdentifierRepository = new YodleeIdentifierRepository(_context);
            YodleeIntermediaryRepository = new YodleeIntermediaryRepository(_context);
            YodleeLoginFormRepository = new YodleeLoginFormRepository(_context);
            YodleeMerchantRepository = new YodleeMerchantRepository(_context);
            YodleeNameRepository = new YodleeNameRepository(_context);
            YodleePreferenceRepository = new YodleePreferenceRepository(_context);
            YodleePrincipalRepository = new YodleePrincipalRepository(_context);
            YodleeProfileRepository = new YodleeProfileRepository(_context);
            YodleeProviderRepository = new YodleeProviderRepository(_context);
            YodleeProviderAccountPreferenceRepository = new YodleeProviderAccountPreferenceRepository(_context);
            YodleeProviderCountRepository = new YodleeProviderCountRepository(_context);
            YodleeProvidersDatasetRepository = new YodleeProvidersDatasetRepository(_context);
            YodleeRowRepository = new YodleeRowRepository(_context);
            YodleeRuleRepository = new YodleeRuleRepository(_context);
            YodleeRuleClausRepository = new YodleeRuleClausRepository(_context);
            YodleeRuleClauseRepository = new YodleeRuleClauseRepository(_context);
            YodleeRunningBalanceRepository = new YodleeRunningBalanceRepository(_context);
            YodleeSecurityHoldingRepository = new YodleeSecurityHoldingRepository(_context);
            YodleeStockExchangeDetailRepository = new YodleeStockExchangeDetailRepository(_context);
            YodleeTotalRepository = new YodleeTotalRepository(_context);
            YodleeTransactionCategorizationRuleRepository = new YodleeTransactionCategorizationRuleRepository(_context);
            YodleeTransactionCategoryRepository = new YodleeTransactionCategoryRepository(_context);
            YodleeTransactionCriteriaRepository = new YodleeTransactionCriteriaRepository(_context);
            YodleeTypeRepository = new YodleeTypeRepository(_context);
            YodleeUpdateProviderAccountAttributeRepository = new YodleeUpdateProviderAccountAttributeRepository(_context);
            YodleeUpdateProviderAccountDataSetRepository = new YodleeUpdateProviderAccountDataSetRepository(_context);
            YodleePhoneNumberRepository = new YodleePhoneNumberRepository(_context);
            YodleeHoldingTypeRepository = new YodleeHoldingTypeRepository(_context);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
