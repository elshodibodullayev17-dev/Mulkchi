using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.Announcements;
using Mulkchi.Api.Models.Foundations.Announcements.Exceptions;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Announcements;

public partial class AnnouncementServiceTests
{
    [Fact]
    public async Task ShouldThrowValidationException_OnAdd_WhenNullAnnouncement()
    {
        // given
        Announcement? inputAnnouncement = null;

        // when
        ValueTask<Announcement> addAnnouncementTask =
            this.announcementService.AddAnnouncementAsync(inputAnnouncement!);

        // then
        AnnouncementValidationException actualException =
            await Assert.ThrowsAsync<AnnouncementValidationException>(
                testCode: async () => await addAnnouncementTask);

        actualException.InnerException.Should().BeOfType<NullAnnouncementException>();

        this.storageBrokerMock.Verify(broker =>
            broker.InsertAnnouncementAsync(It.IsAny<Announcement>()),
            Times.Never);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task ShouldThrowValidationException_OnAdd_WhenIdIsEmpty()
    {
        // given
        Announcement randomAnnouncement = CreateRandomAnnouncement();
        randomAnnouncement.Id = Guid.Empty;

        // when
        ValueTask<Announcement> addAnnouncementTask =
            this.announcementService.AddAnnouncementAsync(randomAnnouncement);

        // then
        await Assert.ThrowsAsync<AnnouncementValidationException>(
            testCode: async () => await addAnnouncementTask);

        this.storageBrokerMock.Verify(broker =>
            broker.InsertAnnouncementAsync(It.IsAny<Announcement>()),
            Times.Never);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
