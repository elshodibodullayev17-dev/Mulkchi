using FluentAssertions;
using Microsoft.Data.SqlClient;
using Moq;
using Mulkchi.Api.Models.Foundations.PropertyImages;
using Mulkchi.Api.Models.Foundations.PropertyImages.Exceptions;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.PropertyImages;

public partial class PropertyImageServiceTests
{
    [Fact]
    public async Task ShouldThrowDependencyException_OnAdd_WhenSqlExceptionOccurs()
    {
        // given
        PropertyImage somePropertyImage = CreateRandomPropertyImage();
        SqlException sqlException = CreateSqlException();

        this.storageBrokerMock.Setup(broker =>
            broker.InsertPropertyImageAsync(It.IsAny<PropertyImage>()))
                .ThrowsAsync(sqlException);

        // when
        Func<Task> addPropertyImageTask = async () =>
            await this.propertyImageService.AddPropertyImageAsync(somePropertyImage);

        // then
        PropertyImageDependencyException actualException =
            await Assert.ThrowsAsync<PropertyImageDependencyException>(
                testCode: async () => await addPropertyImageTask());

        actualException.InnerException.Should().BeOfType<FailedPropertyImageStorageException>();

        this.storageBrokerMock.Verify(broker =>
            broker.InsertPropertyImageAsync(It.IsAny<PropertyImage>()),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task ShouldThrowServiceException_OnAdd_WhenExceptionOccurs()
    {
        // given
        PropertyImage somePropertyImage = CreateRandomPropertyImage();
        var exception = new Exception();

        this.storageBrokerMock.Setup(broker =>
            broker.InsertPropertyImageAsync(It.IsAny<PropertyImage>()))
                .ThrowsAsync(exception);

        // when
        Func<Task> addPropertyImageTask = async () =>
            await this.propertyImageService.AddPropertyImageAsync(somePropertyImage);

        // then
        PropertyImageServiceException actualException =
            await Assert.ThrowsAsync<PropertyImageServiceException>(
                testCode: async () => await addPropertyImageTask());

        actualException.InnerException.Should().BeOfType<FailedPropertyImageServiceException>();

        this.storageBrokerMock.Verify(broker =>
            broker.InsertPropertyImageAsync(It.IsAny<PropertyImage>()),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
