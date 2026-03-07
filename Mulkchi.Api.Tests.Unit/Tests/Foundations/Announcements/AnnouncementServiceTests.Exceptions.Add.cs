using FluentAssertions;
using Microsoft.Data.SqlClient;
using Moq;
using Mulkchi.Api.Models.Foundations.Announcements;
using Mulkchi.Api.Models.Foundations.Announcements.Exceptions;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Announcements;

public partial class AnnouncementServiceTests
{
    [Fact]
    public async Task ShouldThrowDependencyException_OnAdd_WhenSqlExceptionOccurs()
    {
        // given
        Announcement someAnnouncement = CreateRandomAnnouncement();
        SqlException sqlException = CreateSqlException();

        this.storageBrokerMock.Setup(broker =>
            broker.InsertAnnouncementAsync(It.IsAny<Announcement>()))
                .ThrowsAsync(sqlException);

        // when
        Func<Task> addAnnouncementTask = async () =>
            await this.announcementService.AddAnnouncementAsync(someAnnouncement);

        // then
        AnnouncementDependencyException actualException =
            await Assert.ThrowsAsync<AnnouncementDependencyException>(
                testCode: async () => await addAnnouncementTask());

        actualException.InnerException.Should().BeOfType<FailedAnnouncementStorageException>();

        this.storageBrokerMock.Verify(broker =>
            broker.InsertAnnouncementAsync(It.IsAny<Announcement>()),
            Times.Once);

        this.loggingBrokerMock.Verify(broker =>
            broker.LogError(It.IsAny<Exception>()),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
        this.loggingBrokerMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task ShouldThrowServiceException_OnAdd_WhenExceptionOccurs()
    {
        // given
        Announcement someAnnouncement = CreateRandomAnnouncement();
        var exception = new Exception();

        this.storageBrokerMock.Setup(broker =>
            broker.InsertAnnouncementAsync(It.IsAny<Announcement>()))
                .ThrowsAsync(exception);

        // when
        Func<Task> addAnnouncementTask = async () =>
            await this.announcementService.AddAnnouncementAsync(someAnnouncement);

        // then
        AnnouncementServiceException actualException =
            await Assert.ThrowsAsync<AnnouncementServiceException>(
                testCode: async () => await addAnnouncementTask());

        actualException.InnerException.Should().BeOfType<FailedAnnouncementServiceException>();

        this.storageBrokerMock.Verify(broker =>
            broker.InsertAnnouncementAsync(It.IsAny<Announcement>()),
            Times.Once);

        this.loggingBrokerMock.Verify(broker =>
            broker.LogError(It.IsAny<Exception>()),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
        this.loggingBrokerMock.VerifyNoOtherCalls();
    }
}
