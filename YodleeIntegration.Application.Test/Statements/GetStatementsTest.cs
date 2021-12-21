using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using YodleeIntegration.Api.Models;
using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Application.Request.Statements;
using YodleeIntegration.Application.Response;
using YodleeIntegration.Application.Statements.GetStatements;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.Test.Statements
{
    internal class GetStatementsTest : BaseTest
    {
        private Mock<ILogger<GetStatementsQueryHandler>> _logger;
        private Mock<IYodleeStatementRepository> _statementRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _logger = new Mock<ILogger<GetStatementsQueryHandler>>();

            _statementRepositoryMock = new Mock<IYodleeStatementRepository>();
            _statementRepositoryMock.Setup(m => m.SingleOrDefaultAsync(
                It.IsAny<Expression<Func<Statement, bool>>>())).Returns(Task.FromResult(new Statement()));

            _statementRepositoryMock.Setup(m => m.Update(It.IsAny<Statement>())).Verifiable();

            _mockUnitOfWork.Setup(x => x.YodleeStatementRepository).Returns(_statementRepositoryMock.Object);
            _mockUnitOfWork.Setup(x => x.CompleteAsync()).Verifiable();
        }

        [Test]
        public async Task Test_GetStatements_SuccessStatusCode()
        {
            var configuration = await GetConfiguration();

            _newServiceHttpClient.Setup(x => x.GetAsync(It.IsAny<string>())).Returns(
                MediatrMockReturns(configuration.Url, HttpMethod.Get, YodleeEndpoints.GetStatements));

            GetStatementsQueryHandler queryHandler = new GetStatementsQueryHandler(_mockUnitOfWork.Object,
                _newServiceHttpClient.Object, _logger.Object);

            var token = await GetToken();
            var command = new GetStatementsQuery(new StatementsRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", YodleeEndpoints.GetStatements)
            }, configuration, token.Token.Map());

            var response = await queryHandler.Handle(command, CancellationToken.None);

            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [Test]
        public async Task Test_GetStatements_SuccessResponse()
        {
            var configuration = await GetConfiguration();

            _newServiceHttpClient.Setup(x => x.GetAsync(It.IsAny<string>())).Returns(
                MediatrMockReturns(configuration.Url, HttpMethod.Get, YodleeEndpoints.GetStatements,
                new StringContent(JsonConvert.SerializeObject(GetStatementsResponse()))));

            GetStatementsQueryHandler queryHandler = new GetStatementsQueryHandler(_mockUnitOfWork.Object,
                _newServiceHttpClient.Object, _logger.Object);

            var token = await GetToken();
            var command = new GetStatementsQuery(new StatementsRequest()
            {
                Endpoint = string.Concat($"{configuration.Url}", YodleeEndpoints.GetStatements)
            }, configuration, token.Token.Map());

            var response = await queryHandler.Handle(command, CancellationToken.None);

            var transactionResponse =
                    JsonConvert.DeserializeObject<GetStatementsResponse>(
                        await response.Content.ReadAsStringAsync());

            Assert.IsNotNull(transactionResponse.Statement);
        }

        private static GetStatementsResponse GetStatementsResponse()
        {
            return new GetStatementsResponse
            {
                Statement = new List<Statement>()
            };
        }
    }
}