using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.PropertyViews;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.PropertyViews;

public partial class PropertyViewServiceTests
{
    [Fact]
    public async Task ShouldRemovePropertyViewByIdAsync()
    {
        // given
        PropertyView randomPropertyView = CreateRandomPropertyView();
        PropertyView expectedPropertyView = randomPropertyView;

        this.storageBrokerMock.Setup(broker =>
            broker.DeletePropertyViewByIdAsync(randomPropertyView.Id))
                .ReturnsAsync(expectedPropertyView);

        // when
        PropertyView actualPropertyView = await this.propertyViewService.RemovePropertyViewByIdAsync(randomPropertyView.Id);

        // then
        actualPropertyView.Should().BeEquivalentTo(expectedPropertyView);

        this.storageBrokerMock.Verify(broker =>
            broker.DeletePropertyViewByIdAsync(randomPropertyView.Id),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
