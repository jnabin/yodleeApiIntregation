using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using YodleeIntegration.Api.Controllers.Holdings;
using YodleeIntegration.Api.Models;
using YodleeIntegration.Application.Holdings;
using YodleeIntegration.Application.Holdings.GetHoldings;
using YodleeIntegration.Application.Holdings.GetHoldingTypeList;
using YodleeIntegration.Application.Holdings.GetSecurityDetails;

namespace YodleeIntegration.Api.Test.Holdings
{
    public class HoldingsControllerTest : BaseApiTest
    {
        [Test]
        public async Task TestGetAssetClassificationListSucceeds()
        {
            GetImeadiatrMockForGetAssetClassificationList(HttpStatusCode.OK, HttpMethod.Get);
            var hodingsController = new HoldingsController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await hodingsController.GetAssetClassificationList();

            var okResult = result as ObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetAssetClassificationList_Unauthorize()
        {
            var expected = HttpStatusCode.Unauthorized;

            var response = await _client.GetAsync("/api/v1/Holdings/GetAssetClassificationList");

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task TestGetAssetClassificationListNotfound()
        {
            var expected = HttpStatusCode.NotFound;

            var response = await _client.GetAsync("/api/v1/Holdings/GetAssetClassificatio");

            Assert.AreEqual(expected, response.StatusCode);
        }

        private void GetImeadiatrMockForGetAssetClassificationList(HttpStatusCode request,
            HttpMethod response)
        {
            _mockMediatr.Setup(m => m.Send(It.IsAny<GetAssetClassificationListQuery>(),
                 It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(request, response));
        }

        [Test]
        public async Task Test_GetSecurityDetails_Succeeds()
        {
            GetImeadiatrMockForGetSecurityDetail(HttpStatusCode.OK, HttpMethod.Get);

            var hodingsController = new HoldingsController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await hodingsController.GetSecurityDetails(
                GetSecurityDetailsQueryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetSecurityDetails_InvalidHoldingId()
        {
            GetImeadiatrMockForGetSecurityDetail(HttpStatusCode.BadRequest, HttpMethod.Get);

            var hodingsController = new HoldingsController(_mockMediatr.Object, _baseControllerMock.Object);
            hodingsController.ModelState.AddModelError(string.Empty, "invalid value for holdingId");

            IActionResult result = await hodingsController.GetSecurityDetails(
                GetSecurityDetailsQueryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetSecurityDetails_MaxIDCountError()
        {
            GetImeadiatrMockForGetSecurityDetail(HttpStatusCode.BadRequest, HttpMethod.Get);

            var hodingsController = new HoldingsController(_mockMediatr.Object, _baseControllerMock.Object);
            hodingsController.ModelState.AddModelError(string.Empty,
                "The maximum number of holdingIds permitted is 100");

            IActionResult result = await hodingsController.GetSecurityDetails(
                GetSecurityDetailsQueryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        private void GetImeadiatrMockForGetSecurityDetail(HttpStatusCode request,
           HttpMethod response)
        {
            _mockMediatr.Setup(m => m.Send(It.IsAny<GetSecurityDetailsQuery>(),
                 It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(request, response));
        }

        private static GetSecurityDetailsQueryParams GetSecurityDetailsQueryParams()
        {
            return new GetSecurityDetailsQueryParams
            {
                HoldingId = "1,2,3,4,5"
            };
        }

        [Test]
        public async Task TestGetSecurityDetailsUnauthorize()
        {
            var expected = HttpStatusCode.Unauthorized;

            var response = await _client.GetAsync("/api/v1/Holdings/GetSecurityDetails");

            Assert.AreEqual(expected, response.StatusCode);
        }
        [Test]
        public async Task Test_GetSecurityDetails_NotFound()
        {
            var expected = HttpStatusCode.NotFound;

            var response = await _client.GetAsync("/api/v1/Holdings/GetSecurityDeta");

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_GetHoldings_Succeeds()
        {
            GetImeadiatrMockForGetHolding(HttpStatusCode.OK, HttpMethod.Get);
            var hodingsController = new HoldingsController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await hodingsController.GetHoldings(
                GetHoldingsQueryParams());
            var okResult = result as ObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetHoldings_InvalidAccountId()
        {
            GetImeadiatrMockForGetHolding(HttpStatusCode.BadRequest, HttpMethod.Get);
            var hodingsController = new HoldingsController(_mockMediatr.Object, _baseControllerMock.Object);
            hodingsController.ModelState.AddModelError(string.Empty, "Invalid value for accountID");

            IActionResult result = await hodingsController.GetHoldings(
                GetInvalidHoldingsQueryParams());
            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetHoldingsInvalid_ProviderAccountId()
        {
            GetImeadiatrMockForGetHolding(HttpStatusCode.BadRequest, HttpMethod.Get);
            var hodingsController = new HoldingsController(_mockMediatr.Object, _baseControllerMock.Object);
            hodingsController.ModelState.AddModelError(string.Empty, "Invalid value for provider account ID");

            IActionResult result = await hodingsController.GetHoldings(
                GetInvalidHoldingsQueryParams());
            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetHoldings_InvalidIncludeValue()
        {
            GetImeadiatrMockForGetHolding(HttpStatusCode.BadRequest, HttpMethod.Get);
            var hodingsController = new HoldingsController(_mockMediatr.Object, _baseControllerMock.Object);
            hodingsController.ModelState.AddModelError(string.Empty, "Invalid value for Include");

            IActionResult result = await hodingsController.GetHoldings(
                GetInvalidHoldingsQueryParams());
            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetHoldings_InvalidClassificationType()
        {
            GetImeadiatrMockForGetHolding(HttpStatusCode.BadRequest, HttpMethod.Get);
            var hodingsController = new HoldingsController(_mockMediatr.Object, _baseControllerMock.Object);
            hodingsController.ModelState.AddModelError(string.Empty, "Invalid value for Classification Type");

            IActionResult result = await hodingsController.GetHoldings(
                GetInvalidHoldingsQueryParams());
            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetHoldings_ClassificationTypeMismatch()
        {
            GetImeadiatrMockForGetHolding(HttpStatusCode.BadRequest, HttpMethod.Get);
            var hodingsController = new HoldingsController(_mockMediatr.Object, _baseControllerMock.Object);
            hodingsController.ModelState.AddModelError(string.Empty, "Classification Type Mismatch");

            IActionResult result = await hodingsController.GetHoldings(
                GetInvalidHoldingsQueryParams());
            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetHoldings_ExcceedsMaxAccountId()
        {
            GetImeadiatrMockForGetHolding(HttpStatusCode.BadRequest, HttpMethod.Get);
            var hodingsController = new HoldingsController(_mockMediatr.Object, _baseControllerMock.Object);
            hodingsController.ModelState.AddModelError(string.Empty,
                "The maximum number of accountIds permitted is 100");

            IActionResult result = await hodingsController.GetHoldings(
                GetHoldingsQueryParams());
            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        private void GetImeadiatrMockForGetHolding(HttpStatusCode request,
           HttpMethod response)
        {
            _mockMediatr.Setup(m => m.Send(It.IsAny<GetHoldingsQuery>(),
                 It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(request, response));
        }

        private void GetImeadiatrMockForGetHoldings(HttpStatusCode request,
           HttpMethod response)
        {
            _mockMediatr.Setup(m => m.Send(It.IsAny<GetSecurityDetailsQuery>(),
                 It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(request, response));
        }

        private static GetHoldingsQueryParams GetHoldingsQueryParams()
        {
            return new GetHoldingsQueryParams
            {
                AccountId = "1,2,3,4",
                AssetClassificationClassificationType = "Country",
                ClassificationValue = "US",
                Include = "assetClassification",
                ProviderAccountId = "123"
            };
        }

        private static GetHoldingsQueryParams GetInvalidHoldingsQueryParams()
        {
            return new GetHoldingsQueryParams
            {
                AccountId = "sds%",
                AssetClassificationClassificationType = "9999999",
                ClassificationValue = "US",
                Include = "$%^",
                ProviderAccountId = "sds@"
            };
        }

        [Test]
        public async Task TestGetHoldingsUnAuthorize()
        {
            var expected = HttpStatusCode.Unauthorized;

            var response = await _client.GetAsync("/api/v1/Holdings/GetHoldings");

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_GetHoldings_NotFound()
        {
            var expected = HttpStatusCode.NotFound;

            var response = await _client.GetAsync("/api/v1/Holdings/GetHoldi");

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_GetHoldingTypeList_Succeeds()
        {
            GetImeadiatrMockForGetHoldingTypeList(HttpStatusCode.OK, HttpMethod.Get);
            var hodingsController = new HoldingsController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await hodingsController.GetHoldingTypeList();
            var okResult = result as ObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);
        }

        private void GetImeadiatrMockForGetSecurityDetails(HttpStatusCode request,
           HttpMethod response)
        {
            _mockMediatr.Setup(m => m.Send(It.IsAny<GetAssetClassificationListQuery>(),
                 It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(request, response));
        }
               
        
        private void GetImeadiatrMockForGetHoldingTypeList(HttpStatusCode request,
           HttpMethod response)
        {
            _mockMediatr.Setup(m => m.Send(It.IsAny<GetHoldingTypeListQuery>(),
                 It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(request, response));
        }

        [Test]
        public async Task TestGetHoldingTypeListUnauthorize()
        {
            var expected = HttpStatusCode.Unauthorized;

            var response = await _client.GetAsync("/api/v1/Holdings/GetHoldingTypeList");

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task TestGetHoldingTypeListNotFound()
        {
            var expected = HttpStatusCode.NotFound;

            var response = await _client.GetAsync("/api/v1/Holdings/GetHoldingTyp");

            Assert.AreEqual(expected, response.StatusCode);
        }
    }
}
