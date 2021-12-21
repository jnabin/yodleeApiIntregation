using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using YodleeIntegration.Api.Models;
using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Application.Request;
using YodleeIntegration.Application.Request.Derived;
using YodleeIntegration.Application.Response;
using YodleeIntegration.Application.Transactions.CreateOrRunTransactionCategorizationRule;
using YodleeIntegration.Application.Transactions.CreateTransactionCategory;
using YodleeIntegration.Application.Transactions.DeleteTransactionCategorization;
using YodleeIntegration.Application.Transactions.GetTransactionCategoryList;
using YodleeIntegration.Application.Transactions.GetTransactions;
using YodleeIntegration.Application.Transactions.UpdateTransactionCategorizationRule;
using YodleeIntegration.Common.ServiceClient;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.Test.TransactionApplicationTest
{
    public class TransactionsIMediatorPositiveTest : BaseTest
    {
        private Mock<ILogger<GetTransactionsQueryHandler>> _loggerGetTransaction;
        private Mock<ILogger<GetTransactionsCountQueryHandler>> _loggerGetTransactionCount;
        private Mock<ILogger<GetTransactionsCategoryListQueryHandler>> _loggerGetTransactionCategoryList;
        private Mock<ILogger<CreateOrRunTransactionCategorizationRuleHandler>> _loggerCreateOrRunTransaction;
        private Mock<ILogger<CreateTransactionCategoryHandler>> _loggerCreateTransactionCategory;
        private Mock<ILogger<UpdateTransactionHandler>> _loggerUpdateTransaction;
        private Mock<ILogger<DeleteTransactionCategorizationHandler>> _loggerDeleteTransaction;
        private Mock<IYodleeTransactionRepository> _trasactionRepositoryMock;
        private Mock<IYodleeTransactionCategoryRepository> _trasactionCategoryRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _loggerGetTransaction = new Mock<ILogger<GetTransactionsQueryHandler>>();
            _loggerGetTransactionCount = new Mock<ILogger<GetTransactionsCountQueryHandler>>();
            _loggerGetTransactionCategoryList = new Mock<ILogger<GetTransactionsCategoryListQueryHandler>>();
            _loggerCreateOrRunTransaction = new Mock<ILogger<CreateOrRunTransactionCategorizationRuleHandler>>();
            _loggerCreateTransactionCategory = new Mock<ILogger<CreateTransactionCategoryHandler>>();
            _loggerUpdateTransaction = new Mock<ILogger<UpdateTransactionHandler>>();
            _loggerDeleteTransaction = new Mock<ILogger<DeleteTransactionCategorizationHandler>>();
            _trasactionRepositoryMock = new Mock<IYodleeTransactionRepository>();

            _trasactionRepositoryMock = new Mock<IYodleeTransactionRepository>();
            _trasactionRepositoryMock.Setup(m => m.SingleOrDefaultAsync(
                It.IsAny<Expression<Func<Transaction, bool>>>())).Returns(Task.FromResult(new Transaction()));
            _trasactionRepositoryMock.Setup(m => m.Update(It.IsAny<Transaction>())).Verifiable();
            _mockUnitOfWork.Setup(x => x.YodleeTransactionRepository).Returns(_trasactionRepositoryMock.Object);
            _mockUnitOfWork.Setup(x => x.CompleteAsync()).Verifiable();

            _trasactionCategoryRepositoryMock = new Mock<IYodleeTransactionCategoryRepository>();
            _trasactionCategoryRepositoryMock.Setup(m => m.SingleOrDefaultAsync(
                It.IsAny<Expression<Func<TransactionCategory, bool>>>())).Returns(Task.FromResult(new TransactionCategory()));
            _trasactionCategoryRepositoryMock.Setup(m => m.Update(It.IsAny<TransactionCategory>())).Verifiable();
            _mockUnitOfWork.Setup(x => x.YodleeTransactionCategoryRepository).Returns(_trasactionCategoryRepositoryMock.Object);
            _mockUnitOfWork.Setup(x => x.CompleteAsync()).Verifiable();
        }

        [Test]
        public async Task Test_GetTransactionsQueryHandler_SuccessStatusCode()
        {
            var serviceHttpClient = new Mock<IServiceHttpClient>();
            var configuration = await GetConfiguration();
            
            serviceHttpClient.Setup(x => x.GetAsync(It.IsAny<string>())).Returns(
                MediatrMockReturns(configuration.Url, HttpMethod.Get, YodleeEndpoints.GetTransactions));

            var token = await GetToken();
            var command = new GetTransactionsQuery(new TransactionsRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", YodleeEndpoints.GetTransactions)
            }, configuration, token.Token.Map());

            GetTransactionsQueryHandler queryHandler = new GetTransactionsQueryHandler(
                _mockUnitOfWork.Object, serviceHttpClient.Object, _loggerGetTransaction.Object);

            var response = await queryHandler.Handle(command, CancellationToken.None);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [Test]
        public async Task Test_GetTransactionsQueryHandler_SuccessResponse()
        {
            var serviceHttpClient = new Mock<IServiceHttpClient>();
            var configuration = await GetConfiguration();

            serviceHttpClient.Setup(x => x.GetAsync(It.IsAny<string>())).Returns(
                MediatrMockReturns(configuration.Url, HttpMethod.Get, YodleeEndpoints.GetTransactions,
                new StringContent(JsonConvert.SerializeObject(GetTransactionResponse()))));

            var token = await GetToken();
            var command = new GetTransactionsQuery(new TransactionsRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", YodleeEndpoints.GetTransactions)
            }, configuration, token.Token.Map());

            GetTransactionsQueryHandler queryHandler = new GetTransactionsQueryHandler(
                _mockUnitOfWork.Object, serviceHttpClient.Object, _loggerGetTransaction.Object);

            var response = await queryHandler.Handle(command, CancellationToken.None);

            var transactionResponse =
                    JsonConvert.DeserializeObject<TransactionResponse>(
                        await response.Content.ReadAsStringAsync());

            Assert.IsNotNull(transactionResponse.Transaction);
        }

        private static TransactionResponse GetTransactionResponse()
        {
            return new TransactionResponse
            {
                Transaction = new List<Transaction>()
            };
        }

        [Test]
        public async Task Test_GetTransactionsCountQuery_SuccessStatusCode()
        {
            var configuration = await GetConfiguration();

            _newServiceHttpClient.Setup(x => x.GetAsync(It.IsAny<string>())).
                Returns(MediatrMockReturns(configuration.Url, HttpMethod.Get, YodleeEndpoints.GetTransactionsCount));

            var token = await GetToken();
            var command = new GetTransactionsCountQuery(new TransactionsRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", YodleeEndpoints.GetTransactionsCount)
            }, configuration, token.Token.Map());

            GetTransactionsCountQueryHandler queryHandler = new GetTransactionsCountQueryHandler(
                _mockUnitOfWork.Object, _newServiceHttpClient.Object, _loggerGetTransactionCount.Object);

            var response = await queryHandler.Handle(command, CancellationToken.None);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [Test]
        public async Task Test_GetTransactionsCountQuery_SuccessResponse()
        {
            var configuration = await GetConfiguration();

            _newServiceHttpClient.Setup(x => x.GetAsync(It.IsAny<string>())).
                Returns(MediatrMockReturns(configuration.Url, HttpMethod.Get, YodleeEndpoints.GetTransactionsCount,
                new StringContent(JsonConvert.SerializeObject(GetTransactionsCountResponse()))));

            var token = await GetToken();
            var command = new GetTransactionsCountQuery(new TransactionsRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", YodleeEndpoints.GetTransactionsCount)
            }, configuration, token.Token.Map());

            GetTransactionsCountQueryHandler queryHandler = new GetTransactionsCountQueryHandler(
                _mockUnitOfWork.Object, _newServiceHttpClient.Object, _loggerGetTransactionCount.Object);

            var response = await queryHandler.Handle(command, CancellationToken.None);

            var transactionResponse =
                    JsonConvert.DeserializeObject<GetTransactionsCountResponse>(
                        await response.Content.ReadAsStringAsync());

            Assert.IsNotNull(transactionResponse.Transaction);
        }

        private static GetTransactionsCountResponse GetTransactionsCountResponse()
        {
            return new GetTransactionsCountResponse
            {
                Transaction = new Transaction()
            };
        }

        [Test]
        public async Task Test_GetTransactionsCategoryListQueryHandler_SuccessStatusCode()
        {
            var configuration = await GetConfiguration();

            _newServiceHttpClient.Setup(x => x.GetAsync(It.IsAny<string>())).Returns(
                MediatrMockReturns(configuration.Url, HttpMethod.Get,
                YodleeEndpoints.GetTransactionCategoryList));

            var token = await GetToken();
            var command = new GetTransactionsCategoryListQuery(new TransactionsRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", YodleeEndpoints.GetTransactionCategoryList)
            }, configuration, token.Token.Map());

            GetTransactionsCategoryListQueryHandler queryHandler = new GetTransactionsCategoryListQueryHandler(
                _mockUnitOfWork.Object, _newServiceHttpClient.Object,
                _loggerGetTransactionCategoryList.Object);

            var response = await queryHandler.Handle(command, CancellationToken.None);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [Test]
        public async Task Test_GetTransactionsCategoryListQueryHandler_SuccessResponse()
        {
            var configuration = await GetConfiguration();

            _newServiceHttpClient.Setup(x => x.GetAsync(It.IsAny<string>())).Returns(
                MediatrMockReturns(configuration.Url, HttpMethod.Get,
                YodleeEndpoints.GetTransactionCategoryList,
                new StringContent(JsonConvert.SerializeObject(GetTransactionCategoryListResponse()))));

            var token = await GetToken();
            var command = new GetTransactionsCategoryListQuery(new TransactionsRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", YodleeEndpoints.GetTransactionCategoryList)
            }, configuration, token.Token.Map());

            GetTransactionsCategoryListQueryHandler queryHandler = new GetTransactionsCategoryListQueryHandler(
                _mockUnitOfWork.Object, _newServiceHttpClient.Object,
                _loggerGetTransactionCategoryList.Object);

            var response = await queryHandler.Handle(command, CancellationToken.None);

            var transactionResponse =
                    JsonConvert.DeserializeObject<GetTransactionCategoryListResponse>(
                        await response.Content.ReadAsStringAsync());

            Assert.IsNotNull(transactionResponse.TransactionCategory);
        }

        private static GetTransactionCategoryListResponse GetTransactionCategoryListResponse()
        {
            return new GetTransactionCategoryListResponse
            {
                TransactionCategory = new List<TransactionCategory>()
            };
        }

        [Test]
        public async Task Test_CreateOrRunTransactionCategorizationRuleCommand_SuccessStatus()
        {
            var configuration = await GetConfiguration();

            StringBuilder sb = new StringBuilder();
            string rulesParams = @"{ ""rule"" : { ""categoryId"" : 2, ""priority"" : 1, ""source"" : ""SYSTEM"", ""ruleClause"" : [ {""field"" : ""description"", ""operation"" : ""stringContains"", ""value"" : ""gift""}, {""field"" : ""amount"", ""operation"" : ""numberGreaterThan"", ""value"" : ""100""} ] } }";
            sb.Append(rulesParams);

            var token = await GetToken();
            var command = new CreateOrRunTransactionCategorizationRuleCommand(new TransactionsRequest()
            {
                Endpoint = $"{configuration.Url}/transactions/categories/rules?ruleParam={sb}"
            }, configuration, token.Token.Map());

            _newServiceHttpClient.Setup(x => x.PostWithOutRequestBody(It.IsAny<string>())).
                Returns(MediatrMockReturns(configuration.Url, HttpMethod.Post, YodleeEndpoints.GetTransactions));

            CreateOrRunTransactionCategorizationRuleHandler queryHandler = new CreateOrRunTransactionCategorizationRuleHandler(
                _mockUnitOfWork.Object, _newServiceHttpClient.Object, _loggerCreateOrRunTransaction.Object);

            var response = await queryHandler.Handle(command, CancellationToken.None);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }
      
        [Test]
        public async Task Test_CreateTransactionCategoryCommand_Succeeds()
        {
            var configuration = await GetConfiguration();
            CreateCategoryRequestBody createCategoryRequestBody =
                CreateObjectCreateCategoryRequestBody();

            var token = await GetToken();
            var command = new CreateTransactionCategoryCommand(new TransactionsRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", $"{YodleeEndpoints.CreateCategory}")
            }, configuration, token.Token.Map(), createCategoryRequestBody);

            _newServiceHttpClient.Setup(x => x.PostJsonEncodedAsync(createCategoryRequestBody,
                It.IsAny<string>())).Returns(
                MediatrMockReturns(configuration.Url, HttpMethod.Post, YodleeEndpoints.CreateCategory));

            CreateTransactionCategoryHandler queryHandler = new CreateTransactionCategoryHandler(
                _mockUnitOfWork.Object, _newServiceHttpClient.Object, _loggerCreateTransactionCategory.Object);

            var response = await queryHandler.Handle(command, CancellationToken.None);
            Assert.IsTrue(response.IsSuccessStatusCode);
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
        public async Task Test_UpdateTransactionCommand_SuccessStatusCode()
        {
            var configuration = await GetConfiguration();

            UpdateTransactionRequestBody updateTransactionRequestBody =
                CreateUpdateTransactionRequestBody();

            var token = await GetToken();
            var command = new UpdateTransactionCommand(new TransactionsRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", $"{YodleeEndpoints.UpdateTransaction}/101256")
            }, configuration, token.Token.Map(), updateTransactionRequestBody);

            _newServiceHttpClient.Setup(x => x.PutAsync(It.IsAny<object>(), It.IsAny<string>())).
                Returns(MediatrMockReturns(configuration.Url, HttpMethod.Put, $"{YodleeEndpoints.UpdateTransaction}/101256"));

            UpdateTransactionHandler queryHandler = new UpdateTransactionHandler(
                _mockUnitOfWork.Object, _newServiceHttpClient.Object, _loggerUpdateTransaction.Object);

            var response = await queryHandler.Handle(command, CancellationToken.None);

            Assert.IsTrue(response.IsSuccessStatusCode);

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
                        Description = new Domain.Entities.Description()
                        {
                            Consumer = "Electronic Purchases"
                        },
                        Memo = "ascd"
                    }
                };
            return updateTransactionRequestBody;
        }

        [Test]
        public async Task Test_UpdateTransactionCategorizationRuleRequest_Succeeds()
        {
            var configuration = await GetConfiguration();

            UpdateTransactionCategorizationRuleRequestBody updateTransactionCategorizationRuleRequestBody
                = CreateUpdateTransactionCategorizationRuleRequestBody();

            var token = await GetToken();
            var command = new UpdateTransactionCommand(new TransactionsRequest()
            {
                Endpoint = $"{configuration.Url}/transactions/categories/rules/10000802"
            }, configuration, token.Token.Map(),
               updateTransactionCategorizationRuleRequestBody);

            _newServiceHttpClient.Setup(x => x.PutAsync(It.IsAny<object>(), 
                It.IsAny<string>())).Returns(MediatrMockReturns(configuration.Url,
                HttpMethod.Put, "/transactions/categories/rules/10000802"));

            UpdateTransactionHandler queryHandler = new UpdateTransactionHandler(
                _mockUnitOfWork.Object, _newServiceHttpClient.Object, _loggerUpdateTransaction.Object);

            var response = await queryHandler.Handle(command, CancellationToken.None);

            Assert.IsTrue(response.IsSuccessStatusCode);
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
                                Value=100
                            }
                        }
                    }
                };
            return updateTransactionCategorizationRuleRequestBody;
        }

        [Test]
        public async Task Test_UpdateTransactionCommandWithUpdateCategory_SuccessStatusCode()
        {
            var configuration = await GetConfiguration();

            UpdateCategoryRequestBody updateCategoryRequestBody =
                CreateUpdateCategoryRequestBody();

            var token = await GetToken();
            var command = new UpdateTransactionCommand(new TransactionsRequest()
            {
                Endpoint = $"{configuration.Url}/transactions/categories"
            }, configuration, token.Token.Map(), updateCategoryRequestBody);

            _newServiceHttpClient.Setup(x => x.PutAsync(It.IsAny<object>(), It.IsAny<string>())).
                Returns(MediatrMockReturns(configuration.Url, HttpMethod.Put, "/transactions/categories"));

            UpdateTransactionHandler queryHandler = new UpdateTransactionHandler(
                _mockUnitOfWork.Object, _newServiceHttpClient.Object, _loggerUpdateTransaction.Object);

            var response = await queryHandler.Handle(command, CancellationToken.None);
            
            Assert.IsTrue(response.IsSuccessStatusCode);
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
        public async Task Test_DeleteProviderAccountCommandWithDeleteTransactionCategorizationRule_SuccessStatus()
        {
            var configuration = await GetConfiguration();

            var token = await GetToken();
            var command = new DeleteTransactionCategorizationCommand(new TransactionsRequest()
            {
                Endpoint = $"{configuration.Url}/transactions/categories/rules/10045968"
            }, configuration, token.Token.Map());

            _newServiceHttpClient.Setup(x => x.DeleteAsync(It.IsAny<string>())).Returns(
                MediatrMockReturns(configuration.Url, HttpMethod.Delete,
                "/transactions/categories/rules/10045968"));

            DeleteTransactionCategorizationHandler queryHandler = new DeleteTransactionCategorizationHandler(
                _mockUnitOfWork.Object, _newServiceHttpClient.Object, _loggerDeleteTransaction.Object);

            var response = await queryHandler.Handle(command, CancellationToken.None);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [Test]
        public async Task Test_DeleteProviderAccountCommandWithDeleteCategory_SuccessStatus()
        {
            var configuration = await GetConfiguration();

            var token = await GetToken();
            var command = new DeleteTransactionCategorizationCommand(new TransactionsRequest()
            {
                Endpoint = $"{configuration.Url}/transactions/categories/3"
            }, configuration, token.Token.Map());

            _newServiceHttpClient.Setup(x => x.DeleteAsync(It.IsAny<string>())).Returns(
                MediatrMockReturns(configuration.Url, HttpMethod.Delete, "/transactions/categories/3"));

            DeleteTransactionCategorizationHandler queryHandler = new DeleteTransactionCategorizationHandler(
                _mockUnitOfWork.Object, _newServiceHttpClient.Object, _loggerDeleteTransaction.Object);

            var response = await queryHandler.Handle(command, CancellationToken.None);

            Assert.IsTrue(response.IsSuccessStatusCode);
        }
    }
}
