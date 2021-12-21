using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using YodleeIntegration.Api.Controllers.ProviderAccounts;
using YodleeIntegration.Api.Models;
using YodleeIntegration.Application.ProvidersAccounts;
using YodleeIntegration.Application.ProvidersAccounts.DeleteProviderAccount;
using YodleeIntegration.Application.ProvidersAccounts.GetUserProfileDetails;
using YodleeIntegration.Application.ProvidersAccounts.UpdateAccountPreferences;
using YodleeIntegration.Application.ProvidersAccounts.UpdateProviderAccount;
using YodleeIntegration.Application.Request;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Api.Test.ProviderAccount
{
    public class ProviderAccountControllerTests : BaseApiTest
    {

        [Test]
        public async Task Test_GetProviderAccounts_Succeeds()
        {
            GetImeadiatrMockForGetProviderAccounts(HttpStatusCode.OK, HttpMethod.Get);

            var providerAccountsController = new ProviderAccountsController(_mockMediatr.Object,
                _baseControllerMock.Object);

            IActionResult result = await providerAccountsController.GetProviderAccounts(
                GetProviderAccountsParams());
            var okResult = result as ObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);
        }

        private static GetProviderAccountsParams GetProviderAccountsParams()
        {
            return new GetProviderAccountsParams
            {
                Include = "string",
                ProviderIds  ="1,2,3,4"
            };
        }

        [Test]
        public async Task Test_GetProviderAccounts_Unauthorize()
        {
            var expected = HttpStatusCode.Unauthorized;

            var response = await _client.GetAsync("/api/v1/ProviderAccounts/GetProviderAccounts");

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_GetProviderAccounts_NotFound()
        {
            var expected = HttpStatusCode.NotFound;

            var response = await _client.GetAsync("/api/v1/ProviderAccounts/GetProviderAcc");

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_GetProviderAccountDetails_Succeeds()
        {
            GetImeadiatrMockForGetProviderAccounts(HttpStatusCode.OK, HttpMethod.Get);

            var providerAccountsController = new ProviderAccountsController(_mockMediatr.Object,
                _baseControllerMock.Object);

            IActionResult result = await providerAccountsController.GetProviderAccountDetails(
                "123", GetProviderAccountsDetailParams());
            var okResult = result as ObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetProviderAccountDetails_InvalidProviderAccountId()
        {
            GetImeadiatrMockForGetProviderAccounts(HttpStatusCode.BadRequest, HttpMethod.Get);

            var providerAccountsController = new ProviderAccountsController(_mockMediatr.Object,
                _baseControllerMock.Object);
            providerAccountsController.ModelState.AddModelError(string.Empty,
                "Invalid value for providerAccountId");

            IActionResult result = await providerAccountsController.GetProviderAccountDetails(
                "$$", GetProviderAccountsDetailParams());
            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetProviderAccountDetails_InvalidQuestion()
        {
            GetImeadiatrMockForGetProviderAccounts(HttpStatusCode.BadRequest, HttpMethod.Get);

            var providerAccountsController = new ProviderAccountsController(_mockMediatr.Object,
                _baseControllerMock.Object);
            providerAccountsController.ModelState.AddModelError(string.Empty,
                "questions can only be requested for questionAndAnswer Supported Sites");

            IActionResult result = await providerAccountsController.GetProviderAccountDetails(
                "123", GetProviderAccountsDetailParams());
            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        private void GetImeadiatrMockForGetProviderAccounts(HttpStatusCode request,
         HttpMethod response)
        {
            _mockMediatr.Setup(m => m.Send(It.IsAny<GetProvidersAccountQuery>(),
                 It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(request, response));
        }

        private static GetProviderAccountsDetailParams GetProviderAccountsDetailParams()
        {
            return new GetProviderAccountsDetailParams
            {
                Include = "string",
                RequestId = "srring"
            };
        }

        [Test]
        public async Task Test_GetProviderAccountDetails_Unauthorize()
        {
            var expected = HttpStatusCode.Unauthorized;

            var response = await _client.GetAsync("/api/v1/ProviderAccounts/GetProviderAccountDetails/10013434");

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_GetProviderAccountDetails_NotFound()
        {
            var expected = HttpStatusCode.NotFound;

            var response = await _client.GetAsync("/api/v1/ProviderAccounts/GetProviderAccountDetai");

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_GetUserProfileDetails_Succeeds()
        {
            GetImeadiatrMockForGetUserProfileDetails(HttpStatusCode.OK, HttpMethod.Get);

            var providerAccountsController = new ProviderAccountsController(_mockMediatr.Object,
                _baseControllerMock.Object);

            IActionResult result = await providerAccountsController.GetUserProfileDetails(
                GetUserProfileDetailsParams());
            var okResult = result as ObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);
        }

        private void GetImeadiatrMockForGetUserProfileDetails(HttpStatusCode request,
          HttpMethod response)
        {
            _mockMediatr.Setup(m => m.Send(It.IsAny<GetUserProfileDetailsQuery>(),
                 It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(request, response));
        }              

        private static GetUserProfileDetailsParams GetUserProfileDetailsParams()
        {
            return new GetUserProfileDetailsParams
            {
                ProviderAccountId = "1,2,5"
            };
        }

        [Test]
        public async Task Test_GetUserProfileDetails_Unauthorize()
        {
            var expected = HttpStatusCode.Unauthorized;

            var response = await _client.GetAsync("/api/v1/ProviderAccounts/GetUserProfileDetails");

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_GetUserProfileDetails_NotFound()
        {
            var expected = HttpStatusCode.NotFound;

            var response = await _client.GetAsync("/api/v1/ProviderAccounts/GetUserProfileDs");

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_UpdatePreferences_Succeeds()
        {
            GetImeadiatrMockForUpdatePreferences(HttpStatusCode.NoContent, HttpMethod.Put);

            var providerAccountsController = new ProviderAccountsController(_mockMediatr.Object,
                _baseControllerMock.Object);

            IActionResult result = await providerAccountsController.UpdatePreferences(
                "123", CreateUpdateAccountPreferencesRequestBody());
            var okResult = result as ObjectResult;

            Assert.AreEqual(204, okResult.StatusCode);
        }

        [Test]
        public async Task Test_UpdatePreferences_InvalidPreferences()
        {
            GetImeadiatrMockForUpdatePreferences(HttpStatusCode.BadRequest, HttpMethod.Put);

            var providerAccountsController = new ProviderAccountsController(_mockMediatr.Object,
                _baseControllerMock.Object);
            providerAccountsController.ModelState.AddModelError(string.Empty, "Invalid value for preferences");

            IActionResult result = await providerAccountsController.UpdatePreferences(
                "123", CreateUpdateAccountPreferencesRequestBody());
            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_UpdatePreferences_InvalidPreferencesIsDataExtractsEnable()
        {
            GetImeadiatrMockForUpdatePreferences(HttpStatusCode.BadRequest, HttpMethod.Put);

            var providerAccountsController = new ProviderAccountsController(_mockMediatr.Object,
                _baseControllerMock.Object);
            providerAccountsController.ModelState.AddModelError(
                string.Empty, "Invalid value for preferences.isDataExtractsEnable");

            IActionResult result = await providerAccountsController.UpdatePreferences(
                "123", CreateUpdateAccountPreferencesRequestBody());
            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_UpdatePreferences_InvalidPreferencesIsAutoRefreshEnable()
        {
            GetImeadiatrMockForUpdatePreferences(HttpStatusCode.BadRequest, HttpMethod.Put);

            var providerAccountsController = new ProviderAccountsController(_mockMediatr.Object,
                _baseControllerMock.Object);
            providerAccountsController.ModelState.AddModelError(
                string.Empty, "Invalid value for preferences.isAutoRefreshEnable");

            IActionResult result = await providerAccountsController.UpdatePreferences(
                "123", CreateUpdateAccountPreferencesRequestBody());
            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_UpdatePreferences_ResourceNotFound()
        {
            GetImeadiatrMockForUpdatePreferences(HttpStatusCode.BadRequest, HttpMethod.Put);

            var providerAccountsController = new ProviderAccountsController(_mockMediatr.Object,
                _baseControllerMock.Object);
            providerAccountsController.ModelState.AddModelError(string.Empty, "Resource not found");

            IActionResult result = await providerAccountsController.UpdatePreferences(
                "123", CreateUpdateAccountPreferencesRequestBody());
            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_UpdatePreferences_DataExtractsError()
        {
            GetImeadiatrMockForUpdatePreferences(HttpStatusCode.BadRequest, HttpMethod.Put);

            var providerAccountsController = new ProviderAccountsController(_mockMediatr.Object,
                _baseControllerMock.Object);
            providerAccountsController.ModelState.AddModelError(
                string.Empty,
                "Data extracts feature has to be enabled to set preference.isDataExtractsEnabled as true");

            IActionResult result = await providerAccountsController.UpdatePreferences(
                "123", CreateUpdateAccountPreferencesRequestBody());
            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_UpdatePreferences_AutoRefreshError()
        {
            GetImeadiatrMockForUpdatePreferences(HttpStatusCode.BadRequest, HttpMethod.Put);

            var providerAccountsController = new ProviderAccountsController(_mockMediatr.Object,
                _baseControllerMock.Object);
            providerAccountsController.ModelState.AddModelError(
                string.Empty,
                "Auto refresh feature has to be enabled to set preference.isAutoRefreshEnabled as true");

            IActionResult result = await providerAccountsController.UpdatePreferences(
                "123", CreateUpdateAccountPreferencesRequestBody());
            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_UpdatePreferences_NoActionIsAllowed()
        {
            GetImeadiatrMockForUpdatePreferences(HttpStatusCode.BadRequest, HttpMethod.Put);

            var providerAccountsController = new ProviderAccountsController(_mockMediatr.Object,
                _baseControllerMock.Object);
            providerAccountsController.ModelState.AddModelError(
                string.Empty, "No action is allowed, as the data is being migrated to the Open Banking provider");

            IActionResult result = await providerAccountsController.UpdatePreferences(
                "123", CreateUpdateAccountPreferencesRequestBody());
            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        private void GetImeadiatrMockForUpdatePreferences(HttpStatusCode request,
         HttpMethod response)
        {
            _mockMediatr.Setup(m => m.Send(It.IsAny<UpdateAccountPreferencesCommand>(),
                 It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(request, response));
        }

        [Test]
        public async Task Test_UpdatePreferences_Unauthorize()
        {
            var expected = HttpStatusCode.Unauthorized;

            var response = await _client.PutAsJsonAsync("/api/v1/ProviderAccounts/UpdatePreferences/10013434", CreateUpdateAccountPreferencesRequestBody());

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_UpdatePreferences_NotFound()
        {
            var expected = HttpStatusCode.NotFound;

            var response = await _client.PutAsJsonAsync("/api/v1/ProviderAccounts/UpdateAccountPrefe/10013434", CreateUpdateAccountPreferencesRequestBody());

            Assert.AreEqual(expected, response.StatusCode);
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
        public async Task Test_UpdateAccounts_Succeeds()
        {
            GetImeadiatrMockForUpdateAccount(HttpStatusCode.NoContent, HttpMethod.Put);

            var providerAccountsController = new ProviderAccountsController(_mockMediatr.Object,
                _baseControllerMock.Object);

            IActionResult result = await providerAccountsController.UpdateAccounts(
                GetUpdateAccountsQueryParams(), CreateUpdateProviderAccountRequestBody());
            var okResult = result as ObjectResult;

            Assert.AreEqual(204, okResult.StatusCode);
        }

        [Test]
        public async Task Test_UpdateAccounts_MultipleProviderAccountIdError()
        {
            GetImeadiatrMockForUpdateAccount(HttpStatusCode.BadRequest, HttpMethod.Put);

            var providerAccountsController = new ProviderAccountsController(_mockMediatr.Object,
                _baseControllerMock.Object);
            providerAccountsController.ModelState.AddModelError(string.Empty,
                "Multiple providerAccountId not supported for updating credentials");

            IActionResult result = await providerAccountsController.UpdateAccounts(
                GetUpdateAccountsQueryParams(), CreateUpdateProviderAccountRequestBody());
            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_UpdateAccounts_InvalidCredentialParams()
        {
            GetImeadiatrMockForUpdateAccount(HttpStatusCode.BadRequest, HttpMethod.Put);

            var providerAccountsController = new ProviderAccountsController(_mockMediatr.Object,
                _baseControllerMock.Object);
            providerAccountsController.ModelState.AddModelError(string.Empty,
                "Invalid value for credentials params");

            IActionResult result = await providerAccountsController.UpdateAccounts(
                GetUpdateAccountsQueryParams(), CreateUpdateProviderAccountRequestBody());
            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_UpdateAccounts_IdAndCredentialParamsRequired()
        {
            GetImeadiatrMockForUpdateAccount(HttpStatusCode.BadRequest, HttpMethod.Put);

            var providerAccountsController = new ProviderAccountsController(_mockMediatr.Object,
                _baseControllerMock.Object);
            providerAccountsController.ModelState.AddModelError(string.Empty,
                "Id and value in credentials params are required");

            IActionResult result = await providerAccountsController.UpdateAccounts(
                GetUpdateAccountsQueryParams(), CreateUpdateProviderAccountRequestBody());
            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_UpdateAccounts_InvalidInput()
        {
            GetImeadiatrMockForUpdateAccount(HttpStatusCode.BadRequest, HttpMethod.Put);

            var providerAccountsController = new ProviderAccountsController(_mockMediatr.Object,
                _baseControllerMock.Object);
            providerAccountsController.ModelState.AddModelError(string.Empty,"Invalid Input");

            IActionResult result = await providerAccountsController.UpdateAccounts(
                GetUpdateAccountsQueryParams(), CreateUpdateProviderAccountRequestBody());
            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_UpdateAccounts_CredentialsAreNotApplicable()
        {
            GetImeadiatrMockForUpdateAccount(HttpStatusCode.BadRequest, HttpMethod.Put);

            var providerAccountsController = new ProviderAccountsController(_mockMediatr.Object,
                _baseControllerMock.Object);
            providerAccountsController.ModelState.AddModelError(string.Empty,
                "Credential are not applicable for real estage aggregated/manual accounts");

            IActionResult result = await providerAccountsController.UpdateAccounts(
                GetUpdateAccountsQueryParams(), CreateUpdateProviderAccountRequestBody());
            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_UpdateAccounts_NoActionIsAllowed()
        {
            GetImeadiatrMockForUpdateAccount(HttpStatusCode.BadRequest, HttpMethod.Put);

            var providerAccountsController = new ProviderAccountsController(_mockMediatr.Object,
                _baseControllerMock.Object);
            providerAccountsController.ModelState.AddModelError(string.Empty,
                "No action is allowed, as the data is being migrated to the Open Banking provider");

            IActionResult result = await providerAccountsController.UpdateAccounts(
                GetUpdateAccountsQueryParams(), CreateUpdateProviderAccountRequestBody());
            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        private void GetImeadiatrMockForUpdateAccount(HttpStatusCode request,
         HttpMethod response)
        {
            _mockMediatr.Setup(m => m.Send(It.IsAny<UpdateProviderAccountCommand>(),
                 It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(request, response));
        }

        [Test]
        public async Task Test_UpdateAccounts_Unauthorize()
        {
            var expected = HttpStatusCode.Unauthorized;

            var response = await _client.PutAsJsonAsync("/api/v1/ProviderAccounts/UpdateAccounts",
                CreateUpdateProviderAccountRequestBody());

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_UpdateAccounts_NotFound()
        {
            var expected = HttpStatusCode.NotFound;

            var response = await _client.PutAsJsonAsync("/api/v1/ProviderAccounts/UpdateProunts",
                CreateUpdateProviderAccountRequestBody());

            Assert.AreEqual(expected, response.StatusCode);
        }

        private static GetUpdateAccountsQueryParams GetUpdateAccountsQueryParams()
        {
            return new GetUpdateAccountsQueryParams
            {
                ProviderAccountIds = "1,3,4"
            };
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
                        IsAutoRefreshEnabled = true,
                        IsDataExtractsEnabled = true
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
        public async Task Test_DeleteProviderAccount_Succeeds()
        {
            GetImeadiatrMockForDeleteProviderAccount(HttpStatusCode.OK, HttpMethod.Delete);

            var providerAccountsController = new ProviderAccountsController(_mockMediatr.Object,
                _baseControllerMock.Object);

            IActionResult result = await providerAccountsController.AccountDeleteAccount("123");
            var okResult = result as ObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);
        }

        private void GetImeadiatrMockForDeleteProviderAccount(HttpStatusCode request,
         HttpMethod response)
        {
            _mockMediatr.Setup(m => m.Send(It.IsAny<DeleteProviderAccountCommand>(),
                 It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(request, response));
        }

        [Test]
        public async Task Test_DeleteProviderAccount_Unauthorize()
        {
            var expected = HttpStatusCode.Unauthorized;

            var response = await _client.DeleteAsync("/api/v1/ProviderAccounts/DeleteProviderAccount/10013412");

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_DeleteProviderAccount_NotFound()
        {
            var expected = HttpStatusCode.NotFound;

            var response = await _client.DeleteAsync("/api/v1/ProviderAccounts/DeletePrder/10013412");

            Assert.AreEqual(expected, response.StatusCode);
        }
    }
}