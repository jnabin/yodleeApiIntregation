using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using YodleeIntegration.Api.Controllers.DataExtracts;
using YodleeIntegration.Api.Models.DataExtracts;
using YodleeIntegration.Application.DataExtracts.GetEvents;
using YodleeIntegration.Application.DataExtracts.GetUserData;

namespace YodleeIntegration.Api.Test.DataExtracts
{
    public class DataExtractsTests : BaseApiTest
    {

        [Test]
        public async Task TestGetUserDataSucceeds()
        {
            GetImeadiatrMockForGetUserData(HttpStatusCode.OK, HttpMethod.Get);

            var dataExtractsController = new DataExtractsController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await dataExtractsController.GetUserData(
                GetUserDataParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task TestGetUserDataInvalidLoginName()
        {
            GetImeadiatrMockForGetUserData(HttpStatusCode.BadRequest, HttpMethod.Get);

            var dataExtractsController = new DataExtractsController(_mockMediatr.Object, _baseControllerMock.Object);
            dataExtractsController.ModelState.AddModelError(string.Empty, "Invalid Login Name");

            IActionResult result = await dataExtractsController.GetUserData(
                GetUserDataParamsInvalidName());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task TestGetUserDataInvalidDateCannotBeGreaterThanCurrentDate()
        {
            GetImeadiatrMockForGetUserData(HttpStatusCode.BadRequest, HttpMethod.Get);

            var dataExtractsController = new DataExtractsController(_mockMediatr.Object, _baseControllerMock.Object);
            dataExtractsController.ModelState.AddModelError(string.Empty,
                "From Date and To Date cannot be greater than current date");

            IActionResult result = await dataExtractsController.GetUserData(
                GetUserDataParamsInvalidFromDateGreaterThanCurrentDate());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task TestGetUserDataInvalidFromDateCannotBeGreaterThanTODate()
        {
            GetImeadiatrMockForGetUserData(HttpStatusCode.BadRequest, HttpMethod.Get);

            var dataExtractsController = new DataExtractsController(_mockMediatr.Object, _baseControllerMock.Object);
            dataExtractsController.ModelState.AddModelError(string.Empty, "From Date cannot be greater than To Date");

            IActionResult result = await dataExtractsController.GetUserData(
                GetUserDataParamsInvalidFromDateGreaterThantODate());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task TestGetUserDataUnauthorize()
        {
            GetImeadiatrMockForGetUserData(HttpStatusCode.Unauthorized, HttpMethod.Get);

            var dataExtractsController = new DataExtractsController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await dataExtractsController.GetUserData(
                GetUserDataParamsInvalidFromDateGreaterThantODate());

            var okResult = result as ObjectResult;

            Assert.AreEqual(401, okResult.StatusCode);
        }

        [Test]
        public async Task TestGetUserDataNotFound()
        {
            GetImeadiatrMockForGetUserData(HttpStatusCode.NotFound, HttpMethod.Post);

            var dataExtractsController = new DataExtractsController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await dataExtractsController.GetUserData(
                new GetUserDataParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(404, okResult.StatusCode);
        }

        private void GetImeadiatrMockForGetUserData(HttpStatusCode request, HttpMethod response)
        {
            _mockMediatr.Setup(m => m.Send(It.IsAny<GetUserDataQuery>(),
                  It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(request, response));
        }

        private static GetUserDataParams GetUserDataParams()
        {
            return new GetUserDataParams
            {
                FromDate = "12/7/2021",
                LoginName = "xyz",
                ToDate = "12/8/2021"
            };
        }

        private static GetUserDataParams GetUserDataParamsInvalidName()
        {
            return new GetUserDataParams
            {
                FromDate = "12/7/2021",
                LoginName = "#",
                ToDate = "12/8/2021"
            };
        }

        private static GetUserDataParams GetUserDataParamsInvalidFromDateGreaterThanCurrentDate()
        {
            return new GetUserDataParams
            {
                FromDate = "12/7/2022",
                LoginName = "name",
                ToDate = "12/8/2022"
            };
        }

        private static GetUserDataParams GetUserDataParamsInvalidFromDateGreaterThantODate()
        {
            return new GetUserDataParams
            {
                FromDate = "11/7/2021",
                LoginName = "name",
                ToDate = "10/7/2021"
            };
        }

        [Test]
        public async Task TestGetEventsSucceeds()
        {
            GetImeadiatrMockForGetEvents(HttpStatusCode.OK, HttpMethod.Get);

            var dataExtractsController = new DataExtractsController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await dataExtractsController.GetEvents(
                GetEventsParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task TestGetEventsInvalidDateCannotBeGreaterThanCurrentDate()
        {
            GetImeadiatrMockForGetEvents(HttpStatusCode.BadRequest, HttpMethod.Get);

            var dataExtractsController = new DataExtractsController(_mockMediatr.Object, _baseControllerMock.Object);
            dataExtractsController.ModelState.AddModelError(string.Empty,
                "From Date and To Date cannot be greater than current date");

            IActionResult result = await dataExtractsController.GetEvents(
                GetEventsParamsDateConnotbeGreaterThanCurrent());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task TestGetEventsInvalidFromDateCannotBeGreayerThanToDate()
        {
            GetImeadiatrMockForGetEvents(HttpStatusCode.BadRequest, HttpMethod.Get);

            var dataExtractsController = new DataExtractsController(_mockMediatr.Object, _baseControllerMock.Object);
            dataExtractsController.ModelState.AddModelError(string.Empty, "From Date cannot be greater than To Date");

            IActionResult result = await dataExtractsController.GetEvents(
                GetEventsParamsFromDateConnotbeGreaterThanToDate());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task TestGetEventsUnauthorize()
        {
            GetImeadiatrMockForGetEvents(HttpStatusCode.Unauthorized, HttpMethod.Get);

            var dataExtractsController = new DataExtractsController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await dataExtractsController.GetEvents(
                GetEventsParamsFromDateConnotbeGreaterThanToDate());

            var okResult = result as ObjectResult;

            Assert.AreEqual(401, okResult.StatusCode);
        }

        [Test]
        public async Task TestGetEventsNotFound()
        {
            GetImeadiatrMockForGetEvents(HttpStatusCode.NotFound, HttpMethod.Get);

            var dataExtractsController = new DataExtractsController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await dataExtractsController.GetEvents(
                new GetEventsParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(404, okResult.StatusCode);
        }

        private void GetImeadiatrMockForGetEvents(HttpStatusCode request, HttpMethod response)
        {
            _mockMediatr.Setup(m => m.Send(It.IsAny<GetEventsQuery>(),
                  It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(request, response));
        }

        private static GetEventsParams GetEventsParams()
        {
            return new GetEventsParams
            {
                FromDate = "12/7/2021",
                EventName = "REFRESH",
                ToDate = "12/8/2021"
            };
        }

        private static GetEventsParams GetEventsParamsDateConnotbeGreaterThanCurrent()
        {
            return new GetEventsParams
            {
                FromDate = "12/7/2022",
                EventName = "REFRESH",
                ToDate = "12/8/2022"
            };
        }

        private static GetEventsParams GetEventsParamsFromDateConnotbeGreaterThanToDate()
        {
            return new GetEventsParams
            {
                FromDate = "12/7/2021",
                EventName = "REFRESH",
                ToDate = "11/8/2021"
            };
        }
    }
}