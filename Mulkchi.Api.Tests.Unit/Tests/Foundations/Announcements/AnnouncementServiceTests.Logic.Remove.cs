using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.Announcements;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Announcements;

public partial class AnnouncementServiceTests
{
    [Fact]
    public async Task ShouldRemoveAnnouncementByIdAsync()
    {
        // given
        Announcement randomAnnouncement = CreateRandomAnnouncement();
        Announcement expectedAnnouncement = randomAnnouncement;

        this.storageBrokerMock.Setup(broker =>
            broker.DeleteAnnouncementByIdAsync(randomAnnouncement.Id))
                .ReturnsAsync(expectedAnnouncement);

        // when
        Announcement actualAnnouncement = await this.announcementService.RemoveAnnouncementByIdAsync(randomAnnouncement.Id);

        // then
        actualAnnouncement.Should().BeEquivalentTo(expectedAnnouncement);

        this.storageBrokerMock.Verify(broker =>
            broker.DeleteAnnouncementByIdAsync(randomAnnouncement.Id),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
