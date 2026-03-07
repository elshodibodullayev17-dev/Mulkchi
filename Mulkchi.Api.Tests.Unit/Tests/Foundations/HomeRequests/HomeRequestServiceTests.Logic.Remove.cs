using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.HomeRequests;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.HomeRequests;

public partial class HomeRequestServiceTests
{
    [Fact]
    public async Task ShouldRemoveHomeRequestByIdAsync()
    {
        // given
        HomeRequest randomHomeRequest = CreateRandomHomeRequest();
        HomeRequest expectedHomeRequest = randomHomeRequest;

        this.storageBrokerMock.Setup(broker =>
            broker.DeleteHomeRequestByIdAsync(randomHomeRequest.Id))
                .ReturnsAsync(expectedHomeRequest);

        // when
        HomeRequest actualHomeRequest = await this.homeRequestService.RemoveHomeRequestByIdAsync(randomHomeRequest.Id);

        // then
        actualHomeRequest.Should().BeEquivalentTo(expectedHomeRequest);

        this.storageBrokerMock.Verify(broker =>
            broker.DeleteHomeRequestByIdAsync(randomHomeRequest.Id),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
