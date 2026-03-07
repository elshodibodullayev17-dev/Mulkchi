using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.PropertyImages;
using Mulkchi.Api.Models.Foundations.PropertyImages.Exceptions;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.PropertyImages;

public partial class PropertyImageServiceTests
{
    [Fact]
    public async Task ShouldThrowValidationException_OnAdd_WhenNullPropertyImage()
    {
        // given
        PropertyImage? inputPropertyImage = null;

        // when
        ValueTask<PropertyImage> addPropertyImageTask =
            this.propertyImageService.AddPropertyImageAsync(inputPropertyImage!);

        // then
        PropertyImageValidationException actualException =
            await Assert.ThrowsAsync<PropertyImageValidationException>(
                testCode: async () => await addPropertyImageTask);

        actualException.InnerException.Should().BeOfType<NullPropertyImageException>();

        this.storageBrokerMock.Verify(broker =>
            broker.InsertPropertyImageAsync(It.IsAny<PropertyImage>()),
            Times.Never);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task ShouldThrowValidationException_OnAdd_WhenIdIsEmpty()
    {
        // given
        PropertyImage randomPropertyImage = CreateRandomPropertyImage();
        randomPropertyImage.Id = Guid.Empty;

        // when
        ValueTask<PropertyImage> addPropertyImageTask =
            this.propertyImageService.AddPropertyImageAsync(randomPropertyImage);

        // then
        await Assert.ThrowsAsync<PropertyImageValidationException>(
            testCode: async () => await addPropertyImageTask);

        this.storageBrokerMock.Verify(broker =>
            broker.InsertPropertyImageAsync(It.IsAny<PropertyImage>()),
            Times.Never);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
