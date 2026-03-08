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
        DateTimeOffset randomDateTimeOffset = DateTimeOffset.UtcNow;
        PropertyImage randomPropertyImage = CreateRandomPropertyImage();
        PropertyImage inputPropertyImage = randomPropertyImage;
        inputPropertyImage.UpdatedDate = randomDateTimeOffset;
        PropertyImage expectedPropertyImage = inputPropertyImage;

        this.dateTimeBrokerMock.Setup(broker =>
            broker.GetCurrentDateTimeOffset())
                .Returns(randomDateTimeOffset);

        this.storageBrokerMock.Setup(broker =>
            broker.UpdatePropertyImageAsync(inputPropertyImage))
                .ReturnsAsync(expectedPropertyImage);

        // when
        PropertyImage actualPropertyImage = await this.propertyImageService.ModifyPropertyImageAsync(inputPropertyImage);

        // then
        actualPropertyImage.Should().BeEquivalentTo(expectedPropertyImage);

        this.dateTimeBrokerMock.Verify(broker =>
            broker.GetCurrentDateTimeOffset(),
            Times.Once);

        this.storageBrokerMock.Verify(broker =>
            broker.UpdatePropertyImageAsync(inputPropertyImage),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
