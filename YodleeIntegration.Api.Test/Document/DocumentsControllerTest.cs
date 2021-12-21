using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using YodleeIntegration.Api.Controllers.Documents;
using YodleeIntegration.Api.Models.Document;
using YodleeIntegration.Application.Documents.DeleteDocument;
using YodleeIntegration.Application.Documents.DownloadADocument;
using YodleeIntegration.Application.Documents.GetDocuments;

namespace YodleeIntegration.Api.Test.Document
{
    public class DocumentsControllerTest:BaseApiTest
    {
        [Test]
        public async Task TestGetDocumentSucceeds()
        {
            GetImeadiatrMockForGetDocument(HttpStatusCode.OK, HttpMethod.Get);

            var documentController = new DocumentsController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await documentController.GetDocuments(
                GetDocumentParam());

            var okResult = result as ObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task TestGetDocumentInvalidAccountId()
        {
            GetImeadiatrMockForGetDocument(HttpStatusCode.BadRequest, HttpMethod.Get);

            var documentController = new DocumentsController(_mockMediatr.Object, _baseControllerMock.Object);
            documentController.ModelState.AddModelError(string.Empty, "Invalid Account Id");

            IActionResult result = await documentController.GetDocuments(
                GetDocumentParam());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task TestGetDocumentInvalidFromDate()
        {
            GetImeadiatrMockForGetDocument(HttpStatusCode.BadRequest, HttpMethod.Get);

            var documentController = new DocumentsController(_mockMediatr.Object, _baseControllerMock.Object);
            documentController.ModelState.AddModelError(string.Empty, "Invalid Value for From Date");

            IActionResult result = await documentController.GetDocuments(
                GetDocumentParam());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task TestGetDocumentInvalidToDate()
        {
            GetImeadiatrMockForGetDocument(HttpStatusCode.BadRequest, HttpMethod.Get);

            var documentController = new DocumentsController(_mockMediatr.Object, _baseControllerMock.Object);
            documentController.ModelState.AddModelError(string.Empty, "Invalid Value for To Date");

            IActionResult result = await documentController.GetDocuments(
                GetDocumentParam());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task TestGetDocumentInvalidValueForDocType()
        {
            GetImeadiatrMockForGetDocument(HttpStatusCode.BadRequest, HttpMethod.Get);

            var documentController = new DocumentsController(_mockMediatr.Object, _baseControllerMock.Object);
            documentController.ModelState.AddModelError(string.Empty, "Invalid Value for DocType");

            IActionResult result = await documentController.GetDocuments(
                GetDocumentParam());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task TestGetDocumentUnauthorize()
        {
            var expected = HttpStatusCode.Unauthorized;

            var response = await _client.GetAsync("/api/v1/Documents/GetDocuments");

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task TestGetDocumentNotFound()
        {
            var expected = HttpStatusCode.NotFound;

            var response = await _client.GetAsync("/api/v1/Documents/GetDocum");

            Assert.AreEqual(expected, response.StatusCode);
        }

        private void GetImeadiatrMockForGetDocument(HttpStatusCode request, HttpMethod response)
        {
            _mockMediatr.Setup(m => m.Send(It.IsAny<GetDocumentsQuery>(),
                  It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(request, response));
        }

        private static GetDocumentsParam GetDocumentParam()
        {
            return new GetDocumentsParam
            {
                AccountId = "5",
                DocType = "test",
                FromDate = "1/1/2001",
                Keyword = "test",
                ToDate = "1/1/2020"
            };
        }

        [Test]
        public async Task TestDeleteDocumentSucceeds()
        {
            GetImeadiatrMockForDeleteDocument(HttpStatusCode.NoContent, HttpMethod.Delete);

            var documentController = new DocumentsController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await documentController.DeleteDocument("2");

            var okResult = result as ObjectResult;

            Assert.AreEqual(204, okResult.StatusCode);
        }

        [Test]
        public async Task TestDeleteDocumentInvalidDocumentId()
        {
            GetImeadiatrMockForDeleteDocument(HttpStatusCode.BadRequest, HttpMethod.Delete);

            var documentController = new DocumentsController(_mockMediatr.Object, _baseControllerMock.Object);
            documentController.ModelState.AddModelError(string.Empty, "Invalid DocumentId");

            IActionResult result = await documentController.DeleteDocument("@");

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task TestDeleteDocumentUnauthorize()
        {
            var expected = HttpStatusCode.Unauthorized;

            var response = await _client.DeleteAsync("/api/v1/Documents/DeleteDocuments/123");

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task TestDeleteDocumentNotFound()
        {
            var expected = HttpStatusCode.NotFound;

            var response = await _client.DeleteAsync("/api/v1/Documents/DeleteDocum");

            Assert.AreEqual(expected, response.StatusCode);
        }

        private void GetImeadiatrMockForDeleteDocument(HttpStatusCode request, HttpMethod response)
        {
            _mockMediatr.Setup(m => m.Send(It.IsAny<DeleteDocumentQuery>(),
                  It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(request, response));
        }

        [Test]
        public async Task TestDownloadDocumentsSucceeds()
        {
            GetImeadiatrMockForDownloadDocument(HttpStatusCode.OK, HttpMethod.Get);

            var documentController = new DocumentsController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await documentController.DownloadDocument("123");

            var okResult = result as ObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task TestDownloadDocumentsInvalidDocumentId()
        {
            GetImeadiatrMockForDownloadDocument(HttpStatusCode.BadRequest, HttpMethod.Get);

            var documentController = new DocumentsController(_mockMediatr.Object, _baseControllerMock.Object);
            documentController.ModelState.AddModelError(string.Empty, "Invalid document Id");

            IActionResult result = await documentController.DownloadDocument("@");

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task TestDownloadDocumentsUnauthorize()
        {
            var expected = HttpStatusCode.Unauthorized;

            var response = await _client.GetAsync("/api/v1/Documents/DownloadDocuments/123");

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task TestDownloadDocumentsNotFound()
        {
            var expected = HttpStatusCode.NotFound;

            var response = await _client.DeleteAsync("/api/v1/Documents/DownloadDocume");

            Assert.AreEqual(expected, response.StatusCode);
        }

        private void GetImeadiatrMockForDownloadDocument(HttpStatusCode request, HttpMethod response)
        {
            _mockMediatr.Setup(m => m.Send(It.IsAny<DownloadADocumentQuery>(),
                  It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(request, response));
        }
    }
}