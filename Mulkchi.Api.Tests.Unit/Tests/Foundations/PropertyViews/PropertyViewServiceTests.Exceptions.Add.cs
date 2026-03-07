using FluentAssertions;
using Microsoft.Data.SqlClient;
using Moq;
using Mulkchi.Api.Models.Foundations.PropertyViews;
using Mulkchi.Api.Models.Foundations.PropertyViews.Exceptions;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.PropertyViews;

public partial class PropertyViewServiceTests
{
    [Fact]
    public async Task ShouldThrowDependencyException_OnAdd_WhenSqlExceptionOccurs()
    {
        // given
        PropertyView somePropertyView = CreateRandomPropertyView();
        SqlException sqlException = CreateSqlException();

        this.storageBrokerMock.Setup(broker =>
            broker.InsertPropertyViewAsync(It.IsAny<PropertyView>()))
                .ThrowsAsync(sqlException);

        // when
        Func<Task> addPropertyViewTask = async () =>
            await this.propertyViewService.AddPropertyViewAsync(somePropertyView);

        // then
        PropertyViewDependencyException actualException =
            await Assert.ThrowsAsync<PropertyViewDependencyException>(
                testCode: async () => await addPropertyViewTask());

        actualException.InnerException.Should().BeOfType<FailedPropertyViewStorageException>();

        this.storageBrokerMock.Verify(broker =>
            broker.InsertPropertyViewAsync(It.IsAny<PropertyView>()),
            Times.Once);

        this.loggingBrokerMock.Verify(broker =>
            broker.LogError(It.IsAny<Exception>()),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
        this.loggingBrokerMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task ShouldThrowServiceException_OnAdd_WhenExceptionOccurs()
    {
        // given
        PropertyView somePropertyView = CreateRandomPropertyView();
        var exception = new Exception();

        this.storageBrokerMock.Setup(broker =>
            broker.InsertPropertyViewAsync(It.IsAny<PropertyView>()))
                .ThrowsAsync(exception);

        // when
        Func<Task> addPropertyViewTask = async () =>
            await this.propertyViewService.AddPropertyViewAsync(somePropertyView);

        // then
        PropertyViewServiceException actualException =
            await Assert.ThrowsAsync<PropertyViewServiceException>(
                testCode: async () => await addPropertyViewTask());

        actualException.InnerException.Should().BeOfType<FailedPropertyViewServiceException>();

        this.storageBrokerMock.Verify(broker =>
            broker.InsertPropertyViewAsync(It.IsAny<PropertyView>()),
            Times.Once);

        this.loggingBrokerMock.Verify(broker =>
            broker.LogError(It.IsAny<Exception>()),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
        this.loggingBrokerMock.VerifyNoOtherCalls();
    }
}
