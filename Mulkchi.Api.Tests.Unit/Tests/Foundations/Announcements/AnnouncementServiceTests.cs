using System.Runtime.CompilerServices;
using Microsoft.Data.SqlClient;
using Moq;
using Tynamix.ObjectFiller;
using FluentAssertions;
using Mulkchi.Api.Brokers.Storages;
using Mulkchi.Api.Models.Foundations.Announcements;
using Mulkchi.Api.Services.Foundations.Announcements;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Announcements;

public partial class AnnouncementServiceTests
{
    private readonly Mock<IStorageBroker> storageBrokerMock;
    private readonly IAnnouncementService announcementService;

    public AnnouncementServiceTests()
    {
        this.storageBrokerMock = new Mock<IStorageBroker>();
        this.announcementService = new AnnouncementService(this.storageBrokerMock.Object);
    }

    private static Announcement CreateRandomAnnouncement()
    {
        var filler = new Filler<Announcement>();
        filler.Setup()
            .OnType<DateTimeOffset>().Use(() => DateTimeOffset.UtcNow)
            .OnType<DateTimeOffset?>().Use(() => (DateTimeOffset?)DateTimeOffset.UtcNow);

        return filler.Create();
    }

    private static SqlException CreateSqlException() =>
        (SqlException)RuntimeHelpers.GetUninitializedObject(typeof(SqlException));
}
