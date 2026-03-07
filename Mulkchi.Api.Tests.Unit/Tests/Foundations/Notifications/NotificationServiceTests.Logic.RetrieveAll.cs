using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.Notifications;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Notifications;

public partial class NotificationServiceTests
{
    [Fact]
    public void ShouldRetrieveAllNotifications()
    {
        // given
        IQueryable<Notification> randomNotifications = new List<Notification>
        {
            CreateRandomNotification(),
            CreateRandomNotification(),
            CreateRandomNotification()
        }.AsQueryable();

        IQueryable<Notification> expectedNotifications = randomNotifications;

        this.storageBrokerMock.Setup(broker =>
            broker.SelectAllNotifications())
                .Returns(expectedNotifications);

        // when
        IQueryable<Notification> actualNotifications = this.notificationService.RetrieveAllNotifications();

        // then
        actualNotifications.Should().BeEquivalentTo(expectedNotifications);

        this.storageBrokerMock.Verify(broker =>
            broker.SelectAllNotifications(),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
