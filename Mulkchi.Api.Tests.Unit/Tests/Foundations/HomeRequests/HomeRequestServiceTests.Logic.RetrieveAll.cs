using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.HomeRequests;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.HomeRequests;

public partial class HomeRequestServiceTests
{
    [Fact]
    public void ShouldRetrieveAllHomeRequests()
    {
        // given
        IQueryable<HomeRequest> randomHomeRequests = new List<HomeRequest>
        {
            CreateRandomHomeRequest(),
            CreateRandomHomeRequest(),
            CreateRandomHomeRequest()
        }.AsQueryable();

        IQueryable<HomeRequest> expectedHomeRequests = randomHomeRequests;

        this.storageBrokerMock.Setup(broker =>
            broker.SelectAllHomeRequests())
                .Returns(expectedHomeRequests);

        // when
        IQueryable<HomeRequest> actualHomeRequests = this.homeRequestService.RetrieveAllHomeRequests();

        // then
        actualHomeRequests.Should().BeEquivalentTo(expectedHomeRequests);

        this.storageBrokerMock.Verify(broker =>
            broker.SelectAllHomeRequests(),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
