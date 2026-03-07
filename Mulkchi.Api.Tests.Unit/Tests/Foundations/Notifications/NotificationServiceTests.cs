using System.Runtime.CompilerServices;
using Microsoft.Data.SqlClient;
using Moq;
using Tynamix.ObjectFiller;
using FluentAssertions;
using Mulkchi.Api.Brokers.Storages;
using Mulkchi.Api.Models.Foundations.Notifications;
using Mulkchi.Api.Services.Foundations.Notifications;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Notifications;

public partial class NotificationServiceTests
{
    private readonly Mock<IStorageBroker> storageBrokerMock;
    private readonly INotificationService notificationService;

    public NotificationServiceTests()
    {
        this.storageBrokerMock = new Mock<IStorageBroker>();
        this.notificationService = new NotificationService(this.storageBrokerMock.Object);
    }

    private static Notification CreateRandomNotification()
    {
        var filler = new Filler<Notification>();
        filler.Setup()
            .OnType<DateTimeOffset>().Use(() => DateTimeOffset.UtcNow)
            .OnType<DateTimeOffset?>().Use(() => (DateTimeOffset?)DateTimeOffset.UtcNow);

        return filler.Create();
    }

    private static SqlException CreateSqlException() =>
        (SqlException)RuntimeHelpers.GetUninitializedObject(typeof(SqlException));
}
