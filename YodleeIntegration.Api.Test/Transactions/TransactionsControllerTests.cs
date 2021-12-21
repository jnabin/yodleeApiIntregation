using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using YodleeIntegration.Api.Controllers.Transactions;
using YodleeIntegration.Api.Models;
using YodleeIntegration.Application.Request;
using YodleeIntegration.Application.Transactions.CreateOrRunTransactionCategorizationRule;
using YodleeIntegration.Application.Transactions.CreateTransactionCategory;
using YodleeIntegration.Application.Transactions.DeleteTransactionCategorization;
using YodleeIntegration.Application.Transactions.GetTransactionCategoryList;
using YodleeIntegration.Application.Transactions.GetTransactions;
using YodleeIntegration.Application.Transactions.GetTransactionsWithoutQueryParams;
using YodleeIntegration.Application.Transactions.UpdateTransactionCategorizationRule;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Api.Test.Transactions
{
    public class TransactionsControllerTests : BaseApiTest
    {
       
        [Test]
        public async Task Test_GetTransactions_Succeeds()
        {
            GetImeadiatrMockForGetTransactions(HttpStatusCode.OK, HttpMethod.Get);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await transactionController.GetTransactions(GetTransactionsParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetTransactions_InvalidBaseType()
        {
            GetImeadiatrMockForGetTransactions(HttpStatusCode.BadRequest, HttpMethod.Get);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);
            transactionController.ModelState.AddModelError(string.Empty, "Invalid value for basetype");

            IActionResult result = await transactionController.GetTransactions(GetTransactionsParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetTransactions_InvalidFromDate()
        {
            GetImeadiatrMockForGetTransactions(HttpStatusCode.BadRequest, HttpMethod.Get);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);
            transactionController.ModelState.AddModelError(string.Empty, "Invalid value for fromdate");

            IActionResult result = await transactionController.GetTransactions(GetTransactionsParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetTransactions_InvalidCategory()
        {
            GetImeadiatrMockForGetTransactions(HttpStatusCode.BadRequest, HttpMethod.Get);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);
            transactionController.ModelState.AddModelError(string.Empty, "Invalid value for Category");

            IActionResult result = await transactionController.GetTransactions(GetTransactionsParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetTransactions_InvalidContainer()
        {
            GetImeadiatrMockForGetTransactions(HttpStatusCode.BadRequest, HttpMethod.Get);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);
            transactionController.ModelState.AddModelError(string.Empty, "Invalid value for container");

            IActionResult result = await transactionController.GetTransactions(GetTransactionsParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetTransactions_InvalidToDate()
        {
            GetImeadiatrMockForGetTransactions(HttpStatusCode.BadRequest, HttpMethod.Get);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);
            transactionController.ModelState.AddModelError(string.Empty, "Invalid value for toDate");

            IActionResult result = await transactionController.GetTransactions(GetTransactionsParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetTransactions_InvalidDateRange()
        {
            GetImeadiatrMockForGetTransactions(HttpStatusCode.BadRequest, HttpMethod.Get);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);
            transactionController.ModelState.AddModelError(string.Empty, "Invalid date range");

            IActionResult result = await transactionController.GetTransactions(GetTransactionsParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetTransactions_InvalidTopValue()
        {
            GetImeadiatrMockForGetTransactions(HttpStatusCode.BadRequest, HttpMethod.Get);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);
            transactionController.ModelState.AddModelError(string.Empty, "permitted values of top between 1-500");

            IActionResult result = await transactionController.GetTransactions(GetTransactionsParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetTransactions_MultipleContainerNoTSupported()
        {
            GetImeadiatrMockForGetTransactions(HttpStatusCode.BadRequest, HttpMethod.Get);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);
            transactionController.ModelState.AddModelError(string.Empty, "Multiple conatiner not supported");

            IActionResult result = await transactionController.GetTransactions(GetTransactionsParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetTransactions_InvalidTransactionType()
        {
            GetImeadiatrMockForGetTransactions(HttpStatusCode.BadRequest, HttpMethod.Get);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);
            transactionController.ModelState.AddModelError(string.Empty, "Invalid value for transaction type");

            IActionResult result = await transactionController.GetTransactions(GetTransactionsParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetTransactions_MaxAccountIdExceeds()
        {
            GetImeadiatrMockForGetTransactions(HttpStatusCode.BadRequest, HttpMethod.Get);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);
            transactionController.ModelState.AddModelError(string.Empty,
                "the maximum number of accountIds permitted is 100");

            IActionResult result = await transactionController.GetTransactions(GetTransactionsParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetTransactions_MaxCategoryIdExceeds()
        {
            GetImeadiatrMockForGetTransactions(HttpStatusCode.BadRequest, HttpMethod.Get);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);
            transactionController.ModelState.AddModelError(string.Empty,
                "the maximum number of categoryIds permitted is 100");

            IActionResult result = await transactionController.GetTransactions(GetTransactionsParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetTransactions_MaxHighLevelCategoryIdExceeds()
        {
            GetImeadiatrMockForGetTransactions(HttpStatusCode.BadRequest, HttpMethod.Get);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);
            transactionController.ModelState.AddModelError(string.Empty,
                "the maximum number of high level categoryIds permitted is 100");

            IActionResult result = await transactionController.GetTransactions(GetTransactionsParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetTransactions_DetailCategoryIdError()
        {
            GetImeadiatrMockForGetTransactions(HttpStatusCode.BadRequest, HttpMethod.Get);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);
            transactionController.ModelState.AddModelError(string.Empty,
                "detailsCategoryId cannot be provided as input, as the feature is nor enable");

            IActionResult result = await transactionController.GetTransactions(GetTransactionsParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetTransactions_MaxDetailCategoryIdExceeds()
        {
            GetImeadiatrMockForGetTransactions(HttpStatusCode.BadRequest, HttpMethod.Get);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);
            transactionController.ModelState.AddModelError(string.Empty,
                "the maximum number of detailCategoryIds permitted is 100");

            IActionResult result = await transactionController.GetTransactions(GetTransactionsParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetTransactions_InvalidDetailCategoryId()
        {
            GetImeadiatrMockForGetTransactions(HttpStatusCode.BadRequest, HttpMethod.Get);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);
            transactionController.ModelState.AddModelError(string.Empty, "Invalid value for detailCategoryIds");

            IActionResult result = await transactionController.GetTransactions(GetTransactionsParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }


        private static GetTransactionsQueryParams GetTransactionsParams()
        {
            return new GetTransactionsQueryParams { 
                AccountId = "1,2,3",
                BaseType = "DEBIT",
                CategoryId  = "1,2,3",
                Container  = "bank",
                DetailCategoryId = "1,2,3",
                FromDate = "2021-12-06",
                HighLevelCategoryId = "1,2,3",
                Keyword = "sting",
                Skip  = 12,
                ToDate  = "2021-12-08",
                Top = 13,
                Type = "bank"
            };
        }

        private void GetImeadiatrMockForGetTransactions(HttpStatusCode request,
            HttpMethod response)
        {
            _mockMediatr.Setup(m => m.Send(It.IsAny<GetTransactionsQuery>(),
                 It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(request, response));
        }

        [Test]
        public async Task Test_GetTransactions_Unauthorize()
        {
            var expected = HttpStatusCode.Unauthorized;

            var response = await _client.GetAsync("/api/v1/Transactions/GetTransactions");

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_GetTransactions_NotFound()
        {
            var expected = HttpStatusCode.NotFound;

            var response = await _client.GetAsync("/api/v1/Transactions/GetTransact");

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_GetTransactionsCount_Succeeds()
        {
            GetImeadiatrMockForGetTransactionsCount(HttpStatusCode.OK, HttpMethod.Get);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await transactionController.GetTransactionsCount(
                GetTransactionsCountsQueryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetTransactionsCount_InvalidDetailCategoryId()
        {
            GetImeadiatrMockForGetTransactionsCount(HttpStatusCode.BadRequest, HttpMethod.Get);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);
            transactionController.ModelState.AddModelError(string.Empty, "Invalid value for detailCategoryId");

            IActionResult result = await transactionController.GetTransactionsCount(
                GetTransactionsCountsQueryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetTransactionsCount_DetailCategoryIdError()
        {
            GetImeadiatrMockForGetTransactionsCount(HttpStatusCode.BadRequest, HttpMethod.Get);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);
            transactionController.ModelState.AddModelError(string.Empty,
                "detailsCategoryId cannot be provided as input, as the detailsCategory feature is not enable");

            IActionResult result = await transactionController.GetTransactionsCount(
                GetTransactionsCountsQueryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetTransactionsCount_DetailCategoryIdNotApplicable()
        {
            GetImeadiatrMockForGetTransactionsCount(HttpStatusCode.BadRequest, HttpMethod.Get);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);
            transactionController.ModelState.AddModelError(string.Empty,
                "detailsCategoryId isnot applicable for containers other than bank card");

            IActionResult result = await transactionController.GetTransactionsCount(
                GetTransactionsCountsQueryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetTransactionsCount_DetailCategoryIdMaxExceeds()
        {
            GetImeadiatrMockForGetTransactionsCount(HttpStatusCode.BadRequest, HttpMethod.Get);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);
            transactionController.ModelState.AddModelError(string.Empty,
                "The maximum number of detailCategoryIss permitted is 100");

            IActionResult result = await transactionController.GetTransactionsCount(
                GetTransactionsCountsQueryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        private void GetImeadiatrMockForGetTransactionsCount(HttpStatusCode request,
           HttpMethod response)
        {
            _mockMediatr.Setup(m => m.Send(It.IsAny<GetTransactionsCountQuery>(),
                 It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(request, response));
        }

        private static GetTransactionsCountsQueryParams GetTransactionsCountsQueryParams()
        {
            return new GetTransactionsCountsQueryParams
            {
                AccountId = "1,23,3",
                BaseType = "DEBIT",
                CategoryId = "1,2,3,4",
                CategoryType = "string",
                Container = "bank",
                DetailCategoryId = "1,2,3,5",
                FromDate = "2021-11-23",
                HighLevelCategoryId = "1,2,4,6",
                Keyword = "eddc",
                ToDate = "2021-11-25",
                Type = "stirng"
            };
        }

        [Test]
        public async Task Test_GetTransactionsCount_Unauthorize()
        {
            var expected = HttpStatusCode.Unauthorized;

            var response = await _client.GetAsync("/api/v1/Transactions/GetTransactionsCount");

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_GetTransactionsCount_NotFound()
        {
            var expected = HttpStatusCode.NotFound;

            var response = await _client.GetAsync("/api/v1/Transactions/GetTrans");

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_GetTransactionCategorizationRules_Succeeds()
        {
            GetImeadiatrMockForGetTransactionsWithoutParamsQuery(HttpStatusCode.OK, HttpMethod.Get);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await transactionController.GetTransactionCategorizationRules();

            var okResult = result as ObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task Test_GetTransactionCategorizationRules_Unauthorize()
        {
            var expected = HttpStatusCode.Unauthorized;

            var response = await _client.GetAsync("/api/v1/Transactions/GetTransactionCategorizationRules");

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_GetTransactionCategorizationRules_NotFound()
        {
            var expected = HttpStatusCode.NotFound;

            var response = await _client.GetAsync("/api/v1/Transactions/GetTransactionCate");

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_GetTransactionCategoryList_Succeeds()
        {
            GetImeadiatrMockForGetTransactionCategoryList(HttpStatusCode.OK, HttpMethod.Get);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await transactionController.GetTransactionCategoryList();

            var okResult = result as ObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);
        }

        private void GetImeadiatrMockForGetTransactionCategoryList(HttpStatusCode request,
           HttpMethod response)
        {
            _mockMediatr.Setup(m => m.Send(It.IsAny<GetTransactionsCategoryListQuery>(),
                 It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(request, response));
        }

        private void GetImeadiatrMockForGetTransactionsWithoutParamsQuery(HttpStatusCode request,
           HttpMethod response)
        {
            _mockMediatr.Setup(m => m.Send(It.IsAny<GetTransactionsWithoutParamsQuery>(),
                 It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(request, response));
        }
        

        [Test]
        public async Task Test_GetTransactionCategoryList_Unauthorize()
        {
            var expected = HttpStatusCode.Unauthorized;

            var response = await _client.GetAsync("/api/v1/Transactions/GetTransactionCategoryList");

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_GetTransactionCategoryList_NotFound()
        {
            var expected = HttpStatusCode.NotFound;

            var response = await _client.GetAsync("/api/v1/Transactions/GetTransactionCa");

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_UpdateTransactionCategorizationRule_Succeeds()
        {
            GetImeadiatrMockForUpdateTransactionCategorizationRule(HttpStatusCode.NoContent, HttpMethod.Put);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await transactionController.UpdateTransactionCategorizationRule(
                CreateUpdateTransactionCategorizationRuleRequestBody(), "123");

            var okResult = result as ObjectResult;

            Assert.AreEqual(204, okResult.StatusCode);
        }

        [Test]
        public async Task Test_UpdateTransactionCategorizationRule_InvalidRuleId()
        {
            GetImeadiatrMockForUpdateTransactionCategorizationRule(HttpStatusCode.BadRequest, HttpMethod.Put);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);
            transactionController.ModelState.AddModelError(string.Empty, "Invalid value for ruleId");

            IActionResult result = await transactionController.UpdateTransactionCategorizationRule(
                CreateUpdateTransactionCategorizationRuleRequestBody(), "123");

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_UpdateTransactionCategorizationRule_InvalidInput()
        {
            GetImeadiatrMockForUpdateTransactionCategorizationRule(HttpStatusCode.BadRequest, HttpMethod.Put);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);
            transactionController.ModelState.AddModelError(string.Empty, "Invalid Input");

            IActionResult result = await transactionController.UpdateTransactionCategorizationRule(
                CreateUpdateTransactionCategorizationRuleRequestBody(), "123");

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        private void GetImeadiatrMockForUpdateTransactionCategorizationRule(HttpStatusCode request,
            HttpMethod response)
        {
            _mockMediatr.Setup(m => m.Send(It.IsAny<UpdateTransactionCommand>(),
                 It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(request, response));
        }

        [Test]
        public async Task Test_UpdateTransactionCategorizationRuleRequest_Unauthorize()
        {
            var expected = HttpStatusCode.Unauthorized;

            var response = await _client.PutAsJsonAsync(
                "/api/v1/Transactions/UpdateTransactionCategorizationRule/10000802",
                CreateUpdateTransactionCategorizationRuleRequestBody());

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_UpdateTransactionCategorizationRuleRequest_NotFound()
        {
            var expected = HttpStatusCode.NotFound;

            var response = await _client.PutAsJsonAsync(
                "/api/v1/Transactions/UpdateTransactionCe/10000802",
                CreateUpdateTransactionCategorizationRuleRequestBody());

            Assert.AreEqual(expected, response.StatusCode);
        }

        private static UpdateTransactionCategorizationRuleRequestBody CreateUpdateTransactionCategorizationRuleRequestBody()
        {
            UpdateTransactionCategorizationRuleRequestBody updateTransactionCategorizationRuleRequestBody =
                new UpdateTransactionCategorizationRuleRequestBody()
                {
                    Rule = new Rule()
                    {
                        CategoryId = 3,
                        Priority = 1,
                        Source = "SYSTEM",
                        RuleClause = new List<RuleClause>()
                        {
                            new RuleClause()
                            {
                                Field="amount",
                                Operation="numberGreaterThan",
                                Value=90
                            }
                        }
                    }
                };
            return updateTransactionCategorizationRuleRequestBody;
        }

        [Test]
        public async Task Test_UpdateCategory_Succeeds()
        {
            GetImeadiatrMockForUpdateCategory(HttpStatusCode.NoContent, HttpMethod.Put);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await transactionController.UpdateCategory(
                CreateUpdateCategoryRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(204, okResult.StatusCode);
        }

        [Test]
        public async Task Test_UpdateCategory_InvalidCategoryParam()
        {
            GetImeadiatrMockForUpdateCategory(HttpStatusCode.BadRequest, HttpMethod.Put);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);
            transactionController.ModelState.AddModelError(string.Empty, "Invalid value for categoryParam");

            IActionResult result = await transactionController.UpdateCategory(
                CreateUpdateCategoryRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_UpdateCategory_InvalidSource()
        {
            GetImeadiatrMockForUpdateCategory(HttpStatusCode.BadRequest, HttpMethod.Put);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);
            transactionController.ModelState.AddModelError(string.Empty, "Invalid value for source");

            IActionResult result = await transactionController.UpdateCategory(
                CreateUpdateCategoryRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_UpdateCategory_InvalidCategoryNameLength()
        {
            GetImeadiatrMockForUpdateCategory(HttpStatusCode.BadRequest, HttpMethod.Put);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);
            transactionController.ModelState.AddModelError(string.Empty, "Invalid Length for categoryName");

            IActionResult result = await transactionController.UpdateCategory(
                CreateUpdateCategoryRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_UpdateCategory_IdRequired()
        {
            GetImeadiatrMockForUpdateCategory(HttpStatusCode.BadRequest, HttpMethod.Put);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);
            transactionController.ModelState.AddModelError(string.Empty, "Id Required");

            IActionResult result = await transactionController.UpdateCategory(
                CreateUpdateCategoryRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_UpdateCategory_CategoryNameExists()
        {
            GetImeadiatrMockForUpdateCategory(HttpStatusCode.BadRequest, HttpMethod.Put);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);
            transactionController.ModelState.AddModelError(string.Empty, "CategoryName value already exists");

            IActionResult result = await transactionController.UpdateCategory(
                CreateUpdateCategoryRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        private void GetImeadiatrMockForUpdateCategory(HttpStatusCode request,
           HttpMethod response)
        {
            _mockMediatr.Setup(m => m.Send(It.IsAny<UpdateTransactionCommand>(),
                 It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(request, response));
        }

        [Test]
        public async Task Test_UpdateCategory_Unauthorize()
        {
            UpdateCategoryRequestBody updateCategoryRequestBody =
                CreateUpdateCategoryRequestBody();
            
            var expected = HttpStatusCode.Unauthorized;

            var response = await _client.PutAsJsonAsync("/api/v1/Transactions/UpdateCategory", updateCategoryRequestBody);

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_UpdateCategory_NotFound()
        {
            UpdateCategoryRequestBody updateCategoryRequestBody =
                CreateUpdateCategoryRequestBody();

            var expected = HttpStatusCode.NotFound;

            var response = await _client.PutAsJsonAsync("/api/v1/Transactions/Upda", updateCategoryRequestBody);

            Assert.AreEqual(expected, response.StatusCode);
        }

        private static UpdateCategoryRequestBody CreateUpdateCategoryRequestBody()
        {
            UpdateCategoryRequestBody updateCategoryRequestBody =
                new UpdateCategoryRequestBody()
                {
                    Id = 3,
                    Source = "SYSTEM",
                    CategoryName = "TruckExpenses8"
                };

            return updateCategoryRequestBody;
        }

        [Test]
        public async Task Test_UpdateTransaction_Succeeds()
        {
            GetImeadiatrMockForUpdateTransaction(HttpStatusCode.NoContent, HttpMethod.Put);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await transactionController.UpdateTransaction(
                CreateUpdateTransactionRequestBody(), "123");

            var okResult = result as ObjectResult;

            Assert.AreEqual(204, okResult.StatusCode);

        }

        [Test]
        public async Task Test_UpdateTransaction_ContainerMissing()
        {
            GetImeadiatrMockForUpdateTransaction(HttpStatusCode.BadRequest, HttpMethod.Put);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);
            transactionController.ModelState.AddModelError(string.Empty, "container is missing");

            IActionResult result = await transactionController.UpdateTransaction(
                CreateUpdateTransactionRequestBody(), "123");

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);

        }

        [Test]
        public async Task Test_UpdateTransaction_InvalidTransactionId()
        {
            GetImeadiatrMockForUpdateTransaction(HttpStatusCode.BadRequest, HttpMethod.Put);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);
            transactionController.ModelState.AddModelError(string.Empty, "Invalid value for transaction Id");

            IActionResult result = await transactionController.UpdateTransaction(
                CreateUpdateTransactionRequestBody(), "123");

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);

        }

        [Test]
        public async Task Test_UpdateTransaction_InvalidMerchantType()
        {
            GetImeadiatrMockForUpdateTransaction(HttpStatusCode.BadRequest, HttpMethod.Put);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);
            transactionController.ModelState.AddModelError(string.Empty, "Invalid value for merchant type");

            IActionResult result = await transactionController.UpdateTransaction(
                CreateUpdateTransactionRequestBody(), "123");

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);

        }

        [Test]
        public async Task Test_UpdateTransaction_InvalidDetailsCategoryId()
        {
            GetImeadiatrMockForUpdateTransaction(HttpStatusCode.BadRequest, HttpMethod.Put);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);
            transactionController.ModelState.AddModelError(string.Empty, "Invalid value for detailsCategoryId");

            IActionResult result = await transactionController.UpdateTransaction(
                CreateUpdateTransactionRequestBody(), "123");

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);

        }

        [Test]
        public async Task Test_UpdateTransaction_NoActionAllowed()
        {
            GetImeadiatrMockForUpdateTransaction(HttpStatusCode.BadRequest, HttpMethod.Put);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);
            transactionController.ModelState.AddModelError(string.Empty,
                "No action is allowed, as the data is being migrated to the Open Banking provider");

            IActionResult result = await transactionController.UpdateTransaction(
                CreateUpdateTransactionRequestBody(), "123");

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);

        }

        private void GetImeadiatrMockForUpdateTransaction(HttpStatusCode request,
          HttpMethod response)
        {
            _mockMediatr.Setup(m => m.Send(It.IsAny<UpdateTransactionCommand>(),
                 It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(request, response));
        }

        [Test]
        public async Task Test_UpdateTransaction_Unauthorize()
        {           
            var expected = HttpStatusCode.Unauthorized;

            var response = await _client.PutAsJsonAsync("/api/v1/Transactions/UpdateTransaction/12",
                CreateUpdateTransactionRequestBody());

            Assert.AreEqual(expected, response.StatusCode);

        }

        [Test]
        public async Task Test_UpdateTransaction_NotFound()
        {
            var expected = HttpStatusCode.NotFound;

            var response = await _client.PutAsJsonAsync("/api/v1/Transactions/UpdateTra/12",
                CreateUpdateTransactionRequestBody());

            Assert.AreEqual(expected, response.StatusCode);

        }

        private static UpdateTransactionRequestBody CreateUpdateTransactionRequestBody()
        {
            UpdateTransactionRequestBody updateTransactionRequestBody =
                new UpdateTransactionRequestBody()
                {
                    Transaction = new Domain.Entities.UpdateTransaction.Transaction()
                    {
                        Container = "bank",
                        CategoryId = 3,
                        CategorySource = "SYSTEM",
                        Description = new Description()
                        {
                            Consumer = "Electronic Purchases"
                        },
                        Memo = "ascd"
                    }
                };
            return updateTransactionRequestBody;
        }

        [Test]
        public async Task Test_CreateCategory_Succeeds()
        {
            GetImeadiatrMockForCreateCategory(HttpStatusCode.NoContent, HttpMethod.Post);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await transactionController.CreateCategory(
                CreateObjectCreateCategoryRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(204, okResult.StatusCode);
        }

        [Test]
        public async Task Test_CreateCategory_InvalidCategoryParam()
        {
            GetImeadiatrMockForCreateCategory(HttpStatusCode.BadRequest, HttpMethod.Post);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);
            transactionController.ModelState.AddModelError(string.Empty, "Invalid value for category param");

            IActionResult result = await transactionController.CreateCategory(
                CreateObjectCreateCategoryRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_CreateCategory_InvalidSource()
        {
            GetImeadiatrMockForCreateCategory(HttpStatusCode.BadRequest, HttpMethod.Post);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);
            transactionController.ModelState.AddModelError(string.Empty, "Invalid value for source");

            IActionResult result = await transactionController.CreateCategory(
                CreateObjectCreateCategoryRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_CreateCategory_InvalidLengthCategoryName()
        {
            GetImeadiatrMockForCreateCategory(HttpStatusCode.BadRequest, HttpMethod.Post);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);
            transactionController.ModelState.AddModelError(string.Empty, "Invalid length for categoryName");

            IActionResult result = await transactionController.CreateCategory(
                CreateObjectCreateCategoryRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_CreateCategory_ParentCategoryIdRequired()
        {
            GetImeadiatrMockForCreateCategory(HttpStatusCode.BadRequest, HttpMethod.Post);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);
            transactionController.ModelState.AddModelError(string.Empty, "parenrCategoryId is required");

            IActionResult result = await transactionController.CreateCategory(
                CreateObjectCreateCategoryRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_CreateCategory_CategoryNameValueExists()
        {
            GetImeadiatrMockForCreateCategory(HttpStatusCode.BadRequest, HttpMethod.Post);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);
            transactionController.ModelState.AddModelError(string.Empty, "CategoryName Value is already exists");

            IActionResult result = await transactionController.CreateCategory(
                CreateObjectCreateCategoryRequestBody());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        private void GetImeadiatrMockForCreateCategory(HttpStatusCode request,
          HttpMethod response)
        {
            _mockMediatr.Setup(m => m.Send(It.IsAny<CreateTransactionCategoryCommand>(),
                 It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(request, response));
        }

        [Test]
        public async Task Test_CreateCategory_Unauthorize()
        {
            var expected = HttpStatusCode.Unauthorized;

            var response = await _client.PostAsJsonAsync("/api/v1/Transactions/CreateCategory", CreateObjectCreateCategoryRequestBody());

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_CreateCategory_NotFound()
        {
            var expected = HttpStatusCode.NotFound;

            var response = await _client.PostAsJsonAsync("/api/v1/Transactions/Creat", CreateObjectCreateCategoryRequestBody());

            Assert.AreEqual(expected, response.StatusCode);
        }

        private static CreateCategoryRequestBody CreateObjectCreateCategoryRequestBody()
        {
            CreateCategoryRequestBody createCategoryRequestBody =
                new CreateCategoryRequestBody()
                {
                    ParentCategoryId = 3,
                    CategoryName = "Expenses12378"
                };
            return createCategoryRequestBody;
        }

        [Test]
        public async Task Test_CreateOrRunTransactionCategorizationRule_Succeeds()
        {
            GetImeadiatrMockForCreateOrRunTransactionCategorizationRule(HttpStatusCode.Created, HttpMethod.Post);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await transactionController.CreateOrRunTransactionCategorizationRule(
                GetTransactionCategorizationRuleQueryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(201, okResult.StatusCode);
        }

        [Test]
        public async Task Test_CreateOrRunTransactionCategorizationRule_SucceedsNoContent()
        {
            GetImeadiatrMockForCreateOrRunTransactionCategorizationRule(HttpStatusCode.NoContent, HttpMethod.Post);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await transactionController.CreateOrRunTransactionCategorizationRule(
                GetTransactionCategorizationRuleQueryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(204, okResult.StatusCode);
        }

        [Test]
        public async Task Test_CreateOrRunTransactionCategorizationRule_InvalidInput()
        {
            GetImeadiatrMockForCreateOrRunTransactionCategorizationRule(HttpStatusCode.BadRequest, HttpMethod.Post);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);
            transactionController.ModelState.AddModelError(string.Empty, "Invalid input");

            IActionResult result = await transactionController.CreateOrRunTransactionCategorizationRule(
                GetTransactionCategorizationRuleQueryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_CreateOrRunTransactionCategorizationRule_RuleAlreadyExist()
        {
            GetImeadiatrMockForCreateOrRunTransactionCategorizationRule(HttpStatusCode.BadRequest, HttpMethod.Post);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);
            transactionController.ModelState.AddModelError(string.Empty, "Rule Already Exist");

            IActionResult result = await transactionController.CreateOrRunTransactionCategorizationRule(
                GetTransactionCategorizationRuleQueryParams());

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        private static TransactionCategorizationRuleQueryParams GetTransactionCategorizationRuleQueryParams()
        {
            return new TransactionCategorizationRuleQueryParams
            {
                Action = "string",
                RuleParam = "string"
            };
        }      

        [Test]
        public async Task Test_CreateOrRunTransactionCategorizationRule_Unauthorize()
        {         
            var expected = HttpStatusCode.Unauthorized;

            var response = await _client.PostAsync("/api/v1/Transactions/CreateOrRunTransactionCategorizationRule", null!);

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_CreateOrRunTransactionCategorizationRule_NotFound()
        {
            var expected = HttpStatusCode.NotFound;

            var response = await _client.PostAsync("/api/v1/Transactions/CreateOrRunTransactionCategor", null!);

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_RunTransactionCategorizationRule_Succeeds()
        {
            GetImeadiatrMockForCreateOrRunTransactionCategorizationRule(HttpStatusCode.NoContent, HttpMethod.Post);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await transactionController.RunTransactionCategorizationRule(
                GetRunTransactionCategorizationParams(), "123");

            var okResult = result as ObjectResult;

            Assert.AreEqual(204, okResult.StatusCode);
        }

        [Test]
        public async Task Test_RunTransactionCategorizationRule_InvalidRuleId()
        {
            GetImeadiatrMockForCreateOrRunTransactionCategorizationRule(HttpStatusCode.BadRequest, HttpMethod.Post);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);
            transactionController.ModelState.AddModelError(string.Empty, "Invalid value for ruleId");

            IActionResult result = await transactionController.RunTransactionCategorizationRule(
                GetRunTransactionCategorizationParams(), "123");

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public async Task Test_RunTransactionCategorizationRule_CategorizationAlreadyProgress()
        {
            GetImeadiatrMockForCreateOrRunTransactionCategorizationRule(HttpStatusCode.BadRequest, HttpMethod.Post);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);
            transactionController.ModelState.AddModelError(string.Empty, "Categorization already in progress");

            IActionResult result = await transactionController.RunTransactionCategorizationRule(
                GetRunTransactionCategorizationParams(), "123");

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        private static RunTransactionCategorizationParams GetRunTransactionCategorizationParams()
        {
            return new RunTransactionCategorizationParams
            {
                Action = "string"
            };
        }

        private void GetImeadiatrMockForCreateOrRunTransactionCategorizationRule(HttpStatusCode request,
         HttpMethod response)
        {
            _mockMediatr.Setup(m => m.Send(It.IsAny<CreateOrRunTransactionCategorizationRuleCommand>(),
                 It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(request, response));
        }

        [Test]
        public async Task Test_RunTransactionCategorizationRule_Unauthorize()
        {
            string actionparams = "run";           
            var expected = HttpStatusCode.Unauthorized;

            var response = await _client.PostAsync($"/api/v1/Transactions/RunTransactionCategorizationRule/1?action={actionparams}", null!);

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_RunTransactionCategorizationRule_NotFound()
        {
            string actionparams = "run";
            var expected = HttpStatusCode.NotFound;

            var response = await _client.PostAsync($"/api/v1/Transactions/RunTransactionCatele/1?action={actionparams}", null!);

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_DeleteCategory_Succeeds()
        {
            GetImeadiatrMockForDeleteCategory(HttpStatusCode.NoContent, HttpMethod.Delete);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await transactionController.DeleteCategory("123");

            var okResult = result as ObjectResult;

            Assert.AreEqual(204, okResult.StatusCode);
        }

        [Test]
        public async Task Test_DeleteCategory_InvalidCategoryId()
        {
            GetImeadiatrMockForDeleteCategory(HttpStatusCode.BadRequest, HttpMethod.Delete);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);
            transactionController.ModelState.AddModelError(string.Empty, "Invalid Category Id");

            IActionResult result = await transactionController.DeleteCategory("123#");

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }


        [Test]
        public async Task Test_DeleteCategory_Unauthorize()
        {
            var expected = HttpStatusCode.Unauthorized;

            var response = await _client.DeleteAsync("/api/v1/Transactions/DeleteCategory/10045968");

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_DeleteCategory_Notfound()
        {
            var expected = HttpStatusCode.NotFound;

            var response = await _client.DeleteAsync("/api/v1/Transactions/Deegory/10045968");

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_DeleteTransactionCategorizationRule_Succeeds()
        {
            GetImeadiatrMockForDeleteCategory(HttpStatusCode.NoContent, HttpMethod.Delete);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);

            IActionResult result = await transactionController.DeleteTransactionCategorizationRule("123");

            var okResult = result as ObjectResult;

            Assert.AreEqual(204, okResult.StatusCode);
        }

        [Test]
        public async Task Test_DeleteTransactionCategorizationRule_InvalidRuleID()
        {
            GetImeadiatrMockForDeleteCategory(HttpStatusCode.BadRequest, HttpMethod.Delete);

            var transactionController = new TransactionsController(_mockMediatr.Object, _baseControllerMock.Object);
            transactionController.ModelState.AddModelError(string.Empty, "Invalid Rule ID");

            IActionResult result = await transactionController.DeleteTransactionCategorizationRule("123&");

            var okResult = result as ObjectResult;

            Assert.AreEqual(400, okResult.StatusCode);
        }

        private void GetImeadiatrMockForDeleteCategory(HttpStatusCode request,
         HttpMethod response)
        {
            _mockMediatr.Setup(m => m.Send(It.IsAny<DeleteTransactionCategorizationCommand>(),
                 It.IsAny<CancellationToken>())).Returns(MediatrMockReturns(request, response));
        }

        [Test]
        public async Task Test_DeleteTransactionCategorizationRule_Unauthorize()
        {
            var expected = HttpStatusCode.Unauthorized;

            var response = await _client.DeleteAsync("/api/v1/Transactions/DeleteTransactionCategorizationRule/10045968");

            Assert.AreEqual(expected, response.StatusCode);
        }

        [Test]
        public async Task Test_DeleteTransactionCategorizationRule_Notfound()
        {
            var expected = HttpStatusCode.NotFound;

            var response = await _client.DeleteAsync("/api/v1/Transactions/DeleteTransactionCatego/10045968");

            Assert.AreEqual(expected, response.StatusCode);
        }

    }
}
