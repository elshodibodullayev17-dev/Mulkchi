using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.PropertyImages;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.PropertyImages;

public partial class PropertyImageServiceTests
{
    [Fact]
    public async Task ShouldRemovePropertyImageByIdAsync()
    {
        // given
        PropertyImage randomPropertyImage = CreateRandomPropertyImage();
        PropertyImage expectedPropertyImage = randomPropertyImage;

        this.storageBrokerMock.Setup(broker =>
            broker.DeletePropertyImageByIdAsync(randomPropertyImage.Id))
                .ReturnsAsync(expectedPropertyImage);

        // when
        PropertyImage actualPropertyImage = await this.propertyImageService.RemovePropertyImageByIdAsync(randomPropertyImage.Id);

        // then
        actualPropertyImage.Should().BeEquivalentTo(expectedPropertyImage);

        this.storageBrokerMock.Verify(broker =>
            broker.DeletePropertyImageByIdAsync(randomPropertyImage.Id),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
