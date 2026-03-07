using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.PropertyViews;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.PropertyViews;

public partial class PropertyViewServiceTests
{
    [Fact]
    public async Task ShouldRetrievePropertyViewByIdAsync()
    {
        // given
        PropertyView randomPropertyView = CreateRandomPropertyView();
        PropertyView expectedPropertyView = randomPropertyView;

        this.storageBrokerMock.Setup(broker =>
            broker.SelectPropertyViewByIdAsync(randomPropertyView.Id))
                .ReturnsAsync(expectedPropertyView);

        // when
        PropertyView actualPropertyView = await this.propertyViewService.RetrievePropertyViewByIdAsync(randomPropertyView.Id);

        // then
        actualPropertyView.Should().BeEquivalentTo(expectedPropertyView);

        this.storageBrokerMock.Verify(broker =>
            broker.SelectPropertyViewByIdAsync(randomPropertyView.Id),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
