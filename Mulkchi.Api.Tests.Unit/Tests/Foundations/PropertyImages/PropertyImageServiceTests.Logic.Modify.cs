using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.PropertyImages;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.PropertyImages;

public partial class PropertyImageServiceTests
{
    [Fact]
    public async Task ShouldModifyPropertyImageAsync()
    {
        // given
        PropertyImage randomPropertyImage = CreateRandomPropertyImage();
        PropertyImage inputPropertyImage = randomPropertyImage;
        PropertyImage expectedPropertyImage = inputPropertyImage;

        this.storageBrokerMock.Setup(broker =>
            broker.UpdatePropertyImageAsync(inputPropertyImage))
                .ReturnsAsync(expectedPropertyImage);

        // when
        PropertyImage actualPropertyImage = await this.propertyImageService.ModifyPropertyImageAsync(inputPropertyImage);

        // then
        actualPropertyImage.Should().BeEquivalentTo(expectedPropertyImage);

        this.storageBrokerMock.Verify(broker =>
            broker.UpdatePropertyImageAsync(inputPropertyImage),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
