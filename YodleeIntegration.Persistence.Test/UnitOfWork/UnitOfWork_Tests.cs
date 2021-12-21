using Moq;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;
using YodleeIntegration.Persistence.DbContexts;

namespace YodleeIntegration.Persistence.Test.UnitOfWork
{
    public class UnitOfWorkTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task CompleteAsyncSuccess()
        {
            var mockContext = new Mock<ApplicationDbContext>();
            var unitOfWork = new Persistence.UnitOfWork.UnitOfWork(mockContext.Object);

            await unitOfWork.CompleteAsync();

            mockContext.Verify(x => x.SaveChangesAsync(CancellationToken.None));
        }
    }
}
