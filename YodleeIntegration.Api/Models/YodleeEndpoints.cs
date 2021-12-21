namespace YodleeIntegration.Api.Models
{
    public static class YodleeEndpoints
    {
        public static readonly string AuthToken = "/auth/token";
        public static readonly string ApiKey = "/auth/apiKey";
        public static readonly string GetAccounts = "/accounts";
        public static readonly string GetHistoricalBalances = "/accounts/historicalBalances";
        public static readonly string GetLatestBalances = "/accounts/latestBalances";
        public static readonly string EvaluateAddress = "/accounts/evaluateAddress";
        public static readonly string UpdateAccount = "/accounts/";
        public static readonly string DeleteAccount = "/accounts";
        public static readonly string AddManualAccount = "/accounts";
        public static readonly string VerifyAccount = "/verifyAccount";
        public static readonly string GetTransactions = "/transactions";
        public static readonly string GetTransactionsCount = "/transactions/count";
        public static readonly string GetTransactionCategorizationRules = "/transactions/categories/txnRules";
        public static readonly string GetTransactionCategoryList = "/transactions/categories";
        public static readonly string UpdateTransactionCategorizationRule = "/transactions/categories/rules/";
        public static readonly string UpdateCategory = "/transactions/categories";
        public static readonly string UpdateTransaction = "/transactions/";
        public static readonly string CreateCategory = "/transactions/categories";
        public static readonly string CreateOrRunTransactionCategorizationRule = "/transactions/categories/rules";
        public static readonly string RunTransactionCategorization = "/transactions/categories/rules/";
        public static readonly string DeleteTransactionCategorizationRule = "/transactions/categories/rules/";
        public static readonly string DeleteCategory = "/transactions/categories/";
        public static readonly string Verification = "/verification";
        public static readonly string VerificationAccount = "/verification/verifiedAccounts";
        public static readonly string GetProviders = "/providers";
        public static readonly string GetProviderAccounts = "/providerAccounts";
        public static readonly string GetProviderAccountsDetails = "/providerAccounts/";
        public static readonly string GetUserProfileDetails = "/providerAccounts/profile";
        public static readonly string UpdateAccountPreferences = "/providerAccounts/";
        public static readonly string DeleteProviderAccount = "/providerAccounts/";
        public static readonly string UpdateProviderAccount = "/providerAccounts";
        public static readonly string GetProvidersDetails = "/providers/";
        public static readonly string GetProvidersCount = "/providers/count";
        public static readonly string SamlLogin = "/user/samlLogin";
        public static readonly string AccessTokens = "/user/accessTokens";
        public static readonly string UnRegister = "/user/unregister";
        public static readonly string Register = "/user/register";
        public static readonly string User = "/user";
        public static readonly string DeleteUser = "/user/unregister";
        public static readonly string UserData = "/dataExtracts/userData";
        public static readonly string Events = "/dataExtracts/events";
        public static readonly string HoldingsSummary = "/derived/holdingSummary";
        public static readonly string NetWorthSummary = "/derived/networth";
        public static readonly string TransactionsSummary = "/derived/transactionSummary";
        public static readonly string GetSubscribedNotification = "/configs/notifications/events";
        public static readonly string GetPublicKey = "/configs/publicKey";
        public static readonly string UpdateNotificationEvent = "/configs/notifications/events";
        public static readonly string SubscribeNotificationEvent = "/configs/notifications/events";
        public static readonly string GetDocuments = "/documents";
        public static readonly string GetAssetClassificationList = "/holdings/assetClassificationList";
        public static readonly string GetHoldingTypeList = "/holdings/holdingTypeList";
        public static readonly string GetSecurityDetails = "/holdings/securities";
        public static readonly string GetHoldings = "/holdings";
        public static readonly string GetStatements = "/statements";
    }
}