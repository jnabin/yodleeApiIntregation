using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using YodleeIntegration.Api.BaseControllerService;
using YodleeIntegration.Api.Extensions;
using YodleeIntegration.Api.Models;
using YodleeIntegration.Api.Models.Document;
using YodleeIntegration.Application.Documents.DeleteDocument;
using YodleeIntegration.Application.Documents.DownloadADocument;
using YodleeIntegration.Application.Documents.GetDocuments;
using YodleeIntegration.Application.Request.Document;

namespace YodleeIntegration.Api.Controllers.Documents
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class DocumentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IBaseControllerService _baseControllerService;

        public DocumentsController(IMediator mediator,
            IBaseControllerService baseControllerService)
        {
            _mediator = mediator;
            _baseControllerService = baseControllerService;
        }

        [HttpGet("GetDocuments")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.RequestTimeout)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetDocuments([FromQuery] GetDocumentsParam queryParams)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrors());

            var yodleeConfigureSettings = await _baseControllerService.GetYodleeConfigureSettings();

            var response = await _mediator.Send(new GetDocumentsQuery(new GetDocumentsRequest
            {
                Endpoint = $"{yodleeConfigureSettings.yodleeConfiguration.Url}{YodleeEndpoints.GetDocuments}",
                QueryParameters = queryParams.GetQueryParamsList()
            }, yodleeConfigureSettings.yodleeConfiguration, yodleeConfigureSettings.yodleeAccessToken));
            return await response.GetActionResultAsync<DocumentDownload>();
        }

        [HttpDelete("DeleteDocuments/{documentId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.RequestTimeout)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> DeleteDocument(string documentId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrors());

            var yodleeConfigureSettings = await _baseControllerService.GetYodleeConfigureSettings();

            var response = await _mediator.Send(new DeleteDocumentQuery(new DeleteDocumentRequest
            {
                Endpoint = $"{yodleeConfigureSettings.yodleeConfiguration.Url}{YodleeEndpoints.GetDocuments}/{documentId}"
            }, yodleeConfigureSettings.yodleeConfiguration, yodleeConfigureSettings.yodleeAccessToken));

            return await response.GetActionResultAsync<string>();
        }

        [HttpGet("DownloadDocuments/{documentId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.RequestTimeout)]
        [ProducesResponseType(typeof(ErrorDetail), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> DownloadDocument(string documentId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrors());

            var yodleeConfigureSettings = await _baseControllerService.GetYodleeConfigureSettings();

            var response = await _mediator.Send(new DownloadADocumentQuery(new DownloadDocumentRequest
            {
                Endpoint = $"{yodleeConfigureSettings.yodleeConfiguration.Url}{YodleeEndpoints.GetDocuments}/{documentId}"
            }, yodleeConfigureSettings.yodleeConfiguration, yodleeConfigureSettings.yodleeAccessToken));

            return await response.GetActionResultAsync<string>();
        }

    }
}