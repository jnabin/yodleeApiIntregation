using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using YodleeIntegration.Api.Controllers.VerifyAccounts;
using YodleeIntegration.Application.Request;
using YodleeIntegration.Application.VerifyAccounts;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Api.Test.VerifyAccounts
{
    public class VerifyAccountControllerTests : BaseApiTest
    {
        [Test]
        public async Task Test_VerifyAccountsUsingTransactions_Succeeds()
        {
            GetImeadiatrMockForVerifyAccountsUsingTransactions(HttpStatusCode.OK, HttpMethod.Get);

            var verificationAccountController = new VerifyAccountController(_mockMediatr.Object,
                _baseControllerMock.Object);

            IActionResult result = await verificationAccountController.VerifyAccountsUsingTransactions(
                "1234", CreateVerifyAccountRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task Test_VerifyAccountsUsingTransactions_InvalidContainer()
        {
            GetImeadiatrMockForVerifyAccountsUsingTransactions(HttpStatusCode.BadRequest, HttpMethod.Get);

            var verificationAccountController = new VerifyAccountController(_mockMediatr.Object,
                _baseControllerMock.Object);
            verificationAccountController.ModelState.AddModelError(string.Empty, "Invalid value for container");

            IActionResult result = await verificationAccountController.VerifyAccountsUsingTransactions(
                "1234", CreateVerifyAccountRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_VerifyAccountsUsingTransactions_InvalidAccountId()
        {
            GetImeadiatrMockForVerifyAccountsUsingTransactions(HttpStatusCode.BadRequest, HttpMethod.Get);

            var verificationAccountController = new VerifyAccountController(_mockMediatr.Object,
                _baseControllerMock.Object);
            verificationAccountController.ModelState.AddModelError(string.Empty, "Invalid value for AccountId");

            IActionResult result = await verificationAccountController.VerifyAccountsUsingTransactions(
                "1234", CreateVerifyAccountRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_VerifyAccountsUsingTransactions_InvalidAmount()
        {
            GetImeadiatrMockForVerifyAccountsUsingTransactions(HttpStatusCode.BadRequest, HttpMethod.Get);

            var verificationAccountController = new VerifyAccountController(_mockMediatr.Object,
                _baseControllerMock.Object);
            verificationAccountController.ModelState.AddModelError(string.Empty, "Invalid value for amount");

            IActionResult result = await verificationAccountController.VerifyAccountsUsingTransactions(
                "1234", CreateVerifyAccountRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_VerifyAccountsUsingTransactions_InvalidDateVariance()
        {
            GetImeadiatrMockForVerifyAccountsUsingTransactions(HttpStatusCode.BadRequest, HttpMethod.Get);

            var verificationAccountController = new VerifyAccountController(_mockMediatr.Object,
                _baseControllerMock.Object);
            verificationAccountController.ModelState.AddModelError(string.Empty, "Invalid value for dateVariance");

            IActionResult result = await verificationAccountController.VerifyAccountsUsingTransactions(
                "1234", CreateVerifyAccountRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_VerifyAccountsUsingTransactions_InvalidKeyword()
        {
            GetImeadiatrMockForVerifyAccountsUsingTransactions(HttpStatusCode.BadRequest, HttpMethod.Get);

            var verificationAccountController = new VerifyAccountController(_mockMediatr.Object,
                _baseControllerMock.Object);
            verificationAccountController.ModelState.AddModelError(string.Empty, "Invalid value for keyword");

            IActionResult result = await verificationAccountController.VerifyAccountsUsingTransactions(
                "1234", CreateVerifyAccountRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_VerifyAccountsUsingTransactions_DateVarianceError()
        {
            GetImeadiatrMockForVerifyAccountsUsingTransactions(HttpStatusCode.BadRequest, HttpMethod.Get);

            var verificationAccountController = new VerifyAccountController(_mockMediatr.Object,
                _baseControllerMock.Object);
            verificationAccountController.ModelState.AddModelError(string.Empty,
                "Permitted values of dateVariance between 1-7");

            IActionResult result = await verificationAccountController.VerifyAccountsUsingTransactions(
                "1234", CreateVerifyAccountRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_VerifyAccountsUsingTransactions_InvalidInput()
        {
            GetImeadiatrMockForVerifyAccountsUsingTransactions(HttpStatusCode.BadRequest, HttpMethod.Get);

            var verificationAccountController = new VerifyAccountController(_mockMediatr.Object,
                _baseControllerMock.Object);
            verificationAccountController.ModelState.AddModelError(string.Empty,
                "Invalid Input");

            IActionResult result = await verificationAccountController.VerifyAccountsUsingTransactions(
                "1234", CreateVerifyAccountRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_VerifyAccountsUsingTransactions_ResourceNotFound()
        {
            GetImeadiatrMockForVerifyAccountsUsingTransactions(HttpStatusCode.BadRequest, HttpMethod.Get);

            var verificationAccountController = new VerifyAccountController(_mockMediatr.Object,
                _baseControllerMock.Object);
            verificationAccountController.ModelState.AddModelError(string.Empty,
                "Resource not found");

            IActionResult result = await verificationAccountController.VerifyAccountsUsingTransactions(
                "1234", CreateVerifyAccountRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_VerifyAccountsUsingTransactions_InvalidDateRange()
        {
            GetImeadiatrMockForVerifyAccountsUsingTransactions(HttpStatusCode.BadRequest, HttpMethod.Get);

            var verificationAccountController = new VerifyAccountController(_mockMediatr.Object,
                _baseControllerMock.Object);
            verificationAccountController.ModelState.AddModelError(string.Empty,
                "Invalid Date range");

            IActionResult result = await verificationAccountController.VerifyAccountsUsingTransactions(
                "1234", CreateVerifyAccountRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_VerifyAccountsUsingTransactions_TransactionCriteriaMissing()
        {
            GetImeadiatrMockForVerifyAccountsUsingTransactions(HttpStatusCode.BadRequest, HttpMethod.Get);

            var verificationAccountController = new VerifyAccountController(_mockMediatr.Object,
                _baseControllerMock.Object);
            verificationAccountController.ModelState.AddModelError(string.Empty,
                "Transaction criteria missing in the input");

            IActionResult result = await verificationAccountController.VerifyAccountsUsingTransactions(
                "1234", CreateVerifyAccountRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_VerifyAccountsUsingTransactions_AmountMissing()
        {
            GetImeadiatrMockForVerifyAccountsUsingTransactions(HttpStatusCode.BadRequest, HttpMethod.Get);

            var verificationAccountController = new VerifyAccountController(_mockMediatr.Object,
                _baseControllerMock.Object);
            verificationAccountController.ModelState.AddModelError(string.Empty,
                "Amount missing in the input Transaction criteria");

            IActionResult result = await verificationAccountController.VerifyAccountsUsingTransactions(
                "1234", CreateVerifyAccountRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_VerifyAccountsUsingTransactions_AmountDateRequired()
        {
            GetImeadiatrMockForVerifyAccountsUsingTransactions(HttpStatusCode.BadRequest, HttpMethod.Get);

            var verificationAccountController = new VerifyAccountController(_mockMediatr.Object,
                _baseControllerMock.Object);
            verificationAccountController.ModelState.AddModelError(string.Empty,
                "Amount date required Transaction criteria");

            IActionResult result = await verificationAccountController.VerifyAccountsUsingTransactions(
                "1234", CreateVerifyAccountRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_VerifyAccountsUsingTransactions_BaseTypeMissing()
        {
            GetImeadiatrMockForVerifyAccountsUsingTransactions(HttpStatusCode.BadRequest, HttpMethod.Get);

            var verificationAccountController = new VerifyAccountController(_mockMediatr.Object,
                _baseControllerMock.Object);
            verificationAccountController.ModelState.AddModelError(string.Empty,
                "Basetype missing in the Transaction criteria");

            IActionResult result = await verificationAccountController.VerifyAccountsUsingTransactions(
                "1234", CreateVerifyAccountRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_VerifyAccountsUsingTransactions_TransactionNotApplicable()
        {
            GetImeadiatrMockForVerifyAccountsUsingTransactions(HttpStatusCode.BadRequest, HttpMethod.Get);

            var verificationAccountController = new VerifyAccountController(_mockMediatr.Object,
                _baseControllerMock.Object);
            verificationAccountController.ModelState.AddModelError(string.Empty,
                "Transaction not applicable");

            IActionResult result = await verificationAccountController.VerifyAccountsUsingTransactions(
                "1234", CreateVerifyAccountRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_VerifyAccountsUsingTransactions_MaxTransactionCriteriaExceeds()
        {
            GetImeadiatrMockForVerifyAccountsUsingTransactions(HttpStatusCode.BadRequest, HttpMethod.Get);

            var verificationAccountController = new VerifyAccountController(_mockMediatr.Object,
                _baseControllerMock.Object);
            verificationAccountController.ModelState.AddModelError(string.Empty,
                "the maximum number of transaction criteria permitted is 5");

            IActionResult result = await verificationAccountController.VerifyAccountsUsingTransactions(
                "1234", CreateVerifyAccountRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_VerifyAccountsUsingTransactions_TransactionsNotRefreshed()
        {
            GetImeadiatrMockForVerifyAccountsUsingTransactions(HttpStatusCode.BadRequest, HttpMethod.Get);

            var verificationAccountController = new VerifyAccountController(_mockMediatr.Object,
                _baseControllerMock.Object);
            verificationAccountController.ModelState.AddModelError(string.Empty,
                "transactions are not refreshed in the past 24 hours");

            IActionResult result = await verificationAccountController.VerifyAccountsUsingTransactions(
                "1234", CreateVerifyAccountRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_VerifyAccountsUsingTransactions_ActiveAccountCanBeVerified()
        {
            GetImeadiatrMockForVerifyAccountsUsingTransactions(HttpStatusCode.BadRequest, HttpMethod.Get);

            var verificationAccountController = new VerifyAccountController(_mockMediatr.Object,
                _baseControllerMock.Object);
            verificationAccountController.ModelState.AddModelError(string.Empty,
                "Only active accounts can be verified");

            IActionResult result = await verificationAccountController.VerifyAccountsUsingTransactions(
                "1234", CreateVerifyAccountRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_VerifyAccountsUsingTransactions_ServiceNotSupported()
        {
            GetImeadiatrMockForVerifyAccountsUsingTransactions(HttpStatusCode.BadRequest, HttpMethod.Get);

            var verificationAccountController = new VerifyAccountController(_mockMediatr.Object,
                _baseControllerMock.Object);
            verificationAccountController.ModelState.AddModelError(string.Empty,
                "Service not supported");

            IActionResult result = await verificationAccountController.VerifyAccountsUsingTransactions(
                "1234", CreateVerifyAccountRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        private void GetImeadiatrMockForVerifyAccountsUsingTransactions(HttpStatusCode request,
           HttpMethod response)
        {
            _mockMediatr.Setup(m => m.Send(It.IsAny<VerifyAccountCommand>(),
                 It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(request, response));
        }

        [Test]
        public async Task Test_VerifyAccountsUsingTransactions_NotFound()
        {
            var expected = HttpStatusCode.NotFound;

            var response = await _client.PostAsJsonAsync(
               "/api/v1/VerifyAccount/VerifyAccountsUsingTransactio", CreateVerifyAccountRequestBody());

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_VerifyAccountsUsingTransactions_Unauthorize()
        {
            var expected = HttpStatusCode.Unauthorized;

            var response = await _client.PostAsJsonAsync(
               "/api/v1/VerifyAccount/VerifyAccountsUsingTransactions/10012669", CreateVerifyAccountRequestBody());

            Assert.AreEqual(expected, response.StatusCode);
        }

        private static VerifyAccountRequestBody CreateVerifyAccountRequestBody()
        {
            return
                new VerifyAccountRequestBody()
                {
                    Container = "bank",
                    AccountId = 10045967,

                    TransactionCriteria = new List<VerifyAccountTransactionCriteria>()
                    {
                        new VerifyAccountTransactionCriteria()
                        {
                            Date="string",
                            Amount=0,
                            Keyword="string",
                            DateVariance="string",
                            BaseType="CREDIT"
                        }
                    }
                };
        }
    }
}