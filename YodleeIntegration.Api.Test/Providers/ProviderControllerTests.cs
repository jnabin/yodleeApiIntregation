using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using YodleeIntegration.Api.Controllers.Providers;
using YodleeIntegration.Api.Models;
using YodleeIntegration.Application.Providers;

namespace YodleeIntegration.Api.Test.Providers
{
    public class ProviderControllerTests : BaseApiTest
    {

        [Test]
        public async Task Test_GetProviders_Succeeds()
        {
            GetImeadiatrMockForGetProviders(HttpStatusCode.OK, HttpMethod.Get);

            var providerController = new ProvidersController(_mockMediatr.Object,
                _baseControllerMock.Object);

            IActionResult result = await providerController.GetProviders(
                GetProvidersQueryParams());
            var okResult = result as ObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetProviders_InvalidPriority()
        {
            GetImeadiatrMockForGetProviders(HttpStatusCode.BadRequest, HttpMethod.Get);

            var providerController = new ProvidersController(_mockMediatr.Object,
                _baseControllerMock.Object);
            providerController.ModelState.AddModelError(string.Empty, "Invalid value for priority");

            IActionResult result = await providerController.GetProviders(
                GetProvidersQueryParams());
            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetProviders_InvalidProviderName()
        {
            GetImeadiatrMockForGetProviders(HttpStatusCode.BadRequest, HttpMethod.Get);

            var providerController = new ProvidersController(_mockMediatr.Object,
                _baseControllerMock.Object);
            providerController.ModelState.AddModelError(string.Empty, "Invalid provider name");

            IActionResult result = await providerController.GetProviders(
                GetProvidersQueryParams());
            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetProviders_InvalidLengthSiteSearch()
        {
            GetImeadiatrMockForGetProviders(HttpStatusCode.BadRequest, HttpMethod.Get);

            var providerController = new ProvidersController(_mockMediatr.Object,
                _baseControllerMock.Object);
            providerController.ModelState.AddModelError(string.Empty,
                "Invalid length for a site search. The search string must have at least 1 character");

            IActionResult result = await providerController.GetProviders(
                GetProvidersQueryParams());
            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetProviders_InvalidSkip()
        {
            GetImeadiatrMockForGetProviders(HttpStatusCode.BadRequest, HttpMethod.Get);

            var providerController = new ProvidersController(_mockMediatr.Object,
                _baseControllerMock.Object);
            providerController.ModelState.AddModelError(string.Empty, "Invalid value for skip");

            IActionResult result = await providerController.GetProviders(
                GetProvidersQueryParams());
            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetProviders_InvalidTopValue()
        {
            GetImeadiatrMockForGetProviders(HttpStatusCode.BadRequest, HttpMethod.Get);

            var providerController = new ProvidersController(_mockMediatr.Object,
                _baseControllerMock.Object);
            providerController.ModelState.AddModelError(string.Empty, "Permitted values of top between 1-500");

            IActionResult result = await providerController.GetProviders(
                GetProvidersQueryParams());
            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetProviders_DatasetNotSupported()
        {
            GetImeadiatrMockForGetProviders(HttpStatusCode.BadRequest, HttpMethod.Get);

            var providerController = new ProvidersController(_mockMediatr.Object,
                _baseControllerMock.Object);
            providerController.ModelState.AddModelError(string.Empty, "Dataset nor supported");

            IActionResult result = await providerController.GetProviders(
                GetProvidersQueryParams());
            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetProviders_AdditionalDatasetNotSupported()
        {
            GetImeadiatrMockForGetProviders(HttpStatusCode.BadRequest, HttpMethod.Get);

            var providerController = new ProvidersController(_mockMediatr.Object,
                _baseControllerMock.Object);
            providerController.ModelState.AddModelError(string.Empty,
                "The additionalDataSet is not supported for Get provider API");

            IActionResult result = await providerController.GetProviders(
                GetProvidersQueryParams());
            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        private static GetProvidersQueryParams GetProvidersQueryParams()
        {
            return new GetProvidersQueryParams
            {
                Capability = "string",
                InstitutionId = 123,
                Name = "Name",
                Priority = "string",
                ProviderId = "1,2,4",
                Skip = 123,
                Top = 50
            };
        }

        [Test]
        public async Task Test_GetProviders_Unauthorize()
        {
            var expected = HttpStatusCode.Unauthorized;

            var response = await _client.GetAsync("/api/v1/Providers/GetProviders");

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_GetProviders_NotFound()
        {
            var expected = HttpStatusCode.NotFound;

            var response = await _client.GetAsync("/api/v1/Providers/GetPro");

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_GetProviderDetails_Succeeds()
        {
            GetImeadiatrMockForGetProviderDetails(HttpStatusCode.OK, HttpMethod.Get);

            var providerController = new ProvidersController(_mockMediatr.Object,
                _baseControllerMock.Object);

            IActionResult result = await providerController.GetProviderDetails(123);
            var okResult = result as ObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetProviderDetails_InvalidProviderId()
        {
            GetImeadiatrMockForGetProviderDetails(HttpStatusCode.BadRequest, HttpMethod.Get);

            var providerController = new ProvidersController(_mockMediatr.Object,
                _baseControllerMock.Object);
            providerController.ModelState.AddModelError(string.Empty, "Invalid value for providerId");

            IActionResult result = await providerController.GetProviderDetails(-0);
            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        private void GetImeadiatrMockForGetProviderDetails(HttpStatusCode request,
           HttpMethod response)
        {
            _mockMediatr.Setup(m => m.Send(It.IsAny<GetProvidersDetailsQuery>(),
                 It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(request, response));
        }

        [Test]
        public async Task Test_GetProviderDetails_Unauthorize()
        {
            var expected = HttpStatusCode.Unauthorized;

            var response = await _client.GetAsync("/api/v1/Providers/GetProviderDetails/16441");

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_GetProviderDetails_NotFound()
        {
            var expected = HttpStatusCode.NotFound;

            var response = await _client.GetAsync("/api/v1/Providers/GetProviderD");

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_GetProvidersCount_Succeeds()
        {
            GetImeadiatrMockForGetProviders(HttpStatusCode.OK, HttpMethod.Get);

            var providerController = new ProvidersController(_mockMediatr.Object,
                _baseControllerMock.Object);

            IActionResult result = await providerController.GetProvidersCount(
                GetProvidersCountQueryParams());
            var okResult = result as ObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetProvidersCount_InvalidPriority()
        {
            GetImeadiatrMockForGetProviders(HttpStatusCode.BadRequest, HttpMethod.Get);

            var providerController = new ProvidersController(_mockMediatr.Object,
                _baseControllerMock.Object);
            providerController.ModelState.AddModelError(string.Empty, "Invalid value for priority");

            IActionResult result = await providerController.GetProvidersCount(
                GetProvidersCountQueryParams());
            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetProvidersCount_InvalidProviderName()
        {
            GetImeadiatrMockForGetProviders(HttpStatusCode.BadRequest, HttpMethod.Get);

            var providerController = new ProvidersController(_mockMediatr.Object,
                _baseControllerMock.Object);
            providerController.ModelState.AddModelError(string.Empty, "Invalid value for provider Name");

            IActionResult result = await providerController.GetProvidersCount(
                GetProvidersCountQueryParams());
            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetProvidersCount_InvalidLengthSiteSearch()
        {
            GetImeadiatrMockForGetProviders(HttpStatusCode.BadRequest, HttpMethod.Get);

            var providerController = new ProvidersController(_mockMediatr.Object,
                _baseControllerMock.Object);
            providerController.ModelState.AddModelError(string.Empty,
                "Invalid length for a site search. The search string must have at least 1 character");

            IActionResult result = await providerController.GetProvidersCount(
                GetProvidersCountQueryParams());
            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        private static GetProvidersCountQueryParams GetProvidersCountQueryParams()
        {
            return new GetProvidersCountQueryParams
            {
                Capability = "CHALLENGE_DEPOSIT_VERIFICATION",
                Name = "string",
                Priority = "string"
            };
        }

        private void GetImeadiatrMockForGetProviders(HttpStatusCode request, 
            HttpMethod response)
        {
            _mockMediatr.Setup(m => m.Send(It.IsAny<GetProvidersQuery>(),
                 It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(request, response));
        }      

        [Test]
        public async Task Test_GetProvidersCount_Unauthorize()
        {
            var expected = HttpStatusCode.Unauthorized;

            var response = await _client.GetAsync("/api/v1/Providers/GetProvidersCount");

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_GetProvidersCount_NotFound()
        {
            var expected = HttpStatusCode.NotFound;

            var response = await _client.GetAsync("/api/v1/Providers/GetProvi");

            Assert.AreEqual(expected, response.StatusCode);
        }


    }
}
