using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using YodleeIntegration.Api.Controllers.Statements;
using YodleeIntegration.Api.Models.Statements;
using YodleeIntegration.Application.Statements.GetStatements;

namespace YodleeIntegration.Api.Test.Statements
{
    public class StatementsControllerTest : BaseApiTest

    {

        [Test]
        public async Task Test_GetStatements_Succeeds()
        {
            GetImeadiatrMockForGetProviders(HttpStatusCode.OK, HttpMethod.Get);

            var statementsController = new StatementsController(_mockMediatr.Object,
                _baseControllerMock.Object);

            IActionResult result = await statementsController.GetStatements(
                GetStatementsParam());
            var okResult = result as ObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetStatements_InvalidAccountId()
        {
            GetImeadiatrMockForGetProviders(HttpStatusCode.BadRequest, HttpMethod.Get);

            var statementsController = new StatementsController(_mockMediatr.Object,
                _baseControllerMock.Object);
            statementsController.ModelState.AddModelError(string.Empty, "Invalid value for accountId");

            IActionResult result = await statementsController.GetStatements(
                GetStatementsParam());
            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetStatements_InvalidStatus()
        {
            GetImeadiatrMockForGetProviders(HttpStatusCode.BadRequest, HttpMethod.Get);

            var statementsController = new StatementsController(_mockMediatr.Object,
                _baseControllerMock.Object);
            statementsController.ModelState.AddModelError(string.Empty, "Invalid value for status");

            IActionResult result = await statementsController.GetStatements(
                GetStatementsParam());
            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetStatements_MultipleConatainersErrror()
        {
            GetImeadiatrMockForGetProviders(HttpStatusCode.BadRequest, HttpMethod.Get);

            var statementsController = new StatementsController(_mockMediatr.Object,
                _baseControllerMock.Object);
            statementsController.ModelState.AddModelError(string.Empty, "Multiple containers not supported");

            IActionResult result = await statementsController.GetStatements(
                GetStatementsParam());
            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetStatements_InvalidContainer()
        {
            GetImeadiatrMockForGetProviders(HttpStatusCode.BadRequest, HttpMethod.Get);

            var statementsController = new StatementsController(_mockMediatr.Object,
                _baseControllerMock.Object);
            statementsController.ModelState.AddModelError(string.Empty, "Invalid value for container");

            IActionResult result = await statementsController.GetStatements(
                GetStatementsParam());
            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetStatements_InvalidIsLatest()
        {
            GetImeadiatrMockForGetProviders(HttpStatusCode.BadRequest, HttpMethod.Get);

            var statementsController = new StatementsController(_mockMediatr.Object,
                _baseControllerMock.Object);
            statementsController.ModelState.AddModelError(string.Empty, "Invalid value for isLatest");

            IActionResult result = await statementsController.GetStatements(
                GetStatementsParam());
            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetStatements_InvalidFromDate()
        {
            GetImeadiatrMockForGetProviders(HttpStatusCode.BadRequest, HttpMethod.Get);

            var statementsController = new StatementsController(_mockMediatr.Object,
                _baseControllerMock.Object);
            statementsController.ModelState.AddModelError(string.Empty, "Invalid value for fromDate");

            IActionResult result = await statementsController.GetStatements(
                GetStatementsParam());
            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }


        private void GetImeadiatrMockForGetProviders(HttpStatusCode request,
         HttpMethod response)
        {
            _mockMediatr.Setup(m => m.Send(It.IsAny<GetStatementsQuery>(),
                 It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(request, response));
        }

        private static GetStatementsParam GetStatementsParam()
        {
            return new GetStatementsParam
            {
                AccountId = "123",
                Container = "creditCard",
                FromDate = "2021-12-08",
                IsLatest = "true",
                Status = "ACTIVE"
            };
        }

        [Test]
        public async Task Test_GetStatements_Unauthorize()
        {
            var expected = HttpStatusCode.Unauthorized;

            var response = await _client.GetAsync("/api/v1/Statements");

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_GetStatements_NotFound()
        {
            var expected = HttpStatusCode.NotFound;

            var response = await _client.GetAsync("/api/v1/Stat");

            Assert.AreEqual(expected, response.StatusCode);
        }
    }
}