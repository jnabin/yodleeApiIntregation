using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using YodleeIntegration.Api.Controllers.Verification;
using YodleeIntegration.Api.Models.Verification;
using YodleeIntegration.Application.Request;
using YodleeIntegration.Application.Verification.GetVerificationStatus;
using YodleeIntegration.Application.Verification.GetVerifiedAccounts;
using YodleeIntegration.Application.Verification.InitiaiteMatchingServiceandChallengeDeposit;
using YodleeIntegration.Application.Verification.VerifyChallengeDeposit;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Api.Test.Verification
{
    public class VerificationControllerTest : BaseApiTest
    {

        [Test]
        public async Task Test_GetVerificationStatus_Succeeds()
        {
            GetImeadiatrMockForGetVerificationStatus(HttpStatusCode.OK, HttpMethod.Get);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await verificationController.GetVerificationStatus(
                GetVerificationStatusParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetVerificationStatus_ServiceNorSupported()
        {
            GetImeadiatrMockForGetVerificationStatus(HttpStatusCode.BadRequest, HttpMethod.Get);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty, "service not supported");

            IActionResult result = await verificationController.GetVerificationStatus(
                GetVerificationStatusParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetVerificationStatus_AccountIdOrProviderAccountIdRequired()
        {
            GetImeadiatrMockForGetVerificationStatus(HttpStatusCode.BadRequest, HttpMethod.Get);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty,
                "Either accountId or providerAccountId should be provided");

            IActionResult result = await verificationController.GetVerificationStatus(
                GetVerificationStatusParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetVerificationStatus_InvalidAccountId()
        {
            GetImeadiatrMockForGetVerificationStatus(HttpStatusCode.BadRequest, HttpMethod.Get);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty,
                "Inavlid value for accountId");

            IActionResult result = await verificationController.GetVerificationStatus(
                GetVerificationStatusParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetVerificationStatus_InvalidVerficationType()
        {
            GetImeadiatrMockForGetVerificationStatus(HttpStatusCode.BadRequest, HttpMethod.Get);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty,
                "Inavlid value for verfication.verificationType");

            IActionResult result = await verificationController.GetVerificationStatus(
                GetVerificationStatusParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetVerificationStatus_InvalidProviderAccountType()
        {
            GetImeadiatrMockForGetVerificationStatus(HttpStatusCode.BadRequest, HttpMethod.Get);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty,
                "Inavlid value for providerAccountType");

            IActionResult result = await verificationController.GetVerificationStatus(
                GetVerificationStatusParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetVerificationStatus_NoVerficationInitiated()
        {
            GetImeadiatrMockForGetVerificationStatus(HttpStatusCode.BadRequest, HttpMethod.Get);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty,
                "No verification initiated");

            IActionResult result = await verificationController.GetVerificationStatus(
                GetVerificationStatusParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        private static GetVerificationStatusParams GetVerificationStatusParams()
        {
            return new GetVerificationStatusParams
            {
                AccountId = "1,2,3",
                ProviderAccountId = "3,4,5",
                VerificationType = "string"
            };
        }

        private void GetImeadiatrMockForGetVerificationStatus(HttpStatusCode request,
           HttpMethod response)
        {
            _mockMediatr.Setup(m => m.Send(It.IsAny<GetVerificationStatusQuery>(),
                 It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(request, response));
        }

        [Test]
        public async Task Test_GetVerificationStatus_Unauthorize()
        {
            var expected = HttpStatusCode.Unauthorized;

            var response = await _client.GetAsync("/api/v1/Verification/GetVerificationStatus");

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_GetVerificationStatus_NotFound()
        {
            var expected = HttpStatusCode.NotFound;

            var response = await _client.GetAsync("/api/v1/Verification/GetVerification");

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_VerifyChallengeDeposit_Succeeds()
        {
            GetImeadiatrMockForVerifyChallengeDeposit(HttpStatusCode.OK, HttpMethod.Put);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await verificationController.VerifyChallengeDeposit(
                GetVerifyChallengeDepositRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task Test_VerifyChallengeDeposit_ServiceNotSupported()
        {
            GetImeadiatrMockForVerifyChallengeDeposit(HttpStatusCode.BadRequest, HttpMethod.Put);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty, "Service not supported");

            IActionResult result = await verificationController.VerifyChallengeDeposit(
                GetVerifyChallengeDepositRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_VerifyChallengeDeposit_VerificationTypeMissing()
        {
            GetImeadiatrMockForVerifyChallengeDeposit(HttpStatusCode.BadRequest, HttpMethod.Put);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty, "verification.verificationType is missing");

            IActionResult result = await verificationController.VerifyChallengeDeposit(
                GetVerifyChallengeDepositRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_VerifyChallengeDeposit_AmountMissing()
        {
            GetImeadiatrMockForVerifyChallengeDeposit(HttpStatusCode.BadRequest, HttpMethod.Put);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty, "amount.amount is missing");

            IActionResult result = await verificationController.VerifyChallengeDeposit(
                GetVerifyChallengeDepositRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_VerifyChallengeDeposit_BaseTypeMissing()
        {
            GetImeadiatrMockForVerifyChallengeDeposit(HttpStatusCode.BadRequest, HttpMethod.Put);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty, "BaseType is missing");

            IActionResult result = await verificationController.VerifyChallengeDeposit(
                GetVerifyChallengeDepositRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_VerifyChallengeDeposit_CurrencyMissing()
        {
            GetImeadiatrMockForVerifyChallengeDeposit(HttpStatusCode.BadRequest, HttpMethod.Put);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty, "Currency is missing");

            IActionResult result = await verificationController.VerifyChallengeDeposit(
                GetVerifyChallengeDepositRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_VerifyChallengeDeposit_ProviderAccountIdMissing()
        {
            GetImeadiatrMockForVerifyChallengeDeposit(HttpStatusCode.BadRequest, HttpMethod.Put);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty, "ProviderAccountId is missing");

            IActionResult result = await verificationController.VerifyChallengeDeposit(
                GetVerifyChallengeDepositRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_VerifyChallengeDeposit_AccountIdMissing()
        {
            GetImeadiatrMockForVerifyChallengeDeposit(HttpStatusCode.BadRequest, HttpMethod.Put);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty, "AccountId is missing");

            IActionResult result = await verificationController.VerifyChallengeDeposit(
                GetVerifyChallengeDepositRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_VerifyChallengeDeposit_InvalidVerificationParam()
        {
            GetImeadiatrMockForVerifyChallengeDeposit(HttpStatusCode.BadRequest, HttpMethod.Put);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty, "Invalid value for verification param");

            IActionResult result = await verificationController.VerifyChallengeDeposit(
                GetVerifyChallengeDepositRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_VerifyChallengeDeposit_InvalidVerificationType()
        {
            GetImeadiatrMockForVerifyChallengeDeposit(HttpStatusCode.BadRequest, HttpMethod.Put);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty, "Invalid value for verification type");

            IActionResult result = await verificationController.VerifyChallengeDeposit(
                GetVerifyChallengeDepositRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_VerifyChallengeDeposit_InvalidBaseType()
        {
            GetImeadiatrMockForVerifyChallengeDeposit(HttpStatusCode.BadRequest, HttpMethod.Put);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty, "Invalid value for base type");

            IActionResult result = await verificationController.VerifyChallengeDeposit(
                GetVerifyChallengeDepositRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_VerifyChallengeDeposit_InvalidProviderAccountId()
        {
            GetImeadiatrMockForVerifyChallengeDeposit(HttpStatusCode.BadRequest, HttpMethod.Put);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty, "Invalid value for provider account id");

            IActionResult result = await verificationController.VerifyChallengeDeposit(
                GetVerifyChallengeDepositRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_VerifyChallengeDeposit_InvalidAccountId()
        {
            GetImeadiatrMockForVerifyChallengeDeposit(HttpStatusCode.BadRequest, HttpMethod.Put);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty, "Invalid value for account id");

            IActionResult result = await verificationController.VerifyChallengeDeposit(
                GetVerifyChallengeDepositRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_VerifyChallengeDeposit_TransactionNorProvided()
        {
            GetImeadiatrMockForVerifyChallengeDeposit(HttpStatusCode.BadRequest, HttpMethod.Put);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty, "Transaction should be provided");

            IActionResult result = await verificationController.VerifyChallengeDeposit(
                GetVerifyChallengeDepositRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_VerifyChallengeDeposit_InvalidAccountNumber()
        {
            GetImeadiatrMockForVerifyChallengeDeposit(HttpStatusCode.BadRequest, HttpMethod.Put);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty, "Invalid length for account number");

            IActionResult result = await verificationController.VerifyChallengeDeposit(
                GetVerifyChallengeDepositRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_VerifyChallengeDeposit_InvalidAmount()
        {
            GetImeadiatrMockForVerifyChallengeDeposit(HttpStatusCode.BadRequest, HttpMethod.Put);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty, "Invalid length for amount");

            IActionResult result = await verificationController.VerifyChallengeDeposit(
                GetVerifyChallengeDepositRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_VerifyChallengeDeposit_AccountNotEligible()
        {
            GetImeadiatrMockForVerifyChallengeDeposit(HttpStatusCode.BadRequest, HttpMethod.Put);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty, "Account is nor eligible");

            IActionResult result = await verificationController.VerifyChallengeDeposit(
                GetVerifyChallengeDepositRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_VerifyChallengeDeposit_InvalidInput()
        {
            GetImeadiatrMockForVerifyChallengeDeposit(HttpStatusCode.BadRequest, HttpMethod.Put);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty, "Invalid Input");

            IActionResult result = await verificationController.VerifyChallengeDeposit(
                GetVerifyChallengeDepositRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_VerifyChallengeDeposit_VerficationInitiatedAlready()
        {
            GetImeadiatrMockForVerifyChallengeDeposit(HttpStatusCode.BadRequest, HttpMethod.Put);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty, "Verification is already initiated");

            IActionResult result = await verificationController.VerifyChallengeDeposit(
                GetVerifyChallengeDepositRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_VerifyChallengeDeposit_AccountVerified()
        {
            GetImeadiatrMockForVerifyChallengeDeposit(HttpStatusCode.BadRequest, HttpMethod.Put);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty, "Account has been verified already");

            IActionResult result = await verificationController.VerifyChallengeDeposit(
                GetVerifyChallengeDepositRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_VerifyChallengeDeposit_CurrencyCodeDoesnotmatch()
        {
            GetImeadiatrMockForVerifyChallengeDeposit(HttpStatusCode.BadRequest, HttpMethod.Put);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty,
                "The currency code provided doesn't match with the currency");

            IActionResult result = await verificationController.VerifyChallengeDeposit(
                GetVerifyChallengeDepositRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_VerifyChallengeDeposit_VerificationTimeExpired()
        {
            GetImeadiatrMockForVerifyChallengeDeposit(HttpStatusCode.BadRequest, HttpMethod.Put);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty,
                "Verfification time expired");

            IActionResult result = await verificationController.VerifyChallengeDeposit(
                GetVerifyChallengeDepositRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_VerifyChallengeDeposit_NoActionAllowed()
        {
            GetImeadiatrMockForVerifyChallengeDeposit(HttpStatusCode.BadRequest, HttpMethod.Put);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty,
                "No action is being allowed as the data is being migrated");

            IActionResult result = await verificationController.VerifyChallengeDeposit(
                GetVerifyChallengeDepositRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }


        private void GetImeadiatrMockForVerifyChallengeDeposit(HttpStatusCode request,
           HttpMethod response)
        {
            _mockMediatr.Setup(m => m.Send(It.IsAny<VerifyChallengeDepositCommand>(),
                 It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(request, response));
        }

        [Test]
        public async Task Test_VerifyChallengeDeposit_Unauthorize()
        {
            var expected = HttpStatusCode.Unauthorized;

            var response = await _client.PutAsJsonAsync("/api/v1/Verification/VerifyChallengeDeposit",
                 new VerifyChallengeDepositRequestBody());

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_VerifyChallengeDeposit_NotFound()
        {
            var expected = HttpStatusCode.NotFound;

            var response = await _client.PutAsJsonAsync("/api/v1/Verification/VerifyChalleng",
                new VerifyChallengeDepositRequestBody());

            Assert.AreEqual(expected, response.StatusCode);
        }

        private static VerifyChallengeDepositRequestBody GetVerifyChallengeDepositRequestBody()
        {
            return new VerifyChallengeDepositRequestBody
            {
                AccountId = 12,
                ProviderAccountId = 123,
                VerificationType = "string",
                Account = new VerificationAccount
                {
                    AccountName = "string",
                    AccountType = "string",
                    AccountNumber = "string",
                    BankTransferCode = new BankTransferCode
                    {
                        YodleeBankTransferCodeId = "string",
                        Type = "string"
                    }
                }
            };
        }

        [Test]
        public async Task Test_InitializeChallengeDeposit_Succeeds()
        {
            GetImeadiatrMockForInitializeChallengeDeposit(HttpStatusCode.OK, HttpMethod.Post);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await verificationController.InitializeChallengeDeposit(
                GetInitializeChallengeDepositRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task Test_InitializeChallengeDeposit_ServiceNotSupported()
        {
            GetImeadiatrMockForInitializeChallengeDeposit(HttpStatusCode.BadRequest, HttpMethod.Post);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty, "Service not supported");

            IActionResult result = await verificationController.InitializeChallengeDeposit(
                GetInitializeChallengeDepositRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_InitializeChallengeDeposit_VerificationTypeMissing()
        {
            GetImeadiatrMockForInitializeChallengeDeposit(HttpStatusCode.BadRequest, HttpMethod.Post);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty, "verification.verificationType is missing");

            IActionResult result = await verificationController.InitializeChallengeDeposit(
                GetInitializeChallengeDepositRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_InitializeChallengeDeposit_AmountMissing()
        {
            GetImeadiatrMockForInitializeChallengeDeposit(HttpStatusCode.BadRequest, HttpMethod.Post);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty, "amount.amount is missing");

            IActionResult result = await verificationController.InitializeChallengeDeposit(
                GetInitializeChallengeDepositRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_InitializeChallengeDeposit_BaseTypeMissing()
        {
            GetImeadiatrMockForInitializeChallengeDeposit(HttpStatusCode.BadRequest, HttpMethod.Post);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty, "BaseType is missing");

            IActionResult result = await verificationController.InitializeChallengeDeposit(
                GetInitializeChallengeDepositRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_InitializeChallengeDeposit_CurrencyMissing()
        {
            GetImeadiatrMockForInitializeChallengeDeposit(HttpStatusCode.BadRequest, HttpMethod.Post);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty, "Currency is missing");

            IActionResult result = await verificationController.InitializeChallengeDeposit(
                GetInitializeChallengeDepositRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_InitializeChallengeDeposit_ProviderAccountIdMissing()
        {
            GetImeadiatrMockForInitializeChallengeDeposit(HttpStatusCode.BadRequest, HttpMethod.Post);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty, "ProviderAccountId is missing");

            IActionResult result = await verificationController.InitializeChallengeDeposit(
                GetInitializeChallengeDepositRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_InitializeChallengeDeposit_AccountIdMissing()
        {
            GetImeadiatrMockForInitializeChallengeDeposit(HttpStatusCode.BadRequest, HttpMethod.Post);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty, "AccountId is missing");

            IActionResult result = await verificationController.InitializeChallengeDeposit(
                GetInitializeChallengeDepositRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_InitializeChallengeDeposit_InvalidVerificationParam()
        {
            GetImeadiatrMockForInitializeChallengeDeposit(HttpStatusCode.BadRequest, HttpMethod.Post);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty, "Invalid value for verification param");

            IActionResult result = await verificationController.InitializeChallengeDeposit(
                GetInitializeChallengeDepositRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_InitializeChallengeDeposit_InvalidVerificationType()
        {
            GetImeadiatrMockForInitializeChallengeDeposit(HttpStatusCode.BadRequest, HttpMethod.Post);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty, "Invalid value for verification type");

            IActionResult result = await verificationController.InitializeChallengeDeposit(
                GetInitializeChallengeDepositRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_InitializeChallengeDeposit_InvalidBaseType()
        {
            GetImeadiatrMockForInitializeChallengeDeposit(HttpStatusCode.BadRequest, HttpMethod.Post);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty, "Invalid value for base type");

            IActionResult result = await verificationController.InitializeChallengeDeposit(
                GetInitializeChallengeDepositRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_InitializeChallengeDeposit_InvalidProviderAccountId()
        {
            GetImeadiatrMockForInitializeChallengeDeposit(HttpStatusCode.BadRequest, HttpMethod.Post);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty, "Invalid value for provider account id");

            IActionResult result = await verificationController.InitializeChallengeDeposit(
                GetInitializeChallengeDepositRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_InitializeChallengeDeposit_InvalidAccountId()
        {
            GetImeadiatrMockForInitializeChallengeDeposit(HttpStatusCode.BadRequest, HttpMethod.Post);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty, "Invalid value for account id");

            IActionResult result = await verificationController.InitializeChallengeDeposit(
                GetInitializeChallengeDepositRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_InitializeChallengeDeposit_TransactionNorProvided()
        {
            GetImeadiatrMockForInitializeChallengeDeposit(HttpStatusCode.BadRequest, HttpMethod.Post);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty, "Transaction should be provided");

            IActionResult result = await verificationController.InitializeChallengeDeposit(
                GetInitializeChallengeDepositRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_InitializeChallengeDeposit_InvalidAccountNumber()
        {
            GetImeadiatrMockForInitializeChallengeDeposit(HttpStatusCode.BadRequest, HttpMethod.Post);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty, "Invalid length for account number");

            IActionResult result = await verificationController.InitializeChallengeDeposit(
                GetInitializeChallengeDepositRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_InitializeChallengeDeposit_InvalidAmount()
        {
            GetImeadiatrMockForInitializeChallengeDeposit(HttpStatusCode.BadRequest, HttpMethod.Post);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty, "Invalid length for amount");

            IActionResult result = await verificationController.InitializeChallengeDeposit(
                GetInitializeChallengeDepositRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_InitializeChallengeDeposit_AccountNotEligible()
        {
            GetImeadiatrMockForInitializeChallengeDeposit(HttpStatusCode.BadRequest, HttpMethod.Post);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty, "Account is nor eligible");

            IActionResult result = await verificationController.InitializeChallengeDeposit(
                GetInitializeChallengeDepositRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_InitializeChallengeDeposit_InvalidInput()
        {
            GetImeadiatrMockForInitializeChallengeDeposit(HttpStatusCode.BadRequest, HttpMethod.Post);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty, "Invalid Input");

            IActionResult result = await verificationController.InitializeChallengeDeposit(
                GetInitializeChallengeDepositRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_InitializeChallengeDeposit_VerficationInitiatedAlready()
        {
            GetImeadiatrMockForInitializeChallengeDeposit(HttpStatusCode.BadRequest, HttpMethod.Post);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty, "Verification is already initiated");

            IActionResult result = await verificationController.InitializeChallengeDeposit(
                GetInitializeChallengeDepositRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_InitializeChallengeDeposit_AccountVerified()
        {
            GetImeadiatrMockForInitializeChallengeDeposit(HttpStatusCode.BadRequest, HttpMethod.Post);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty, "Account has been verified already");

            IActionResult result = await verificationController.InitializeChallengeDeposit(
                GetInitializeChallengeDepositRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_InitializeChallengeDeposit_CurrencyCodeDoesnotmatch()
        {
            GetImeadiatrMockForInitializeChallengeDeposit(HttpStatusCode.BadRequest, HttpMethod.Post);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty,
                "The currency code provided doesn't match with the currency");

            IActionResult result = await verificationController.InitializeChallengeDeposit(
                GetInitializeChallengeDepositRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_InitializeChallengeDeposit_VerificationTimeExpired()
        {
            GetImeadiatrMockForInitializeChallengeDeposit(HttpStatusCode.BadRequest, HttpMethod.Post);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty,
                "Verfification time expired");

            IActionResult result = await verificationController.InitializeChallengeDeposit(
                GetInitializeChallengeDepositRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_InitializeChallengeDeposit_NoActionAllowed()
        {
            GetImeadiatrMockForInitializeChallengeDeposit(HttpStatusCode.BadRequest, HttpMethod.Post);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty,
                "No action is being allowed as the data is being migrated");

            IActionResult result = await verificationController.InitializeChallengeDeposit(
                GetInitializeChallengeDepositRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }


        private void GetImeadiatrMockForInitializeChallengeDeposit(HttpStatusCode request,
           HttpMethod response)
        {
            _mockMediatr.Setup(m => m.Send(It.IsAny<InitializeChallengeDepositQuery>(),
                 It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(request, response));
        }

        [Test]
        public async Task Test_InitializeChallengeDeposit_Unauthorize()
        {
            var expected = HttpStatusCode.Unauthorized;

            var response = await _client.PostAsJsonAsync("/api/v1/Verification/InitializeChallengeDeposit",
                new InitializeChallengeDepositRequestBody());

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_InitializeChallengeDeposit_NotFound()
        {
            var expected = HttpStatusCode.NotFound;

            var response = await _client.PostAsJsonAsync("/api/v1/Verification/InitializeChallt",
                new InitializeChallengeDepositRequestBody());

            Assert.AreEqual(expected, response.StatusCode);
        }

        private static InitializeChallengeDepositRequestBody GetInitializeChallengeDepositRequestBody()
        {
            return new InitializeChallengeDepositRequestBody
            {
                AccountId = 12,
                ProviderAccountId = 123,
                VerificationType = "string",
                Account = new VerificationAccount
                {
                    AccountName = "string",
                    AccountType = "string",
                    AccountNumber = "string",
                    BankTransferCode = new BankTransferCode
                    {
                        YodleeBankTransferCodeId = "string",
                        Type = "string"
                    }
                }
            };
        }

        [Test]
        public async Task Test_GetVerifiedAccounts_Succeed()
        {
            GetImeadiatrMockForGetVerifiedAccounts(HttpStatusCode.OK, HttpMethod.Get);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await verificationController.GetVerifiedAccounts(
                GetVerifiedAccountsParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetVerifiedAccounts_ProviderAccountIdMissing()
        {
            GetImeadiatrMockForGetVerifiedAccounts(HttpStatusCode.BadRequest, HttpMethod.Get);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty, "provider account id shouls be provided");

            IActionResult result = await verificationController.GetVerifiedAccounts(
                GetVerifiedAccountsParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetVerifiedAccounts_InvalidProviderAccountId()
        {
            GetImeadiatrMockForGetVerifiedAccounts(HttpStatusCode.BadRequest, HttpMethod.Get);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty, "Invalid provider account id");

            IActionResult result = await verificationController.GetVerifiedAccounts(
                GetVerifiedAccountsParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetVerifiedAccounts_InvalidVerificationStatus()
        {
            GetImeadiatrMockForGetVerifiedAccounts(HttpStatusCode.BadRequest, HttpMethod.Get);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty, "Invalid verification status");

            IActionResult result = await verificationController.GetVerifiedAccounts(
                GetVerifiedAccountsParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetVerifiedAccounts_InvalidIsSelected()
        {
            GetImeadiatrMockForGetVerifiedAccounts(HttpStatusCode.BadRequest, HttpMethod.Get);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty, "Invalid value for isSelected");

            IActionResult result = await verificationController.GetVerifiedAccounts(
                GetVerifiedAccountsParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetVerifiedAccounts_InvalidAccountId()
        {
            GetImeadiatrMockForGetVerifiedAccounts(HttpStatusCode.BadRequest, HttpMethod.Get);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty, "Invalid value for AccountOId");

            IActionResult result = await verificationController.GetVerifiedAccounts(
                GetVerifiedAccountsParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetVerifiedAccounts_ResourceNotFound()
        {
            GetImeadiatrMockForGetVerifiedAccounts(HttpStatusCode.BadRequest, HttpMethod.Get);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty, "resource not found");

            IActionResult result = await verificationController.GetVerifiedAccounts(
                GetVerifiedAccountsParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetVerifiedAccounts_AccountIdExceed()
        {
            GetImeadiatrMockForGetVerifiedAccounts(HttpStatusCode.BadRequest, HttpMethod.Get);

            var verificationController = new VerificationController(_mockMediatr.Object, _baseControllerMock.Object);
            verificationController.ModelState.AddModelError(string.Empty,
                "The maximum number of accountIds permitted is 10");

            IActionResult result = await verificationController.GetVerifiedAccounts(
                GetVerifiedAccountsParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        private void GetImeadiatrMockForGetVerifiedAccounts(HttpStatusCode request,
          HttpMethod response)
        {
            _mockMediatr.Setup(m => m.Send(It.IsAny<GetVerifiedAccountsQuery>(),
                 It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(request, response));
        }

        private static GetVerifiedAccountsParams GetVerifiedAccountsParams()
        {
            return new GetVerifiedAccountsParams
            {
                AccountId = "1,2,3",
                IsSelected = "true, false, true",
                ProviderAccountId = "123",
                VerificationStatus = "success, failed, success"
            };
        }

        [Test]
        public async Task Test_GetVerifiedAccounts_Unauthorize()
        {
            var expected = HttpStatusCode.Unauthorized;

            var response = await _client.GetAsync("/api/v1/Verification/GetVerifiedAccounts");

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_GetVerifiedAccounts_NotFound()
        {
            var expected = HttpStatusCode.NotFound;

            var response = await _client.GetAsync("/api/v1/Verification/GetVerifiedA");

            Assert.AreEqual(expected, response.StatusCode);
        }

       
    }
}