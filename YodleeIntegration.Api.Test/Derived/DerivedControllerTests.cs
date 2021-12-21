using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using YodleeIntegration.Api.Controllers.Derived;
using YodleeIntegration.Api.Models.Derived;
using YodleeIntegration.Application.Derived.GetHoldingSummary;
using YodleeIntegration.Application.Derived.GetNetworthSummary;
using YodleeIntegration.Application.Derived.GetTransactionSummary;

namespace YodleeIntegration.Api.Test.Derived
{
    internal class DerivedControllerTests:BaseApiTest
    {

        [Test]
        public async Task TestGetNetWorthSucceeds()
        {
            GetImeadiatrMockForGetNetWorth(HttpStatusCode.OK, HttpMethod.Get);

            var derivedController = new DerivedController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await derivedController.GetNetworth(
                GetNetworthSummaryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task TestGetNetWorthInvalidValueForAccountIds()
        {
            GetImeadiatrMockForGetNetWorth(HttpStatusCode.BadRequest, HttpMethod.Get);

            var derivedController = new DerivedController(_mockMediatr.Object, _baseControllerMock.Object);
            derivedController.ModelState.AddModelError(string.Empty, "Invalid Value For Account Ids");

            IActionResult result = await derivedController.GetNetworth(
                GetNetworthSummaryParamsInvalidAccountsId());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task TestGetNetWorthInvalidValueForDate()
        {
            GetImeadiatrMockForGetNetWorth(HttpStatusCode.BadRequest, HttpMethod.Get);

            var derivedController = new DerivedController(_mockMediatr.Object, _baseControllerMock.Object);
            derivedController.ModelState.AddModelError(string.Empty, "From Date and To Date cannot be greater than current date");

            IActionResult result = await derivedController.GetNetworth(
                GetNetworthSummaryParamsInvalidDate());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task TestGetNetWorthInvalidValueForInterval()
        {
            GetImeadiatrMockForGetNetWorth(HttpStatusCode.BadRequest, HttpMethod.Get);

            var derivedController = new DerivedController(_mockMediatr.Object, _baseControllerMock.Object);
            derivedController.ModelState.AddModelError(string.Empty, "Invalid Value For Interval");

            IActionResult result = await derivedController.GetNetworth(
                GetNetworthSummaryParamsInvalidInterval());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task TestGetNetWorthInvalidDateRange()
        {
            GetImeadiatrMockForGetNetWorth(HttpStatusCode.BadRequest, HttpMethod.Get);

            var derivedController = new DerivedController(_mockMediatr.Object, _baseControllerMock.Object);
            derivedController.ModelState.AddModelError(string.Empty, "Invalid Value For Interval");

            IActionResult result = await derivedController.GetNetworth(
                GetNetworthSummaryParamsInvalidDateRange());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task TestGetNetWorthInvalidExchangeRate()
        {
            GetImeadiatrMockForGetNetWorth(HttpStatusCode.BadRequest, HttpMethod.Get);

            var derivedController = new DerivedController(_mockMediatr.Object, _baseControllerMock.Object);
            derivedController.ModelState.AddModelError(string.Empty, "EXCHANGE Rate not available for currency");

            IActionResult result = await derivedController.GetNetworth(
                GetNetworthSummaryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task TestGetNetWorthInvalidContainer()
        {
            GetImeadiatrMockForGetNetWorth(HttpStatusCode.BadRequest, HttpMethod.Get);

            var derivedController = new DerivedController(_mockMediatr.Object, _baseControllerMock.Object);
            derivedController.ModelState.AddModelError(string.Empty, "Invalid value for container");

            IActionResult result = await derivedController.GetNetworth(
                GetNetworthSummaryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task TestGetNetWorthUnauthorize()
        {
            var expected = HttpStatusCode.Unauthorized;

            var response = await _client.GetAsync("/api/v1/Derived/Networth");

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task TestGetNetWorthNotFound()
        {
            GetImeadiatrMockForGetNetWorth(HttpStatusCode.NotFound, HttpMethod.Get);

            var derivedController = new DerivedController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await derivedController.GetNetworth(
                GetNetworthSummaryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(404, okResult.StatusCode);
        }

        private void GetImeadiatrMockForGetNetWorth(HttpStatusCode request, HttpMethod response)
        {
            _mockMediatr.Setup(m => m.Send(It.IsAny<GetNetworthSummaryQuery>(),
                  It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(request, response));
        }

        private static GetNetworthSummaryParams GetNetworthSummaryParams()
        {
            return new GetNetworthSummaryParams
            {
                AccountIds = "123, 124",
                Container = "string",
                FromDate = "12/6/2021",
                Include = "string",
                Interval = "D-daily",
                Skip = 1,
                ToDate = "12/7/2021",
                Top = 3
            };
        }

        private static GetNetworthSummaryParams GetNetworthSummaryParamsInvalidAccountsId()
        {
            return new GetNetworthSummaryParams
            {
                AccountIds = "",
                Container = "string",
                FromDate = "12/6/2021",
                Include = "string",
                Interval = "D-daily",
                Skip = 1,
                ToDate = "12/7/2021",
                Top = 3
            };
        }

        private static GetNetworthSummaryParams GetNetworthSummaryParamsInvalidInterval()
        {
            return new GetNetworthSummaryParams
            {
                AccountIds = "",
                Container = "string",
                FromDate = "12/6/2021",
                Include = "string",
                Interval = "",
                Skip = 1,
                ToDate = "12/7/2021",
                Top = 3
            };
        }

        private static GetNetworthSummaryParams GetNetworthSummaryParamsInvalidDate() 
        { 
            return new GetNetworthSummaryParams
            {
                AccountIds = "",
                Container = "string",
                FromDate = "12/6/2022",
                Include = "string",
                Interval = "string",
                Skip = 1,
                ToDate = "12/7/2022",
                Top = 3
            };
        }

        private static GetNetworthSummaryParams GetNetworthSummaryParamsInvalidDateRange()
        {
            return new GetNetworthSummaryParams
            {
                AccountIds = "",
                Container = "string",
                FromDate = "12/7/2021",
                Include = "string",
                Interval = "string",
                Skip = 1,
                ToDate = "12/6/2021",
                Top = 3
            };
        }

        [Test]
        public async Task TestGetHoldingSummarySucceeds()
        {
            GetImeadiatrMockForGetHoldingSummary(HttpStatusCode.OK, HttpMethod.Get);

            var derivedController = new DerivedController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await derivedController.GetHoldingSummary(
                GetHoldingSummaryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task TestGetHoldingSummaryInvalidClassification()
        {
            GetImeadiatrMockForGetHoldingSummary(HttpStatusCode.BadRequest, HttpMethod.Get);

            var derivedController = new DerivedController(_mockMediatr.Object, _baseControllerMock.Object);
            derivedController.ModelState.AddModelError(string.Empty, "Invalid value for classificaionType");

            IActionResult result = await derivedController.GetHoldingSummary(
                GetHoldingSummaryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task TestGetHoldingSummaryInvalidAccountIds()
        {
            GetImeadiatrMockForGetHoldingSummary(HttpStatusCode.BadRequest, HttpMethod.Get);

            var derivedController = new DerivedController(_mockMediatr.Object, _baseControllerMock.Object);
            derivedController.ModelState.AddModelError(string.Empty,
                "The maximum number of accountIds permitted is 100");

            IActionResult result = await derivedController.GetHoldingSummary(
                GetHoldingSummaryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task TestGetHoldingSummaryUnauthorize()
        {
            GetImeadiatrMockForGetHoldingSummary(HttpStatusCode.Unauthorized, HttpMethod.Get);

            var derivedController = new DerivedController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await derivedController.GetHoldingSummary(
                GetHoldingSummaryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(401, okResult.StatusCode);
        }

        [Test]
        public async Task TestGetHoldingSummaryNotFound()
        {
            GetImeadiatrMockForGetHoldingSummary(HttpStatusCode.NotFound, HttpMethod.Get);

            var derivedController = new DerivedController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await derivedController.GetHoldingSummary(
                GetHoldingSummaryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(404, okResult.StatusCode);
        }

        private void GetImeadiatrMockForGetHoldingSummary(HttpStatusCode request, HttpMethod response)
        {
            _mockMediatr.Setup(m => m.Send(It.IsAny<GetHoldingSummaryQuery>(),
                  It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(request, response));
        }

        private GetHoldingSummaryParams GetHoldingSummaryParams()
        {
            return new GetHoldingSummaryParams
            {
                AccountIds = "123, 23",
                ClassificationType = "Country",
                Include = "details"
            };
        }


        [Test]
        public async Task TestGetTransactionSummarySucceeds()
        {
            GetImeadiatrMockForGetTransactionSummary(HttpStatusCode.OK, HttpMethod.Get);

            var derivedController = new DerivedController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await derivedController.GetTransactionSummary(
                GetTransactionSummaryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task TestGetTransactionSummaryInvalidSession()
        {
            GetImeadiatrMockForGetTransactionSummary(HttpStatusCode.BadRequest, HttpMethod.Get);

            var derivedController = new DerivedController(_mockMediatr.Object, _baseControllerMock.Object);
            derivedController.ModelState.AddModelError(string.Empty, "Invalid Session");

            IActionResult result = await derivedController.GetTransactionSummary(
                GetTransactionSummaryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task TestGetTransactionSummaryInvalidAccountId()
        {
            GetImeadiatrMockForGetTransactionSummary(HttpStatusCode.BadRequest, HttpMethod.Get);

            var derivedController = new DerivedController(_mockMediatr.Object, _baseControllerMock.Object);
            derivedController.ModelState.AddModelError(string.Empty, "Invalid value for accountId");

            IActionResult result = await derivedController.GetTransactionSummary(
                GetTransactionSummaryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task TestGetTransactionSummaryInvalidGroupBy()
        {
            GetImeadiatrMockForGetTransactionSummary(HttpStatusCode.BadRequest, HttpMethod.Get);

            var derivedController = new DerivedController(_mockMediatr.Object, _baseControllerMock.Object);
            derivedController.ModelState.AddModelError(string.Empty, "Invalid value for groupBy");

            IActionResult result = await derivedController.GetTransactionSummary(
                GetTransactionSummaryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task TestGetTransactionSummaryGroupByRequired()
        {
            GetImeadiatrMockForGetTransactionSummary(HttpStatusCode.BadRequest, HttpMethod.Get);

            var derivedController = new DerivedController(_mockMediatr.Object, _baseControllerMock.Object);
            derivedController.ModelState.AddModelError(string.Empty, "groupBy required");

            IActionResult result = await derivedController.GetTransactionSummary(
                GetTransactionSummaryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task TestGetTransactionSummaryCategoryTypeRequired()
        {
            GetImeadiatrMockForGetTransactionSummary(HttpStatusCode.BadRequest, HttpMethod.Get);

            var derivedController = new DerivedController(_mockMediatr.Object, _baseControllerMock.Object);
            derivedController.ModelState.AddModelError(string.Empty, "categoryType required");

            IActionResult result = await derivedController.GetTransactionSummary(
                GetTransactionSummaryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task TestGetTransactionSummaryInvalidCategoryId()
        {
            GetImeadiatrMockForGetTransactionSummary(HttpStatusCode.BadRequest, HttpMethod.Get);

            var derivedController = new DerivedController(_mockMediatr.Object, _baseControllerMock.Object);
            derivedController.ModelState.AddModelError(string.Empty, "invalid value for categoryId");

            IActionResult result = await derivedController.GetTransactionSummary(
                GetTransactionSummaryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task TestGetTransactionSummaryInvalidFromDate()
        {
            GetImeadiatrMockForGetTransactionSummary(HttpStatusCode.BadRequest, HttpMethod.Get);

            var derivedController = new DerivedController(_mockMediatr.Object, _baseControllerMock.Object);
            derivedController.ModelState.AddModelError(string.Empty, "invalid value for From Date");

            IActionResult result = await derivedController.GetTransactionSummary(
                GetTransactionSummaryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task TestGetTransactionSummaryInvalidToDate()
        {
            GetImeadiatrMockForGetTransactionSummary(HttpStatusCode.BadRequest, HttpMethod.Get);

            var derivedController = new DerivedController(_mockMediatr.Object, _baseControllerMock.Object);
            derivedController.ModelState.AddModelError(string.Empty, "invalid value for To Date");

            IActionResult result = await derivedController.GetTransactionSummary(
                GetTransactionSummaryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task TestGetTransactionSummaryInvalidExchangeRate()
        {
            GetImeadiatrMockForGetTransactionSummary(HttpStatusCode.BadRequest, HttpMethod.Get);

            var derivedController = new DerivedController(_mockMediatr.Object, _baseControllerMock.Object);
            derivedController.ModelState.AddModelError(string.Empty, "Exchange Rate not available for currency");

            IActionResult result = await derivedController.GetTransactionSummary(
                GetTransactionSummaryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task TestGetTransactionSummaryInvalidMaxAccountId()
        {
            GetImeadiatrMockForGetTransactionSummary(HttpStatusCode.BadRequest, HttpMethod.Get);

            var derivedController = new DerivedController(_mockMediatr.Object, _baseControllerMock.Object);
            derivedController.ModelState.AddModelError(string.Empty, "The maximum number of accountIds permitted is 100");

            IActionResult result = await derivedController.GetTransactionSummary(
                GetTransactionSummaryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task TestGetTransactionSummaryInvalidMaxCategoryId()
        {
            GetImeadiatrMockForGetTransactionSummary(HttpStatusCode.BadRequest, HttpMethod.Get);

            var derivedController = new DerivedController(_mockMediatr.Object, _baseControllerMock.Object);
            derivedController.ModelState.AddModelError(string.Empty, "The maximum number of categoryIds permitted is 100");

            IActionResult result = await derivedController.GetTransactionSummary(
                GetTransactionSummaryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task TestGetTransactionSummaryInvalidMaxCategoryTypes()
        {
            GetImeadiatrMockForGetTransactionSummary(HttpStatusCode.BadRequest, HttpMethod.Get);

            var derivedController = new DerivedController(_mockMediatr.Object, _baseControllerMock.Object);
            derivedController.ModelState.AddModelError(string.Empty, "The maximum number of categoryTypes permitted is 100");

            IActionResult result = await derivedController.GetTransactionSummary(
                GetTransactionSummaryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task TestGetTransactionSummaryUnauthorize()
        {
            GetImeadiatrMockForGetTransactionSummary(HttpStatusCode.Unauthorized, HttpMethod.Get);

            var derivedController = new DerivedController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await derivedController.GetTransactionSummary(
                GetTransactionSummaryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(401, okResult.StatusCode);
        }

        [Test]
        public async Task TestGetTransactionSummaryNotFound()
        {
            GetImeadiatrMockForGetTransactionSummary(HttpStatusCode.NotFound, HttpMethod.Get);

            var derivedController = new DerivedController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await derivedController.GetTransactionSummary(
                GetTransactionSummaryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(404, okResult.StatusCode);
        }

        private void GetImeadiatrMockForGetTransactionSummary(HttpStatusCode request, HttpMethod response)
        {
            _mockMediatr.Setup(m => m.Send(It.IsAny<GetTransactionSummaryQuery>(),
                  It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(request, response));
        }

        private static GetTransactionSummaryParams GetTransactionSummaryParams()
        {
            return new GetTransactionSummaryParams
            {
                AccountId = "1,2,3",
                CategoryId = "3,4,5",
                CategoryType = "INCOME",
                FromDate = "2021-12-6",
                GroupBy = "Category",
                Include  ="details",
                IncludeUserCategory = true,
                Interval = "D-daily",
                ToDate = "2021-12-7"
            };
        }

    }
}