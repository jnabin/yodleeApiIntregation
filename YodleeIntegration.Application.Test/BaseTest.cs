using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using YodleeIntegration.Api;
using YodleeIntegration.Api.Extensions;
using YodleeIntegration.Api.Models;
using YodleeIntegration.Application.Authorization.GenerateAccessToken;
using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Application.Request;
using YodleeIntegration.Application.Response;
using YodleeIntegration.Common.ServiceClient;
using YodleeIntegration.Domain.Model.Authorizations;
using YodleeIntegration.Domain.Model.Configurations;

namespace YodleeIntegration.Application.Test
{
    public class BaseTest
    {
        protected DependencyResolverHelper _serviceProvider;
        protected IServiceHttpClient _serviceHttpClient;
        protected Mock<IYodleeConfigurationRepository> _mockYodleeConfigurationRepository;
        protected Mock<IYodleeAccessTokenRepository> _mockYodleeAccessTokenRepository;
        protected Mock<IRequestLogRepository> _mockRequestLogRepository;
        protected Mock<IUnitOfWork> _mockUnitOfWork;
        protected Mock<ILogger<GenerateAccessTokenCommandHandler>> _loggerToken;
        protected Mock<IServiceHttpClient> _newServiceHttpClient;

        public BaseTest()
        {
            var webHost = WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>()
                .Build();
            _serviceProvider = new DependencyResolverHelper(webHost);
            _serviceHttpClient = _serviceProvider.GetService<IServiceHttpClient>();
            _mockYodleeConfigurationRepository = new Mock<IYodleeConfigurationRepository>();
            _mockYodleeAccessTokenRepository = new Mock<IYodleeAccessTokenRepository>();
            _mockRequestLogRepository = new Mock<IRequestLogRepository>();
            _loggerToken = new Mock<ILogger<GenerateAccessTokenCommandHandler>>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _newServiceHttpClient = new Mock<IServiceHttpClient>();
        }

        public async Task<AuthorizationUserTokenResponse> GetToken()
        {
            var configuration = await GetConfiguration();
            _mockYodleeAccessTokenRepository
                .Setup(x => x.SingleOrDefaultAsync(It.IsAny<Expression<Func<YodleeAccessToken, bool>>>()))
                .Returns(Task.FromResult(new YodleeAccessToken()
                {
                    EntityId = 1,
                    IsActive = true
                })).Verifiable();

            _mockUnitOfWork.Setup(x => x.YodleeAccessTokenRepository)
                .Returns(_mockYodleeAccessTokenRepository.Object).Verifiable();
            _mockUnitOfWork.Setup(x => x.RequestLogRepository)
                .Returns(_mockRequestLogRepository.Object).Verifiable();
            var command = new GenerateAccessTokenDataCommand(new AuthorizationUserTokenRequest
            {
                ClientId = configuration.ClientId,
                Secret = configuration.Secret,
                Endpoint = $"{configuration.Url}/auth/token"
            }, configuration, configuration.Username);

            var handler = new GenerateAccessTokenCommandHandler(_mockUnitOfWork.Object, _serviceHttpClient, _loggerToken.Object);
            var response = await handler.Handle(command, CancellationToken.None);
            return (AuthorizationUserTokenResponse)await response.DeserializeAsync<AuthorizationUserTokenResponse>();
        }

        public async Task<YodleeConfiguration> GetConfiguration()
        {
            _mockYodleeConfigurationRepository
                .Setup(x => x.SingleOrDefaultAsync(It.IsAny<Expression<Func<YodleeConfiguration, bool>>>()))
                .Returns(Task.FromResult(new YodleeConfiguration()
                {
                    EntityId = 1,
                    Url = "https://sandbox.api.yodlee.com.au/ysl",
                    Username = "sbMem6184f0c6f0fa61",
                    ClientId = "vBiHDIyeBhUTV78Q2AJFMA0We8JXqJsC",
                    Secret = "37VPcEjRNGVu1hTH",
                    ProviderId = "16441",
                    ProviderAccountId = "10012606",
                    AccountId = "10045607",
                    RequestId = "1RZ0OH87GA3QnO4+rxsiweU8KbU=",
                    ApiVersion = "1.1",
                    IsActive = true
                })).Verifiable();

            _mockUnitOfWork.Setup(x => x.YodleeConfigurationRepository)
                .Returns(_mockYodleeConfigurationRepository.Object).Verifiable();
            _mockYodleeAccessTokenRepository
                .Setup(x => x.SingleOrDefaultAsync(It.IsAny<Expression<Func<YodleeAccessToken, bool>>>()))
                .Returns(Task.FromResult(new YodleeAccessToken()
                {
                    EntityId = 1,
                    IsActive = true
                })).Verifiable();

            _mockUnitOfWork.Setup(x => x.YodleeAccessTokenRepository)
                .Returns(_mockYodleeAccessTokenRepository.Object).Verifiable();

            _mockUnitOfWork.Setup(x => x.RequestLogRepository)
                .Returns(_mockRequestLogRepository.Object).Verifiable();
            return await _mockUnitOfWork.Object.YodleeConfigurationRepository.SingleOrDefaultAsync(It.IsAny<Expression<Func<YodleeConfiguration, bool>>>());
        }

        public static GetAccountsDetailQueryParams CreateGetAccountsDetailQueryParams()
        {
            GetAccountsDetailQueryParams getAccountsDetailQueryParams = new GetAccountsDetailQueryParams()
            {
                Container = "container",
                Include = "include"
            };
            return getAccountsDetailQueryParams;
        }

        public static GetAccountsQueryParams CreateGetAccountsQueryParams()
        {
            GetAccountsQueryParams getAccountsQueryParams = new GetAccountsQueryParams()
            {
                AccountId = "102456",
                Container = "container",
                Include = "include",
                ProviderAccountId = "101356",
                RequestId = "123",
                Status = "Status"
            };
            return getAccountsQueryParams;
        }
        public static GetHistoricalBalancesQueryParams CreateGetHistoricalBalancesQueryParams()
        {
            GetHistoricalBalancesQueryParams getHistoricalBalancesQueryParams = new GetHistoricalBalancesQueryParams()
            {
                AccountId = "AccountId",
                AccountReconType = "AccountReconType",
                FromDate = "FromDate",
                IncludeCf = "IncludeCf",
                Interval = "Interval",
                Skip = "skip",
                ToDate = "ToDate",
                Top = "top"
            };
            return getHistoricalBalancesQueryParams;
        }
        public GetLatestBalancesQueryParams CreateGetLatestBalancesQueryParams()
        {
            GetLatestBalancesQueryParams getLatestBalancesQueryParams = new GetLatestBalancesQueryParams()
            {
                AccountId = "AccountId",
                ProviderAccountId = "ProviderAccountId",
            };
            return getLatestBalancesQueryParams;
        }

        protected static Task<HttpResponseMessage> MediatrMockReturns(
            string url, HttpMethod method, string endpionts, HttpContent content=null)
        {
            return Task.FromResult(new HttpResponseMessage()
            {
                Content = content,
                StatusCode = HttpStatusCode.OK,
                RequestMessage = new HttpRequestMessage()
                {
                    Method = method,
                    RequestUri = new Uri(string.Concat($"{url}", endpionts))
                }
            });
        }

        protected static Task<HttpResponseMessage> MediatrMockReturnsNotFound(string url, HttpMethod method, string endpionts)
        {
            return Task.FromResult(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.NotFound,
                RequestMessage = new HttpRequestMessage()
                {
                    Method = method,
                    RequestUri = new Uri(string.Concat($"{url}", endpionts))
                }
            });
        }

    }
}