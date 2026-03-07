using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.PropertyViews;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.PropertyViews;

public partial class PropertyViewServiceTests
{
    [Fact]
    public async Task ShouldModifyPropertyViewAsync()
    {
        // given
        PropertyView randomPropertyView = CreateRandomPropertyView();
        PropertyView inputPropertyView = randomPropertyView;
        PropertyView expectedPropertyView = inputPropertyView;

        this.storageBrokerMock.Setup(broker =>
            broker.UpdatePropertyViewAsync(inputPropertyView))
                .ReturnsAsync(expectedPropertyView);

        // when
        PropertyView actualPropertyView = await this.propertyViewService.ModifyPropertyViewAsync(inputPropertyView);

        // then
        actualPropertyView.Should().BeEquivalentTo(expectedPropertyView);

        this.storageBrokerMock.Verify(broker =>
            broker.UpdatePropertyViewAsync(inputPropertyView),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
