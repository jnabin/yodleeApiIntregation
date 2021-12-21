using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using YodleeIntegration.Api.Controllers.Accounts;
using YodleeIntegration.Api.Models;
using YodleeIntegration.Application.Accounts.AddManualAccount;
using YodleeIntegration.Application.Accounts.DeleteAccount;
using YodleeIntegration.Application.Accounts.EvaluateAddress;
using YodleeIntegration.Application.Accounts.GetAccounts;
using YodleeIntegration.Application.Accounts.GetHistoricalAccounts;
using YodleeIntegration.Application.Accounts.GetLatestBalances;
using YodleeIntegration.Application.Accounts.UpdateAccount;
using YodleeIntegration.Application.Request;
using YodleeIntegration.Domain.Entities;
using Assert = NUnit.Framework.Assert;

namespace YodleeIntegration.Api.Test.Accounts
{
    public class AccountsControllerTests : BaseApiTest
    {
        [Test]
        public async Task Test_GetAccounts_Succeeds()
        {
            GetImeadiatrMockForGetAccounts(HttpStatusCode.OK, HttpMethod.Get);

            var accountsController = new AccountsController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await accountsController.GetAccounts(new GetAccountsQueryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetAccounts_InvalidStatus()
        {
            GetImeadiatrMockForGetAccounts(HttpStatusCode.BadRequest, HttpMethod.Get);

            var accountsController = new AccountsController(_mockMediatr.Object, _baseControllerMock.Object);
            accountsController.ModelState.AddModelError(string.Empty, "Invalid value for status");

            IActionResult result = await accountsController.GetAccounts(new GetAccountsQueryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetAccounts_InvalidContainer()
        {
            GetImeadiatrMockForGetAccounts(HttpStatusCode.BadRequest, HttpMethod.Get);

            var accountsController = new AccountsController(_mockMediatr.Object, _baseControllerMock.Object);
            accountsController.ModelState.AddModelError(string.Empty, "Invalid value for container");

            IActionResult result = await accountsController.GetAccounts(new GetAccountsQueryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetAccounts_InvalidProviderId()
        {
            GetImeadiatrMockForGetAccounts(HttpStatusCode.BadRequest, HttpMethod.Get);

            var accountsController = new AccountsController(_mockMediatr.Object, _baseControllerMock.Object);
            accountsController.ModelState.AddModelError(string.Empty, "Invalid value for providerId");

            IActionResult result = await accountsController.GetAccounts(new GetAccountsQueryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetAccounts_MaxAccountIdExceeds()
        {
            GetImeadiatrMockForGetAccounts(HttpStatusCode.BadRequest, HttpMethod.Get);

            var accountsController = new AccountsController(_mockMediatr.Object, _baseControllerMock.Object);
            accountsController.ModelState.AddModelError(string.Empty,
                "The maximum number of accountIds permitted is 100");

            IActionResult result = await accountsController.GetAccounts(new GetAccountsQueryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetAccounts_Unauthorize()
        {
            var expected = HttpStatusCode.Unauthorized;

            var response = await _client.GetAsync("/api/v1/Accounts/GetAccounts");

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_GetAccounts_Notfound()
        {
            var expected = HttpStatusCode.NotFound;

            var response = await _client.GetAsync("/api/v1/Accounts/GetAccou");

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_GetAccountsDetail_Succeeds()
        {
            GetImeadiatrMockForGetAccounts(HttpStatusCode.OK, HttpMethod.Get);

            var accountsController = new AccountsController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await accountsController.GetAccountDetail(new GetAccountsDetailQueryParams(),
                "1012345");

            var okResult = result as ObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);
        }

        private void GetImeadiatrMockForGetAccounts(HttpStatusCode request,
          HttpMethod response)
        {
            _mockMediatr.Setup(m => m.Send(It.IsAny<GetAccountsQuery>(),
                 It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(request, response));
        }

        [Test]
        public async Task Test_GetAccountsDetail_Unauthorize()
        {
            var expected = HttpStatusCode.Unauthorized;

            var response = await _client.GetAsync("/api/v1/Accounts/GetAccountDetail/1233");

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_GetAccountsDetail_NotFound()
        {
            var expected = HttpStatusCode.NotFound;

            var response = await _client.GetAsync("/api/v1/Accounts/GetAccou/1233");

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_GetHistoricalBalances_Succeeds()
        {
            GetImeadiatrMockForGetHistoricalBalances(HttpStatusCode.OK, HttpMethod.Get);

            var accountsController = new AccountsController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await accountsController.GetHistoricalBalances(
                new GetHistoricalBalancesQueryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetHistoricalBalances_InvalidAccountId()
        {
            GetImeadiatrMockForGetHistoricalBalances(HttpStatusCode.BadRequest, HttpMethod.Get);

            var accountsController = new AccountsController(_mockMediatr.Object, _baseControllerMock.Object);
            accountsController.ModelState.AddModelError(string.Empty, "invalid value for accountId");

            IActionResult result = await accountsController.GetHistoricalBalances(
                new GetHistoricalBalancesQueryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetHistoricalBalances_InvalidFromDate()
        {
            GetImeadiatrMockForGetHistoricalBalances(HttpStatusCode.BadRequest, HttpMethod.Get);

            var accountsController = new AccountsController(_mockMediatr.Object, _baseControllerMock.Object);
            accountsController.ModelState.AddModelError(string.Empty, "invalid value for fromDate");

            IActionResult result = await accountsController.GetHistoricalBalances(
                new GetHistoricalBalancesQueryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetHistoricalBalances_InvalidToDate()
        {
            GetImeadiatrMockForGetHistoricalBalances(HttpStatusCode.BadRequest, HttpMethod.Get);

            var accountsController = new AccountsController(_mockMediatr.Object, _baseControllerMock.Object);
            accountsController.ModelState.AddModelError(string.Empty, "invalid value for toDate");

            IActionResult result = await accountsController.GetHistoricalBalances(
                new GetHistoricalBalancesQueryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetHistoricalBalances_InvalidDateRange()
        {
            GetImeadiatrMockForGetHistoricalBalances(HttpStatusCode.BadRequest, HttpMethod.Get);

            var accountsController = new AccountsController(_mockMediatr.Object, _baseControllerMock.Object);
            accountsController.ModelState.AddModelError(string.Empty, "invalid value for dateRange");

            IActionResult result = await accountsController.GetHistoricalBalances(
                new GetHistoricalBalancesQueryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetHistoricalBalances_InvalidInterval()
        {
            GetImeadiatrMockForGetHistoricalBalances(HttpStatusCode.BadRequest, HttpMethod.Get);

            var accountsController = new AccountsController(_mockMediatr.Object, _baseControllerMock.Object);
            accountsController.ModelState.AddModelError(string.Empty, "invalid value for interval");

            IActionResult result = await accountsController.GetHistoricalBalances(
                new GetHistoricalBalancesQueryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetHistoricalBalances_FutureDateNotAllowed()
        {
            GetImeadiatrMockForGetHistoricalBalances(HttpStatusCode.BadRequest, HttpMethod.Get);

            var accountsController = new AccountsController(_mockMediatr.Object, _baseControllerMock.Object);
            accountsController.ModelState.AddModelError(string.Empty, "future date is not allowed");

            IActionResult result = await accountsController.GetHistoricalBalances(
                new GetHistoricalBalancesQueryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        private void GetImeadiatrMockForGetHistoricalBalances(HttpStatusCode request,
          HttpMethod response)
        {
            _mockMediatr.Setup(m => m.Send(It.IsAny<GetHistoricalAccountsQuery>(),
                 It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(request, response));
        }

        [Test]
        public async Task Test_GetHistoricalBalances_Unauthorize()
        {
            var expected = HttpStatusCode.Unauthorized;

            var response = await _client.GetAsync("/api/v1/Accounts/GetHistoricalBalances");

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_GetHistoricalBalances_NotFound()
        {
            var expected = HttpStatusCode.NotFound;

            var response = await _client.GetAsync("/api/v1/Accounts/GetHistorical");

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_GetLatestBalances_Succeeds()
        {
            GetImeadiatrMockForGetLatestBalances(HttpStatusCode.OK, HttpMethod.Get);

            var accountsController = new AccountsController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await accountsController.GetLatestBalances(new GetLatestBalancesQueryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetLatestBalances_InvalidProviderAccountId()
        {
            GetImeadiatrMockForGetLatestBalances(HttpStatusCode.BadRequest, HttpMethod.Get);

            var accountsController = new AccountsController(_mockMediatr.Object, _baseControllerMock.Object);
            accountsController.ModelState.AddModelError(string.Empty, "inavlid value for providerAccountId");

            IActionResult result = await accountsController.GetLatestBalances(new GetLatestBalancesQueryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetLatestBalances_InvalidAccountId()
        {
            GetImeadiatrMockForGetLatestBalances(HttpStatusCode.BadRequest, HttpMethod.Get);

            var accountsController = new AccountsController(_mockMediatr.Object, _baseControllerMock.Object);
            accountsController.ModelState.AddModelError(string.Empty, "inavlid value for AccountId");

            IActionResult result = await accountsController.GetLatestBalances(new GetLatestBalancesQueryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetLatestBalances_ServiceNotSupported()
        {
            GetImeadiatrMockForGetLatestBalances(HttpStatusCode.BadRequest, HttpMethod.Get);

            var accountsController = new AccountsController(_mockMediatr.Object, _baseControllerMock.Object);
            accountsController.ModelState.AddModelError(string.Empty, "service not supported");

            IActionResult result = await accountsController.GetLatestBalances(new GetLatestBalancesQueryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetLatestBalances_ProviderAccountIdRequired()
        {
            GetImeadiatrMockForGetLatestBalances(HttpStatusCode.BadRequest, HttpMethod.Get);

            var accountsController = new AccountsController(_mockMediatr.Object, _baseControllerMock.Object);
            accountsController.ModelState.AddModelError(string.Empty, "provider accountId required");

            IActionResult result = await accountsController.GetLatestBalances(new GetLatestBalancesQueryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetLatestBalances_MultipleProviderAccountIdNotSupported()
        {
            GetImeadiatrMockForGetLatestBalances(HttpStatusCode.BadRequest, HttpMethod.Get);

            var accountsController = new AccountsController(_mockMediatr.Object, _baseControllerMock.Object);
            accountsController.ModelState.AddModelError(string.Empty, "multiple provider accountId not supported");

            IActionResult result = await accountsController.GetLatestBalances(new GetLatestBalancesQueryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetLatestBalances_AccountIdRequired()
        {
            GetImeadiatrMockForGetLatestBalances(HttpStatusCode.BadRequest, HttpMethod.Get);

            var accountsController = new AccountsController(_mockMediatr.Object, _baseControllerMock.Object);
            accountsController.ModelState.AddModelError(string.Empty, "AccountId is required");

            IActionResult result = await accountsController.GetLatestBalances(new GetLatestBalancesQueryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetLatestBalances_MaxAccountIdsExceeds()
        {
            GetImeadiatrMockForGetLatestBalances(HttpStatusCode.BadRequest, HttpMethod.Get);

            var accountsController = new AccountsController(_mockMediatr.Object, _baseControllerMock.Object);
            accountsController.ModelState.AddModelError(string.Empty,
                "the maximum number of accountids permitted is 10");

            IActionResult result = await accountsController.GetLatestBalances(new GetLatestBalancesQueryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        private void GetImeadiatrMockForGetLatestBalances(HttpStatusCode request,
         HttpMethod response)
        {
            _mockMediatr.Setup(m => m.Send(It.IsAny<GetLatestBalancesQuery>(),
                 It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(request, response));
        }

        [Test]
        public async Task Test_GetLatestBalances_Unauthorize()
        {
            var expected = HttpStatusCode.Unauthorized;

            var response = await _client.GetAsync("/api/v1/Accounts/GetLatestBalances");

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_GetLatestBalances_NotFound()
        {
            var expected = HttpStatusCode.NotFound;

            var response = await _client.GetAsync("/api/v1/Accounts/GetLatestBals");

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_AddManualAccount_Succeeds()
        {
            GetImeadiatrMockForAddManualAccount(HttpStatusCode.OK, HttpMethod.Post);

            var accountsController = new AccountsController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await accountsController.AddManualAccount(CreateAddManualAccountRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task Test_AddManualAccount_InvalidAccountParam()
        {
            GetImeadiatrMockForAddManualAccount(HttpStatusCode.BadRequest, HttpMethod.Post);

            var accountsController = new AccountsController(_mockMediatr.Object, _baseControllerMock.Object);
            accountsController.ModelState.AddModelError(string.Empty, "Invalid value for accountParam");

            IActionResult result = await accountsController.AddManualAccount(CreateAddManualAccountRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_AddManualAccount_RealStagePropertyExist()
        {
            GetImeadiatrMockForAddManualAccount(HttpStatusCode.BadRequest, HttpMethod.Post);

            var accountsController = new AccountsController(_mockMediatr.Object, _baseControllerMock.Object);
            accountsController.ModelState.AddModelError(string.Empty, "Real Estage property already exists");

            IActionResult result = await accountsController.AddManualAccount(CreateAddManualAccountRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_AddManualAccount_ProviderAddressInvalid()
        {
            GetImeadiatrMockForAddManualAccount(HttpStatusCode.BadRequest, HttpMethod.Post);

            var accountsController = new AccountsController(_mockMediatr.Object, _baseControllerMock.Object);
            accountsController.ModelState.AddModelError(string.Empty, "the provider address is invalid");

            IActionResult result = await accountsController.AddManualAccount(CreateAddManualAccountRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_AddManualAccount_MultipleMatchesFound()
        {
            GetImeadiatrMockForAddManualAccount(HttpStatusCode.BadRequest, HttpMethod.Post);

            var accountsController = new AccountsController(_mockMediatr.Object, _baseControllerMock.Object);
            accountsController.ModelState.AddModelError(string.Empty, "Multiple matches found");

            IActionResult result = await accountsController.AddManualAccount(CreateAddManualAccountRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        private void GetImeadiatrMockForAddManualAccount(HttpStatusCode request,
          HttpMethod response)
        {
            _mockMediatr.Setup(m => m.Send(It.IsAny<AddManualAccountCommand>(),
                 It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(request, response));
        }

        [Test]
        public async Task Test_AddManualAccount_Unauthorize()
        {
            var expected = HttpStatusCode.Unauthorized;

            var response = await _client.PostAsJsonAsync("/api/v1/Accounts/AddManualAccount",
                CreateAddManualAccountRequestBody());

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_AddManualAccount_NotFound()
        {
            var expected = HttpStatusCode.NotFound;

            var response = await _client.PostAsJsonAsync("/api/v1/Accounts/AddManualA",
                CreateAddManualAccountRequestBody());

            Assert.AreEqual(expected, response.StatusCode);
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
        public async Task Test_EvaluateAddress_Succeeds()
        {
            GetImeadiatrMockForEvaluateAddress(HttpStatusCode.OK, HttpMethod.Post);

            var accountsController = new AccountsController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await accountsController.EvaluateAddress(CreateEvaluateRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task Test_EvaluateAddress_InvalidInput()
        {
            GetImeadiatrMockForEvaluateAddress(HttpStatusCode.BadRequest, HttpMethod.Post);

            var accountsController = new AccountsController(_mockMediatr.Object, _baseControllerMock.Object);
            accountsController.ModelState.AddModelError(string.Empty, "invalid input");

            IActionResult result = await accountsController.EvaluateAddress(CreateEvaluateRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_EvaluateAddress_InvalidValueForZip()
        {
            GetImeadiatrMockForEvaluateAddress(HttpStatusCode.BadRequest, HttpMethod.Post);

            var accountsController = new AccountsController(_mockMediatr.Object, _baseControllerMock.Object);
            accountsController.ModelState.AddModelError(string.Empty, "invalid value for zip");

            IActionResult result = await accountsController.EvaluateAddress(CreateEvaluateRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_EvaluateAddress_AddressMissing()
        {
            GetImeadiatrMockForEvaluateAddress(HttpStatusCode.BadRequest, HttpMethod.Post);

            var accountsController = new AccountsController(_mockMediatr.Object, _baseControllerMock.Object);
            accountsController.ModelState.AddModelError(string.Empty, "address missing in the request");

            IActionResult result = await accountsController.EvaluateAddress(CreateEvaluateRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_EvaluateAddress_StreetMissing()
        {
            GetImeadiatrMockForEvaluateAddress(HttpStatusCode.BadRequest, HttpMethod.Post);

            var accountsController = new AccountsController(_mockMediatr.Object, _baseControllerMock.Object);
            accountsController.ModelState.AddModelError(string.Empty, "street missing in the request");

            IActionResult result = await accountsController.EvaluateAddress(CreateEvaluateRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_EvaluateAddress_StateCityMissing()
        {
            GetImeadiatrMockForEvaluateAddress(HttpStatusCode.BadRequest, HttpMethod.Post);

            var accountsController = new AccountsController(_mockMediatr.Object, _baseControllerMock.Object);
            accountsController.ModelState.AddModelError(string.Empty, "state & city / zip missing in the request");

            IActionResult result = await accountsController.EvaluateAddress(CreateEvaluateRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        private void GetImeadiatrMockForEvaluateAddress(HttpStatusCode request,
          HttpMethod response)
        {
            _mockMediatr.Setup(m => m.Send(It.IsAny<EvaluateAddressCommand>(),
                 It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(request, response));
        }

        [Test]
        public async Task Test_EvaluateAddress_Unauthorize()
        {
            var expected = HttpStatusCode.Unauthorized;

            var response = await _client.PostAsJsonAsync("/api/v1/Accounts/EvaluateAddress",
                CreateEvaluateRequestBody());

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_EvaluateAddress_NotFound()
        {
            var expected = HttpStatusCode.NotFound;

            var response = await _client.PostAsJsonAsync("/api/v1/Accounts/NotFound",
                CreateEvaluateRequestBody());

            Assert.AreEqual(expected, response.StatusCode);
        }

        private static EvaluateAddressRequestBody CreateEvaluateRequestBody()
        {
            return
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
        }

        [Test]
        public async Task Test_UpdateAccount_Succeeds()
        {
            GetImeadiatrMockForUpdateAccount(HttpStatusCode.NoContent, HttpMethod.Put);

            var accountsController = new AccountsController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await accountsController.UpdateAccount("1012345",CreateUpdateAccountRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(204, okResult.StatusCode);
        }

        [Test]
        public async Task Test_UpdateAccount_InvalidAccountId()
        {
            GetImeadiatrMockForUpdateAccount(HttpStatusCode.BadRequest, HttpMethod.Put);

            var accountsController = new AccountsController(_mockMediatr.Object, _baseControllerMock.Object);
            accountsController.ModelState.AddModelError(string.Empty, "invalid value for accountId");

            IActionResult result = await accountsController.UpdateAccount("1012345", CreateUpdateAccountRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_UpdateAccount_InvalidUpdateParam()
        {
            GetImeadiatrMockForUpdateAccount(HttpStatusCode.BadRequest, HttpMethod.Put);

            var accountsController = new AccountsController(_mockMediatr.Object, _baseControllerMock.Object);
            accountsController.ModelState.AddModelError(string.Empty, "invalid value for updateparam");

            IActionResult result = await accountsController.UpdateAccount("1012345", CreateUpdateAccountRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_UpdateAccount_InvalidProvidedAddress()
        {
            GetImeadiatrMockForUpdateAccount(HttpStatusCode.BadRequest, HttpMethod.Put);

            var accountsController = new AccountsController(_mockMediatr.Object, _baseControllerMock.Object);
            accountsController.ModelState.AddModelError(string.Empty, "invalid value for providedAddress");

            IActionResult result = await accountsController.UpdateAccount("1012345", CreateUpdateAccountRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_UpdateAccount_NoActionAllowed()
        {
            GetImeadiatrMockForUpdateAccount(HttpStatusCode.BadRequest, HttpMethod.Put);

            var accountsController = new AccountsController(_mockMediatr.Object, _baseControllerMock.Object);
            accountsController.ModelState.AddModelError(string.Empty, "No action is allowed");

            IActionResult result = await accountsController.UpdateAccount("1012345", CreateUpdateAccountRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_UpdateAccount_MultipleMatchesFound()
        {
            GetImeadiatrMockForUpdateAccount(HttpStatusCode.BadRequest, HttpMethod.Put);

            var accountsController = new AccountsController(_mockMediatr.Object, _baseControllerMock.Object);
            accountsController.ModelState.AddModelError(string.Empty, "Multiple mathces found");

            IActionResult result = await accountsController.UpdateAccount("1012345", CreateUpdateAccountRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        private void GetImeadiatrMockForUpdateAccount(HttpStatusCode request,
          HttpMethod response)
        {
            _mockMediatr.Setup(m => m.Send(It.IsAny<UpdateAccountCommand>(),
                 It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(request, response));
        }

        [Test]
        public async Task Test_UpdateAccount_Unauthorize()
        {
            var expected = HttpStatusCode.Unauthorized;

            var response = await _client.PutAsJsonAsync("/api/v1/Accounts/UpdateAccount/1234",
                CreateEvaluateRequestBody());

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_UpdateAccount_NotFound()
        {
            var expected = HttpStatusCode.NotFound;

            var response = await _client.PostAsJsonAsync("/api/v1/Accounts/UpdateAc/1234",
                CreateEvaluateRequestBody());

            Assert.AreEqual(expected, response.StatusCode);
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
        public async Task Test_DeleteAccount_Succeeds()
        {
            GetImeadiatrMockForDeleteAccount(HttpStatusCode.NoContent, HttpMethod.Delete);

            var accountsController = new AccountsController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await accountsController.DeleteAccount("1012345");

            var okResult = result as ObjectResult;

            Assert.AreEqual(204, okResult.StatusCode);
        }

        [Test]
        public async Task Test_DeleteAccount_InvalidAccountId()
        {
            GetImeadiatrMockForDeleteAccount(HttpStatusCode.BadRequest, HttpMethod.Delete);

            var accountsController = new AccountsController(_mockMediatr.Object, _baseControllerMock.Object);
            accountsController.ModelState.AddModelError(string.Empty, "invalid value for accountId");

            IActionResult result = await accountsController.DeleteAccount("1012345");

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_DeleteAccount_InvalidInput()
        {
            GetImeadiatrMockForDeleteAccount(HttpStatusCode.BadRequest, HttpMethod.Delete);

            var accountsController = new AccountsController(_mockMediatr.Object, _baseControllerMock.Object);
            accountsController.ModelState.AddModelError(string.Empty, "invalid Input");

            IActionResult result = await accountsController.DeleteAccount("1012345");

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_DeleteAccount_ResourceNotFound()
        {
            GetImeadiatrMockForDeleteAccount(HttpStatusCode.BadRequest, HttpMethod.Delete);

            var accountsController = new AccountsController(_mockMediatr.Object, _baseControllerMock.Object);
            accountsController.ModelState.AddModelError(string.Empty, "Resource not found");

            IActionResult result = await accountsController.DeleteAccount("1012345");

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        private void GetImeadiatrMockForDeleteAccount(HttpStatusCode request,
         HttpMethod response)
        {
            _mockMediatr.Setup(m => m.Send(It.IsAny<DeleteAccountCommand>(),
                 It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(request, response));
        }

        [Test]
        public async Task Test_DeleteAccount_Unauthorize()
        {
            var expected = HttpStatusCode.Unauthorized;

            var response = await _client.DeleteAsync("/api/v1/Accounts/DeleteAccount/1234");

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_DeleteAccount_NotFound()
        {
            var expected = HttpStatusCode.NotFound;

            var response = await _client.DeleteAsync("/api/v1/Accounts/DeleteAcc/1234");

            Assert.AreEqual(expected, response.StatusCode);
        }
    }
}