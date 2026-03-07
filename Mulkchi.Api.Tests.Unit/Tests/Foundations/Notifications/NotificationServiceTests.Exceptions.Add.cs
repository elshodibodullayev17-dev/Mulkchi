using FluentAssertions;
using Microsoft.Data.SqlClient;
using Moq;
using Mulkchi.Api.Models.Foundations.Notifications;
using Mulkchi.Api.Models.Foundations.Notifications.Exceptions;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Notifications;

public partial class NotificationServiceTests
{
    [Fact]
    public async Task ShouldThrowDependencyException_OnAdd_WhenSqlExceptionOccurs()
    {
        // given
        Notification someNotification = CreateRandomNotification();
        SqlException sqlException = CreateSqlException();

        this.storageBrokerMock.Setup(broker =>
            broker.InsertNotificationAsync(It.IsAny<Notification>()))
                .ThrowsAsync(sqlException);

        // when
        Func<Task> addNotificationTask = async () =>
            await this.notificationService.AddNotificationAsync(someNotification);

        // then
        NotificationDependencyException actualException =
            await Assert.ThrowsAsync<NotificationDependencyException>(
                testCode: async () => await addNotificationTask());

        actualException.InnerException.Should().BeOfType<FailedNotificationStorageException>();

        this.storageBrokerMock.Verify(broker =>
            broker.InsertNotificationAsync(It.IsAny<Notification>()),
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
        Notification someNotification = CreateRandomNotification();
        var exception = new Exception();

        this.storageBrokerMock.Setup(broker =>
            broker.InsertNotificationAsync(It.IsAny<Notification>()))
                .ThrowsAsync(exception);

        // when
        Func<Task> addNotificationTask = async () =>
            await this.notificationService.AddNotificationAsync(someNotification);

        // then
        NotificationServiceException actualException =
            await Assert.ThrowsAsync<NotificationServiceException>(
                testCode: async () => await addNotificationTask());

        actualException.InnerException.Should().BeOfType<FailedNotificationServiceException>();

        this.storageBrokerMock.Verify(broker =>
            broker.InsertNotificationAsync(It.IsAny<Notification>()),
            Times.Once);

        this.loggingBrokerMock.Verify(broker =>
            broker.LogError(It.IsAny<Exception>()),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
        this.loggingBrokerMock.VerifyNoOtherCalls();
    }
}
