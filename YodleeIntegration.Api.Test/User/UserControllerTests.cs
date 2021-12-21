using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using YodleeIntegration.Api.Controllers.User;
using YodleeIntegration.Api.Models.User;
using YodleeIntegration.Application.Request;
using YodleeIntegration.Application.User.DeleteUser;
using YodleeIntegration.Application.User.GetAccessTokens;
using YodleeIntegration.Application.User.GetUserDetails;
using YodleeIntegration.Application.User.RegisterUser;
using YodleeIntegration.Application.User.SamlLogin;
using YodleeIntegration.Application.User.UpdateUserDetails;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Api.Test.User
{
    public class UserControllerTests: BaseApiTest
    {

        [Test]
        public async Task Test_SamlLogin_Succeeds()
        {
            GetImeadiatrMockForSamlLogin(HttpStatusCode.OK, HttpMethod.Post);

            var userController = new UserController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await userController.SamlLogin(GetSamlLoginParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task Test_SamlLogin_InvalidSamlResponse()
        {
            GetImeadiatrMockForSamlLogin(HttpStatusCode.BadRequest, HttpMethod.Post);

            var userController = new UserController(_mockMediatr.Object, _baseControllerMock.Object);
            userController.ModelState.AddModelError(string.Empty, "invalid value for samlResponse");

            IActionResult result = await userController.SamlLogin(GetSamlLoginParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_SamlLogin_InvalidIssueer()
        {
            GetImeadiatrMockForSamlLogin(HttpStatusCode.BadRequest, HttpMethod.Post);

            var userController = new UserController(_mockMediatr.Object, _baseControllerMock.Object);
            userController.ModelState.AddModelError(string.Empty, "invalid value for issuer");

            IActionResult result = await userController.SamlLogin(GetSamlLoginParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        private void GetImeadiatrMockForSamlLogin(HttpStatusCode request,
           HttpMethod response)
        {
            _mockMediatr.Setup(m => m.Send(It.IsAny<SamlLoginQuery>(),
                 It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(request, response));
        }

        [Test]
        public async Task Test_SamlLogin_UnAuthorize()
        {
            var expected = HttpStatusCode.Unauthorized;

            var response = await _client.PostAsync("/api/v1/User/SamlLogin", null);

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_SamlLogin_NotFound()
        {
            var expected = HttpStatusCode.NotFound;

            var response = await _client.PostAsync("/api/v1/User/Saml", null);

            Assert.AreEqual(expected, response.StatusCode);
        }

        private SamlLoginParams GetSamlLoginParams()
        {
            return new SamlLoginParams
            {
                Issuer  ="string",
                SamlResponse = "string",
                Source = "string"
            };
        }

        [Test]
        public async Task Test_GetAccessToken_Succeeds()
        {
            GetImeadiatrMockForGetAccessToken(HttpStatusCode.OK, HttpMethod.Get);

            var userController = new UserController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await userController.GetAccessTokens(GetAccessTokensParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetAccessToken_Unauthorize()
        {
            var expected = HttpStatusCode.Unauthorized;

            var response = await _client.GetAsync("/api/v1/User/GetAccessTokens");

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_GetAccessToken_NotFound()
        {
            var expected = HttpStatusCode.NotFound;

            var response = await _client.GetAsync("/api/v1/User/GetAcce");

            Assert.AreEqual(expected, response.StatusCode);
        }

        private void GetImeadiatrMockForGetAccessToken(HttpStatusCode request,
           HttpMethod response)
        {
            _mockMediatr.Setup(m => m.Send(It.IsAny<GetAccessTokensQuery>(),
                 It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(request, response));
        }

        private AccessTokensParams GetAccessTokensParams()
        {
            return new AccessTokensParams
            {
                AppIds = "string"
            };
        }

        [Test]
        public async Task Test_GetUserDetails_Succeeds()
        {

            GetImeadiatrMockForGetUserDetails(HttpStatusCode.OK, HttpMethod.Get);

            var userController = new UserController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await userController.GetUserDetails();

            var okResult = result as ObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);

        }

        private void GetImeadiatrMockForGetUserDetails(HttpStatusCode request,
           HttpMethod response)
        {
            _mockMediatr.Setup(m => m.Send(It.IsAny<GetUserDetailsQuery>(),
                 It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(request, response));
        }

        [Test]
        public async Task Test_GetUserDetails_Unauthorize()
        {

            var expected = HttpStatusCode.Unauthorized;

            var response = await _client.GetAsync("/api/v1/User/GetUserDetails");

            Assert.AreEqual(expected, response.StatusCode);

        }

        [Test]
        public async Task Test_GetUserDetails_NotFound()
        {

            var expected = HttpStatusCode.NotFound;

            var response = await _client.GetAsync("/api/v1/User/GetUse");

            Assert.AreEqual(expected, response.StatusCode);

        }

        [Test]
        public async Task Test_UpdateUserDetails_Succeeds()
        {
            GetImeadiatrMockForUpdateUserDetails(HttpStatusCode.NoContent, HttpMethod.Put);

            var userController = new UserController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await userController.UpdateUserDetails(GetUpdateUserDetailsRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(204, okResult.StatusCode);
        }

        private void GetImeadiatrMockForUpdateUserDetails(HttpStatusCode request,
            HttpMethod response)
        {
            _mockMediatr.Setup(m => m.Send(It.IsAny<UpdateUserDetailsCommand>(),
                 It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(request, response));
        }

        [Test]
        public async Task Test_UpdateUserDetails_Unauthorize()
        {
            var expected = HttpStatusCode.Unauthorized;

            var response = await _client.PutAsJsonAsync("/api/v1/User/UpdateUserDetails",
                GetUpdateUserDetailsRequestBody());

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_UpdateUserDetails_NotFound()
        {
            var expected = HttpStatusCode.NotFound;

            var response = await _client.PutAsJsonAsync("/api/v1/User/Upda",
                GetUpdateUserDetailsRequestBody());

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_RegisterUser_Succeeds()
        {
            GetImeadiatrMockForRegisterUser(HttpStatusCode.OK, HttpMethod.Post);

            var userController = new UserController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await userController.RegisterUser(GetUpdateUserDetailsRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task Test_RegisterUser_InvalidLoginName()
        {
            GetImeadiatrMockForRegisterUser(HttpStatusCode.BadRequest, HttpMethod.Post);

            var userController = new UserController(_mockMediatr.Object, _baseControllerMock.Object);
            userController.ModelState.AddModelError(string.Empty, "Invalid Value for login Name");

            IActionResult result = await userController.RegisterUser(GetUpdateUserDetailsRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_RegisterUser_InvalidValueForEmail()
        {
            GetImeadiatrMockForRegisterUser(HttpStatusCode.BadRequest, HttpMethod.Post);

            var userController = new UserController(_mockMediatr.Object, _baseControllerMock.Object);
            userController.ModelState.AddModelError(string.Empty, "Invalid Value for email");

            IActionResult result = await userController.RegisterUser(GetUpdateUserDetailsRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_RegisterUser_InvalidLengthLoginName()
        {
            GetImeadiatrMockForRegisterUser(HttpStatusCode.BadRequest, HttpMethod.Post);

            var userController = new UserController(_mockMediatr.Object, _baseControllerMock.Object);
            userController.ModelState.AddModelError(string.Empty, "Invalid length for login name");

            IActionResult result = await userController.RegisterUser(GetUpdateUserDetailsRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        private void GetImeadiatrMockForRegisterUser(HttpStatusCode request,
           HttpMethod response)
        {
            _mockMediatr.Setup(m => m.Send(It.IsAny<RegisterUserCommand>(),
                 It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(request, response));
        }

        [Test]
        public async Task Test_RegisterUser_Unauthorize()
        {
            var expected = HttpStatusCode.Unauthorized;

            var response = await _client.PostAsJsonAsync("/api/v1/User/RegisterUser",
                GetUpdateUserDetailsRequestBody());

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_RegisterUser_NotFound()
        {
            var expected = HttpStatusCode.NotFound;

            var response = await _client.PutAsJsonAsync("/api/v1/User/RegrUser",
                GetUpdateUserDetailsRequestBody());

            Assert.AreEqual(expected, response.StatusCode);
        }

        private UpdateUserDetailsRequestBody GetUpdateUserDetailsRequestBody()
        {
            return new UpdateUserDetailsRequestBody
            {
                User = new Users
                {
                    Preferences = new Preference
                    {
                        DateFormat = "yyyy-dd-mm",
                        TimeZone = "utc",
                        Currency = "USD",
                        Locale = "en_US"
                    },
                    Address = new Address
                    {
                        Zip = "string",
                        Country = "America",
                        Address3 = "string",
                        Address2 = "string",
                        Address1 = "string",
                        City = "string",
                        State = "string"
                    },
                    Name = new Name
                    {
                        Middle = "string",
                        Last = "string",
                        FullName = "string",
                        First = "string"
                    },
                    Email = "jnabin12@gmail.com",
                    SegmentName = "string"
                }
            };
        }

        [Test]
        public async Task Test_DeleteUser_Succeeds()
        {
            GetImeadiatrMockForDeleteUser(HttpStatusCode.NoContent, HttpMethod.Delete);

            var userController = new UserController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await userController.DeleteUser();

            var okResult = result as ObjectResult;

            Assert.AreEqual(204, okResult.StatusCode);
        }

        private void GetImeadiatrMockForDeleteUser(HttpStatusCode request,
           HttpMethod response)
        {
            _mockMediatr.Setup(m => m.Send(It.IsAny<DeleteUserQuery>(),
                 It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(request, response));
        }

        [Test]
        public async Task Test_DeleteUser_Unauthorize()
        {
            var expected = HttpStatusCode.Unauthorized;

            var response = await _client.DeleteAsync("/api/v1/User/DeleteUser");

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_DeleteUser_NotFound()
        {
            var expected = HttpStatusCode.NotFound;

            var response = await _client.PutAsJsonAsync("/api/v1/User/Deletr",
                GetUpdateUserDetailsRequestBody());

            Assert.AreEqual(expected, response.StatusCode);
        }
    }
}