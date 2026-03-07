using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.Notifications;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Notifications;

public partial class NotificationServiceTests
{
    [Fact]
    public async Task ShouldAddNotificationAsync()
    {
        // given
        Notification randomNotification = CreateRandomNotification();
        Notification inputNotification = randomNotification;
        Notification expectedNotification = inputNotification;

        this.storageBrokerMock.Setup(broker =>
            broker.InsertNotificationAsync(inputNotification))
                .ReturnsAsync(expectedNotification);

        // when
        Notification actualNotification = await this.notificationService.AddNotificationAsync(inputNotification);

        // then
        actualNotification.Should().BeEquivalentTo(expectedNotification);

        this.storageBrokerMock.Verify(broker =>
            broker.InsertNotificationAsync(inputNotification),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
