using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Moq;
using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Application.Response;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.Test.User
{
    public class BaseUserTest : BaseTest
    {
        private readonly Mock<IYodleeUserRepository> _userRepositoryMock;

        public BaseUserTest()
        {
            _userRepositoryMock = new Mock<IYodleeUserRepository>();
            _userRepositoryMock.Setup(m => m.SingleOrDefaultAsync(
                It.IsAny<Expression<Func<Users, bool>>>())).Returns(Task.FromResult(new Users()));

            _userRepositoryMock.Setup(m => m.Update(It.IsAny<Users>())).Verifiable();

            _mockUnitOfWork.Setup(x => x.YodleeUserRepository).Returns(_userRepositoryMock.Object);
            _mockUnitOfWork.Setup(x => x.CompleteAsync()).Verifiable();
        }

        protected static UserResponse GetUserResponse()
        {
            return new UserResponse
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
    }
}
