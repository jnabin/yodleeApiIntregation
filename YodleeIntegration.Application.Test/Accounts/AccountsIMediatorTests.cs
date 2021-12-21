using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using YodleeIntegration.Api.Models;
using YodleeIntegration.Application.Accounts.AddManualAccount;
using YodleeIntegration.Application.Accounts.DeleteAccount;
using YodleeIntegration.Application.Accounts.EvaluateAddress;
using YodleeIntegration.Application.Accounts.GetAccounts;
using YodleeIntegration.Application.Accounts.GetHistoricalAccounts;
using YodleeIntegration.Application.Accounts.GetLatestBalances;
using YodleeIntegration.Application.Accounts.UpdateAccount;
using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Application.Request;
using YodleeIntegration.Application.Response;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.Test.Accounts
{
    public class AccountsIMediatorTests : BaseTest
    {
        private Mock<ILogger<GetAccountsQueryHandler>> _loggerofGetAccountsQueryHandler;
        private Mock<IYodleeAccountRepository> _accountRepositoryMock;

        private Mock<ILogger<GetHistoricalAccountsQueryHandler>> _loggerofGetHistoricalAccountsQueryHandler;
        private Mock<IYodleeHistoricalAccountRepository> _historicalAccountRepositoryMock;

        private Mock<ILogger<GetLatestBalancesQueryHandler>> _loggerofGetLatestBalancesOfAccountsQueryHandler;
        private Mock<IYodleeAccountBalanceRepository> _LatestBalancesOfAccountRepositoryMock;

        private Mock<ILogger<AddManualAccountCommandHandler>> _loggerofAddManualAccountCommandHandler;
        private Mock<ILogger<UpdateAccountHandler>> _loggerofUpdateAccountHandler;
        private Mock<ILogger<EvaluateAddressCommandHandler>> _loggerofEvaluateAddressCommandHandler;
        private Mock<ILogger<DeleteAccountHandler>> _loggerofDeleteAccountHandler;

        private object configuration;
        private object response = null;
        private GetAccountsQueryParams getAccountsQueryParams;
        private GetHistoricalBalancesQueryParams getHistoricalBalancesQueryParams;
        private GetLatestBalancesQueryParams getLatestBalancesQueryParams;
        private AddManualAccountRequestBody addManualAccountRequestBody;
        private UpdateAccountRequestBody updateAccountRequestBody;
        private EvaluateAddressRequestBody evaluateAddressRequestBody;
        [SetUp]
        public async Task SetupAsync()
        {
            _loggerofGetAccountsQueryHandler = new Mock<ILogger<GetAccountsQueryHandler>>();
            _loggerofAddManualAccountCommandHandler = new Mock<ILogger<AddManualAccountCommandHandler>>();
            _loggerofUpdateAccountHandler = new Mock<ILogger<UpdateAccountHandler>>();
            _loggerofEvaluateAddressCommandHandler = new Mock<ILogger<EvaluateAddressCommandHandler>>();
            _loggerofDeleteAccountHandler = new Mock<ILogger<DeleteAccountHandler>>();

            configuration = await GetConfiguration();
            getAccountsQueryParams = CreateGetAccountsQueryParams();
            getHistoricalBalancesQueryParams = CreateGetHistoricalBalancesQueryParams();
            getLatestBalancesQueryParams = CreateGetLatestBalancesQueryParams();
            addManualAccountRequestBody = CreateAddManualAccountRequestBody();
            updateAccountRequestBody = CreateUpdateAccountRequestBody();
            evaluateAddressRequestBody = CreateEvaluateRequestBody();

            _accountRepositoryMock = new Mock<IYodleeAccountRepository>();
            _accountRepositoryMock.Setup(m => m.SingleOrDefaultAsync(
                It.IsAny<Expression<Func<Account, bool>>>())).Returns(Task.FromResult(new Account()));
            _accountRepositoryMock.Setup(m => m.Add(It.IsAny<Account>())).Verifiable();
            _mockUnitOfWork.Setup(x => x.YodleeAccountRepository).Returns(_accountRepositoryMock.Object);
            _mockUnitOfWork.Setup(x => x.CompleteAsync()).Verifiable();

            _loggerofGetHistoricalAccountsQueryHandler = new Mock<ILogger<GetHistoricalAccountsQueryHandler>>();
            _historicalAccountRepositoryMock=new Mock<IYodleeHistoricalAccountRepository>();
            _historicalAccountRepositoryMock.Setup(m => m.SingleOrDefaultAsync(
                It.IsAny<Expression<Func<HistoricalAccount, bool>>>())).Returns(Task.FromResult(new HistoricalAccount()));
            _historicalAccountRepositoryMock.Setup(m => m.Add(It.IsAny<HistoricalAccount>())).Verifiable();
            _mockUnitOfWork.Setup(x => x.YodleeHistoricalAccountRepository).Returns(_historicalAccountRepositoryMock.Object);
            _mockUnitOfWork.Setup(x => x.CompleteAsync()).Verifiable();

            _loggerofGetLatestBalancesOfAccountsQueryHandler = new Mock<ILogger<GetLatestBalancesQueryHandler>>();
            _LatestBalancesOfAccountRepositoryMock = new Mock<IYodleeAccountBalanceRepository>();
            _LatestBalancesOfAccountRepositoryMock.Setup(m => m.SingleOrDefaultAsync(
             It.IsAny<Expression<Func<AccountBalance, bool>>>())).Returns(Task.FromResult(new AccountBalance()));
            _LatestBalancesOfAccountRepositoryMock.Setup(m => m.Add(It.IsAny<AccountBalance>())).Verifiable();
            _mockUnitOfWork.Setup(x => x.YodleeAccountBalanceRepository).Returns(_LatestBalancesOfAccountRepositoryMock.Object);
            _mockUnitOfWork.Setup(x => x.CompleteAsync()).Verifiable();
        }

        [Test]
        public async Task Test_GetAccountsQuery_SuccessStatusCode()
        {
            var configuration = await GetConfiguration();

            _newServiceHttpClient.Setup(x => x.GetAsync(It.IsAny<string>())).
                Returns(MediatrMockReturns(configuration.Url, HttpMethod.Get, YodleeEndpoints.GetAccounts,
                new StringContent(JsonConvert.SerializeObject(GetAccountsResponse()))));

            var token = await GetToken();
            var command = new GetAccountsQuery(new AccountsRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", YodleeEndpoints.GetAccounts)
            }, configuration, token.Token.Map());

            GetAccountsQueryHandler queryHandler = new GetAccountsQueryHandler(
                _mockUnitOfWork.Object, _newServiceHttpClient.Object, _loggerofGetAccountsQueryHandler.Object);

            var response = await queryHandler.Handle(command, CancellationToken.None);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [Test]
        public async Task Test_GetAccountsQuery_SuccessReponse()
        {
            var configuration = await GetConfiguration();

            _newServiceHttpClient.Setup(x => x.GetAsync(It.IsAny<string>())).
                Returns(MediatrMockReturns(configuration.Url, HttpMethod.Get, YodleeEndpoints.GetAccounts,
                new StringContent(JsonConvert.SerializeObject(GetAccountsResponse()))));

            var token = await GetToken();
            var command = new GetAccountsQuery(new AccountsRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", YodleeEndpoints.GetAccounts)
            }, configuration, token.Token.Map());

            GetAccountsQueryHandler queryHandler = new GetAccountsQueryHandler(
                _mockUnitOfWork.Object, _newServiceHttpClient.Object, _loggerofGetAccountsQueryHandler.Object);

            var response = await queryHandler.Handle(command, CancellationToken.None);
            var accountsResponse =
                   JsonConvert.DeserializeObject<AccountResponse>(
                       await response.Content.ReadAsStringAsync());

            Assert.IsNotNull(accountsResponse.Account);
        }
        
        [Test]
        public async Task Test_GetAccountDetail_SuccessStatusCode()
        {
            var configuration = await GetConfiguration();

            _newServiceHttpClient.Setup(x => x.GetAsync(It.IsAny<string>())).
                Returns(MediatrMockReturns(configuration.Url, HttpMethod.Get, YodleeEndpoints.GetAccounts,
                new StringContent(JsonConvert.SerializeObject(GetAccountsResponse()))));

            var token = await GetToken();
            var command = new GetAccountsQuery(new AccountsRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}",
                $"{YodleeEndpoints.GetProviderAccountsDetails}/1001456")
            }, configuration, token.Token.Map());

            GetAccountsQueryHandler queryHandler = new GetAccountsQueryHandler(
                _mockUnitOfWork.Object, _newServiceHttpClient.Object, _loggerofGetAccountsQueryHandler.Object);

            var response = await queryHandler.Handle(command, CancellationToken.None);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [Test]
        public async Task Test_GetAccountDetail_SuccessReponse()
        {
            var configuration = await GetConfiguration();

            _newServiceHttpClient.Setup(x => x.GetAsync(It.IsAny<string>())).
                Returns(MediatrMockReturns(configuration.Url, HttpMethod.Get, YodleeEndpoints.GetAccounts,
                new StringContent(JsonConvert.SerializeObject(GetAccountsResponse()))));

            var token = await GetToken();
            var command = new GetAccountsQuery(new AccountsRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}",
                $"{YodleeEndpoints.GetProviderAccountsDetails}/1001456")
            }, configuration, token.Token.Map());

            GetAccountsQueryHandler queryHandler = new GetAccountsQueryHandler(
                _mockUnitOfWork.Object, _newServiceHttpClient.Object, _loggerofGetAccountsQueryHandler.Object);

            var response = await queryHandler.Handle(command, CancellationToken.None);
            var accountsResponse =
                   JsonConvert.DeserializeObject<AccountResponse>(
                       await response.Content.ReadAsStringAsync());

            Assert.IsNotNull(accountsResponse.Account);
        }
        private object GetAccountsResponse()
        {
            return new AccountResponse()
            {
                Account = new List<Account>()
            };
        }

        [Test]
        public async Task Test_GetHistoricalBalances_SuccessStatusCode()
        {
            var configuration = await GetConfiguration();

            _newServiceHttpClient.Setup(x => x.GetAsync(It.IsAny<string>())).
                Returns(MediatrMockReturns(configuration.Url, HttpMethod.Get, YodleeEndpoints.GetHistoricalBalances,
                new StringContent(JsonConvert.SerializeObject(GetHistoricalAccountsResponse()))));

            var token = await GetToken();
            var command = new GetHistoricalAccountsQuery(new AccountsRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}",
                $"{YodleeEndpoints.GetHistoricalBalances}")
            }, configuration, token.Token.Map());

            GetHistoricalAccountsQueryHandler queryHandler = new GetHistoricalAccountsQueryHandler(
                _mockUnitOfWork.Object, _newServiceHttpClient.Object, _loggerofGetHistoricalAccountsQueryHandler.Object);

            var response = await queryHandler.Handle(command, CancellationToken.None);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [Test]
        public async Task Test_GetHistoricalBalances_SuccessReponse()
        {
            var configuration = await GetConfiguration();

            _newServiceHttpClient.Setup(x => x.GetAsync(It.IsAny<string>())).
                Returns(MediatrMockReturns(configuration.Url, HttpMethod.Get, YodleeEndpoints.GetHistoricalBalances,
                new StringContent(JsonConvert.SerializeObject(GetHistoricalAccountsResponse()))));

            var token = await GetToken();
            var command = new GetHistoricalAccountsQuery(new AccountsRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}",
                $"{YodleeEndpoints.GetHistoricalBalances}")
            }, configuration, token.Token.Map());

            GetHistoricalAccountsQueryHandler queryHandler = new GetHistoricalAccountsQueryHandler(
                _mockUnitOfWork.Object, _newServiceHttpClient.Object, _loggerofGetHistoricalAccountsQueryHandler.Object);

            var response = await queryHandler.Handle(command, CancellationToken.None);
            var accountsResponse =
                  JsonConvert.DeserializeObject<HistoricalAccountResponseBody>(
                      await response.Content.ReadAsStringAsync());

            Assert.IsNotNull(accountsResponse.Account);
        }

        private object GetHistoricalAccountsResponse()
        {
            return new HistoricalAccountResponseBody()
            {
                Account = new List<HistoricalAccount>()
            };
        }

        [Test]
        public async Task Test_GetLatestBalances_SuccessStatusCode()
        {
            var configuration = await GetConfiguration();

            _newServiceHttpClient.Setup(x => x.GetAsync(It.IsAny<string>())).
                Returns(MediatrMockReturns(configuration.Url, HttpMethod.Get, YodleeEndpoints.GetHistoricalBalances,
                new StringContent(JsonConvert.SerializeObject(GetLatestBalancesResponse()))));

            var token = await GetToken();
            var command = new GetLatestBalancesQuery(new AccountsRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}",
                $"{YodleeEndpoints.GetLatestBalances}")
            }, configuration, token.Token.Map());

            GetLatestBalancesQueryHandler queryHandler = new GetLatestBalancesQueryHandler(
                _mockUnitOfWork.Object, _newServiceHttpClient.Object, _loggerofGetLatestBalancesOfAccountsQueryHandler.Object);

            var response = await queryHandler.Handle(command, CancellationToken.None);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [Test]
        public async Task Test_GetLatestBalances_SuccessReponse()
        {
            var configuration = await GetConfiguration();

            _newServiceHttpClient.Setup(x => x.GetAsync(It.IsAny<string>())).
                Returns(MediatrMockReturns(configuration.Url, HttpMethod.Get, YodleeEndpoints.GetHistoricalBalances,
                new StringContent(JsonConvert.SerializeObject(GetLatestBalancesResponse()))));

            var token = await GetToken();
            var command = new GetLatestBalancesQuery(new AccountsRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}",
                $"{YodleeEndpoints.GetLatestBalances}")
            }, configuration, token.Token.Map());

            GetLatestBalancesQueryHandler queryHandler = new GetLatestBalancesQueryHandler(
                _mockUnitOfWork.Object, _newServiceHttpClient.Object, _loggerofGetLatestBalancesOfAccountsQueryHandler.Object);

            var response = await queryHandler.Handle(command, CancellationToken.None);
            var accountsResponse =
                  JsonConvert.DeserializeObject<GetLatestBalancesResponseBody>(
                      await response.Content.ReadAsStringAsync());

            Assert.IsNotNull(accountsResponse.AccountBalance);
        }

        private object GetLatestBalancesResponse()
        {
            return new GetLatestBalancesResponseBody()
            {
                AccountBalance = new List<AccountBalance>()
            };
        }

        [Test]
        public async Task Test_AddManualAccountCommand_SuccessStatusCode()
        {
            var configuration = await GetConfiguration();

            AddManualAccountCommandHandler queryHandler = new AddManualAccountCommandHandler(
                   _mockUnitOfWork.Object,
                   _newServiceHttpClient.Object, _loggerofAddManualAccountCommandHandler.Object);

            _newServiceHttpClient.Setup(x => x.PostJsonEncodedAsync(addManualAccountRequestBody, It.IsAny<string>())).
                Returns(MediatrMockReturns(configuration.Url,
                HttpMethod.Post, YodleeEndpoints.User));

            var command = new AddManualAccountCommand(new AccountsRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", $"{YodleeEndpoints.AddManualAccount}")
            }, configuration, new Domain.Model.Authorizations.YodleeAccessToken(), addManualAccountRequestBody);

            var response = await queryHandler.Handle(command, CancellationToken.None);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [Test]
        public async Task TestAddManualAccountCommandFails()
        {
            var configuration = await GetConfiguration();

            AddManualAccountCommandHandler queryHandler = new AddManualAccountCommandHandler(
                   _mockUnitOfWork.Object,
                   _newServiceHttpClient.Object, _loggerofAddManualAccountCommandHandler.Object);

            _newServiceHttpClient.Setup(x => x.PostJsonEncodedAsync(addManualAccountRequestBody, It.IsAny<string>())).
                Returns(MediatrMockReturnsNotFound(configuration.Url,
                HttpMethod.Post, YodleeEndpoints.User));

            var command = new AddManualAccountCommand(new AccountsRequest()
            {
                Endpoint = string.Concat("WrongUrl")
            }, configuration, new Domain.Model.Authorizations.YodleeAccessToken(),
            addManualAccountRequestBody);

            Assert.DoesNotThrow(code: () => response = queryHandler.Handle(command, CancellationToken.None));
        }


        private static AddManualAccountRequestBody CreateAddManualAccountRequestBody()
        {
            return
                new AddManualAccountRequestBody()
                {
                    Account = new AddManualAccount
                    {
                        AccountType = "BROKERAGE_CASH",
                        AccountName = "BNP Account",
                        Nickname = "Flood Cash",
                        AccountNumber = "1245",
                        Balance = new RunningBalance
                        {
                            Amount = 133789,
                            Currency = "USD"
                        },
                        IncludeInNetWorth = "True",
                        Memo = "This is an investment account"
                    }
                };
        }

        [Test]
        public async Task Test_UpdateAccountCommand_SuccessStatusCode()
        {
            var configuration = await GetConfiguration();

            UpdateAccountHandler queryHandler = new UpdateAccountHandler(
                        _mockUnitOfWork.Object,
                        _newServiceHttpClient.Object, _loggerofUpdateAccountHandler.Object);

            _newServiceHttpClient.Setup(x => x.PutAsync(updateAccountRequestBody, It.IsAny<string>())).
               Returns(MediatrMockReturns(configuration.Url,
               HttpMethod.Post, YodleeEndpoints.UpdateAccount));

            var command = new UpdateAccountCommand(new AccountsRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", $"{YodleeEndpoints.UpdateAccount}/10046961")
            }, configuration, new Domain.Model.Authorizations.YodleeAccessToken(), updateAccountRequestBody);

            var response = await queryHandler.Handle(command, CancellationToken.None);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }
        [Test]
        public async Task TestUpdateAccountCommandFails()
        {
            var configuration = await GetConfiguration();

            UpdateAccountHandler queryHandler = new UpdateAccountHandler(
                 _mockUnitOfWork.Object,
                 _newServiceHttpClient.Object, _loggerofUpdateAccountHandler.Object);

            _newServiceHttpClient.Setup(x => x.PutAsync(updateAccountRequestBody, It.IsAny<string>())).
               Returns(MediatrMockReturnsNotFound(configuration.Url,
               HttpMethod.Post, YodleeEndpoints.User));

            var command = new UpdateAccountCommand(new AccountsRequest()
            {
                Endpoint = string.Concat("WrongUrl")
            }, configuration, new Domain.Model.Authorizations.YodleeAccessToken(), updateAccountRequestBody);

            Assert.DoesNotThrow(code: () => response = queryHandler.Handle(command, CancellationToken.None));

        }


        private static UpdateAccountRequestBody CreateUpdateAccountRequestBody()
        {
            return
                new UpdateAccountRequestBody()
                {
                    Account = new UpdateAccountDetails()
                    {
                        Container = "string",
                        Address = new Address()
                        {
                            Zip = "string",
                            Country = "string",
                            Address3 = "string",
                            Address2 = "string",
                            City = "string",
                            SourceType = "string",
                            Address1 = "string",
                            Street = "string",
                            State = "string",
                            Type = "string"
                        },
                        Memo = "string",
                        HomeValue = new RunningBalance()
                        {
                            Amount = 0,
                        },
                        Balance = new RunningBalance()
                        {
                            Amount = 0
                        },
                        Is_E_billEnrolled = "string",
                        Nickname = "string",
                    }
                };
        }

        [Test]
        public async Task Test_EvaluateAddressCommand_SuccessStatusCode()
        {
            var configuration = await GetConfiguration();

            EvaluateAddressCommandHandler queryHandler = new EvaluateAddressCommandHandler(
                 _mockUnitOfWork.Object,
                 _newServiceHttpClient.Object, _loggerofEvaluateAddressCommandHandler.Object);

            _newServiceHttpClient.Setup(x => x.PostJsonEncodedAsync(evaluateAddressRequestBody, It.IsAny<string>())).
                Returns(MediatrMockReturns(configuration.Url,
                HttpMethod.Post, YodleeEndpoints.EvaluateAddress,
                new StringContent(JsonConvert.SerializeObject(GetAccountsResponse()))));

            var command = new EvaluateAddressCommand(new EvaluateAddressRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", $"{YodleeEndpoints.EvaluateAddress}")
            }, configuration, new Domain.Model.Authorizations.YodleeAccessToken(), evaluateAddressRequestBody);

            var response = await queryHandler.Handle(command, CancellationToken.None);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        private static EvaluateAddressRequestBody CreateEvaluateRequestBody()
        {
            EvaluateAddressRequestBody evaluateAddressRequestBody =
                new EvaluateAddressRequestBody()
                {
                    Address = new Address()
                    {
                        Zip = "string",
                        Country = "string",
                        Address3 = "string",
                        Address2 = "string",
                        City = "string",
                        SourceType = "string",
                        Address1 = "string",
                        Street = "string",
                        State = "string",
                        Type = "string"
                    }
                };
            return evaluateAddressRequestBody;
        }

        [Test]
        public async Task Test_DeleteAccountCommand_SuccessStatusCode()
        {
            var configuration = await GetConfiguration();

            DeleteAccountHandler queryHandler = new DeleteAccountHandler(
                          _mockUnitOfWork.Object,
                          _newServiceHttpClient.Object, _loggerofDeleteAccountHandler.Object);

            _newServiceHttpClient.Setup(x => x.DeleteAsync(It.IsAny<string>())).
                Returns(MediatrMockReturns(configuration.Url,
                HttpMethod.Delete, YodleeEndpoints.User));

            var command = new DeleteAccountCommand(new AccountsRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", $"{YodleeEndpoints.DeleteAccount}/101403")
            }, configuration, new Domain.Model.Authorizations.YodleeAccessToken());

            var response = await queryHandler.Handle(command, CancellationToken.None);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }
        [Test]
        public async Task TestDeleteAccountCommandFails()
        {
            var configuration = await GetConfiguration();

            DeleteAccountHandler queryHandler = new DeleteAccountHandler(
                 _mockUnitOfWork.Object,
                 _newServiceHttpClient.Object, _loggerofDeleteAccountHandler.Object);

            _newServiceHttpClient.Setup(x => x.DeleteAsync(It.IsAny<string>())).
                Returns(MediatrMockReturnsNotFound(configuration.Url,
                HttpMethod.Delete, YodleeEndpoints.User));

            var command = new DeleteAccountCommand(new AccountsRequest()
            {
                Endpoint = string.Concat("WrongUrl")
            }, configuration, new Domain.Model.Authorizations.YodleeAccessToken());

            Assert.DoesNotThrow(code: () => response = queryHandler.Handle(command, CancellationToken.None));
        }
    }
}