using System.Runtime.CompilerServices;
using Microsoft.Data.SqlClient;
using Moq;
using Tynamix.ObjectFiller;
using FluentAssertions;
using Mulkchi.Api.Brokers.Storages;
using Mulkchi.Api.Models.Foundations.PropertyImages;
using Mulkchi.Api.Services.Foundations.PropertyImages;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.PropertyImages;

public partial class PropertyImageServiceTests
{
    private readonly Mock<IStorageBroker> storageBrokerMock;
    private readonly IPropertyImageService propertyImageService;

    public PropertyImageServiceTests()
    {
        this.storageBrokerMock = new Mock<IStorageBroker>();
        this.propertyImageService = new PropertyImageService(this.storageBrokerMock.Object);
    }

    private static PropertyImage CreateRandomPropertyImage()
    {
        var filler = new Filler<PropertyImage>();
        filler.Setup()
            .OnType<DateTimeOffset>().Use(() => DateTimeOffset.UtcNow)
            .OnType<DateTimeOffset?>().Use(() => (DateTimeOffset?)DateTimeOffset.UtcNow);

        return filler.Create();
    }

    private static SqlException CreateSqlException() =>
        (SqlException)RuntimeHelpers.GetUninitializedObject(typeof(SqlException));
}
