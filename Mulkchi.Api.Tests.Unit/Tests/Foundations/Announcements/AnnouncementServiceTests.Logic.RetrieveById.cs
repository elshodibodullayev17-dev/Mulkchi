using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.Announcements;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Announcements;

public partial class AnnouncementServiceTests
{
    [Fact]
    public async Task ShouldRetrieveAnnouncementByIdAsync()
    {
        // given
        Announcement randomAnnouncement = CreateRandomAnnouncement();
        Announcement expectedAnnouncement = randomAnnouncement;

        this.storageBrokerMock.Setup(broker =>
            broker.SelectAnnouncementByIdAsync(randomAnnouncement.Id))
                .ReturnsAsync(expectedAnnouncement);

        // when
        Announcement actualAnnouncement = await this.announcementService.RetrieveAnnouncementByIdAsync(randomAnnouncement.Id);

        // then
        actualAnnouncement.Should().BeEquivalentTo(expectedAnnouncement);

        this.storageBrokerMock.Verify(broker =>
            broker.SelectAnnouncementByIdAsync(randomAnnouncement.Id),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
