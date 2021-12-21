using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Moq;
using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Application.Response;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.Repositories;

namespace YodleeIntegration.Application.Test.Verification
{
    public class BaseVerificationTest : BaseTest
    {
        private readonly Mock<IYodleeVerificationsRepository> _verificationRepositoryMock;

        public BaseVerificationTest()
        {
            _verificationRepositoryMock = new Mock<IYodleeVerificationsRepository>();
            _verificationRepositoryMock.Setup(m => m.SingleOrDefaultAsync(
                It.IsAny<Expression<Func<Verifications, bool>>>())).Returns(Task.FromResult(new Verifications()));

            _verificationRepositoryMock.Setup(m => m.Update(It.IsAny<Verifications>())).Verifiable();

            _mockUnitOfWork.Setup(x => x.YodleeVerificationsRepository).Returns(_verificationRepositoryMock.Object);
            _mockUnitOfWork.Setup(x => x.CompleteAsync()).Verifiable();
        }

        protected static VerficationResponse GetVerficationResponse()
        {
            return new VerficationResponse
            {
                Verfications = new List<Verifications>()
            };
        }
    }
}
