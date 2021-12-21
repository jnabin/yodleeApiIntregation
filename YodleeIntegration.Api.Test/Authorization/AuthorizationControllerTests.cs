using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using YodleeIntegration.Api.Controllers.Authorization;
using YodleeIntegration.Api.Models.Authorization;
using YodleeIntegration.Application.Authorization.DeleteAccessToken;
using YodleeIntegration.Application.Response;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Domain.Model.Configurations;

namespace YodleeIntegration.Api.Test.Authorization
{
    public class AuthorizationControllerTests : BaseApiTest
    {
        [Test]
        public async Task Test_PostToken_Succeeds()
        {
            GetbaseControllerMockForPostToken(HttpStatusCode.OK, HttpMethod.Post);

            var authController = new AuthorizationController(_configuration.Object, _mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await authController.PostToken(GetTokenParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);
        }

        private static TokenParams GetTokenParams()
        {
            return new TokenParams
            {
                Username = "e99fd0da-7dc3-42de-b6d7-7a7185b5d707_ADMIN"
            };
        }

        [Test]
        public async Task Test_PostToken_InvalidLoginName()
        {
            GetbaseControllerMockForPostToken(HttpStatusCode.BadRequest, HttpMethod.Post);

            var authController = new AuthorizationController(_configuration.Object,_mockMediatr.Object, _baseControllerMock.Object);
            authController.ModelState.AddModelError(string.Empty, "Invalid Login name");

            IActionResult result = await authController.PostToken(new TokenParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_PostToken_InvalidInput()
        {
            GetbaseControllerMockForPostToken(HttpStatusCode.BadRequest, HttpMethod.Post);

            var authController = new AuthorizationController(_configuration.Object,_mockMediatr.Object, _baseControllerMock.Object);
            authController.ModelState.AddModelError(string.Empty, "Invalid input");

            IActionResult result = await authController.PostToken(new TokenParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_PostToken_InvalidLoginNameLength()
        {
            GetbaseControllerMockForPostToken(HttpStatusCode.BadRequest, HttpMethod.Post);

            var authController = new AuthorizationController(_configuration.Object,_mockMediatr.Object, _baseControllerMock.Object);
            authController.ModelState.AddModelError(string.Empty, "Invalid length for login name");

            IActionResult result = await authController.PostToken(new TokenParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_PostToken_SecretIsMissing()
        {
            GetbaseControllerMockForPostToken(HttpStatusCode.BadRequest, HttpMethod.Post);

            var authController = new AuthorizationController(_configuration.Object,_mockMediatr.Object, _baseControllerMock.Object);
            authController.ModelState.AddModelError(string.Empty, "clienId or secret is missing");

            IActionResult result = await authController.PostToken(new TokenParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_PostToken_InactiveUser()
        {
            GetbaseControllerMockForPostToken(HttpStatusCode.BadRequest, HttpMethod.Post);

            var authController = new AuthorizationController(_configuration.Object,_mockMediatr.Object, _baseControllerMock.Object);
            authController.ModelState.AddModelError(string.Empty, "Inactive user");

            IActionResult result = await authController.PostToken(new TokenParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_PostToken_ServiceNotSupported()
        {
            GetbaseControllerMockForPostToken(HttpStatusCode.BadRequest, HttpMethod.Post);

            var authController = new AuthorizationController(_configuration.Object,_mockMediatr.Object, _baseControllerMock.Object);
            authController.ModelState.AddModelError(string.Empty, "Service not supported");

            IActionResult result = await authController.PostToken(new TokenParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        private void GetbaseControllerMockForPostToken(HttpStatusCode request, HttpMethod response)
        {
            _baseControllerMock.Setup(x => x.GetAuthTokenFromApi(It.IsAny<YodleeConfiguration>(),
                It.IsAny<string>())).Returns(MediatrMockReturns(request, response,
                new StringContent(JsonConvert.SerializeObject(GetAuthorizationUserTokenResponse()))));
        }

        private static AuthorizationUserTokenResponse GetAuthorizationUserTokenResponse()
        {
            return new AuthorizationUserTokenResponse
            {
                Token = new UserToken
                {
                    AccessToken = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                    IssuedAt = DateTime.Now,
                    ExpiresIn = 60
                }
            };
        }

        [Test]
        public async Task Test_DeleteAuthToken_Succeeds()
        {
            GetImeadiatrMockForDeleteAuthToken(HttpStatusCode.NoContent, HttpMethod.Delete);

            var authController = new AuthorizationController(_configuration.Object,_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await authController.DeleteToken();

            var okResult = result as ObjectResult;

            Assert.AreEqual(204, okResult.StatusCode);
        }

        [Test]
        public async Task Test_DeleteAuthToken_InvalidToken()
        {
            GetImeadiatrMockForDeleteAuthToken(HttpStatusCode.Unauthorized, HttpMethod.Delete);

            var authController = new AuthorizationController(_configuration.Object,_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await authController.DeleteToken();

            var okResult = result as ObjectResult;

            Assert.AreEqual(401, okResult.StatusCode);
        }

        [Test]
        public async Task Test_DeleteAuthToken_TokenExpired()
        {
            GetImeadiatrMockForDeleteAuthToken(HttpStatusCode.Unauthorized, HttpMethod.Delete);

            var authController = new AuthorizationController(_configuration.Object,_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await authController.DeleteToken();

            var okResult = result as ObjectResult;

            Assert.AreEqual(401, okResult.StatusCode);
        }

        [Test]
        public async Task Test_DeleteAuthToken_ApiVersionHeaderMissing()
        {
            GetImeadiatrMockForDeleteAuthToken(HttpStatusCode.Unauthorized, HttpMethod.Delete);

            var authController = new AuthorizationController(_configuration.Object,_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await authController.DeleteToken();

            var okResult = result as ObjectResult;

            Assert.AreEqual(401, okResult.StatusCode);
        }

        [Test]
        public async Task Test_DeleteAuthToken_UnauthorizeUser()
        {
            GetImeadiatrMockForDeleteAuthToken(HttpStatusCode.Unauthorized, HttpMethod.Delete);

            var authController = new AuthorizationController(_configuration.Object,_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await authController.DeleteToken();

            var okResult = result as ObjectResult;

            Assert.AreEqual(401, okResult.StatusCode);
        }

        [Test]
        public async Task Test_DeleteAuthToken_UnsupportedType()
        {
            GetImeadiatrMockForDeleteAuthToken(HttpStatusCode.Unauthorized, HttpMethod.Delete);

            var authController = new AuthorizationController(_configuration.Object,_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await authController.DeleteToken();

            var okResult = result as ObjectResult;

            Assert.AreEqual(401, okResult.StatusCode);
        }

        [Test]
        public async Task Test_DeleteAuthToken_HeaderMissing()
        {
            GetImeadiatrMockForDeleteAuthToken(HttpStatusCode.Unauthorized, HttpMethod.Delete);

            var authController = new AuthorizationController(_configuration.Object,_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await authController.DeleteToken();

            var okResult = result as ObjectResult;

            Assert.AreEqual(401, okResult.StatusCode);
        }

        [Test]
        public async Task Test_DeleteAuthToken_InvalidTokenInHeader()
        {
            GetImeadiatrMockForDeleteAuthToken(HttpStatusCode.Unauthorized, HttpMethod.Delete);

            var authController = new AuthorizationController(_configuration.Object,_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await authController.DeleteToken();

            var okResult = result as ObjectResult;

            Assert.AreEqual(401, okResult.StatusCode);
        }

        private void GetImeadiatrMockForDeleteAuthToken(HttpStatusCode request,
         HttpMethod response)
        {
            _mockMediatr.Setup(m => m.Send(It.IsAny<DeleteAccessTokenCommand>(),
                 It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(request, response));
        }

        [Test]
        public async Task Test_DeleteAuthToken_Unauthorize()
        {
            var expected = HttpStatusCode.Unauthorized;

            var response = await _client.DeleteAsync("/api/v1/Authorization/token");

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_DeleteAuthToken_NotFound()
        {
            var expected = HttpStatusCode.NotFound;

            var response = await _client.DeleteAsync("/api/v1/Authorization/ton");

            Assert.AreEqual(expected, response.StatusCode);
        }
    }
}