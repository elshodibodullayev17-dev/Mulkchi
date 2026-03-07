using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.Announcements;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Announcements;

public partial class AnnouncementServiceTests
{
    [Fact]
    public async Task ShouldAddAnnouncementAsync()
    {
        // given
        Announcement randomAnnouncement = CreateRandomAnnouncement();
        Announcement inputAnnouncement = randomAnnouncement;
        Announcement expectedAnnouncement = inputAnnouncement;

        this.storageBrokerMock.Setup(broker =>
            broker.InsertAnnouncementAsync(inputAnnouncement))
                .ReturnsAsync(expectedAnnouncement);

        // when
        Announcement actualAnnouncement = await this.announcementService.AddAnnouncementAsync(inputAnnouncement);

        // then
        actualAnnouncement.Should().BeEquivalentTo(expectedAnnouncement);

        this.storageBrokerMock.Verify(broker =>
            broker.InsertAnnouncementAsync(inputAnnouncement),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
