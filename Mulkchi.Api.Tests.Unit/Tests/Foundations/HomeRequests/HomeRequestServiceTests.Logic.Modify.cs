using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.HomeRequests;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.HomeRequests;

public partial class HomeRequestServiceTests
{
    [Fact]
    public async Task ShouldModifyHomeRequestAsync()
    {
        // given
        HomeRequest randomHomeRequest = CreateRandomHomeRequest();
        HomeRequest inputHomeRequest = randomHomeRequest;
        HomeRequest expectedHomeRequest = inputHomeRequest;

        this.storageBrokerMock.Setup(broker =>
            broker.UpdateHomeRequestAsync(inputHomeRequest))
                .ReturnsAsync(expectedHomeRequest);

        // when
        HomeRequest actualHomeRequest = await this.homeRequestService.ModifyHomeRequestAsync(inputHomeRequest);

        // then
        actualHomeRequest.Should().BeEquivalentTo(expectedHomeRequest);

        this.storageBrokerMock.Verify(broker =>
            broker.UpdateHomeRequestAsync(inputHomeRequest),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
