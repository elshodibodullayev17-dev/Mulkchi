using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.HomeRequests;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.HomeRequests;

public partial class HomeRequestServiceTests
{
    [Fact]
    public async Task ShouldAddHomeRequestAsync()
    {
        // given
        HomeRequest randomHomeRequest = CreateRandomHomeRequest();
        HomeRequest inputHomeRequest = randomHomeRequest;
        HomeRequest expectedHomeRequest = inputHomeRequest;

        this.storageBrokerMock.Setup(broker =>
            broker.InsertHomeRequestAsync(inputHomeRequest))
                .ReturnsAsync(expectedHomeRequest);

        // when
        HomeRequest actualHomeRequest = await this.homeRequestService.AddHomeRequestAsync(inputHomeRequest);

        // then
        actualHomeRequest.Should().BeEquivalentTo(expectedHomeRequest);

        this.storageBrokerMock.Verify(broker =>
            broker.InsertHomeRequestAsync(inputHomeRequest),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
