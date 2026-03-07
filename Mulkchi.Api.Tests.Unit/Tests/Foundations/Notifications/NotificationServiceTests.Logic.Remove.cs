using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.Notifications;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Notifications;

public partial class NotificationServiceTests
{
    [Fact]
    public async Task ShouldRemoveNotificationByIdAsync()
    {
        // given
        Notification randomNotification = CreateRandomNotification();
        Notification expectedNotification = randomNotification;

        this.storageBrokerMock.Setup(broker =>
            broker.DeleteNotificationByIdAsync(randomNotification.Id))
                .ReturnsAsync(expectedNotification);

        // when
        Notification actualNotification = await this.notificationService.RemoveNotificationByIdAsync(randomNotification.Id);

        // then
        actualNotification.Should().BeEquivalentTo(expectedNotification);

        this.storageBrokerMock.Verify(broker =>
            broker.DeleteNotificationByIdAsync(randomNotification.Id),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
