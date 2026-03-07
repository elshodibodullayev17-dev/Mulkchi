using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.PropertyImages;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.PropertyImages;

public partial class PropertyImageServiceTests
{
    [Fact]
    public async Task ShouldAddPropertyImageAsync()
    {
        // given
        PropertyImage randomPropertyImage = CreateRandomPropertyImage();
        PropertyImage inputPropertyImage = randomPropertyImage;
        PropertyImage expectedPropertyImage = inputPropertyImage;

        this.storageBrokerMock.Setup(broker =>
            broker.InsertPropertyImageAsync(inputPropertyImage))
                .ReturnsAsync(expectedPropertyImage);

        // when
        PropertyImage actualPropertyImage = await this.propertyImageService.AddPropertyImageAsync(inputPropertyImage);

        // then
        actualPropertyImage.Should().BeEquivalentTo(expectedPropertyImage);

        this.storageBrokerMock.Verify(broker =>
            broker.InsertPropertyImageAsync(inputPropertyImage),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
