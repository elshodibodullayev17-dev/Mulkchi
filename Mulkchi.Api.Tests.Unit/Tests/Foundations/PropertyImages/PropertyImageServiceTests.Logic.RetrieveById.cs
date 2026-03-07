using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.PropertyImages;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.PropertyImages;

public partial class PropertyImageServiceTests
{
    [Fact]
    public async Task ShouldRetrievePropertyImageByIdAsync()
    {
        // given
        PropertyImage randomPropertyImage = CreateRandomPropertyImage();
        PropertyImage expectedPropertyImage = randomPropertyImage;

        this.storageBrokerMock.Setup(broker =>
            broker.SelectPropertyImageByIdAsync(randomPropertyImage.Id))
                .ReturnsAsync(expectedPropertyImage);

        // when
        PropertyImage actualPropertyImage = await this.propertyImageService.RetrievePropertyImageByIdAsync(randomPropertyImage.Id);

        // then
        actualPropertyImage.Should().BeEquivalentTo(expectedPropertyImage);

        this.storageBrokerMock.Verify(broker =>
            broker.SelectPropertyImageByIdAsync(randomPropertyImage.Id),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
