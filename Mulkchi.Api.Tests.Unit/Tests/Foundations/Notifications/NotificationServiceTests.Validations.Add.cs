using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.Notifications;
using Mulkchi.Api.Models.Foundations.Notifications.Exceptions;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Notifications;

public partial class NotificationServiceTests
{
    [Fact]
    public async Task ShouldThrowValidationException_OnAdd_WhenNullNotification()
    {
        // given
        Notification? inputNotification = null;

        // when
        ValueTask<Notification> addNotificationTask =
            this.notificationService.AddNotificationAsync(inputNotification!);

        // then
        NotificationValidationException actualException =
            await Assert.ThrowsAsync<NotificationValidationException>(
                testCode: async () => await addNotificationTask);

        actualException.InnerException.Should().BeOfType<NullNotificationException>();

        this.storageBrokerMock.Verify(broker =>
            broker.InsertNotificationAsync(It.IsAny<Notification>()),
            Times.Never);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task ShouldThrowValidationException_OnAdd_WhenIdIsEmpty()
    {
        // given
        Notification randomNotification = CreateRandomNotification();
        randomNotification.Id = Guid.Empty;

        // when
        ValueTask<Notification> addNotificationTask =
            this.notificationService.AddNotificationAsync(randomNotification);

        // then
        await Assert.ThrowsAsync<NotificationValidationException>(
            testCode: async () => await addNotificationTask);

        this.storageBrokerMock.Verify(broker =>
            broker.InsertNotificationAsync(It.IsAny<Notification>()),
            Times.Never);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
