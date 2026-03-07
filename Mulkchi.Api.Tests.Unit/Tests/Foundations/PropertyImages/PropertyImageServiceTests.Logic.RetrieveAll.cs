using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.PropertyImages;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.PropertyImages;

public partial class PropertyImageServiceTests
{
    [Fact]
    public void ShouldRetrieveAllPropertyImages()
    {
        // given
        IQueryable<PropertyImage> randomPropertyImages = new List<PropertyImage>
        {
            CreateRandomPropertyImage(),
            CreateRandomPropertyImage(),
            CreateRandomPropertyImage()
        }.AsQueryable();

        IQueryable<PropertyImage> expectedPropertyImages = randomPropertyImages;

        this.storageBrokerMock.Setup(broker =>
            broker.SelectAllPropertyImages())
                .Returns(expectedPropertyImages);

        // when
        IQueryable<PropertyImage> actualPropertyImages = this.propertyImageService.RetrieveAllPropertyImages();

        // then
        actualPropertyImages.Should().BeEquivalentTo(expectedPropertyImages);

        this.storageBrokerMock.Verify(broker =>
            broker.SelectAllPropertyImages(),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
