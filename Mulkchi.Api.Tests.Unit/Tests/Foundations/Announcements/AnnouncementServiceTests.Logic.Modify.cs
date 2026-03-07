using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.Announcements;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Announcements;

public partial class AnnouncementServiceTests
{
    [Fact]
    public async Task ShouldModifyAnnouncementAsync()
    {
        // given
        Announcement randomAnnouncement = CreateRandomAnnouncement();
        Announcement inputAnnouncement = randomAnnouncement;
        Announcement expectedAnnouncement = inputAnnouncement;

        this.storageBrokerMock.Setup(broker =>
            broker.UpdateAnnouncementAsync(inputAnnouncement))
                .ReturnsAsync(expectedAnnouncement);

        // when
        Announcement actualAnnouncement = await this.announcementService.ModifyAnnouncementAsync(inputAnnouncement);

        // then
        actualAnnouncement.Should().BeEquivalentTo(expectedAnnouncement);

        this.storageBrokerMock.Verify(broker =>
            broker.UpdateAnnouncementAsync(inputAnnouncement),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
