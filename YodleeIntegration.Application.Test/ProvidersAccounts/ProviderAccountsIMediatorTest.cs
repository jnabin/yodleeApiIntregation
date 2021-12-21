using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using YodleeIntegration.Api.Models;
using YodleeIntegration.Application.ProvidersAccounts;
using YodleeIntegration.Application.ProvidersAccounts.DeleteProviderAccount;
using YodleeIntegration.Application.ProvidersAccounts.GetUserProfileDetails;
using YodleeIntegration.Application.ProvidersAccounts.UpdateAccountPreferences;
using YodleeIntegration.Application.ProvidersAccounts.UpdateProviderAccount;
using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Application.Request;
using YodleeIntegration.Application.Response;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.Test.ProvidersAccounts
{
    public class ProviderAccountsIMediatorTest : BaseTest
    {
        private Mock<ILogger<GetProvidersAccountQueryHandler>> _loggerProviderAccount;
        private Mock<ILogger<GetUserProfileDetailsQueryHandler>> _loggerUserProfile;        
        private Mock<ILogger<UpdateAccountPreferencesHandler>> _loggerUpdateAccountPreference;
        private Mock<ILogger<UpdateProviderAccountHandler>> _loggerUpdateAccount;
        private Mock<ILogger<DeleteProviderAccountHandler>> _loggerDeleteProviderAccount;
        private Mock<IYodleeProviderAccountProfileRepository> _userProfileRepositoryMock;
        private Mock<IYodleeProviderAccountRepository> _providerAccountRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _loggerProviderAccount = new Mock<ILogger<GetProvidersAccountQueryHandler>>();
            _loggerUserProfile = new Mock<ILogger<GetUserProfileDetailsQueryHandler>>();
            _loggerUpdateAccountPreference = new Mock<ILogger<UpdateAccountPreferencesHandler>>();
            _loggerUpdateAccount = new Mock<ILogger<UpdateProviderAccountHandler>>();
            _loggerDeleteProviderAccount = new Mock<ILogger<DeleteProviderAccountHandler>>();

            _providerAccountRepositoryMock = new Mock<IYodleeProviderAccountRepository>();
            _providerAccountRepositoryMock.Setup(m => m.SingleOrDefaultAsync(
                It.IsAny<Expression<Func<ProviderAccount, bool>>>())).Returns(Task.FromResult(new ProviderAccount()));
            _providerAccountRepositoryMock.Setup(m => m.Add(It.IsAny<ProviderAccount>())).Verifiable();
            _mockUnitOfWork.Setup(x => x.YodleeProviderAccountRepository).Returns(_providerAccountRepositoryMock.Object);
            _mockUnitOfWork.Setup(x => x.CompleteAsync()).Verifiable();

            _userProfileRepositoryMock = new Mock<IYodleeProviderAccountProfileRepository>();
            _userProfileRepositoryMock.Setup(m => m.SingleOrDefaultAsync(
                It.IsAny<Expression<Func<ProviderAccountProfile, bool>>>())).Returns(Task.FromResult(new ProviderAccountProfile()));
            _userProfileRepositoryMock.Setup(m => m.Add(It.IsAny<ProviderAccountProfile>())).Verifiable();
            _mockUnitOfWork.Setup(x => x.YodleeProviderAccountProfileRepository).Returns(_userProfileRepositoryMock.Object);
            _mockUnitOfWork.Setup(x => x.CompleteAsync()).Verifiable();
        }

        [Test]
        public async Task Test_GetProviderAccounts_SucceedsStatusCode()
        {
            var configuration = await GetConfiguration();
            _newServiceHttpClient.Setup(x => x.GetAsync(It.IsAny<string>())).
                Returns(MediatrMockReturns(configuration.Url, HttpMethod.Get, YodleeEndpoints.GetProviderAccounts));

            var token = await GetToken();
            var command = new GetProvidersAccountQuery(new ProvidersAccountRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", YodleeEndpoints.GetProviderAccounts)
            }, configuration, token.Token.Map());

            GetProvidersAccountQueryHandler queryHandler = new GetProvidersAccountQueryHandler(
                _mockUnitOfWork.Object, _newServiceHttpClient.Object, _loggerProviderAccount.Object);

            var response = await queryHandler.Handle(command, CancellationToken.None);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [Test]
        public async Task Test_GetProviderAccounts_SucceedsResponse()
        {
            var configuration = await GetConfiguration();
            _newServiceHttpClient.Setup(x => x.GetAsync(It.IsAny<string>())).
                Returns(MediatrMockReturns(configuration.Url, HttpMethod.Get, YodleeEndpoints.GetProviderAccounts,
                new StringContent(JsonConvert.SerializeObject(GetProviderAccountResponseList()))));

            var token = await GetToken();
            var command = new GetProvidersAccountQuery(new ProvidersAccountRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", YodleeEndpoints.GetProviderAccounts)
            }, configuration, token.Token.Map());

            GetProvidersAccountQueryHandler queryHandler = new GetProvidersAccountQueryHandler(
                _mockUnitOfWork.Object, _newServiceHttpClient.Object, _loggerProviderAccount.Object);

            var response = await queryHandler.Handle(command, CancellationToken.None);
            var providerResponse =
                     JsonConvert.DeserializeObject<ProviderAccountResponseList>(
                         await response.Content.ReadAsStringAsync());

            Assert.IsNotNull(providerResponse.ProviderAccount);
        }

        private static ProviderAccountResponseList GetProviderAccountResponseList()
        {
            return new ProviderAccountResponseList
            {
                ProviderAccount = new List<ProviderAccount>()
            };
        }

        [Test]
        public async Task Test_GetUserProfileDetails_SuccessStatus()
        {
            var configuration = await GetConfiguration();
            _newServiceHttpClient.Setup(x => x.GetAsync(It.IsAny<string>())).
                Returns(MediatrMockReturns(configuration.Url, HttpMethod.Get, YodleeEndpoints.GetUserProfileDetails));

            var token = await GetToken();
            var command = new GetUserProfileDetailsQuery(new ProvidersAccountRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", YodleeEndpoints.GetUserProfileDetails)
            }, configuration, token.Token.Map());

            GetUserProfileDetailsQueryHandler queryHandler = new GetUserProfileDetailsQueryHandler(
                _mockUnitOfWork.Object, _newServiceHttpClient.Object, _loggerUserProfile.Object);

            var response = await queryHandler.Handle(command, CancellationToken.None);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [Test]
        public async Task Test_GetUserProfileDetails_SuccessRepsonse()
        {
            var configuration = await GetConfiguration();
            _newServiceHttpClient.Setup(x => x.GetAsync(It.IsAny<string>())).
                Returns(MediatrMockReturns(configuration.Url, HttpMethod.Get, YodleeEndpoints.GetUserProfileDetails,
                new StringContent(JsonConvert.SerializeObject(GetUserProfileDetailsResponse()))));

            var token = await GetToken();
            var command = new GetUserProfileDetailsQuery(new ProvidersAccountRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", YodleeEndpoints.GetUserProfileDetails)
            }, configuration, token.Token.Map());

            GetUserProfileDetailsQueryHandler queryHandler = new GetUserProfileDetailsQueryHandler(
                _mockUnitOfWork.Object, _newServiceHttpClient.Object, _loggerUserProfile.Object);

            var response = await queryHandler.Handle(command, CancellationToken.None);
            var providerResponse =
                     JsonConvert.DeserializeObject<UserProfileDetailsResponse>(
                         await response.Content.ReadAsStringAsync());

            Assert.IsNotNull(providerResponse.ProviderAccount);
        }

        private static UserProfileDetailsResponse GetUserProfileDetailsResponse()
        {
            return new UserProfileDetailsResponse
            {
                ProviderAccount = new List<ProviderAccountProfile>()
            };
        }

        [Test]
        public async Task Test_UpdateAccountPreferences_SuccessStatusCode()
        {            
            var configuration = await GetConfiguration();
            UpdateAccountPreferencesRequestBody updateAccountPreferencesRequestBody = CreateUpdateAccountPreferencesRequestBody();

            var token = await GetToken();
            var command = new UpdateAccountPreferencesCommand(new ProvidersAccountRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", $"{YodleeEndpoints.UpdateAccount}/10046961/preferences")
            }, configuration, token.Token.Map(), updateAccountPreferencesRequestBody);

            _newServiceHttpClient.Setup(x => x.PutAsync(updateAccountPreferencesRequestBody, It.IsAny<string>())).
                Returns(MediatrMockReturns(configuration.Url, HttpMethod.Put, $"{YodleeEndpoints.UpdateAccount}/10046961/preferences"));


            UpdateAccountPreferencesHandler queryHandler = new UpdateAccountPreferencesHandler(
                _mockUnitOfWork.Object, _newServiceHttpClient.Object, _loggerUpdateAccountPreference.Object);

            var response = await queryHandler.Handle(command, CancellationToken.None);
            Assert.IsTrue(response.IsSuccessStatusCode);


        }
       
        private static UpdateAccountPreferencesRequestBody CreateUpdateAccountPreferencesRequestBody()
        {
            return
                new UpdateAccountPreferencesRequestBody()
                {
                    Preferences = new ProviderAccountPreference()
                    {
                        LinkedProviderAccountId = 1,
                        IsAutoRefreshEnabled = true
                    }
                };
        }

        [Test]
        public async Task Test_UpdateProviderAccountCommand_SuccessStatusCode()
        {
            var configuration = await GetConfiguration();
            ProviderAccountRequestBody providerAccountRequestBody = CreateUpdateProviderAccountRequestBody();

            var token = await GetToken();
            var command = new UpdateProviderAccountCommand(new ProvidersAccountRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", $"{YodleeEndpoints.UpdateProviderAccount}/10046961")
            }, configuration, token.Token.Map(), providerAccountRequestBody);

            _newServiceHttpClient.Setup(x => x.PutAsync(providerAccountRequestBody, It.IsAny<string>())).Returns(
                MediatrMockReturns(configuration.Url, HttpMethod.Put, $"{YodleeEndpoints.UpdateProviderAccount}/10046961"));

            UpdateProviderAccountHandler queryHandler = new UpdateProviderAccountHandler(
                _mockUnitOfWork.Object, _newServiceHttpClient.Object, _loggerUpdateAccount.Object);

            var response = await queryHandler.Handle(command, CancellationToken.None);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        private static ProviderAccountRequestBody CreateUpdateProviderAccountRequestBody()
        {
            return
                new ProviderAccountRequestBody()
                {
                    ConsentId = 0,
                    Preferences = new ProviderAccountPreference()
                    {
                        LinkedProviderAccountId = 0,
                        IsAutoRefreshEnabled = true
                    },
                    Field = new List<UpdateProviderAccountField>()
                    {
                        new UpdateProviderAccountField()
                        {
                            Image = "string",
                            EntityId = 0,
                            Value = "string"
                        }
                    }
                };
        }

        [Test]
        public async Task Test_DeleteProviderAccountCommand_Succeeds()
        {
            var configuration = await GetConfiguration();

            var token = await GetToken();
            var command = new DeleteProviderAccountCommand(new ProvidersAccountRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", $"{YodleeEndpoints.DeleteProviderAccount}/101403")
            }, configuration, token.Token.Map());

            _newServiceHttpClient.Setup(x => x.DeleteAsync(It.IsAny<string>())).
                Returns(MediatrMockReturns(configuration.Url, HttpMethod.Delete, $"{YodleeEndpoints.DeleteProviderAccount}/101403"));

            DeleteProviderAccountHandler queryHandler = new DeleteProviderAccountHandler(
                _mockUnitOfWork.Object, _newServiceHttpClient.Object, _loggerDeleteProviderAccount.Object);

            var response = await queryHandler.Handle(command, CancellationToken.None);
            Assert.IsTrue(response.IsSuccessStatusCode);

        }

    }
}