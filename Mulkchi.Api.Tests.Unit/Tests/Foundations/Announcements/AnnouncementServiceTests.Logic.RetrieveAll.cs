using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.Announcements;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Announcements;

public partial class AnnouncementServiceTests
{
    [Fact]
    public void ShouldRetrieveAllAnnouncements()
    {
        // given
        IQueryable<Announcement> randomAnnouncements = new List<Announcement>
        {
            CreateRandomAnnouncement(),
            CreateRandomAnnouncement(),
            CreateRandomAnnouncement()
        }.AsQueryable();

        IQueryable<Announcement> expectedAnnouncements = randomAnnouncements;

        this.storageBrokerMock.Setup(broker =>
            broker.SelectAllAnnouncements())
                .Returns(expectedAnnouncements);

        // when
        IQueryable<Announcement> actualAnnouncements = this.announcementService.RetrieveAllAnnouncements();

        // then
        actualAnnouncements.Should().BeEquivalentTo(expectedAnnouncements);

        this.storageBrokerMock.Verify(broker =>
            broker.SelectAllAnnouncements(),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
